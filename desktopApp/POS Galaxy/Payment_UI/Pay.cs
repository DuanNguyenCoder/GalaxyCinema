using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS_Galaxy.Payment_UI;
using POS_Galaxy.Products_UI;
using POS_Galaxy.User_Controls;

namespace POS_Galaxy
{
    public partial class Pay : Form
    {
        POS_galaxyDataSetTableAdapters.InvoiceTableAdapter invoice = new POS_galaxyDataSetTableAdapters.InvoiceTableAdapter();
        POS_galaxyDataSetTableAdapters.orderFilmTableAdapter orderFilm = new POS_galaxyDataSetTableAdapters.orderFilmTableAdapter();
        POS_galaxyDataSetTableAdapters.OrdersTableAdapter order = new POS_galaxyDataSetTableAdapters.OrdersTableAdapter();
        POS_galaxyDataSetTableAdapters.ProductTableAdapter PRO = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
       
        string Total;
       public int idHoaDon;
        public Pay(string total)
        {
            InitializeComponent();
            Total = total;
            totalbill.Text = Total;
        }
        public static Pay _pay;
        private void guna2Button4_Click(object sender, EventArgs e)
        {
           Guna2CircleButton guna = sender as Guna2CircleButton;
            if (sender is Guna2Button)
            {
                Guna2Button guna2 = sender as Guna2Button;
                input.Text += guna2.Text;
                return;
            }
            if (guna.Text == "AC")
            {
                input.Text = "";
            }
            else
            {
            input.Text += guna.Text;

            }

        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (input.Text=="")
            {
                change.Text = "0";
                return;
            }else if(decimal.Parse(input.Text) < decimal.Parse(totalbill.Text)) { change.Text = "0"; return; }

            else
            {
            change.Text = "= " + (decimal.Parse(input.Text) - decimal.Parse(totalbill.Text)).ToString();

            }
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            Guna2Panel pan = btn.Parent as Guna2Panel;
            foreach (var item in guna2Panel1.Controls)
            {
                if (item is Guna2Panel)
                {
                    Guna2Panel pan2 = item as Guna2Panel;
                    pan2.ShadowDecoration.Enabled = false;
                }
            }
            pan.ShadowDecoration.Enabled = true;
            if (panelmomo.ShadowDecoration.Enabled) { momopay pay = new momopay(Total);  this.Controls.Add(pay); pay.Location = new Point( panelcash.Location.X - 30,panelcash.Location.Y + 10); pay.BringToFront(); }
        }

        private void reset()
        {
           Form1._form1.bill_panel.Controls.Clear();
            List<detailCombo> list = new List<detailCombo>();
            foreach (var item in Form1._form1.bill_panel_parent.Controls)
            {
                if (item is detailCombo)
                {
                    list.Add((detailCombo)item);
                }
            }
            foreach (var item in list)
            {
                Form1._form1.bill_panel_parent.Controls.Remove(item);
            }
            Form1._form1.label_total.Text = "00";
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            _pay = this;
            if (panelmomo.ShadowDecoration.Enabled) // 1
            {
                payment(1);
               

            }
            if (panelsacom.ShadowDecoration.Enabled) // 2
            {
                payment(2);

            }
            if (panelcash.ShadowDecoration.Enabled) // 3
            {
                payment(3);

            }

            PrintBill print = new PrintBill();
            print.Show();
                reset();
            this.Hide();
        }

        private void payment(int typeOfpay)
        {
            //int countCO = 0;
            //int countBO = 0;
            //int combo = 0;

            /// create bill

            invoice.InsertQuery(DateTime.Now, null, 7, 0, decimal.Parse(Total), null, null, typeOfpay, null);
            int idInvoice = (int)invoice.getIDinvoice();
            idHoaDon = idInvoice;



            // duyet lay cac san pham thuong va ve
            foreach (var item in Form1._form1.bill_panel.Controls)
            {
                /////////// lay ve
                if (item is ticket_Item)
                {
                    ticket_Item ticketItem = item as ticket_Item;
                    if (ticketItem.voucher != null)
                    {
                     orderFilm.Insert((int)ticketItem.Tag, ticketItem.voucher, ticketItem.seatLabel.Text, ticketItem.TypeTicket, idHoaDon);

                    }
                    else
                    {
                       orderFilm.Insert((int)ticketItem.Tag, null , ticketItem.seatLabel.Text, ticketItem.TypeTicket, idHoaDon);
                    }
                 //   int idOrderFilm = (int)orderFilm.getIdOrderFilm();
                //    invoice.UpdateQuery2(idOrderFilm, idInvoice);

                    // countBO++;
                }
                ///////////////// lay cac san pham thuong
                if (item is bill_item)
                {
                    bill_item billItem = item as bill_item;
                    if (billItem.numericUpDown.Visible)
                    {
                        order.Insert((int)billItem.Tag, idInvoice, billItem.numericUpDown.Value, null);
                      
                        int newSL = (int)PRO.getSL((int)billItem.Tag) - (int)billItem.numericUpDown.Value;
                        PRO.updateSL(newSL, (int)billItem.Tag);

                   // countCO++;

                    }

                }
            }


            /// duyet lay cac bang chi tiet combo
            foreach (var item in Form1._form1.bill_panel_parent.Controls)
            {  string nameCombo = "";
                List<string> product = new List<string>();
                if (item is detailCombo)
                {
                    detailCombo de = item as detailCombo;
                    ///// duyet lay cac thanh phan chi tiet combo - cac panel - moi pan chua 1 label
                    foreach (var de2 in de.Controls)
                    {
                        if (de2 is Guna2HtmlLabel) { Guna2HtmlLabel la = de2 as Guna2HtmlLabel; nameCombo = la.Text;  }
                 
                        if (de2 is Guna2Panel)
                        {
                            Guna2Panel pan3 = de2 as Guna2Panel;
                            Label label = (Label)pan3.Controls[0];
                            if (label.Tag != null)
                            {
                                product.Add( nameCombo + "_" + label.Text + "_" + label.Tag.ToString());

                            }

                            else { product.Add(label.Text); }
                        }
                    }
                    /// in ra danh sach san pham trong bang
                 //   string contain = "";
                    foreach (string list in product)
                    {
                        string[] contain = list.Split('_');
                        order.Insert(int.Parse(contain[2]), idInvoice, 1, list);
                        int newSL = (int)PRO.getSL(int.Parse(contain[2])) - 1;
                        PRO.updateSL(newSL, int.Parse(contain[2]));
                    }
                    //   combo++;
                  //  MessageBox.Show(contain);
                }

            }
            //  MessageBox.Show($"so luong san pham thuong: {countCO} \n so luong ve phim: {countBO} \n so luong combo: {combo}");
            //// tao moi hoa don

        }

    }
}
