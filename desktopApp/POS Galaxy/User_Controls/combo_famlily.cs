using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;

namespace POS_Galaxy.User_Controls
{
    public partial class combo_famlily : UserControl
    {
        public selectPopcorn detail;
        public detailCombo detail2;
        public static combo_famlily combo_farm;
        public combo_famlily()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panel_family.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            setData();
        }
        private void setData()
        {
            guna2Button1.Tag = new object[] { "combo family1 snack", "129000", 1, 3, 1, 0 };
            guna2Button2.Tag = new object[] { "combo family1 ff", "129000", 1, 3, 0, 1 };
            guna2Button3.Tag = new object[] { "combo family1 popcorn", "129000", 2, 3, 0, 0 };
            guna2Button4.Tag = new object[] { "combo family2 snack mix", "179000", 2, 4, 1, 0 };
            guna2Button5.Tag = new object[] { "combo family2 ff", "179000", 2, 4, 0, 1 };
            guna2Button6.Tag = new object[] { "combo family2 popcorn", "179000", 3, 4, 0, 0 };
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            object[] ob = button.Tag as object[];
            bill_item item = new bill_item(ob[0].ToString(), ob[1].ToString());
            item.numericUpDown.Hide();
            item.Show();
            Form1._form1.bill_panel.Controls.Add(item);

            // bap - nuoc


            detail = new selectPopcorn((int)ob[2], (int)ob[3], (int)ob[4], (int)ob[5], selectPopcorn.TypeDrink.lygiay, ob[0].ToString());
            detail.Show();
            detail.TopLevel = false;
            Form1._form1.panel_Dashboard.Controls.Add(detail);
            detail.BringToFront();
            detail.Location = new Point(300, 100);

            ///////// chon id ly lon hoac ly be
            if (ob[0].ToString().Contains("family2"))
            {
                detail.Tag = 5;
            }
            else {
                detail.Tag = 26;
            }

            detail2 = new detailCombo((int)ob[2], (int)ob[3], (int)ob[4], (int)ob[5]);
            detail2.nameCombo = (string)ob[0];
            detail2.Show();
            detail2.TopLevel = false;
            Form1._form1.bill_panel_parent.Controls.Add(detail2);
            detail2.BringToFront();
            detail2.Location = new Point(20, item.Location.Y + 60);

            item.Tag = detail2;
            combo_farm = this;
        }
    }
}
