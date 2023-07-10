using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;

namespace POS_Galaxy.User_Controls
{
    public partial class selectSnack_item : UserControl
    {
        int press = 1;
       
        public selectSnack_item()
        {
            InitializeComponent();
        }
        public selectSnack_item(string _name)
        {
            InitializeComponent();
            guna2Button2.Text = _name;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (press == 1)
            {
                if (combo_famlily.combo_farm != null)
                {
                    if (combo_famlily.combo_farm.detail != null)
                    {
            Guna2Button but = sender as Guna2Button;
            detailCombo._detailsCombo2.snack_pan[0].Controls[0].Text = but.Text;
            detailCombo._detailsCombo2.snack_pan[0].Controls[0].Tag = this.Tag;
            detailCombo._detailsCombo2.snack_pan[0].BackColor = Color.White;
                        combo_famlily.combo_farm.detail.Hide();
                        combo_famlily.combo_farm.detail2.Hide();
                    }

                }
                return;
            }
           

            press++;
        }
    }
}
