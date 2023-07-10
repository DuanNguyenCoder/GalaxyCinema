using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Galaxy.User_Controls;
using System.Windows.Forms;

namespace POS_Galaxy.Products_UI
{
    public partial class Drink : Form
    {
    private const string Price32 = "35000";
    private const string Price22 = "32000";

            drink_lon l = new drink_lon();
            drink_chai c = new drink_chai();
        public Drink()
        {
            InitializeComponent();
            l.TopLevel = false;
            c.TopLevel = false;
            this.Controls.Add(l);
            this.Controls.Add(c);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Form1._form1.panel_Dashboard.Controls.Remove(this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            l.SendToBack();
            c.SendToBack();
        }

        private void drink_uc9_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            l.Show();
           l.Location = guna2Panel2.Location;
            l.BringToFront();

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            c.Show();
            c.Location = guna2Panel2.Location;
            c.BringToFront();
        }

     // ly 22
        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2PictureBox pic = sender as Guna.UI2.WinForms.Guna2PictureBox;
            bill_item item = new bill_item(pic.Name.ToString(), Price22);
            if (pic.Name == "milo" )
            {
                item.Tag = 32;
            }
            else if(pic.Name == "nutri") 
            { 
                item.Tag = 33; 
            }
            else
            {
            item.Tag = 26;
            }
        }

        // ly 32
        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2PictureBox pic = sender as Guna.UI2.WinForms.Guna2PictureBox;
            bill_item item = new bill_item(pic.Name.ToString(), Price32);
            item.Tag = 5;
           
        }
    }
}
