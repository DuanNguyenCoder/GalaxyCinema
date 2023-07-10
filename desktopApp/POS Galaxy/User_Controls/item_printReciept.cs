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
    public partial class item_printReciept : UserControl
    {
        public item_printReciept(string name, int sl, double price, double subtotal)
        {
            InitializeComponent();
            txtname.Text = name;
            txtquantity.Text = sl.ToString();
            txtprice.Text = String.Format("{0:0,0}", price);
            txtsubtotal.Text = String.Format("{0:0,0}", subtotal);

        }
        public item_printReciept(string name, int sl, string price, string subtotal,string _starhow, string _seat)
        {
            InitializeComponent();
            txtname.Text = name;
            txtquantity.Text = sl.ToString();
            txtprice.Text = price;
            txtsubtotal.Text = subtotal;
            seat.Text = _seat;
            starshow.Text = _starhow;
            seat.Show();
            starshow.Show();
        }
    }
}
