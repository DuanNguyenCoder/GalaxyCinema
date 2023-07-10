namespace POS_Galaxy.User_Controls
{
    partial class fastFood_uc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fastFood_uc));
            this.namelb = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pricelb = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // namelb
            // 
            this.namelb.BackColor = System.Drawing.Color.Transparent;
            this.namelb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.namelb.Location = new System.Drawing.Point(3, 102);
            this.namelb.Name = "namelb";
            this.namelb.Size = new System.Drawing.Size(73, 23);
            this.namelb.TabIndex = 4;
            this.namelb.Text = "Khoai Tây";
            // 
            // pricelb
            // 
            this.pricelb.BackColor = System.Drawing.Color.Transparent;
            this.pricelb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pricelb.Location = new System.Drawing.Point(13, 131);
            this.pricelb.Name = "pricelb";
            this.pricelb.Size = new System.Drawing.Size(52, 23);
            this.pricelb.TabIndex = 5;
            this.pricelb.Text = "35.000";
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(0, 3);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(104, 93);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 6;
            this.image.TabStop = false;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // fastFood_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.image);
            this.Controls.Add(this.namelb);
            this.Controls.Add(this.pricelb);
            this.Name = "fastFood_uc";
            this.Size = new System.Drawing.Size(110, 167);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2HtmlLabel namelb;
        private Guna.UI2.WinForms.Guna2HtmlLabel pricelb;
    }
}
