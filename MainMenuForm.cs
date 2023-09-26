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
        static int satirSayisi;

        static string mainpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string mapPath = Path.Combine(mainpath, "Maps");
        static string mapTxtPath = Path.Combine(mainpath, $"Maps\\maps.txt");

        static MapClass selectedMap = new MapClass();


        // map'leri okuyo
        private MapClass VeriOku(int tane, int rule)
        {
            MapClass newMap = new MapClass { };

            string maps = string.Empty;
            int maksimumSatir = tane + satirSayisi;
            if (rule > 0) maksimumSatir = int.MaxValue;

            using (StreamReader sr = new StreamReader(mapTxtPath))
            {
                string satir;
                List<string> satirlar = new List<string>();

                for (int i = 0; i < satirSayisi; i++)
                {
                    sr.ReadLine();
                }

                while ((satir = sr.ReadLine()) != null)
                {
                    string[] kesme = satir.Split(';');

                    newMap.Name = kesme[0];
                    newMap.Image = kesme[1];
                    if(kesme.Length > 2) newMap.Obstacles = kesme[2];

                    satirlar.Add(satir);
                    satirSayisi++;

                    if (satirSayisi >= maksimumSatir)
                    {
                        satirlar.Clear();
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


        // map dosyasını yoksa yaratıyo ve default map'i gösteriyo
        private void MainMenuForm_Load(object sender, EventArgs e) { }
        public MainMenuForm()
        {
            InitializeComponent();

            satirSayisi = 0;

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

            MapClass map = VeriOku(1, 0); // map.txt den 1 satır oku

            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image)); // map'in image dosya isminden image'ı aldı
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size); // alınan image'ı levelPicture panelinin boyutlarına scale'ladık
            levelNameLabel.Text = map.Name; // mapin adını label'a yazık
        }



        // sıradaki mapi getiriyo
        private void nextButton_Click(object sender, EventArgs e)
        {
            var map = VeriOku(1, 0);
            if (map == null)
            {
                satirSayisi = 0;
                map = VeriOku(1, 0);
            }
            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image));
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size);
            levelNameLabel.Text = map.Name;
            selectedMap = map; // seçili map değerini okuduğum map yaptım

            
        }        
        // önceki mapi getiriyo
        private void prevButton_Click(object sender, EventArgs e)
        {
            MapClass map = new MapClass();

            if (satirSayisi == 1) // son satır
            {
                map = VeriOku(1, 1);
            }
            else
            {
                satirSayisi -= 2;
                map = VeriOku(1, 0);
            }
            if (map == null)
            {
                satirSayisi = 0;
                map = VeriOku(1, 0);
            }
            Image originalImage = Image.FromFile(Path.Combine(mapPath, map.Image));
            levelPicture.Image = ScaleImage(originalImage, levelPicture.Size);
            levelNameLabel.Text = map.Name;
            selectedMap = map;
        }
        // sıradaki sayfaya geçiyo
        private void selectButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "")
            {
                MessageBox.Show("Bir isim gir!");
                return;
            }

            Form1 form1 = new Form1(selectedMap, usernameBox.Text);
            form1.Show();
            this.Hide();
        }

        // admin sayfasını açıyo
        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Hide();
        }

        // ekstra görsel boyutu ayarlama fonksiyonu
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
    }
}
