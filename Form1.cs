using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StajProje2.Classes;

namespace StajProje2
{
    public partial class Form1 : Form
    {
        static int satirSayisi;

        static string mainpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string consPath = Path.Combine(mainpath, "Maps\\consumables.txt");
        static string scoreboardPath = Path.Combine(mainpath, "Maps\\scoreboard.txt");

        static int consTimer;
        bool coolDown;
        int scoreLimit = 0;   
        string direction = "sağ";

        MapClass selectedMap = new MapClass();
        List<ConsumableClass> consumableList = new List<ConsumableClass>();
        List<ScoreClass> mapScores = new List<ScoreClass>();

        Panel unit;
        Panel apple = new Panel();
        List<Panel> consumablePanels = new List<Panel>();
        List<Panel> snake = new List<Panel>();
        List<Panel> obstacles = new List<Panel>();
        List<Panel> consumableToRemove = new List<Panel>();

        


        //
        // Oyunu başlat
        //
        private void Start_Click(object sender, EventArgs e)
        {
            if (scoreLimitTextBox.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz.");
                return;
            }
            scoreValueLabel.Text = "0";
            Clear_Panel();
            CreatePanelsFromCoordinates(selectedMap.Obstacles);
            unit = new Panel();
            unit.Location = new Point(200, 200);
            unit.Size = new Size(20, 20);
            unit.BackColor = Color.Blue;
            snake.Add(unit);
            gamePanel.Controls.Add(snake[0]);
            scoreLimit = int.Parse(scoreLimitTextBox.Text);
            scoreLimitTextBox.Enabled = false;
            timer.Start();
            consumableTimer.Start();
            Spawn_Apple();
        }



        //
        // Game Logic
        //

        // Ticks
        private void Timer_Tick(object sender, EventArgs e)
        {
            int snakeX = this.snake[0].Location.X;
            int snakeY = this.snake[0].Location.Y;

            isConsumed();
            Movement();
            Collision_Control();
            Score_Control();

            if (direction == "sağ")
            {
                if (snakeX < 580)
                    snakeX += 20;
                else
                    snakeX = 0;
            }
            if (direction == "sol")
            {
                if (snakeX > 0)
                    snakeX -= 20;
                else
                    snakeX = 580;
            }
            if (direction == "aşağı")
            {
                if (snakeY < 580)
                    snakeY += 20;
                else
                    snakeY = 0;
            }
            if (direction == "yukarı")
            {
                if (snakeY > 0)
                    snakeY -= 20;
                else
                    snakeY = 580;
            }

            this.snake[0].Location = new Point(snakeX, snakeY);
        }
        // Saniyelik Tick
        private void Consumable_Tick(object sender, EventArgs e)
        {
            consTimer++;

            foreach (var consumable in consumableList)
            {
                if ((consTimer - consumable.lifetime) % consumable.spawnRate == 0)
                {
                    Panel selectedPanel = gamePanel.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == consumable.name);

                    if (selectedPanel != null && selectedPanel.Parent != null)
                    {
                        consumableToRemove.Add(selectedPanel);
                    }
                }

                if (consTimer % consumable.spawnRate == 0)
                {
                    Spawn_Consumable(consumable);
                }
            }

            foreach (var consumablePanel in consumableToRemove)
            {
                gamePanel.Controls.Remove(consumablePanel);
                consumablePanels.Remove(consumablePanel);
                consumablePanel.Dispose();
            }
        }
        // Bir hızlandırma yada yavaşlatmanın etki süresi için Tick
        private void speedTick(object sender, EventArgs e)
        {
            if (sender is Timer thistimer)
            {
                if (thistimer.Tag is Tuple<int, int> tuple)
                {
                    int num1 = tuple.Item1;
                    int num2 = tuple.Item2;
                    if (num1 == 0) timer.Interval = timer.Interval * num2;
                    if (num1 == 1) timer.Interval = timer.Interval / num2;
                }

                thistimer.Stop();
                thistimer.Dispose();
            }
        }

        
        // Elma oluşturma
        void Spawn_Apple()
        {
            Random rnd = new Random();
            int appleX, appleY;
            appleX = rnd.Next(580);
            appleY = rnd.Next(580);

            appleX -= appleX % 20;
            appleY -= appleY % 20;

            apple.Size = new Size(20, 20);
            apple.BackColor = Color.Red;
            apple.Location = new Point(appleX, appleY);

            foreach (var obstacle in obstacles)
            {
                if (obstacle.Bounds.IntersectsWith(new Rectangle(appleX, appleY, 20, 20)))
                {
                    Spawn_Apple();
                    return;
                }
            }

            foreach (var unit in snake)
            {
                if (unit.Bounds.IntersectsWith(new Rectangle(appleX, appleY, 20, 20)))
                {
                    Spawn_Apple();
                    return;
                }
            }

            gamePanel.Controls.Add(apple);
        }

