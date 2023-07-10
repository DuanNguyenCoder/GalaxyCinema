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
    public partial class voucher_uc : UserControl
    {
        public voucher_uc(int id, string _name, Image img, string _gia)
        {
            InitializeComponent();
            this.Tag = id;
            name.Text = _name;
            price.Text = _gia.ToString();
            guna2PictureBox1.Image = img;
        }

    private void guna2PictureBox1_Click(object sender, EventArgs e)
    {
        bill_item item = new bill_item(name.Text, price.Text);
        item.Tag = this.Tag;

    }
}
}
