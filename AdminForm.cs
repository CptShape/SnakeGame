using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace StajProje2
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void mapButton_Click(object sender, EventArgs e)
        {
            MapCreationForm form = new MapCreationForm();
            form.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            form.Show();
            this.Close();
        }

        private void consumableButton_Click(object sender, EventArgs e)
        {
            ConsumableForm form = new ConsumableForm();
            form.Show();
            this.Close();
        }
    }
}
