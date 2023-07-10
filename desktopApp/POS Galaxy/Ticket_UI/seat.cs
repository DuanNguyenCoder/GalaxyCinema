using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace POS_Galaxy.Ticket_UI
{
    public partial class seat : Form
    {
        int press;
        public seat( string _name, string _startshow, string _endshow, string _screen, int count)
        {
            InitializeComponent();
            name.Text = _name;
            startshow.Text = _startshow;
            endshow.Text = _endshow;
            string[] split = _screen.Split(' ');
            screen.Text = split[1];
            press = count;


            // load imgae 
            POS_galaxyDataSetTableAdapters.FilmTableAdapter film = new POS_galaxyDataSetTableAdapters.FilmTableAdapter();

           DataTable table = film.findFilmByName(_name);
            DataRow row = table.Rows[0];
                guna2PictureBox1.Image =  byteToImage((byte[])row[6]);


        }
            Image byteToImage(byte[] b)
            {
                MemoryStream a = new MemoryStream(b);
                return Image.FromStream(a);
            }




        private void guna2Button61_Click(object sender, EventArgs e)
        {
           Guna2Button button = sender as Guna2Button;
            Guna2Panel pan = button.Parent as Guna2Panel;

            if (guna2GradientButton1.FillColor != Color.FromArgb(255, 180, 58))
            {
            if (!button.Checked)
            {
                foreach (Guna2Button item in pan.Controls)
                {
                    if (item.FillColor == Color.FromArgb(255, 180, 58))
                    {
                        item.FillColor = Color.FromArgb(255, 180, 58);
                        press = 0;
                        item.Checked = true;
                        button.Checked = true;
                    }
                }
            }
            else
            {
                button.FillColor = Color.FromArgb(85, 85, 85);
                button.Checked = false;
                press++;
            }

            }
            else {
                if (button.FillColor == Color.FromArgb(255, 180, 58))
                {
                    press++;
                }
                if(button.FillColor == Color.FromArgb(85, 85, 85)) { 

                button.FillColor = Color.FromArgb(255, 180, 58);
                if (press == 0) { 
                    return; 
                }
                    press--; 
                
                }
            }

           
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Guna2GradientButton btn = sender as Guna2GradientButton;

            if (btn.Tag.ToString() == "4")
            {
            this.Hide();
            }else if (btn.Tag.ToString() == "1") { btn.FillColor = Color.LightGreen;
   
                guna2GradientButton2.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton4.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton3.FillColor = Color.FromArgb(255, 180, 58);
            }
            else if (btn.Tag.ToString() == "2") { btn.FillColor = Color.LightGreen;

                btn.Text = "Single  x" + press.ToString();
                guna2GradientButton1.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton4.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton3.FillColor = Color.FromArgb(255, 180, 58);

            }
            else
            {
                btn.FillColor = Color.LightGreen;
                guna2GradientButton2.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton4.FillColor = Color.FromArgb(255, 180, 58);
                guna2GradientButton1.FillColor = Color.FromArgb(255, 180, 58);
            }


        }

        private void guna2Button1_MouseHover(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (guna2GradientButton1.FillColor != Color.FromArgb(255, 180, 58))
            {
            if (btn.FillColor == Color.White)
            {
                btn.HoverState.FillColor = Color.White;
                return;
            }
            if (press == 0 || btn.FillColor == Color.White) { return; }

            Guna2Panel pan = btn.Parent as Guna2Panel;
            foreach ( Guna2Button item in pan.Controls)
            {
                if (int.Parse(item.Text) > (int.Parse(btn.Text)) && item.FillColor !=Color.White && int.Parse(item.Text) < (int.Parse(btn.Text) + press))
                {
                    item.FillColor = Color.FromArgb(255,180,58);
                }
            }
                    btn.FillColor = Color.FromArgb(255,180,58);
            }
            else
            {
                btn.FillColor = Color.FromArgb(255, 180, 58);
            }
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            Guna2Panel pan = btn.Parent as Guna2Panel;
            if (guna2GradientButton1.FillColor != Color.FromArgb(255, 180, 58))
            {
                foreach (Guna2Button item in pan.Controls)
                {
                    if (item.FillColor == Color.FromArgb(255, 180, 58))
                    {
                        item.FillColor = Color.FromArgb(85, 85, 85);

                    }
                }
            }
            if(guna2GradientButton2.FillColor == Color.LightGreen)
            {
                if(btn.FillColor != Color.White)
                {
                btn.FillColor = Color.FromArgb(85, 85, 85);

                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            List<string> seat = new List<string>();
            foreach (Guna2Button item in guna2Panel7.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add( guna2Panel7.Tag.ToString() + " " + item.Text);
                }
            }
            foreach (Guna2Button item in guna2Panel8.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add(guna2Panel8.Tag.ToString() + " " + item.Text);
                }
            }
            foreach (Guna2Button item in guna2Panel9.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add(guna2Panel9.Tag.ToString() + " " + item.Text);
                }
            }
            foreach (Guna2Button item in guna2Panel10.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add(guna2Panel10.Tag.ToString() + " " + item.Text);
                }
            }
            foreach (Guna2Button item in guna2Panel11.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add(guna2Panel11.Tag.ToString() + " " + item.Text);
                }
            }
            foreach (Guna2Button item in guna2Panel12.Controls)
            {
                if (item.Checked == true)
                {
                    seat.Add(guna2Panel12.Tag.ToString() + " " + item.Text);
                }
            }

            ///// THEM GHE VUA CHON VAO VE PHIM

            int i = 0;
            foreach (var item in Form1._form1.bill_panel.Controls)
            {
                if (item is POS_Galaxy.User_Controls.ticket_Item)
                {
                    POS_Galaxy.User_Controls.ticket_Item tk = item as POS_Galaxy.User_Controls.ticket_Item;
                    if(i == seat.Count) { return; }
                    tk.seatLabel.Text = seat[i];
                    i++;
                }
            }
            this.Hide();
        }
    }
}
