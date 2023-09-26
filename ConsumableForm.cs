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

namespace StajProje2
{
    public partial class ConsumableForm : Form
    {
        public ConsumableForm()
        {
            InitializeComponent();
            trackBar4.Value = 255;
        }

        static string mainpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string mapPath = Path.Combine(mainpath, "Maps");
        static string mapTxtPath = Path.Combine(mainpath, $"Maps\\maps.txt");
        static string consumableTxtPath = Path.Combine(mainpath, $"Maps\\consumables.txt");

        // TrackBar, renk seçimi için
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
            label4.Text = trackBar2.Value.ToString();
            label5.Text = trackBar3.Value.ToString();
            label6.Text = trackBar4.Value.ToString();
            panel1.BackColor = Color.FromArgb(trackBar4.Value, trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("İsim girmelisin.");
                return;
            }
            if (lifetimeBox.Text == "")
            {
                MessageBox.Show("Hayat süresi girmelisin.");
                return;
            }
            if (periodBox.Text == "")
            {
                MessageBox.Show("Periyot girmelisin.");
                return;
            }
            if (pointBox.Text == "")
            {
                MessageBox.Show("Puan girmelisin.");
                return;
            }

            ConsumableClass newConsumable = new ConsumableClass()
            {
                Name = nameBox.Text,
                Description = richTextBox1.Text,
                Lifetime = float.Parse(lifetimeBox.Text),
                SpawnRate = float.Parse(periodBox.Text),
                Point = float.Parse(pointBox.Text),
                Color = Color.FromArgb(trackBar4.Value, trackBar1.Value, trackBar2.Value, trackBar3.Value),
            };

            try
            {
                string metin = newConsumable.Name + ";" + newConsumable.Lifetime + ";" + newConsumable.SpawnRate + ";" + newConsumable.Point + ";" + newConsumable.Color + ";" + newConsumable.Description;
                File.AppendAllText(consumableTxtPath, Environment.NewLine + metin);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            nameBox.Text = "";
            richTextBox1.Text = "";
            lifetimeBox.Text = "";
            periodBox.Text = "";
            pointBox.Text = "";
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 255;
            panel1.BackColor = Color.FromArgb(trackBar4.Value, trackBar1.Value, trackBar2.Value, trackBar3.Value);
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "255";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Close();
        }
    }
}
