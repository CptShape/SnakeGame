using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using StajProje2.Classes;
using static System.Windows.Forms.DataFormats;

namespace StajProje2
{
    public partial class MainMenuForm : Form
    {
        static int lineNum;

        static string mainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string mapPath = Path.Combine(mainPath, "Maps");
        static string mapTxtPath = Path.Combine(mainPath, $"Maps\\maps.txt");

        static MapClass selectedMap = new MapClass();

        public MainMenuForm()
        {
            InitializeComponent();

            lineNum = 0;

            if (File.Exists(mapTxtPath))
            {
                Console.WriteLine("Dosya zaten mevcut.");
            }
            else
            {
                try
                {
                    File.WriteAllText(mapTxtPath, "default;deault.png");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }

            MapClass map = ReadData(1, 0);
            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image));
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size);
            levelNameLabel.Text = map.Name;
            selectedMap = map;
        }




        // map.txt dosyasından mevcut mapleri okur
        private MapClass ReadData(int amount, int rule)
        {
            MapClass newMap = new MapClass { };

            string maps = string.Empty;
            int maxLine = amount + lineNum;
            if (rule > 0) maxLine = int.MaxValue;

            using (StreamReader sr = new StreamReader(mapTxtPath))
            {
                string line;
                List<string> lines = new List<string>();

                for (int i = 0; i < lineNum; i++)
                {
                    sr.ReadLine();
                }

                while ((line = sr.ReadLine()) != null)
                {
                    string[] cut = line.Split(';');

                    newMap.Name = cut[0];
                    newMap.Image = cut[1];
                    if (cut.Length > 2) newMap.Obstacles = cut[2];

                    lines.Add(line);
                    lineNum++;

                    if (lineNum >= maxLine)
                    {
                        lines.Clear();
                        return newMap;
                    }
                }
                if (rule > 0)
                {
                    return newMap;
                }
                return null;
            }
        }




        private void nextButton_Click(object sender, EventArgs e)
        {
            var map = ReadData(1, 0);
            if (map == null)
            {
                lineNum = 0;
                map = ReadData(1, 0);
            }
            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image));
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size);
            levelNameLabel.Text = map.Name;
            selectedMap = map;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            MapClass map = new MapClass();

            if (lineNum == 1)
            {
                map = ReadData(1, 1);
            }
            else
            {
                lineNum -= 2;
                map = ReadData(1, 0);
            }
            if (map == null)
            {
                lineNum = 0;
                map = ReadData(1, 0);
            }
            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image));
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size);
            levelNameLabel.Text = map.Name;
            selectedMap = map;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "")
            {
                MessageBox.Show("Bir isim gir!");
                return;
            }

            Form1 form = new Form1(selectedMap, usernameBox.Text);
            form.Show();
            this.Hide();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Hide();
        }




        // Fotoğrafın boyutlarını, panel boyutuna getirir
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

        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