        // Custom yem oluşturma
        private void Spawn_Consumable(ConsumableClass consToSpawn)
        {
            Random rnd = new Random();
            int consX, consY;
            consX = rnd.Next(580);
            consY = rnd.Next(580);

            consX -= consX % 20;
            consY -= consY % 20;

            Panel consumablePanel = new Panel
            {
                Size = new Size(20, 20),
                Location = new Point(consX, consY),
                BackColor = consToSpawn.color,
                Name = consToSpawn.name,
            };

            foreach (var obstacle in obstacles)
            {
                if (obstacle.Bounds.IntersectsWith(new Rectangle(consX, consY, 20, 20)))
                {
                    Spawn_Consumable(consToSpawn);
                    return;
                }
            }

            foreach (var unit in snake)
            {
                if (unit.Bounds.IntersectsWith(new Rectangle(consX, consY, 20, 20)))
                {
                    Spawn_Consumable(consToSpawn);
                    return;
                }
            }
            consumablePanels.Add(consumablePanel);
            gamePanel.Controls.Add(consumablePanel);
        }

        // Yem yedikten sonraki logic
        void isConsumed()
        {
            int score = int.Parse(scoreValueLabel.Text);
            if (snake[0].Location == apple.Location)
            {
                gamePanel.Controls.Remove(apple);
                score += 50;
                scoreValueLabel.Text = score.ToString();
                Spawn_Apple();
                Unit_Addition();
            }

            foreach (var consumablePanel in consumablePanels)
            {
                if (snake[0].Location == consumablePanel.Location)
                {
                    var consType = consumableList.First(p => p.name == consumablePanel.Name);
                    score += (int)consType.point;
                    scoreValueLabel.Text = score.ToString();

                    for (int i = 0; i < consType.expand; i++)
                    {
                        Unit_Addition();
                    }

                    if (consType.speedUp > 0)
                    {
                        timer.Interval = timer.Interval / consType.speedUp;
                        Timer newTimer = new Timer();
                        newTimer.Interval = 10000; // 10 saniye
                        newTimer.Start();
                        newTimer.Tag = Tuple.Create(0, consType.speedUp);
                        newTimer.Tick += new EventHandler(speedTick);
                    }
                    if (consType.speedDown > 0)
                    {
                        timer.Interval = timer.Interval * consType.speedDown;
                        Timer newTimer = new Timer();
                        newTimer.Interval = 10000; // 10 saniye
                        newTimer.Start();
                        newTimer.Tag = Tuple.Create(1, consType.speedDown);
                        newTimer.Tick += new EventHandler(speedTick);
                    }
                    consumableToRemove.Add(consumablePanel);
                }
            }

            foreach (var consumablePanel in consumableToRemove)
            {
                gamePanel.Controls.Remove(consumablePanel);
                consumablePanels.Remove(consumablePanel);
                consumablePanel.Dispose();
            }
        }

        // Yılanı uzatma
        void Unit_Addition()
        {
            Panel newUnit = new Panel();
            newUnit.Size = new Size(20, 20);
            newUnit.BackColor = Color.Gray;
            snake.Add(newUnit);
            gamePanel.Controls.Add(newUnit);
        }

