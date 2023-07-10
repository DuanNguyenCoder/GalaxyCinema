namespace POS_Galaxy.User_Controls
{
    partial class item_printReciept
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
            this.txtsubtotal = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.Label();
            this.starshow = new System.Windows.Forms.Label();
            this.seat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.AutoSize = true;
            this.txtsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtsubtotal.Location = new System.Drawing.Point(347, 5);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(60, 17);
            this.txtsubtotal.TabIndex = 34;
            this.txtsubtotal.Text = "100.000";
            // 
            // txtprice
            // 
            this.txtprice.AutoSize = true;
            this.txtprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtprice.Location = new System.Drawing.Point(240, 5);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(60, 17);
            this.txtprice.TabIndex = 33;
            this.txtprice.Text = "100.000";
            // 
            // txtquantity
            // 
            this.txtquantity.AutoSize = true;
            this.txtquantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtquantity.Location = new System.Drawing.Point(159, 5);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(16, 17);
            this.txtquantity.TabIndex = 32;
            this.txtquantity.Text = "1";
            // 
            // txtname
            // 
            this.txtname.AutoSize = true;
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtname.Location = new System.Drawing.Point(2, 5);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(60, 17);
            this.txtname.TabIndex = 31;
            this.txtname.Text = "Combo1";
            // 
            // starshow
            // 
            this.starshow.AutoSize = true;
            this.starshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.starshow.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.starshow.Location = new System.Drawing.Point(3, 25);
            this.starshow.Name = "starshow";
            this.starshow.Size = new System.Drawing.Size(56, 15);
            this.starshow.TabIndex = 35;
            this.starshow.Text = "starshow";
            this.starshow.Visible = false;
            // 
            // seat
            // 
            this.seat.AutoSize = true;
            this.seat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.seat.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.seat.Location = new System.Drawing.Point(77, 25);
            this.seat.Name = "seat";
            this.seat.Size = new System.Drawing.Size(30, 15);
            this.seat.TabIndex = 36;
            this.seat.Text = "seat";
            this.seat.Visible = false;
            // 
            // item_printReciept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.seat);
            this.Controls.Add(this.starshow);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.txtname);
            this.Name = "item_printReciept";
            this.Size = new System.Drawing.Size(488, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtsubtotal;
        private System.Windows.Forms.Label txtprice;
        private System.Windows.Forms.Label txtquantity;
        private System.Windows.Forms.Label txtname;
        private System.Windows.Forms.Label starshow;
        private System.Windows.Forms.Label seat;
    }
}
