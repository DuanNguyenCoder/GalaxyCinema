using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;
using System;
using POS_Galaxy.User_Controls;
using System.Drawing;
using System.Windows.Forms;


namespace POS_Galaxy.ComboItem_UI
{
    public partial class selectLy : Form
    {
      public  int press = 0;
        public int DRAW_DRINK_ITEM;
        int Snack;
        int Fastfood;

        /// ly nho hay lon ly lon id la 5 
        ///  ly nho la 26
        int idLy;


        public selectLy( int draw_drink_item, int snack, int fastfood, int TypeLy)
        {
            idLy = TypeLy;
            Snack = snack;
            Fastfood = fastfood;    
            InitializeComponent();
            DRAW_DRINK_ITEM = draw_drink_item;
            detailCombo._detailsCombo2.ly_pan[0].BackColor = Color.Orange;
            CreateItemDrink();
        }
        private void CreateItemDrink()
        {
            //185,132
            //  Guna2Panel
            switch (DRAW_DRINK_ITEM)
            {
                case 1:
                    guna2Button5.Hide();
                    break;
                case 2:
                    guna2Button1.Hide();
                    guna2Button2.Hide();
                    guna2Button3.Hide();
                    guna2Button4.Hide();
                    guna2Button6.Hide();
                    break;
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (press == (int)this.Tag)
            {
                return;
            }

            Guna2Button but = sender as Guna2Button;
            detailCombo._detailsCombo2.ly_pan[press].Controls[0].Text = but.Text;
            detailCombo._detailsCombo2.ly_pan[press].Controls[0].Tag = idLy;


            detailCombo._detailsCombo2.ly_pan[press].BackColor = Color.White;
            try
            {
                if (press != ((int)this.Tag - 1))
                {
                detailCombo._detailsCombo2.ly_pan[press + 1].BackColor = Color.Orange;

                }
     
            }
            catch (Exception)
            {
                if (ComboPopcorn.popcorn != null)
                {
                    if (ComboPopcorn.popcorn.detail != null) {

                        ComboPopcorn.popcorn.detail.Hide();
                        ComboPopcorn.popcorn.detail2.Hide();
                    }
                }
                if(combo_nestle.combo_nest != null)
                {
                    if(combo_nestle.combo_nest.detail != null)
                    {
                combo_nestle.combo_nest.detail.Hide();
                combo_nestle.combo_nest.detail2.Hide();

                    }

                }
               

            }
            press++;

            if (press == ((int)this.Tag) && Snack != 0)
            {
                selectSnack snack = new selectSnack();
                detailCombo._detailsCombo2.snack_pan[0].BackColor = Color.Orange;
                snack.Show();
                selectPopcorn._selectPopcorn.labelNameCB.Text = selectPopcorn._selectPopcorn._nameCombo +  " - chọn snack";
                // ly.Tag = nuoc;
                snack.TopLevel = false;
                snack.Location = new Point(1, 42);
                selectPopcorn._selectPopcorn.panContain.Controls.Add(snack);
                snack.BringToFront();
                return;

            }

            if (press == ((int)this.Tag) && Fastfood != 0)
            {
                selectFastFood fast = new selectFastFood();
                detailCombo._detailsCombo2.fast_pan[0].BackColor = Color.Orange;
                fast.Show();
                selectPopcorn._selectPopcorn.labelNameCB.Text = selectPopcorn._selectPopcorn._nameCombo + " - chọn fastfood";
                // ly.Tag = nuoc;
                fast.TopLevel = false;
                fast.Location = new Point(1, 42);
                selectPopcorn._selectPopcorn.panContain.Controls.Add(fast);
                fast.BringToFront();
                return;
            }
            if (press == ((int)this.Tag) && ComboPopcorn.popcorn != null)
            {
                if (ComboPopcorn.popcorn.detail != null)
                {

                    ComboPopcorn.popcorn.detail.Hide();
                    ComboPopcorn.popcorn.detail2.Hide();
                }
            }
            if (press == ((int)this.Tag) && combo_nestle.combo_nest != null)
            {
                if (combo_nestle.combo_nest.detail != null)
                {
                    combo_nestle.combo_nest.detail.Hide();
                    combo_nestle.combo_nest.detail2.Hide();

                }

            }
            if (press == ((int)this.Tag) && combo_famlily.combo_farm != null)
            {
                if (combo_famlily.combo_farm.detail != null)
                {
                    combo_famlily.combo_farm.detail.Hide();
                    combo_famlily.combo_farm.detail2.Hide();

                }

            }

        }
    }
}