        // Kendine veya engele çarpma kontrolü
        void Collision_Control()
        {
            for (int i = 2; i < snake.Count; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    gamePanel.Controls.Add(resultLabel);
                    resultLabel.Visible = true;
                    resultLabel.ForeColor = Color.Red;
                    resultLabel.Text = "KAYBETTİN!";
                    WriteScore();
                    timer.Stop();
                    consumableTimer.Stop();
                    scoreLimitTextBox.Enabled = true;
                }
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                if (snake[0].Location == obstacles[i].Location)
                {
                    gamePanel.Controls.Add(resultLabel);
                    resultLabel.Visible = true;
                    resultLabel.ForeColor = Color.Red;
                    resultLabel.Text = "KAYBETTİN!";
                    WriteScore();
                    timer.Stop();
                    consumableTimer.Stop();
                    scoreLimitTextBox.Enabled = true;
                }
            }

        }

        // Hedef skor varsa eğer, skora ulaşma kontrolü
        void Score_Control()
        {
            if (scoreLimit == 0)
            {
                return;
            }
            int score = int.Parse(scoreValueLabel.Text);
            if (score >= scoreLimit)
            {
                gamePanel.Controls.Add(resultLabel);
                resultLabel.Visible = true;
                resultLabel.ForeColor = Color.Green;
                resultLabel.Text = "KAZANDIN!";
                WriteScore();
                timer.Stop();
                consumableTimer.Stop();
                scoreLimitTextBox.Enabled = true;
            }
        }

        // Hareket
        void Movement()
        {
            for (int i = snake.Count - 1; i > 0; i--)
                snake[i].Location = snake[i - 1].Location;
            coolDown = false;
        }

        // Yön tuşları okuyucu
        private void KeyDown_Reader(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && direction != "sol" && coolDown == false)
            {
                direction = "sağ";
                coolDown = true;
            }
            if (e.KeyCode == Keys.Left && direction != "sağ" && coolDown == false)
            {
                direction = "sol";
                coolDown = true;
            }
            if (e.KeyCode == Keys.Up && direction != "aşağı" && coolDown == false)
            {
                direction = "yukarı";
                coolDown = true;
            }
            if (e.KeyCode == Keys.Down && direction != "yukarı" && coolDown == false)
            {
                direction = "aşağı";
                coolDown = true;
            }
        }




        //
        // Veri Okuma / Yazma
        //

        // Oyun bittikten sonra skoru kaydetme
        private void WriteScore()
        {
            try
            {
                string text = usernameLabel.Text + ";" + selectedMap.Name + ";" + scoreValueLabel.Text;
                File.AppendAllText(scoreboardPath, Environment.NewLine + text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }

        // Yem verilerini oku
        private List<ConsumableClass> ReadData_Consumables()
        {
            List<ConsumableClass> consumables = new List<ConsumableClass> { };

            using (StreamReader sr = new StreamReader(consPath))
            {
                string line;
                List<string> lines = new List<string>();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] cut = line.Split(';');

                    ConsumableClass consumable = new ConsumableClass()
                    {
                        name = cut[0],
                        lifetime = float.Parse(cut[1]),
                        spawnRate = float.Parse(cut[2]),
                        point = float.Parse(cut[3]),
                        color = ParseColorString(cut[4]),
                        description = cut[5],
                        spawned = false,
                        expand = int.Parse(cut[6]),
                        speedDown = int.Parse(cut[7]),
                        speedUp = int.Parse(cut[8]),
                    };
                    consumables.Add(consumable);

                    lines.Add(line);
                }
                return consumables;
            }
        }

        // Skor tablosu verilerini oku
        private List<ScoreClass> ReadData_Scoreboard()
        {
            List<ScoreClass> scores = new List<ScoreClass> { };

            using (StreamReader sr = new StreamReader(scoreboardPath))
            {
                string line;
                List<string> lines = new List<string>();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] cut = line.Split(';');

                    ScoreClass score = new ScoreClass()
                    {
                        username = cut[0],
                        map = cut[1],
                        score = int.Parse(cut[2]),
                    };
                    scores.Add(score);

                    lines.Add(line);
                }
                return scores;
            }
        }




        //
        // Map / Form Logic
        //

        // Form açılınca ayarlanması gereken şeyleri ayarla
        public Form1(MapClass selectedMapInput, string usernameInput)
        {
            InitializeComponent();

            selectedMap = selectedMapInput;
            gamePanel.BackColor = Color.FromArgb(255, 196, 208, 162);
            this.BackColor = Color.FromArgb(255, 139, 150, 110);
            scoreValueLabel.ForeColor = Color.FromArgb(255, 196, 208, 162);
            scoreLabel.ForeColor = Color.FromArgb(255, 196, 208, 162);
            startLabel.BackColor = Color.FromArgb(255, 196, 208, 162);
            resultLabel.Visible = false;
            usernameLabel.Text = usernameInput;
            maxScoreLabel.Text = "0";
            CreatePanelsFromCoordinates(selectedMap.Obstacles);
            consumableList = ReadData_Consumables();

            var scores = ReadData_Scoreboard();
            mapScores = scores.Where(p => p.map == selectedMap.Name).ToList();

            if (mapScores.Count() == 0)
            {
                maxScoreLabel.Text = "0";
            }
            else
            {
                var maxScore = mapScores.OrderByDescending(p => p.score).FirstOrDefault().score;
                maxScoreLabel.Text = maxScore.ToString();

                var yourScore = mapScores.Where(p => p.username == usernameInput).FirstOrDefault();

                if (yourScore != null)
                {
                    var yourMaxScore = mapScores.Where(p => p.username == usernameInput).OrderByDescending(p => p.score).FirstOrDefault().score;
                    yourMaxLabel.Text = yourMaxScore.ToString();
                }
                else
                {
                    yourMaxLabel.Text = "0";
                }
            }
        }

        // MainMenuForm'dan gelen map verilerini kullanarak panel'e engelleri yerleştirip map oluşturma
        private void CreatePanelsFromCoordinates(string coordinates)
        {
            if (coordinates == null) return;

            string[] coordinateArray = coordinates.Split(',');

            foreach (string coordinate in coordinateArray)
            {
                string[] xy = coordinate.Split('x');
                if (xy.Length == 2 && int.TryParse(xy[0], out int x) && int.TryParse(xy[1], out int y))
                {
                    Panel obstaclePanel = new Panel
                    {
                        Size = new Size(20, 20),
                        Location = new Point(x, y),
                        BackColor = Color.Black
                    };
                    obstacles.Add(obstaclePanel);
                    gamePanel.Controls.Add(obstaclePanel);
                }
                else
                {
                    Console.WriteLine("Hatalı koordinat formatı: " + coordinate);
                }
            }
        }

        // Paneli temizleme
        void Clear_Panel()
        {
            gamePanel.Controls.Clear();
            snake.Clear();
            resultLabel.Visible = false;
        }




        //
        // Düğmeler
        //

        // Skor tablosu düğmesi
        private void scoreTableButton_Click(object sender, EventArgs e)
        {
            var orderedList = mapScores.OrderByDescending(p => p.score).ToList();
            string metin = string.Empty;
            int loopAmount = 10;
            if (orderedList.Count() < 10) loopAmount = orderedList.Count();
            for (int i = 0; i < loopAmount; i++)
            {
                metin += i + 1 + ") " + orderedList[i].username + ": " + orderedList[i].score + "\n";
            }
            MessageBox.Show(metin);
        }

        // Yem düğmesi
        private void consumablesButton_Click(object sender, EventArgs e)
        {
            string metin = string.Empty;
            foreach (var consumable in consumableList)
            {
                metin += consumable.name + ": " + consumable.description + "\n";
            }
            MessageBox.Show(metin);
        }

        // Geri düğmesi
        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            form.Show();
            this.Close();
        }




        //
        // Diğer
        //

        // String'e çevrilmiş renk verisini okuyarak tekrardan renk oluşturma
        private static Color ParseColorString(string colorString)
        {
            Regex regex = new Regex(@"\[(A=\d+), (R=\d+), (G=\d+), (B=\d+)\]");
            Match match = regex.Match(colorString);

            if (match.Success)
            {
                int alpha = int.Parse(match.Groups[1].Value.Split('=')[1]);
                int red = int.Parse(match.Groups[2].Value.Split('=')[1]);
                int green = int.Parse(match.Groups[3].Value.Split('=')[1]);
                int blue = int.Parse(match.Groups[4].Value.Split('=')[1]);

                return Color.FromArgb(alpha, red, green, blue);
            }
            else
            {
                throw new FormatException("Geçersiz format.");
            }
        }

        // Skor limit kutusuna sadece sayı girilmesi
        private void scoreLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}