namespace StajProje2
{
    partial class ConsumableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            descLabel = new System.Windows.Forms.Label();
            descRichTextBox = new System.Windows.Forms.RichTextBox();
            redTrackBar = new System.Windows.Forms.TrackBar();
            greenTrackBar = new System.Windows.Forms.TrackBar();
            blueTrackBar = new System.Windows.Forms.TrackBar();
            redLabel = new System.Windows.Forms.Label();
            greenLabel = new System.Windows.Forms.Label();
            blueLabel = new System.Windows.Forms.Label();
            argbPanel = new System.Windows.Forms.Panel();
            alphaTrackBar = new System.Windows.Forms.TrackBar();
            alphaLabel = new System.Windows.Forms.Label();
            lifetimeBox = new System.Windows.Forms.TextBox();
            lifetimeLabel = new System.Windows.Forms.Label();
            rateLabel = new System.Windows.Forms.Label();
            periodBox = new System.Windows.Forms.TextBox();
            pointBox = new System.Windows.Forms.TextBox();
            pointLabel = new System.Windows.Forms.Label();
            createButton = new System.Windows.Forms.Button();
            backButton = new System.Windows.Forms.Button();
            ekstraLabel = new System.Windows.Forms.Label();
            lengthCheckBox = new System.Windows.Forms.CheckBox();
            lengthSlider = new System.Windows.Forms.TrackBar();
            speedupSlider = new System.Windows.Forms.TrackBar();
            speedupCheckBox = new System.Windows.Forms.CheckBox();
            speeddownSlider = new System.Windows.Forms.TrackBar();
            speeddownCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)redTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)greenTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blueTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lengthSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)speedupSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)speeddownSlider).BeginInit();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(75, 18);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(127, 23);
            nameBox.TabIndex = 0;
            nameBox.KeyPress += nameBox_KeyPress;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(27, 18);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(29, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Isim";
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new System.Drawing.Point(27, 92);
            descLabel.Name = "descLabel";
            descLabel.Size = new System.Drawing.Size(56, 15);
            descLabel.TabIndex = 2;
            descLabel.Text = "Açıklama";
            // 
            // descRichTextBox
            // 
            descRichTextBox.Location = new System.Drawing.Point(27, 110);
            descRichTextBox.Name = "descRichTextBox";
            descRichTextBox.Size = new System.Drawing.Size(330, 81);
            descRichTextBox.TabIndex = 3;
            descRichTextBox.Text = "";
            // 
            // redTrackBar
            // 
            redTrackBar.Location = new System.Drawing.Point(27, 235);
            redTrackBar.Maximum = 255;
            redTrackBar.Name = "redTrackBar";
            redTrackBar.Size = new System.Drawing.Size(175, 45);
            redTrackBar.TabIndex = 4;
            redTrackBar.ValueChanged += trackBar1_ValueChanged;
            // 
            // greenTrackBar
            // 
            greenTrackBar.Location = new System.Drawing.Point(27, 273);
            greenTrackBar.Maximum = 255;
            greenTrackBar.Name = "greenTrackBar";
            greenTrackBar.Size = new System.Drawing.Size(175, 45);
            greenTrackBar.TabIndex = 5;
            greenTrackBar.ValueChanged += trackBar1_ValueChanged;
            // 
            // blueTrackBar
            // 
            blueTrackBar.Location = new System.Drawing.Point(27, 309);
            blueTrackBar.Maximum = 255;
            blueTrackBar.Name = "blueTrackBar";
            blueTrackBar.Size = new System.Drawing.Size(175, 45);
            blueTrackBar.TabIndex = 6;
            blueTrackBar.ValueChanged += trackBar1_ValueChanged;
            // 
            // redLabel
            // 
            redLabel.AutoSize = true;
            redLabel.ForeColor = System.Drawing.Color.Red;
            redLabel.Location = new System.Drawing.Point(208, 235);
            redLabel.Name = "redLabel";
            redLabel.Size = new System.Drawing.Size(13, 15);
            redLabel.TabIndex = 7;
            redLabel.Text = "0";
            // 
            // greenLabel
            // 
            greenLabel.AutoSize = true;
            greenLabel.ForeColor = System.Drawing.Color.Green;
            greenLabel.Location = new System.Drawing.Point(208, 273);
            greenLabel.Name = "greenLabel";
            greenLabel.Size = new System.Drawing.Size(13, 15);
            greenLabel.TabIndex = 8;
            greenLabel.Text = "0";
            // 
            // blueLabel
            // 
            blueLabel.AutoSize = true;
            blueLabel.ForeColor = System.Drawing.Color.SteelBlue;
            blueLabel.Location = new System.Drawing.Point(208, 309);
            blueLabel.Name = "blueLabel";
            blueLabel.Size = new System.Drawing.Size(13, 15);
            blueLabel.TabIndex = 9;
            blueLabel.Text = "0";
            // 
            // argbPanel
            // 
            argbPanel.Location = new System.Drawing.Point(254, 235);
            argbPanel.Name = "argbPanel";
            argbPanel.Size = new System.Drawing.Size(103, 103);
            argbPanel.TabIndex = 10;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new System.Drawing.Point(27, 344);
            alphaTrackBar.Maximum = 255;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new System.Drawing.Size(175, 45);
            alphaTrackBar.TabIndex = 11;
            alphaTrackBar.ValueChanged += trackBar1_ValueChanged;
            // 
            // alphaLabel
            // 
            alphaLabel.AutoSize = true;
            alphaLabel.Location = new System.Drawing.Point(208, 344);
            alphaLabel.Name = "alphaLabel";
            alphaLabel.Size = new System.Drawing.Size(25, 15);
            alphaLabel.TabIndex = 12;
            alphaLabel.Text = "255";
            // 
            // lifetimeBox
            // 
            lifetimeBox.Location = new System.Drawing.Point(105, 61);
            lifetimeBox.Name = "lifetimeBox";
            lifetimeBox.Size = new System.Drawing.Size(63, 23);
            lifetimeBox.TabIndex = 13;
            lifetimeBox.KeyPress += KeyPress_OnlyDigits;
            // 
            // lifetimeLabel
            // 
            lifetimeLabel.AutoSize = true;
            lifetimeLabel.Location = new System.Drawing.Point(27, 64);
            lifetimeLabel.Name = "lifetimeLabel";
            lifetimeLabel.Size = new System.Drawing.Size(72, 15);
            lifetimeLabel.TabIndex = 14;
            lifetimeLabel.Text = "Hayat Süresi";
            // 
            // rateLabel
            // 
            rateLabel.AutoSize = true;
            rateLabel.Location = new System.Drawing.Point(241, 69);
            rateLabel.Name = "rateLabel";
            rateLabel.Size = new System.Drawing.Size(47, 15);
            rateLabel.TabIndex = 15;
            rateLabel.Text = "Periyod";
            // 
            // periodBox
            // 
            periodBox.Location = new System.Drawing.Point(294, 64);
            periodBox.Name = "periodBox";
            periodBox.Size = new System.Drawing.Size(63, 23);
            periodBox.TabIndex = 16;
            periodBox.KeyPress += KeyPress_OnlyDigits;
            // 
            // pointBox
            // 
            pointBox.Location = new System.Drawing.Point(294, 18);
            pointBox.Name = "pointBox";
            pointBox.Size = new System.Drawing.Size(63, 23);
            pointBox.TabIndex = 18;
            pointBox.KeyPress += KeyPress_OnlyDigits;
            // 
            // pointLabel
            // 
            pointLabel.AutoSize = true;
            pointLabel.Location = new System.Drawing.Point(254, 21);
            pointLabel.Name = "pointLabel";
            pointLabel.Size = new System.Drawing.Size(34, 15);
            pointLabel.TabIndex = 17;
            pointLabel.Text = "Puan";
            // 
            // createButton
            // 
            createButton.Location = new System.Drawing.Point(266, 418);
            createButton.Name = "createButton";
            createButton.Size = new System.Drawing.Size(75, 23);
            createButton.TabIndex = 19;
            createButton.Text = "Oluştur";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new System.Drawing.Point(55, 418);
            backButton.Name = "backButton";
            backButton.Size = new System.Drawing.Size(75, 23);
            backButton.TabIndex = 20;
            backButton.Text = "Geri";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // ekstraLabel
            // 
            ekstraLabel.AutoSize = true;
            ekstraLabel.Location = new System.Drawing.Point(10, 480);
            ekstraLabel.Name = "ekstraLabel";
            ekstraLabel.Size = new System.Drawing.Size(89, 15);
            ekstraLabel.TabIndex = 21;
            ekstraLabel.Text = "Ekstra Özellikler";
            // 
            // lengthCheckBox
            // 
            lengthCheckBox.AutoSize = true;
            lengthCheckBox.Location = new System.Drawing.Point(10, 520);
            lengthCheckBox.Name = "lengthCheckBox";
            lengthCheckBox.Size = new System.Drawing.Size(85, 19);
            lengthCheckBox.TabIndex = 22;
            lengthCheckBox.Text = "Boy Uzama";
            lengthCheckBox.UseVisualStyleBackColor = true;
            lengthCheckBox.CheckedChanged += lengthCheckBox_CheckedChanged;
            // 
            // lengthSlider
            // 
            lengthSlider.Location = new System.Drawing.Point(113, 520);
            lengthSlider.Maximum = 3;
            lengthSlider.Name = "lengthSlider";
            lengthSlider.Size = new System.Drawing.Size(175, 45);
            lengthSlider.TabIndex = 23;
            lengthSlider.Visible = false;
            // 
            // speedupSlider
            // 
            speedupSlider.Location = new System.Drawing.Point(113, 560);
            speedupSlider.Maximum = 4;
            speedupSlider.Name = "speedupSlider";
            speedupSlider.Size = new System.Drawing.Size(175, 45);
            speedupSlider.TabIndex = 25;
            speedupSlider.Visible = false;
            // 
            // speedupCheckBox
            // 
            speedupCheckBox.AutoSize = true;
            speedupCheckBox.Location = new System.Drawing.Point(10, 560);
            speedupCheckBox.Name = "speedupCheckBox";
            speedupCheckBox.Size = new System.Drawing.Size(73, 19);
            speedupCheckBox.TabIndex = 24;
            speedupCheckBox.Text = "Hızlandır";
            speedupCheckBox.UseVisualStyleBackColor = true;
            speedupCheckBox.CheckedChanged += speedupCheckBox_CheckedChanged;
            // 
            // speeddownSlider
            // 
            speeddownSlider.Location = new System.Drawing.Point(113, 603);
            speeddownSlider.Maximum = 4;
            speeddownSlider.Name = "speeddownSlider";
            speeddownSlider.Size = new System.Drawing.Size(175, 45);
            speeddownSlider.TabIndex = 27;
            speeddownSlider.Visible = false;
            // 
            // speeddownCheckBox
            // 
            speeddownCheckBox.AutoSize = true;
            speeddownCheckBox.Location = new System.Drawing.Point(10, 603);
            speeddownCheckBox.Name = "speeddownCheckBox";
            speeddownCheckBox.Size = new System.Drawing.Size(68, 19);
            speeddownCheckBox.TabIndex = 26;
            speeddownCheckBox.Text = "Yavaşlat";
            speeddownCheckBox.UseVisualStyleBackColor = true;
            speeddownCheckBox.CheckedChanged += speeddownCheckBox_CheckedChanged;
            // 
            // ConsumableForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(386, 660);
            Controls.Add(speeddownSlider);
            Controls.Add(speeddownCheckBox);
            Controls.Add(speedupSlider);
            Controls.Add(speedupCheckBox);
            Controls.Add(lengthSlider);
            Controls.Add(lengthCheckBox);
            Controls.Add(ekstraLabel);
            Controls.Add(backButton);
            Controls.Add(createButton);
            Controls.Add(pointBox);
            Controls.Add(pointLabel);
            Controls.Add(periodBox);
            Controls.Add(rateLabel);
            Controls.Add(lifetimeLabel);
            Controls.Add(lifetimeBox);
            Controls.Add(alphaLabel);
            Controls.Add(alphaTrackBar);
            Controls.Add(argbPanel);
            Controls.Add(blueLabel);
            Controls.Add(greenLabel);
            Controls.Add(redLabel);
            Controls.Add(blueTrackBar);
            Controls.Add(greenTrackBar);
            Controls.Add(redTrackBar);
            Controls.Add(descRichTextBox);
            Controls.Add(descLabel);
            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Name = "ConsumableForm";
            Text = "ConsumableForm";
            ((System.ComponentModel.ISupportInitialize)redTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)greenTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)blueTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)lengthSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)speedupSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)speeddownSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.RichTextBox descRichTextBox;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Panel argbPanel;
        private System.Windows.Forms.TrackBar alphaTrackBar;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.TextBox lifetimeBox;
        private System.Windows.Forms.Label lifetimeLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.TextBox periodBox;
        private System.Windows.Forms.TextBox pointBox;
        private System.Windows.Forms.Label pointLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label ekstraLabel;
        private System.Windows.Forms.CheckBox lengthCheckBox;
        private System.Windows.Forms.TrackBar lengthSlider;
        private System.Windows.Forms.TrackBar speedupSlider;
        private System.Windows.Forms.CheckBox speedupCheckBox;
        private System.Windows.Forms.TrackBar speeddownSlider;
        private System.Windows.Forms.CheckBox speeddownCheckBox;
    }
}