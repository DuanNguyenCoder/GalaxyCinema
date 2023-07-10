using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;
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
    public partial class selectFastFood_Item : UserControl
    {
        int press = 1;
        public selectFastFood_Item()
        {
            InitializeComponent();
        }
        public selectFastFood_Item(string name)
        {
            InitializeComponent();
            guna2Button1.Text = name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (press == 1)
            {
                if (combo_famlily.combo_farm != null)
                {
                    if (combo_famlily.combo_farm.detail != null)
                    {
                        Guna2Button but = sender as Guna2Button;
                        detailCombo._detailsCombo2.fast_pan[0].Controls[0].Text = but.Text;
                        detailCombo._detailsCombo2.fast_pan[0].Controls[0].Tag = this.Tag;
                        detailCombo._detailsCombo2.fast_pan[0].BackColor = Color.White;
                        combo_famlily.combo_farm.detail.Hide();
                        combo_famlily.combo_farm.detail2.Hide();

                    }

                }
                return;
            }
        }
    }
}
