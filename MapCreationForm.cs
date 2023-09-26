using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace StajProje2
{
    public partial class MapCreationForm : Form
    {
        private const int gridSize = 20;  // Karelerin kenar uzunluğu ve grid boyutu

        static string mainpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string mapPath = Path.Combine(mainpath, "Maps");
        static string mapTxtPath = Path.Combine(mainpath, $"Maps\\maps.txt");

        static List<string> kareler = new List<string>();

        public MapCreationForm()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // Mouse konumunu al
            Point mouseKonumuPanel = e.Location;

            // Kare için yeni konumu hesapla
            int kareX = (mouseKonumuPanel.X / gridSize) * gridSize;
            int kareY = (mouseKonumuPanel.Y / gridSize) * gridSize;

            // Kare oluştur ve özelliklerini ayarla
            Panel kare = new Panel();
            kare.Size = new Size(gridSize, gridSize);
            kare.BackColor = Color.Black; // Kare rengi (örneğin, siyah)
            kare.Location = new Point(kareX, kareY);

            // Kareyi panele ekle
            panel1.Controls.Add(kare);
            kare.MouseClick += Kare_MouseClick;

            // Kareyi kare listesine ekle
            kareler.Add(kareX + "x" + kareY);
        }

        private void Kare_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Sağ tıklandığında kare panelini sil
                Panel karePanel = sender as Panel;
                Point panelLocation = karePanel.Location;

                panel1.Controls.Remove(karePanel);
                karePanel.Dispose();

                while (kareler.Contains(panelLocation.X.ToString() + "x" + panelLocation.Y.ToString()))
                {
                    kareler.Remove(panelLocation.X.ToString() + "x" + panelLocation.Y.ToString());
                }
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            // Sürüklenen öğe bir resim mi kontrol et
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            // Sürüklenen resmi PictureBox'e yükle
            string[] dosyaYollari = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (dosyaYollari != null && dosyaYollari.Length > 0)
            {
                string dosyaAdi = Path.GetFileName(dosyaYollari[0]);
                Image originalImage = new Bitmap(dosyaYollari[0]);
                pictureBox1.Image = ScaleImage(originalImage, pictureBox1.Size);
            }
        }

        // scale
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // image kısmında bir şey varsa
            {
                string dosyaAdi = textBox1.Text + ".png"; // dosyaAdi = asd.png
                string hedefYol = Path.Combine(mapPath, dosyaAdi); // hedef = .../Maps/asd.png

                try
                {
                    pictureBox1.Image.Save(hedefYol); // hedefe girilen resmi kaydet

                    string addKare = string.Empty;
                    foreach (var kare in kareler)
                    {
                        addKare += kare + ",";
                    }
                    if(addKare.Length != 0) addKare = addKare.Remove(addKare.Length - 1);

                    try
                    {
                        File.AppendAllText(mapTxtPath, Environment.NewLine + textBox1.Text + ";" + dosyaAdi + ";" + addKare);
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

                pictureBox1.Image = null;
            }
            else
            {
                saveScreenshot();

                string addKare = string.Empty;
                foreach (var kare in kareler)
                {
                    addKare += kare + ",";
                }
                addKare = addKare.Remove(addKare.Length - 1);

                try
                {
                    File.AppendAllText(mapTxtPath, Environment.NewLine + textBox1.Text + ";" + textBox1.Text + ".png" + ";" + addKare);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bir hata oluştu: " + ex.Message);
                }
            }

            panel1.Controls.Clear();
            kareler.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Space ve , tuşuna izin verme
            if (e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == ';')
            {
                e.Handled = true;
                return;
            }

            // Karakter sınırını kontrol et
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void saveScreenshot()
        {
            // Get the location and size of the panel to capture
            Point panelLocation = panel1.PointToScreen(Point.Empty);
            Size panelSize = panel1.Size;

            // Create a bitmap to store the screenshot
            Bitmap screenshot = new Bitmap(panelSize.Width, panelSize.Height);

            // Capture the screenshot of the panel
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(panelLocation, Point.Empty, panelSize);
            }

            // Save the screenshot as an image file
            string filePath = Path.Combine(mapPath, textBox1.Text + ".png");
            screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
