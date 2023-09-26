namespace StajProje2
{
    partial class MainMenuForm
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
            usernameBox = new System.Windows.Forms.TextBox();
            descLabel1 = new System.Windows.Forms.Label();
            levelPicture = new System.Windows.Forms.PictureBox();
            prevButton = new System.Windows.Forms.Button();
            nextButton = new System.Windows.Forms.Button();
            levelNameLabel = new System.Windows.Forms.Label();
            selectButton = new System.Windows.Forms.Button();
            adminButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)levelPicture).BeginInit();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            usernameBox.Location = new System.Drawing.Point(136, 26);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new System.Drawing.Size(148, 29);
            usernameBox.TabIndex = 0;
            usernameBox.KeyPress += usernameBox_KeyPress;
            // 
            // descLabel1
            // 
            descLabel1.AutoSize = true;
            descLabel1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            descLabel1.Location = new System.Drawing.Point(27, 26);
            descLabel1.Name = "descLabel1";
            descLabel1.Size = new System.Drawing.Size(103, 28);
            descLabel1.TabIndex = 1;
            descLabel1.Text = "Username:";
            // 
            // levelPicture
            // 
            levelPicture.Location = new System.Drawing.Point(254, 111);
            levelPicture.Name = "levelPicture";
            levelPicture.Size = new System.Drawing.Size(250, 250);
            levelPicture.TabIndex = 2;
            levelPicture.TabStop = false;
            // 
            // prevButton
            // 
            prevButton.Location = new System.Drawing.Point(108, 213);
            prevButton.Name = "prevButton";
            prevButton.Size = new System.Drawing.Size(85, 29);
            prevButton.TabIndex = 3;
            prevButton.Text = "Previous";
            prevButton.UseVisualStyleBackColor = true;
            prevButton.Click += prevButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new System.Drawing.Point(574, 222);
            nextButton.Name = "nextButton";
            nextButton.Size = new System.Drawing.Size(85, 29);
            nextButton.TabIndex = 4;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // levelNameLabel
            // 
            levelNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            levelNameLabel.AutoSize = true;
            levelNameLabel.Location = new System.Drawing.Point(353, 392);
            levelNameLabel.Name = "levelNameLabel";
            levelNameLabel.Size = new System.Drawing.Size(82, 15);
            levelNameLabel.TabIndex = 5;
            levelNameLabel.Text = "yourMaxLabel";
            levelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectButton
            // 
            selectButton.Location = new System.Drawing.Point(701, 406);
            selectButton.Name = "selectButton";
            selectButton.Size = new System.Drawing.Size(75, 23);
            selectButton.TabIndex = 6;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // adminButton
            // 
            adminButton.Location = new System.Drawing.Point(701, 12);
            adminButton.Name = "adminButton";
            adminButton.Size = new System.Drawing.Size(75, 23);
            adminButton.TabIndex = 7;
            adminButton.Text = "Admin";
            adminButton.UseVisualStyleBackColor = true;
            adminButton.Click += adminButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(adminButton);
            Controls.Add(selectButton);
            Controls.Add(levelNameLabel);
            Controls.Add(nextButton);
            Controls.Add(prevButton);
            Controls.Add(levelPicture);
            Controls.Add(descLabel1);
            Controls.Add(usernameBox);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ((System.ComponentModel.ISupportInitialize)levelPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label descLabel1;
        private System.Windows.Forms.PictureBox levelPicture;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label levelNameLabel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button adminButton;
    }
}