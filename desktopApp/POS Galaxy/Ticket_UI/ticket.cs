using POS_Galaxy.User_Controls;
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

namespace POS_Galaxy.Ticket_UI
{
    public partial class ticket : Form
    {
        POS_galaxyDataSetTableAdapters.getShowTimeTableAdapter film = new POS_galaxyDataSetTableAdapters.getShowTimeTableAdapter();
        public ticket()
        {
            InitializeComponent();

           // fakeData();

            this.DoubleBuffered = true;
            guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        }
        Image byteToImage(byte[] b)
        {
            MemoryStream a = new MemoryStream(b);
            return Image.FromStream(a);
        }

        private void ticket_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;

            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
            //  loadFilmByday(DateTime.Now.Day, DateTime.Now.Day, DateTime.Now.Day);
            loadFilmByday(day,month,year);
        }

        private void loadFilmByday(int day, int month, int year)
        {
            int w = 0;
            int h = 10;

            DataTable data = film.getItemFilm(day, month, year);
            List<string> filmName = new List<string>();
            foreach (DataRow item in data.Rows)
            {
                if (filmName.Contains(item[0].ToString()))
                {
                    continue;
                }

                filmName.Add(item[0].ToString());
                string name = item[0].ToString();
                string starShow = item[4].ToString();
                string endShow = item[5].ToString();
                string Screen = item[2].ToString();
                string age = item[3].ToString();
                Image img = byteToImage((byte[])item[1]);
                film_uc f = new film_uc(img, name, starShow, endShow, age);
                f.day = day; f.month = month; f.year = year;
                f.showTimeID = (int)item[6];
                f.Tag = (int)item[7];
                guna2Panel1.Controls.Add(f);
                f.Location = new Point(w, h);
                h += 130;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (sfCalendar1.Visible)
            {
                sfCalendar1.Hide();
            }
            else
            {
                sfCalendar1.Show();

            }
        }

        private void sfCalendar1_DoubleClick(object sender, EventArgs e)
        {
            DateTime date = (DateTime)sfCalendar1.SelectedDate;
            sfCalendar1.Hide();
            List<film_uc> list = new List<film_uc>();

            ///// xoa di phim trong pan
            foreach (var item in guna2Panel1.Controls)
            {
                if (item is film_uc)
                {
                    film_uc film = item as film_uc;
                    list.Add(film);
                }
            }
            foreach (var item in list)
            {
                guna2Panel1.Controls.Remove(item);
            }
            ///////////////////
            loadFilmByday(date.Day, date.Month, date.Year);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime)sfCalendar1.SelectedDate;
            sfCalendar1.Hide();
            List<film_uc> list = new List<film_uc>();

            ///// xoa di phim trong pan
            foreach (var item in guna2Panel1.Controls)
            {
                if (item is film_uc)
                {
                    film_uc film = item as film_uc;
                    list.Add(film);
                }
            }
            foreach (var item in list)
            {
                guna2Panel1.Controls.Remove(item);
            }
            loadFilmByday(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
