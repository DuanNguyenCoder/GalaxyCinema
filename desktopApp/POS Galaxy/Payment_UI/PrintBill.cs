using POS_Galaxy.User_Controls;
using System;
using System.Windows.Forms;
using POS_Galaxy.Products_UI;


namespace POS_Galaxy.Payment_UI
{
    public partial class PrintBill : Form
    {
        public PrintBill()
        {
            InitializeComponent();
        }

        private void PrintBill_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1._form1.bill_panel.Controls.Count; i++)
            {

                if (Form1._form1.bill_panel.Controls[i] is bill_item)
                {
                bill_item a;
                a = (bill_item)Form1._form1.bill_panel.Controls[i];
                string name = a.b_name;
                int quantity = a.b_quantity;

                //subtotal += a.price ;
                double gianiemyet = (double.Parse(a.gianiemyet.ToString()) * quantity) / quantity;

                
                this.Height += 47;
                 item_printReciept itemPrint = new item_printReciept(name, quantity, gianiemyet, (double)a.gianiemyet * quantity);
                flowLayoutPanel1.Controls.Add(itemPrint);

                }
                if (Form1._form1.bill_panel.Controls[i] is ticket_Item)
                {
                    ticket_Item a;
                    a = (ticket_Item)Form1._form1.bill_panel.Controls[i];
                    string name = a.filmName;
                    int quantity = 1;
                    double gianiemyet = double.Parse( a.fimlPrice);
                    this.Height += 47;
                    item_printReciept itemPrint = new item_printReciept(name, quantity, gianiemyet +",000",( gianiemyet * quantity).ToString() + ",000",a.filmName,a.seatLabel.Text.ToString());
                    flowLayoutPanel1.Controls.Add(itemPrint);
                }

            }
            //this.Height += 47*3;
            //item_printReciept b = new item_printReciept("Combo2 Big", 1, 92000, 92000);
            //item_printReciept b1 = new item_printReciept("Kitkat", 2, 32000, 64000);
            //item_printReciept b2 = new item_printReciept("Avenger", 1, 80000, 80000);
            //flowLayoutPanel1.Controls.Add(b);
            //flowLayoutPanel1.Controls.Add(b1);
            //flowLayoutPanel1.Controls.Add(b2);

            // hien thi thong ti co ban trong bill
            if (Form1._form1.nameGuestService != null)
            {
            label_gs.Text = Form1._form1.nameGuestService;

            }
            label_date.Text = DateTime.Now.ToString();
            txttotal.Text = Form1._form1.label_total.Text;
            if (label_cus.Text != string.Empty)
            {
               ////
            }
            else
            {
                label_cus.Text = "custommer";
            }
            id_hd.Text = "HD" + Pay._pay.idHoaDon;
        }
    }
}
