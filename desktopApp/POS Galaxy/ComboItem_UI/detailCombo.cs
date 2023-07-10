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

namespace POS_Galaxy.Products_UI
{
    public partial class detailCombo : Form
    {
        public static detailCombo _detailsCombo2;
        public string nameCombo;
        public int Popcorn;
        public int ly;
        public int snack;
        public int fastfood;
        int item;
        public Guna2Panel[] pop_pan;
        public Guna2Panel[] ly_pan;
        public Guna2Panel[] snack_pan;
        public Guna2Panel[] fast_pan;
       
        public detailCombo(int bap , int nuoc, int Snack, int Fastfood)
        {
            Popcorn = bap;
            ly = nuoc;
            snack = Snack;
            fastfood = Fastfood;
            item = Popcorn + ly + snack + fastfood;
            pop_pan = new Guna2Panel[Popcorn];
            ly_pan = new Guna2Panel[ly];
            snack_pan = new Guna2Panel[snack];
            fast_pan = new Guna2Panel[fastfood];
            InitializeComponent();
            createItem();
            effect();
            _detailsCombo2 = this;
        }


        // 314 28
        int last_Y_location;
        private void createItem()
        {
            this.Height += 30 * item;
            // them panel bap
            for (int i = 0; i < Popcorn; i++)
            {
                pop_pan[i] = new Guna2Panel();
                pop_pan[i].Width = 314;
                pop_pan[i].Height = 28;
                pop_pan[i].BorderColor = Color.Black;
                pop_pan[i].Location = new Point(0, 29 * (i + 1));
                last_Y_location = pop_pan[i].Location.Y;
                pop_pan[i].Show();
                this.Controls.Add(pop_pan[i]);

                Label a = new Label();
                // ma hop bap la 4
                a.Tag = 4;
                a.Text = "POPCORN";
                a.BackColor = Color.Transparent;
                a.Location = new Point(20, 5);
                a.Show();
                pop_pan[i].Controls.Add(a);
            }

            // them panel nuoc
            for (int i = 0; i < ly; i++)
            {
                ly_pan[i] = new Guna2Panel();
                ly_pan[i].Width = 314;
                ly_pan[i].Height = 28;
                ly_pan[i].BorderColor = Color.Black;
                ly_pan[i].Location = new Point(0, last_Y_location + 29);
                last_Y_location = ly_pan[i].Location.Y;
                ly_pan[i].Show();
                this.Controls.Add(ly_pan[i]);

                Label a = new Label();
                a.Text = "DRINK";
                a.BackColor = Color.Transparent;
                a.Location = new Point(20, 5);
                a.Show();
                ly_pan[i].Controls.Add(a);
            }

            // them panel snack
            for (int i = 0; i < snack; i++)
            {
                snack_pan[i] = new Guna2Panel();
                snack_pan[i].Width = 314;
                snack_pan[i].Height = 28;
                snack_pan[i].BorderColor = Color.Black;
                snack_pan[i].Location = new Point(0, last_Y_location + 29);
                last_Y_location = snack_pan[i].Location.Y;
                snack_pan[i].Show();
                this.Controls.Add(snack_pan[i]);

                Label a = new Label();
                a.Text = "SNACK";
                a.BackColor = Color.Transparent;
                a.Location = new Point(20, 5);
                a.Show();
                snack_pan[i].Controls.Add(a);
            }

            // them panel fastfood
            for (int i = 0; i < fastfood; i++)
            {
                fast_pan[i] = new Guna2Panel();
                fast_pan[i].Width = 314;
                fast_pan[i].Height = 28;
                fast_pan[i].BorderColor = Color.Black;
                fast_pan[i].Location = new Point(0, last_Y_location + 29);
                last_Y_location = fast_pan[i].Location.Y;
                fast_pan[i].Show();
                this.Controls.Add(fast_pan[i]);

                Label a = new Label();
                a.Text = "FASTFOOD";
                a.BackColor = Color.Transparent;
                a.Location = new Point(20, 5);
                a.Show();
                fast_pan[i].Controls.Add(a);
            }


        }

        private void effect()
        {
            pop_pan[0].BackColor = Color.Orange;
        }

        private void detailCombo_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = nameCombo;
        }
    }
}
