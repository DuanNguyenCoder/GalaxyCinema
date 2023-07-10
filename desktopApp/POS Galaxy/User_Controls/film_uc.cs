using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace POS_Galaxy.User_Controls
{
    public partial class film_uc : UserControl
    {
        POS_galaxyDataSetTableAdapters.getShowTimeTableAdapter st = new POS_galaxyDataSetTableAdapters.getShowTimeTableAdapter();
       public int showTimeID;
        public static film_uc _filmUC;
        public int day;
        public int month;
        public int year;
        

        public film_uc()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        }
        public film_uc( Image _image, string _name, string _start, string _end, string _age)
        {
            InitializeComponent();
            name.Text = _name;
            guna2PictureBox1.Image = _image;
            showTime.Text = _start;
            endTime.Text = _end;
            ageLimited.Text = "C" + _age;

            flowLayoutPanel2.Hide();
            this.DoubleBuffered = true;
          //  guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;

            flowLayoutPanel2.AutoScroll = false;
            flowLayoutPanel2.VerticalScroll.Enabled = false;
            flowLayoutPanel2.VerticalScroll.Maximum = 0;
            flowLayoutPanel2.AutoScroll = true;
 
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            _filmUC = this;
            if (flowLayoutPanel2.Controls.Count == 0)
            {
                return;
            }
            
            if (!flowLayoutPanel2.Visible) { flowLayoutPanel2.Show();return; } 
           
            if (flowLayoutPanel2.Visible) { flowLayoutPanel2.Hide(); return; }
        }

        private void btn_nguoiLon_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            ticket_Item item = null;
            if (btn.Tag.ToString() == "1") {  
             item = new ticket_Item( new object[] {name.Text,tammuoi.Text, screen.Text, showTime.Text,endTime.Text, btn.Text });
            }else if(btn.Tag.ToString() == "2") {  item = new ticket_Item(new object[] { name.Text, bonlam.Text, screen.Text, showTime.Text, endTime.Text,btn.Text }); }
            else if (btn.Tag.ToString() == "4")
            {
                findBarcode find = new findBarcode(new object[] { name.Text, tammuoi.Text, screen.Text, showTime.Text, endTime.Text, btn.Text },showTimeID);
                find.Show();

                Guna2Panel pan = this.Parent as Guna2Panel;
                pan.Controls.Add(find);
                find.Show(); find.Location = new Point( btn.Location.X - find.Width, btn.Location.Y + 16);
                find.BringToFront();
            }
            else
            {
             item = new ticket_Item(new object[] { name.Text, baylam.Text, screen.Text, showTime.Text, endTime.Text,btn.Text });
            }
            if(btn.Tag.ToString() != "4")
            {
            item.Tag = showTimeID;
            item.Show();
            Form1._form1.bill_panel.Controls.Add(item);

            }
        }

        private void film_uc_Load(object sender, EventArgs e)
        {
            
            DataTable data = st.GetDShowTime( (int)this.Tag, day, month, year);
            foreach (DataRow item in data.Rows)
            {
                string name = item[0].ToString();
                string starShow = item[4].ToString();
                string endShow = item[5].ToString();
                string Screen = item[2].ToString();
                string age = item[3].ToString();

                showTime_uc showTime = new showTime_uc(name, starShow, endShow, Screen, age);
                showTime.idShowTime = (int)item[6];
                showTime.Show();
                flowLayoutPanel2.Controls.Add(showTime);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int hour = int.Parse( DateTime.Now.ToString("HH"));
            //int minutes = int.Parse( DateTime.Now.ToString("mm"));
            //TimeSpan now = new TimeSpan(hour, minutes,0);
            //bool suatgannhat = false;
            //TimeSpan best = new TimeSpan();
            //int i = 0;
            //foreach (var item in flowLayoutPanel2.Controls)
            //{
            //    showTime_uc show = item as showTime_uc;
            //   string[] split =  show.starShow.Split(':');
            //    TimeSpan time = new TimeSpan(int.Parse( split[0]), int.Parse(split[1]),0);
            //    TimeSpan result = now - time;
            //    if (i == 0)
            //    {
            //        best = result;
            //    }
            //    if (now - result < best)
            //    {
            //        suatgannhat = true;
            //    }
            //    i++;
            //}
        }
    }
}
