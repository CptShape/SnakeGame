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
        MapClass selectedMap = new MapClass();
        static string mainpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string consPath = Path.Combine(mainpath, "Maps\\consumables.txt");
        static int satirSayisi;
        List<ConsumableClass> consumableList = new List<ConsumableClass>();
        static int consTimer;

        public Form1(MapClass selectedMapInput, string usernameInput)
        {
            InitializeComponent();
            selectedMap = selectedMapInput;
            gamePanel.BackColor = Color.FromArgb(255, 196, 208, 162);
            this.BackColor = Color.FromArgb(255, 139, 150, 110);
            scoreValueLabel.ForeColor = Color.FromArgb(255, 196, 208, 162);
            scoreLabel.ForeColor = Color.FromArgb(255, 196, 208, 162);
            label3.BackColor = Color.FromArgb(255, 196, 208, 162);
            loseLabel.Visible = false;
            usernameLabel.Text = usernameInput;
            maxScoreLabel.Text = "0";
            CreatePanelsFromCoordinates(selectedMap.Obstacles);
            consumableList = VeriOku();
        }
        
        bool coolDown;
        int scoreLimit = 0;
        Panel unit;
        Panel apple = new Panel();
        List<Panel> consumablePanels = new List<Panel>();
        List<Panel> snake = new List<Panel>();
        string direction = "sağ";
        List<Panel> obstacles = new List<Panel>();


        private List<ConsumableClass> VeriOku()
        {
            List<ConsumableClass> consumables = new List<ConsumableClass> { };

            using (StreamReader sr = new StreamReader(consPath))
            {
                string satir;
                List<string> satirlar = new List<string>();

                while ((satir = sr.ReadLine()) != null)
                {
                    string[] kesme = satir.Split(';');

                    ConsumableClass consumable = new ConsumableClass()
                    {
                        Name = kesme[0],
                        Lifetime = float.Parse(kesme[1]),
                        SpawnRate = float.Parse(kesme[2]),
                        Point = float.Parse(kesme[3]),
                        Color = ParseColorString(kesme[4]),
                        Description = kesme[5],
                        spawned = false,
                    };
                    consumables.Add(consumable);

                    satirlar.Add(satir);
                }
                return consumables;
            }
        }


        private static Color ParseColorString(string colorString)
        {
            // Use a regular expression to extract the color values
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
                throw new FormatException("Invalid color string format.");
            }
        }



        private void CreatePanelsFromCoordinates(string coordinates)
        { // "100x100,200x200,300x300"
            if (coordinates == null) return;
            // Koordinatları "," karakterinden ayırarak string dizisine dönüştür
            string[] coordinateArray = coordinates.Split(',');
            // 

            foreach (string coordinate in coordinateArray)
            {
                // Koordinatları "x" karakterinden ayırarak x ve y konumlarını al
                string[] xy = coordinate.Split('x');
                if (xy.Length == 2 && int.TryParse(xy[0], out int x) && int.TryParse(xy[1], out int y))
                {
                    // Panel oluştur
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







        private void Timer_Tick(object sender, EventArgs e)
        {
            int locX = snake[0].Location.X;
            int locY = snake[0].Location.Y;

            isConsumed();
            Movement();
            Collision_Control();
            Score_Control();

            if (direction == "sağ")
            {
                if (locX < 580)
                    locX += 20;
                else
                    locX = 0;
            }
            if (direction == "sol")
            {
                if (locX > 0)
                    locX -= 20;
                else
                    locX = 580;
            }
            if (direction == "aşağı")
            {
                if (locY < 580)
                    locY += 20;
                else
                    locY = 0;
            }
            if (direction == "yukarı")
            {
                if (locY > 0)
                    locY -= 20;
                else
                    locY = 580;
            }

            snake[0].Location = new Point(locX, locY);
        }


        void Collision_Control()
        {
            for (int i = 2; i < snake.Count; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    gamePanel.Controls.Add(loseLabel);
                    loseLabel.Visible = true;
                    loseLabel.ForeColor = Color.Red;
                    loseLabel.Text = "KAYBETTİN!";
                    timer.Stop();
                    consumableTimer.Stop();
                    scoreLimitTextBox.Enabled = true;
                }
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                if (snake[0].Location == obstacles[i].Location)
                {
                    gamePanel.Controls.Add(loseLabel);
                    loseLabel.Visible = true;
                    loseLabel.ForeColor = Color.Red;
                    loseLabel.Text = "KAYBETTİN!";
                    timer.Stop();
                    consumableTimer.Stop();
                    scoreLimitTextBox.Enabled = true;
                }
            }

        }


        void Score_Control()
        {
            if (scoreLimit == 0)
            {
                return;
            }
            int score = int.Parse(scoreValueLabel.Text);
            if (score >= scoreLimit)
            {
                gamePanel.Controls.Add(loseLabel);
                loseLabel.Visible = true;
                loseLabel.ForeColor = Color.Green;
                loseLabel.Text = "KAZANDIN!";
                timer.Stop();
                consumableTimer.Stop();
                scoreLimitTextBox.Enabled = true;
            }
        }


        void Movement()
        {
            for (int i = snake.Count - 1; i > 0; i--)
                snake[i].Location = snake[i - 1].Location;
            coolDown = false;
        }




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




        void Spawn_Apple()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            apple.Size = new Size(20, 20);
            apple.BackColor = Color.Red;
            apple.Location = new Point(elmaX, elmaY);

            foreach (var obstacle in obstacles)
            {
                if (obstacle.Bounds.IntersectsWith(new Rectangle(elmaX, elmaY, 20, 20)))
                {
                    Spawn_Apple();
                    return;
                }
            }

            foreach (var unit in snake)
            {
                if (unit.Bounds.IntersectsWith(new Rectangle(elmaX, elmaY, 20, 20)))
                {
                    Spawn_Apple();
                    return;
                }
            }

            gamePanel.Controls.Add(apple);
        }

        private void Consumable_Tick(object sender, EventArgs e)
        {
            consTimer++;

            foreach (var consumable in consumableList)
            {
                if (consTimer % consumable.SpawnRate == 0)
                {
                    Spawn_Consumable(consumable);
                }
            }


        }

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
                    gamePanel.Controls.Remove(consumablePanel);
                    var consType = consumableList.First(p => p.Name == consumablePanel.Name);
                    score += (int)consType.Point;
                    scoreValueLabel.Text = score.ToString();
                }
            }
        }

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
                BackColor = consToSpawn.Color,
                Name = consToSpawn.Name,
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




        void Unit_Addition()
        {
            Panel newUnit = new Panel();
            newUnit.Size = new Size(20, 20);
            newUnit.BackColor = Color.Gray;
            snake.Add(newUnit);
            gamePanel.Controls.Add(newUnit);
        }




        void Clear_Panel()
        {
            gamePanel.Controls.Clear();
            snake.Clear();
            loseLabel.Visible = false;

        }

        private void scoreLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
