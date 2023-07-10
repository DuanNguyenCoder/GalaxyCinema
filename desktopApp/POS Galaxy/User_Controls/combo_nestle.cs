using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Windows.Forms;
using POS_Galaxy.Products_UI;

namespace POS_Galaxy.User_Controls
{
    public partial class combo_nestle : UserControl
    {
        public selectPopcorn detail;
        public detailCombo detail2;
        public static combo_nestle combo_nest;
        public combo_nestle()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panel_nestle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            setData();
        }
        private void setData()
        {
            guna2Button1.Tag = new object[] { "combo1 milo small", "76000", 1, 1, 0, 0 };
            guna2Button2.Tag = new object[] { "combo1 milo small mix", "76000", 1, 1, 0, 0 };
            guna2Button3.Tag = new object[] { "combo2 milo small", "89000", 1, 2, 0, 0 };
            guna2Button4.Tag = new object[] { "combo2 milo small mix", "89000", 1, 2, 0, 0 };
            guna2Button5.Tag = new object[] { "combo1 milo big", "79000", 1, 1, 0, 0 };
            guna2Button6.Tag = new object[] { "combo1 milo big mix", "79000", 1, 1, 0, 0 };
            guna2Button7.Tag = new object[] { "combo2 milo big", "92000", 1, 2, 0, 0 };
            guna2Button8.Tag = new object[] { "combo2 milo big mix", "92000", 1, 2, 0, 0 };
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


            detail = new selectPopcorn((int)ob[2], (int)ob[3], (int)ob[4], (int)ob[5],selectPopcorn.TypeDrink.hop,ob[0].ToString());
            detail.Show();
            detail.TopLevel = false;
            Form1._form1.panel_Dashboard.Controls.Add(detail);
            detail.BringToFront();
            detail.Location = new Point(300, 100);
            detail.Tag = 32;

            detail2 = new detailCombo((int)ob[2], (int)ob[3], (int)ob[4], (int)ob[5]);
            detail2.nameCombo = (string)ob[0];
            detail2.Show();
            detail2.TopLevel = false;
            Form1._form1.bill_panel_parent.Controls.Add(detail2);
            detail2.BringToFront();
            detail2.Location = new Point(20, item.Location.Y + 60);

            item.Tag = detail2;
            combo_nest = this;
        }
    }
}
