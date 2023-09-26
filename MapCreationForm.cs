using StajProje2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace StajProje2
{
    public partial class MapCreationForm : Form
    {
        static string mainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string mapPath = Path.Combine(mainPath, "Maps");
        static string mapTxtPath = Path.Combine(mainPath, $"Maps\\maps.txt");

        private const int gridSize = 20;

        static List<string> squares = new List<string>();




        public MapCreationForm()
        {
            InitializeComponent();
            pictureBox.AllowDrop = true;
        }




        // Map verilerini oku
        private List<MapClass> ReadData_Map()
        {
            List<MapClass> maps = new List<MapClass> { };

            using (StreamReader sr = new StreamReader(mapTxtPath))
            {
                string line;
                List<string> lines = new List<string>();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] cut = line.Split(';');

                    MapClass map = new MapClass()
                    {
                       Name = cut[0],
                    };
                    maps.Add(map);

                    lines.Add(line);
                }
                return maps;
            }
        }




        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // Mouse konumunu al
            Point mouseLocationPanel = e.Location;

            // Kare için yeni konumu hesapla
            int squareX = (mouseLocationPanel.X / gridSize) * gridSize;
            int squareY = (mouseLocationPanel.Y / gridSize) * gridSize;

            // Kare oluştur ve özelliklerini ayarla
            Panel square = new Panel();
            square.Size = new Size(gridSize, gridSize);
            square.BackColor = Color.Black;
            square.Location = new Point(squareX, squareY);

            // Kareyi panele ekle
            mapPanel.Controls.Add(square);
            square.MouseClick += square_MouseClick;

            // Kareyi square listesine ekle
            squares.Add(squareX + "x" + squareY);
        }

        // Sağ tıklandığında square panelini sil
        private void square_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel squarePanel = sender as Panel;
                Point panelLocation = squarePanel.Location;

                mapPanel.Controls.Remove(squarePanel);
                squarePanel.Dispose();

                while (squares.Contains(panelLocation.X.ToString() + "x" + panelLocation.Y.ToString()))
                {
                    squares.Remove(panelLocation.X.ToString() + "x" + panelLocation.Y.ToString());
                }
            }
        }




        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (filePaths != null && filePaths.Length > 0)
            {
                string fileName = Path.GetFileName(filePaths[0]);
                Image originalImage = new Bitmap(filePaths[0]);
                pictureBox.Image = ScaleImage(originalImage, pictureBox.Size);
            }
        }

        private Image ScaleImage(Image image, Size size)
        {
            Bitmap scaledImage = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, size.Width, size.Height);
            }
            return scaledImage;
        }




        private void createButton_Click(object sender, EventArgs e)
        {
            var maps = ReadData_Map();
            var result = maps.Where(p => p.Name == nameBox.Text).ToList();

            if(result.Count() != 0)
            {
                MessageBox.Show("Bu isimde bir map mevcut.");
                return;
            }

            if (pictureBox.Image != null) // image kısmında bir şey varsa
            {
                string fileName = nameBox.Text + ".png";
                string targetPath = Path.Combine(mapPath, fileName);

                try
                {
                    pictureBox.Image.Save(targetPath); // hedefe girilen resmi kaydet

                    string addSquare = string.Empty;
                    foreach (var square in squares)
                    {
                        addSquare += square + ",";
                    }
                    if (addSquare.Length != 0) addSquare = addSquare.Remove(addSquare.Length - 1);

                    try
                    {
                        File.AppendAllText(mapTxtPath, Environment.NewLine + nameBox.Text + ";" + fileName + ";" + addSquare);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bir hata oluştu: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim kaydedilirken bir hata oluştu: " + ex.Message);
                }

                pictureBox.Image = null;
            }
            else
            {
                saveScreenshot();

                string addSquare = string.Empty;
                foreach (var square in squares)
                {
                    addSquare += square + ",";
                }
                addSquare = addSquare.Remove(addSquare.Length - 1);

                try
                {
                    File.AppendAllText(mapTxtPath, Environment.NewLine + nameBox.Text + ";" + nameBox.Text + ".png" + ";" + addSquare);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bir hata oluştu: " + ex.Message);
                }
            }

            mapPanel.Controls.Clear();
            squares.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Close();
        }




        private void saveScreenshot()
        {
            Point panelLocation = mapPanel.PointToScreen(Point.Empty);
            Size panelSize = mapPanel.Size;

            Bitmap screenshot = new Bitmap(panelSize.Width, panelSize.Height);

            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(panelLocation, Point.Empty, panelSize);
            }

            string filePath = Path.Combine(mapPath, nameBox.Text + ".png");
            screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }




        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == ';')
            {
                e.Handled = true;
                return;
            }

            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
