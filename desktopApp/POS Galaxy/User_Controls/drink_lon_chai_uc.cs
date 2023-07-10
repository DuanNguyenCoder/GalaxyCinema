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
    public partial class drink_lon_chai_uc : UserControl
    {
        public drink_lon_chai_uc(int id,string _name, string _price, Image image)
        {
            InitializeComponent();
            this.Tag = id;
            name.Text = _name;
            price.Text = _price;
            guna2PictureBox1.Image = image;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            bill_item item = new bill_item(name.Text,price.Text);
            item.Tag = this.Tag;
            
        }
    }
}
