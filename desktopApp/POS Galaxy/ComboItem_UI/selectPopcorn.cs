using System;
using System.Drawing;
using System.Windows.Forms;
using POS_Galaxy.ComboItem_UI;
using Guna.UI2.WinForms;
namespace POS_Galaxy.Products_UI
{
    public partial class selectPopcorn : Form
    {
        public static selectPopcorn _selectPopcorn;

        public Guna2Panel panContain { get { return guna2Panel1; } }
        public Guna2HtmlLabel labelNameCB { get { return guna2HtmlLabel1; } }
        public string _nameCombo { get { return nameCombo; } }
 

        int CREATE_DRINK_ITEM; // dung de xac dinh ve panel cac loai nuoc hay la hop milo hoac nutri ben giao dien chon ly
        string nameCombo;
        int press = 0;
        int bap;
        int nuoc;
        int Snack;
        int Fastfood;
        public enum TypeDrink { lygiay = 1, hop = 2 };
        public selectPopcorn(int Bap, int Nuoc, int snack, int fastfood, TypeDrink Typedrink, string NameCombo)
        {
            nameCombo = NameCombo;
            Snack = snack;
            Fastfood = fastfood;
            bap = Bap;
            nuoc = Nuoc;
            CREATE_DRINK_ITEM = (int)Typedrink;
            InitializeComponent();
            guna2HtmlLabel1.Text = nameCombo + " - chọn bắp";
            this.DoubleBuffered = true;
            guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(press == bap) {
                return;
            }

            Guna2Button but = sender as Guna2Button; 
                detailCombo._detailsCombo2.pop_pan[press].Controls[0].Text = but.Text;
            if (this.Tag != null)
            {
                detailCombo._detailsCombo2.pop_pan[press].Controls[0].Tag = 4;

            }
                detailCombo._detailsCombo2.pop_pan[press].BackColor = Color.White;
            try
            {
                detailCombo._detailsCombo2.pop_pan[press + 1].BackColor = Color.Orange;
            }
            catch (Exception)
            { 
                selectLy ly = new selectLy(CREATE_DRINK_ITEM,Snack,Fastfood, (int)this.Tag);
                guna2HtmlLabel1.Text = nameCombo + "- chọn nước";
                ly.Tag = nuoc;
                ly.Show();
                ly.TopLevel = false;
                guna2Panel1.Controls.Add(ly);
                ly.BringToFront();
                ly.Location = new Point(1, 42);
            }
            press++;
            _selectPopcorn = this;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            foreach (var item in Form1._form1.bill_panel_parent.Controls)
            {
                if (item is detailCombo)
                {
                    detailCombo detail = item as detailCombo;
                    if (detail.Visible)
                    {
                        Form1._form1.bill_panel_parent.Controls.Remove(detail);
                    }
                }
            }
            int count = Form1._form1.bill_panel.Controls.Count;
            Form1._form1.bill_panel.Controls.RemoveAt(count - 1);
        }
    }
}
