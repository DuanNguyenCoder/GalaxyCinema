using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Galaxy.Products_UI;

namespace POS_Galaxy.User_Controls
{
    public partial class bill_item : UserControl
    {
      public  decimal gianiemyet;
        public string b_name;
        public int b_quantity;
     public Guna.UI2.WinForms.Guna2NumericUpDown numericUpDown
        {
            get { return guna2NumericUpDown1; }
        }
        public bill_item(string _name, string _price)
        {
            // kiem tra xem san pham da co trong bill chua
            if (!check(_name, _price))
            {
                return;
            }
            InitializeComponent();
            gianiemyet = decimal.Parse(_price);
            b_name = _name;
            name.Text = _name;
            b_quantity = (int)guna2NumericUpDown1.Value;
            price.Text = String.Format("{0:0,0}", decimal.Parse(_price));
            Form1._form1.bill_panel.Controls.Add(this);
          
        }
        private bool check(string _name, string _price)
        {
            foreach (var item in Form1._form1.bill_panel.Controls)
            {
                if (item is bill_item)
                {
                    bill_item bill = item as bill_item;
                    if (bill.b_name == _name && bill.numericUpDown.Visible == true)
                    {
                        bill.numericUpDown.Value++;
                        return false;
                    }
                }
                
            }
            return true;
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form1._form1.bill_panel.Controls.Remove(this);
            Form1._form1.label_total.Text = String.Format("{0:0,0}", (decimal.Parse(Form1._form1.label_total.Text.ToString()) - decimal.Parse(this.price.Text.ToString())));

            if (this.Tag is detailCombo)
            {
                Form1._form1.bill_panel_parent.Controls.Remove(this.Tag as detailCombo);
            }
            try
            {
                foreach (var item in Form1._form1.panel_Dashboard.Controls)
                {
                    if (item is selectPopcorn)
                    {
                        selectPopcorn select = item as selectPopcorn;
                        if (select.Visible)
                        {
                            Form1._form1.panel_Dashboard.Controls.Remove(select);
                        }
                    }
                }

            if ( ComboPopcorn.popcorn.detail2.Visible)
               {
                Form1._form1.bill_panel_parent.Controls.Remove(ComboPopcorn.popcorn.detail2);
            }

            }
            catch (Exception)
            {

               
            }



        }
        //String.Format("{0:0,0}", total1);
        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (guna2NumericUpDown1.Value == 1)
            {
                price.Text =  gianiemyet.ToString();
            }
            b_quantity = (int)guna2NumericUpDown1.Value;
            decimal total = guna2NumericUpDown1.Value * gianiemyet;
            price.Text = String.Format("{0:0,0}", total);
            decimal totalBill = 0;
            foreach (var item in Form1._form1.bill_panel.Controls)
            {
                if (item is bill_item)
                {
                    bill_item bill = item as bill_item;
                totalBill += decimal.Parse( bill.price.Text);

                }
                if (item is ticket_Item)
                {
                    ticket_Item bill = item as ticket_Item;
                    totalBill += decimal.Parse(bill.fimlPrice.Replace('.',','));

                }

            }
            Form1._form1.label_total.Text = String.Format("{0:0,0}", totalBill);
        }

        private void bill_item_Load(object sender, EventArgs e)
        {
            total();
        }
        private void total()
        {
            decimal totalBill = Convert.ToDecimal(Form1._form1.label_total.Text);
            Form1._form1.label_total.Text = String.Format("{0:0,0}", (totalBill + decimal.Parse(price.Text)));

        }
    }
}
