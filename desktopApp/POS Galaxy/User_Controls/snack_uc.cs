using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Galaxy.User_Controls
{
    public partial class snack_uc : UserControl
    {
        public snack_uc(int id , string name, string price, Image image)
        {
            InitializeComponent();
            txtname.Text = name; ;
            txtprice.Text = price;
            guna2PictureBox1.Image = image;
            this.Tag = id;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            bill_item item = new bill_item(txtname.Text, txtprice.Text);
            item.Tag = this.Tag;
        }
    }
}
