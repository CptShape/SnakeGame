namespace StajProje2
{
    partial class AdminForm
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
            mapButton = new System.Windows.Forms.Button();
            consumableButton = new System.Windows.Forms.Button();
            exitButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // mapButton
            // 
            mapButton.Location = new System.Drawing.Point(35, 30);
            mapButton.Name = "mapButton";
            mapButton.Size = new System.Drawing.Size(137, 33);
            mapButton.TabIndex = 0;
            mapButton.Text = "Create Map";
            mapButton.UseVisualStyleBackColor = true;
            mapButton.Click += mapButton_Click;
            // 
            // consumableButton
            // 
            consumableButton.Location = new System.Drawing.Point(35, 95);
            consumableButton.Name = "consumableButton";
            consumableButton.Size = new System.Drawing.Size(137, 33);
            consumableButton.TabIndex = 1;
            consumableButton.Text = "Create Consumable";
            consumableButton.UseVisualStyleBackColor = true;
            consumableButton.Click += consumableButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(35, 257);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(137, 33);
            exitButton.TabIndex = 2;
            exitButton.Text = "Geri";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(212, 372);
            Controls.Add(exitButton);
            Controls.Add(consumableButton);
            Controls.Add(mapButton);
            Name = "AdminForm";
            Text = "AdminForm";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.Button consumableButton;
        private System.Windows.Forms.Button exitButton;
    }
}