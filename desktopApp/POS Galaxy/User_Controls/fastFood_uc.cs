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
    public partial class fastFood_uc : UserControl
    {
        public fastFood_uc(int id , string name, Image _img, string price)
        {
            InitializeComponent();
            this.Tag = id;
            image.Image = _img;
            namelb.Text = name;
            pricelb.Text = string.Format("{0:0,0}", price);
        }

        private void image_Click(object sender, EventArgs e)
        {
            bill_item item = new bill_item(namelb.Text, pricelb.Text);
            item.Tag = this.Tag;
        }
    }
}
