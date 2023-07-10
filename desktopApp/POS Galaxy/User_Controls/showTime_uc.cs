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

namespace POS_Galaxy.User_Controls
{
    public partial class showTime_uc : UserControl
    {
       public string starShow;
        public int idShowTime;
        public showTime_uc(string _film, string _starShow, string _endShow,string _screen, string _AgeLimited)
        {
            InitializeComponent();
            film.Text = _film;
            starShow = _starShow;
            showtime.Text = _starShow;
            endTime.Text = _endShow;
            AgeLimited.Text = _AgeLimited;
            screen.Text = _screen;
            this.DoubleBuffered = true;
            guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;

        }

     
        private void showTime_uc_MouseLeave(object sender, EventArgs e)
        {
          

        }

        private void showTime_uc_MouseUp(object sender, MouseEventArgs e)
        {
           

        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel parent1 = this.Parent as FlowLayoutPanel;
            parent1.Hide();
            Guna2Panel parent2 = parent1.Parent as Guna2Panel;

            foreach (var item in parent2.Controls)
            {
                if(item is Guna2HtmlLabel)
                {
                    Guna2HtmlLabel label = item as Guna2HtmlLabel;
                if (label.Name == "name")
                {
                        label.Text = film.Text;
                }
                if(label.Name == "screen")
                {
                        label.Text = screen.Text;
                }
                if (label.Name == "showTime")
                {
                        label.Text = showtime.Text;
                }
                if (label.Name == "endTime")
                {
                        label.Text = endTime.Text;
                }
                if (label.Name == "ageLimited")
                {
                        label.Text = "C"+AgeLimited.Text;
                }

                }
            }
            film_uc._filmUC.showTimeID = idShowTime;

        }
        FlowLayoutPanel flow;
        private void timer1_Tick(object sender, EventArgs e)
        {
             flow = this.Parent as FlowLayoutPanel;
            if (flow.Controls[0] == this)
            {
          if(  showtime.ForeColor == Color.Red)
            {
            showtime.ForeColor = Color.White;
            endTime.ForeColor = Color.White;
            }
            else
            {
                showtime.ForeColor = Color.Red;
                endTime.ForeColor = Color.Red;
            }

            } 

        }
    }
}
