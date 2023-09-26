
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
            loseLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            scoreValueLabel = new System.Windows.Forms.Label();
            scoreLabel = new System.Windows.Forms.Label();
            timer = new System.Windows.Forms.Timer(components);
            scoreLimitTextBox = new System.Windows.Forms.TextBox();
            descLabel = new System.Windows.Forms.Label();
            descLabel2 = new System.Windows.Forms.Label();
            descLabel3 = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            maxScoreLabel = new System.Windows.Forms.Label();
            consumableTimer = new System.Windows.Forms.Timer(components);
            gamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BackColor = System.Drawing.Color.White;
            gamePanel.Controls.Add(loseLabel);
            gamePanel.Location = new System.Drawing.Point(10, 11);
            gamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new System.Drawing.Size(600, 600);
            gamePanel.TabIndex = 0;
            // 
            // loseLabel
            // 
            loseLabel.AutoSize = true;
            loseLabel.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            loseLabel.ForeColor = System.Drawing.Color.White;
            loseLabel.Location = new System.Drawing.Point(118, 33);
            loseLabel.Name = "loseLabel";
            loseLabel.Size = new System.Drawing.Size(339, 72);
            loseLabel.TabIndex = 4;
            loseLabel.Text = "KAYBETTİN!";
            loseLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.White;
            label3.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.SystemColors.ControlText;
            label3.Location = new System.Drawing.Point(636, 565);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(118, 46);
            label3.TabIndex = 3;
            label3.Text = "BAŞLA";
            label3.Click += Start_Click;
            // 
            // scoreValueLabel
            // 
            scoreValueLabel.AutoSize = true;
            scoreValueLabel.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            scoreValueLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            scoreValueLabel.Location = new System.Drawing.Point(750, 106);
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
            scoreLabel.Location = new System.Drawing.Point(636, 106);
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
            // descLabel2
            // 
            descLabel2.AutoSize = true;
            descLabel2.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            descLabel2.ForeColor = System.Drawing.SystemColors.Desktop;
            descLabel2.Location = new System.Drawing.Point(774, 509);
            descLabel2.Name = "descLabel2";
            descLabel2.Size = new System.Drawing.Size(110, 31);
            descLabel2.TabIndex = 6;
            descLabel2.Text = "Skor limit";
            // 
            // descLabel3
            // 
            descLabel3.AutoSize = true;
            descLabel3.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            descLabel3.ForeColor = System.Drawing.SystemColors.Desktop;
            descLabel3.Location = new System.Drawing.Point(636, 172);
            descLabel3.Name = "descLabel3";
            descLabel3.Size = new System.Drawing.Size(188, 31);
            descLabel3.TabIndex = 7;
            descLabel3.Text = "(Elma = 50 puan)";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            usernameLabel.Location = new System.Drawing.Point(626, 11);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(65, 28);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "label1";
            // 
            // maxScoreLabel
            // 
            maxScoreLabel.AutoSize = true;
            maxScoreLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            maxScoreLabel.Location = new System.Drawing.Point(626, 44);
            maxScoreLabel.Name = "maxScoreLabel";
            maxScoreLabel.Size = new System.Drawing.Size(65, 28);
            maxScoreLabel.TabIndex = 9;
            maxScoreLabel.Text = "label1";
            // 
            // consumableTimer
            // 
            consumableTimer.Interval = 1000;
            consumableTimer.Tick += Consumable_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new System.Drawing.Size(906, 652);
            Controls.Add(maxScoreLabel);
            Controls.Add(usernameLabel);
            Controls.Add(descLabel3);
            Controls.Add(descLabel2);
            Controls.Add(descLabel);
            Controls.Add(scoreLimitTextBox);
            Controls.Add(gamePanel);
            Controls.Add(scoreValueLabel);
            Controls.Add(label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label loseLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox scoreLimitTextBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label descLabel2;
        private System.Windows.Forms.Label descLabel3;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label maxScoreLabel;
        private System.Windows.Forms.Timer consumableTimer;
    }
}
