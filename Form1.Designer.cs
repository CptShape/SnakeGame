
namespace StajProje2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gamePanel = new System.Windows.Forms.Panel();
            resultLabel = new System.Windows.Forms.Label();
            startLabel = new System.Windows.Forms.Label();
            scoreValueLabel = new System.Windows.Forms.Label();
            scoreLabel = new System.Windows.Forms.Label();
            timer = new System.Windows.Forms.Timer(components);
            scoreLimitTextBox = new System.Windows.Forms.TextBox();
            descLabel = new System.Windows.Forms.Label();
            skorlimitLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            maxScoreLabel = new System.Windows.Forms.Label();
            consumableTimer = new System.Windows.Forms.Timer(components);
            yourMaxLabel = new System.Windows.Forms.Label();
            consumablesLabel = new System.Windows.Forms.Label();
            scoreTableLabel = new System.Windows.Forms.Label();
            backLabel = new System.Windows.Forms.Label();
            gamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BackColor = System.Drawing.Color.White;
            gamePanel.Controls.Add(resultLabel);
            gamePanel.Location = new System.Drawing.Point(10, 11);
            gamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new System.Drawing.Size(600, 600);
            gamePanel.TabIndex = 0;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            resultLabel.ForeColor = System.Drawing.Color.White;
            resultLabel.Location = new System.Drawing.Point(118, 33);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new System.Drawing.Size(339, 72);
            resultLabel.TabIndex = 4;
            resultLabel.Text = "KAYBETTİN!";
            resultLabel.Visible = false;
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.BackColor = System.Drawing.Color.White;
            startLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            startLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            startLabel.Location = new System.Drawing.Point(636, 565);
            startLabel.Name = "startLabel";
            startLabel.Size = new System.Drawing.Size(118, 46);
            startLabel.TabIndex = 3;
            startLabel.Text = "BAŞLA";
            startLabel.Click += Start_Click;
            // 
            // scoreValueLabel
            // 
            scoreValueLabel.AutoSize = true;
            scoreValueLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            scoreValueLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            scoreValueLabel.Location = new System.Drawing.Point(740, 106);
            scoreValueLabel.Name = "scoreValueLabel";
            scoreValueLabel.Size = new System.Drawing.Size(38, 46);
            scoreValueLabel.TabIndex = 2;
            scoreValueLabel.Text = "0";
            scoreValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            scoreLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            scoreLabel.Location = new System.Drawing.Point(626, 107);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new System.Drawing.Size(108, 46);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "PUAN";
            // 
            // timer
            // 
            timer.Tick += Timer_Tick;
            // 
            // scoreLimitTextBox
            // 
            scoreLimitTextBox.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            scoreLimitTextBox.Location = new System.Drawing.Point(636, 509);
            scoreLimitTextBox.Name = "scoreLimitTextBox";
            scoreLimitTextBox.Size = new System.Drawing.Size(118, 38);
            scoreLimitTextBox.TabIndex = 4;
            scoreLimitTextBox.KeyPress += scoreLimit_KeyPress;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            descLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            descLabel.Location = new System.Drawing.Point(636, 462);
            descLabel.Name = "descLabel";
            descLabel.Size = new System.Drawing.Size(228, 31);
            descLabel.TabIndex = 5;
            descLabel.Text = "(Sonsuz için 0 giriniz)";
            // 
            // skorlimitLabel
            // 
            skorlimitLabel.AutoSize = true;
            skorlimitLabel.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            skorlimitLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            skorlimitLabel.Location = new System.Drawing.Point(774, 509);
            skorlimitLabel.Name = "skorlimitLabel";
            skorlimitLabel.Size = new System.Drawing.Size(110, 31);
            skorlimitLabel.TabIndex = 6;
            skorlimitLabel.Text = "Skor limit";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            usernameLabel.Location = new System.Drawing.Point(626, 11);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(99, 28);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Username";
            // 
            // maxScoreLabel
            // 
            maxScoreLabel.AutoSize = true;
            maxScoreLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            maxScoreLabel.Location = new System.Drawing.Point(626, 44);
            maxScoreLabel.Name = "maxScoreLabel";
            maxScoreLabel.Size = new System.Drawing.Size(23, 28);
            maxScoreLabel.TabIndex = 9;
            maxScoreLabel.Text = "0";
            // 
            // consumableTimer
            // 
            consumableTimer.Interval = 1000;
            consumableTimer.Tick += Consumable_Tick;
            // 
            // yourMaxLabel
            // 
            yourMaxLabel.AutoSize = true;
            yourMaxLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            yourMaxLabel.Location = new System.Drawing.Point(626, 78);
            yourMaxLabel.Name = "yourMaxLabel";
            yourMaxLabel.Size = new System.Drawing.Size(23, 28);
            yourMaxLabel.TabIndex = 10;
            yourMaxLabel.Text = "0";
            // 
            // consumablesLabel
            // 
            consumablesLabel.AutoSize = true;
            consumablesLabel.BackColor = System.Drawing.Color.White;
            consumablesLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            consumablesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            consumablesLabel.Location = new System.Drawing.Point(653, 302);
            consumablesLabel.Name = "consumablesLabel";
            consumablesLabel.Size = new System.Drawing.Size(70, 28);
            consumablesLabel.TabIndex = 14;
            consumablesLabel.Text = "Yemler";
            consumablesLabel.Click += consumablesButton_Click;
            // 
            // scoreTableLabel
            // 
            scoreTableLabel.AutoSize = true;
            scoreTableLabel.BackColor = System.Drawing.Color.White;
            scoreTableLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            scoreTableLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            scoreTableLabel.Location = new System.Drawing.Point(761, 302);
            scoreTableLabel.Name = "scoreTableLabel";
            scoreTableLabel.Size = new System.Drawing.Size(123, 28);
            scoreTableLabel.TabIndex = 15;
            scoreTableLabel.Text = "Skor Tablosu";
            scoreTableLabel.Click += scoreTableButton_Click;
            // 
            // backLabel
            // 
            backLabel.AutoSize = true;
            backLabel.BackColor = System.Drawing.Color.White;
            backLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            backLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            backLabel.Location = new System.Drawing.Point(795, 565);
            backLabel.Name = "backLabel";
            backLabel.Size = new System.Drawing.Size(89, 46);
            backLabel.TabIndex = 16;
            backLabel.Text = "GERI";
            backLabel.Click += backButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new System.Drawing.Size(906, 652);
            Controls.Add(backLabel);
            Controls.Add(scoreTableLabel);
            Controls.Add(consumablesLabel);
            Controls.Add(yourMaxLabel);
            Controls.Add(maxScoreLabel);
            Controls.Add(usernameLabel);
            Controls.Add(skorlimitLabel);
            Controls.Add(descLabel);
            Controls.Add(scoreLimitTextBox);
            Controls.Add(gamePanel);
            Controls.Add(scoreValueLabel);
            Controls.Add(startLabel);
            Controls.Add(scoreLabel);
            ForeColor = System.Drawing.SystemColors.HighlightText;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyDown_Reader;
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreValueLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox scoreLimitTextBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label skorlimitLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label maxScoreLabel;
        private System.Windows.Forms.Timer consumableTimer;
        private System.Windows.Forms.Label yourMaxLabel;
        private System.Windows.Forms.Label consumablesLabel;
        private System.Windows.Forms.Label scoreTableLabel;
        private System.Windows.Forms.Label backLabel;
    }
}
