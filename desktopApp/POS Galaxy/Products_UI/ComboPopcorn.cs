using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Galaxy.User_Controls;
using Guna.UI2.WinForms;

namespace POS_Galaxy.Products_UI
{
    public partial class ComboPopcorn : Form
    {
        combo_nestle nes = new combo_nestle();
        combo_famlily fa = new combo_famlily();
        public  selectPopcorn detail;
        public   detailCombo detail2;
        public static ComboPopcorn popcorn;
        
        private void setData()
        {
            guna2Button1.Tag = new object[] { "combo1 small", "76000",1,1,0,0 };
            guna2Button2.Tag = new object[] { "combo1 small mix", "76000",1,1,0,0 };
            guna2Button3.Tag = new object[] { "combo2 small", "89000",1,2,0,0 };
            guna2Button4.Tag = new object[] { "combo2 small mix", "89000",1,2,0,0 };
            guna2Button5.Tag = new object[] { "combo1 big", "79000",1,1,0,0 };
            guna2Button6.Tag = new object[] { "combo1 big mix", "79000",1,1,0,0 };
            guna2Button7.Tag = new object[] { "combo2 big", "92000" ,1,2,0,0};
            guna2Button8.Tag = new object[] { "combo2 big mix", "92000",1,2,0,0 };
        }
        public ComboPopcorn()
        { 
            InitializeComponent();
            this.DoubleBuffered = true;
            panel_pepsi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            setData();
        }
        private void ComboPopcorn_Load(object sender, EventArgs e)
        {
            nes.Hide();
            fa.Hide();
            guna2Panel1.Controls.Add(nes);
            guna2Panel1.Controls.Add(fa);
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            Form1._form1.panel_Dashboard.Controls.Remove(this);
        }
        // pepsi
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            panel_pepsi.Show();
            fa.Hide();
            nes.Hide();
            panel_pepsi.Location = new Point(32, 86);
        }
        // nestle
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            panel_pepsi.Hide();
            fa.Hide();
            nes.Show();
            nes.Location = new Point(32, 86);
        }
        //family
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            panel_pepsi.Hide();
            fa.Show();
            nes.Hide();
            fa.Location = new Point(32, 86);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            object[] ob = button.Tag as object[];
            bill_item item = new bill_item(ob[0].ToString(),ob[1].ToString());
            item.numericUpDown.Hide();
            item.Show();
            Form1._form1.bill_panel.Controls.Add(item);

            // bap - nuoc
            

            detail = new selectPopcorn((int)ob[2],(int)ob[3],(int)ob[4],(int)ob[5],selectPopcorn.TypeDrink.lygiay,ob[0].ToString());
            detail.Show();
            detail.TopLevel = false;
            Form1._form1.panel_Dashboard.Controls.Add(detail);
            detail.BringToFront();
            detail.Location = new Point(300, 100);

            // chon the tag cho san pham la 5 neu la ly lon va 26 la ly nho

            if (ob[0].ToString().Contains("big"))
            {
                detail.Tag = 5;
            }
            else
            {
                detail.Tag = 26;
            }

            //////////////////////////////////////
            
            detail2 = new detailCombo((int)ob[2], (int)ob[3], (int)ob[4], (int)ob[5]);
            detail2.nameCombo = (string)ob[0];
            detail2.Show();
            detail2.TopLevel = false;
            Form1._form1.bill_panel_parent.Controls.Add(detail2);
            detail2.BringToFront();
            detail2.Location = new Point(20, item.Location.Y + 60);

            item.Tag = detail2;
            popcorn = this;
        }
    }
}
