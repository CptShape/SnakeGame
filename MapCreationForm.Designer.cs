namespace StajProje2
{
    partial class MapCreationForm
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
            mapPanel = new System.Windows.Forms.Panel();
            nameBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            createButton = new System.Windows.Forms.Button();
            backButton = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            pictureLabel = new System.Windows.Forms.Label();
            clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // mapPanel
            // 
            mapPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            mapPanel.Location = new System.Drawing.Point(0, 0);
            mapPanel.Name = "mapPanel";
            mapPanel.Size = new System.Drawing.Size(600, 600);
            mapPanel.TabIndex = 0;
            mapPanel.MouseClick += mapPanel_MouseClick;
            // 
            // nameBox
            // 
            nameBox.Location = new System.Drawing.Point(782, 29);
            nameBox.Name = "nameBox";
            nameBox.Size = new System.Drawing.Size(100, 23);
            nameBox.TabIndex = 1;
            nameBox.KeyPress += nameBox_KeyPress;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(710, 32);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(29, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Isim";
            // 
            // createButton
            // 
            createButton.Location = new System.Drawing.Point(877, 533);
            createButton.Name = "createButton";
            createButton.Size = new System.Drawing.Size(75, 23);
            createButton.TabIndex = 3;
            createButton.Text = "Olustur";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new System.Drawing.Point(652, 533);
            backButton.Name = "backButton";
            backButton.Size = new System.Drawing.Size(75, 23);
            backButton.TabIndex = 4;
            backButton.Text = "Geri";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            pictureBox.Location = new System.Drawing.Point(652, 162);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(300, 300);
            pictureBox.TabIndex = 5;
            pictureBox.TabStop = false;
            pictureBox.DragDrop += pictureBox_DragDrop;
            pictureBox.DragEnter += pictureBox_DragEnter;
            // 
            // pictureLabel
            // 
            pictureLabel.AutoSize = true;
            pictureLabel.Location = new System.Drawing.Point(764, 135);
            pictureLabel.Name = "pictureLabel";
            pictureLabel.Size = new System.Drawing.Size(52, 15);
            pictureLabel.TabIndex = 6;
            pictureLabel.Text = "Fotoğraf";
            // 
            // clearButton
            // 
            clearButton.Location = new System.Drawing.Point(652, 131);
            clearButton.Name = "clearButton";
            clearButton.Size = new System.Drawing.Size(75, 23);
            clearButton.TabIndex = 7;
            clearButton.Text = "Temizle";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // MapCreationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(991, 601);
            Controls.Add(clearButton);
            Controls.Add(pictureLabel);
            Controls.Add(pictureBox);
            Controls.Add(backButton);
            Controls.Add(createButton);
            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Controls.Add(mapPanel);
            Name = "MapCreationForm";
            Text = "MapCreationForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label pictureLabel;
        private System.Windows.Forms.Button clearButton;
    }
}