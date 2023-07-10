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
    public partial class ticket_Item : UserControl
    {
       public string filmName;
       public string fimlPrice;
        public string showTime;
        public string endTime;
        public string screen;
        public string TypeTicket;
        public string voucher;
        public static ticket_Item _ticket_Item;
        public Guna.UI2.WinForms.Guna2HtmlLabel seatLabel
        {
            get
            {
                return seat;
            }
        }
        public ticket_Item(object[] ob)
        {
            filmName = (string)ob[0];
            fimlPrice = (string)ob[1];
            screen = (string)ob[2];
            showTime = (string)ob[3];
            endTime = (string)ob[4];
            TypeTicket = (string)ob[5];
            InitializeComponent();
            name_item.Text = filmName;
            price_item.Text = fimlPrice;
            showTime_item.Text = showTime;
            endTime_item.Text = endTime;
            screen_item.Text = screen;
            type_item.Text = TypeTicket;
            _ticket_Item = this;

            //   tinh lai tong tien tren hoa don

           decimal old = decimal.Parse( Form1._form1.label_total.Text.Replace(',', '.'));
            decimal New = old + decimal.Parse(fimlPrice);

            Form1._form1.label_total.Text = String.Format("{0:0,0}" + ",000", New);
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form1._form1.bill_panel.Controls.Remove(this);

            decimal old = decimal.Parse(Form1._form1.label_total.Text.Replace(',', '.'));
            decimal New = old - decimal.Parse(fimlPrice);
            Form1._form1.label_total.Text = String.Format("{0:0,0}" + ",000", New);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
