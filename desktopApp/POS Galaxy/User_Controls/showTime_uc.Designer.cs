namespace POS_Galaxy.User_Controls
{
    partial class showTime_uc
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.screen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.showtime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.film = new System.Windows.Forms.Label();
            this.AgeLimited = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.endTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(169)))), ((int)(((byte)(22)))));
            this.guna2Panel1.Controls.Add(this.screen);
            this.guna2Panel1.Controls.Add(this.showtime);
            this.guna2Panel1.Controls.Add(this.film);
            this.guna2Panel1.Controls.Add(this.AgeLimited);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel7);
            this.guna2Panel1.Controls.Add(this.endTime);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(131, 85);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Click += new System.EventHandler(this.guna2Panel1_Click);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Transparent;
            this.screen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.screen.ForeColor = System.Drawing.Color.Black;
            this.screen.IsSelectionEnabled = false;
            this.screen.Location = new System.Drawing.Point(7, 59);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(37, 19);
            this.screen.TabIndex = 18;
            this.screen.Text = "RAP 4";
            // 
            // showtime
            // 
            this.showtime.BackColor = System.Drawing.Color.Transparent;
            this.showtime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.showtime.ForeColor = System.Drawing.Color.Red;
            this.showtime.IsSelectionEnabled = false;
            this.showtime.Location = new System.Drawing.Point(7, 34);
            this.showtime.Name = "showtime";
            this.showtime.Size = new System.Drawing.Size(32, 19);
            this.showtime.TabIndex = 15;
            this.showtime.Text = "19:00";
            // 
            // film
            // 
            this.film.AutoSize = true;
            this.film.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.film.ForeColor = System.Drawing.Color.Black;
            this.film.Location = new System.Drawing.Point(9, 3);
            this.film.MaximumSize = new System.Drawing.Size(150, 0);
            this.film.Name = "film";
            this.film.Size = new System.Drawing.Size(72, 21);
            this.film.TabIndex = 20;
            this.film.Text = "Avenger";
            // 
            // AgeLimited
            // 
            this.AgeLimited.BackColor = System.Drawing.Color.Transparent;
            this.AgeLimited.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AgeLimited.ForeColor = System.Drawing.Color.Black;
            this.AgeLimited.IsSelectionEnabled = false;
            this.AgeLimited.Location = new System.Drawing.Point(98, 5);
            this.AgeLimited.Name = "AgeLimited";
            this.AgeLimited.Size = new System.Drawing.Size(25, 19);
            this.AgeLimited.TabIndex = 19;
            this.AgeLimited.Text = "C16";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel7.IsSelectionEnabled = false;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(45, 34);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(8, 19);
            this.guna2HtmlLabel7.TabIndex = 17;
            this.guna2HtmlLabel7.Text = "-";
            // 
            // endTime
            // 
            this.endTime.BackColor = System.Drawing.Color.Transparent;
            this.endTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.endTime.ForeColor = System.Drawing.Color.Red;
            this.endTime.IsSelectionEnabled = false;
            this.endTime.Location = new System.Drawing.Point(57, 34);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(32, 19);
            this.endTime.TabIndex = 16;
            this.endTime.Text = "19:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // showTime_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(15)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "showTime_uc";
            this.Size = new System.Drawing.Size(131, 85);
            this.MouseLeave += new System.EventHandler(this.showTime_uc_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showTime_uc_MouseUp);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel screen;
        private Guna.UI2.WinForms.Guna2HtmlLabel showtime;
        private System.Windows.Forms.Label film;
        private Guna.UI2.WinForms.Guna2HtmlLabel AgeLimited;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel endTime;
        private System.Windows.Forms.Timer timer1;
    }
}
