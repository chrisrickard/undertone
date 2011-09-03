namespace UnderTone
{
    partial class Form1
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
            this.image = new System.Windows.Forms.PictureBox();
            this.chooseimage = new System.Windows.Forms.OpenFileDialog();
            this.GrabImage = new System.Windows.Forms.Button();
            this.Generate = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image.Location = new System.Drawing.Point(12, 12);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(190, 146);
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // GrabImage
            // 
            this.GrabImage.Location = new System.Drawing.Point(228, 12);
            this.GrabImage.Name = "GrabImage";
            this.GrabImage.Size = new System.Drawing.Size(143, 31);
            this.GrabImage.TabIndex = 1;
            this.GrabImage.Text = "Grab Image...";
            this.GrabImage.UseVisualStyleBackColor = true;
            this.GrabImage.Click += new System.EventHandler(this.GrabImage_Click);
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(228, 49);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(143, 32);
            this.Generate.TabIndex = 2;
            this.Generate.Text = "Generate UnderTone File";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.AcceptsTab = true;
            this.output.Location = new System.Drawing.Point(12, 164);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(505, 144);
            this.output.TabIndex = 3;
            this.output.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 318);
            this.Controls.Add(this.output);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.GrabImage);
            this.Controls.Add(this.image);
            this.Name = "Form1";
            this.Text = "UnderTone";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.OpenFileDialog chooseimage;
        private System.Windows.Forms.Button GrabImage;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox output;
    }
}

