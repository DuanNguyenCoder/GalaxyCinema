using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Galaxy.Ticket_UI;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;
using POS_Galaxy.Login_UI;
using POS_Galaxy.User_Controls;

namespace POS_Galaxy
{
    public partial class Form1 : Form
    {
       
        public static  Form1 _form1;
            ticket tk = new ticket();
            seat s ;
            ComboPopcorn cb = new ComboPopcorn();
        popcorn pop = new popcorn();
        Drink d = new Drink();
        fastfood ff = new fastfood();
        snack sn = new snack();
        Voucher v = new Voucher();
        promotion pro = new promotion();


        public string nameGuestService;
        public Guna2Panel panel_Dashboard
        {
            get { return DashBoard_products_panel; }
        }
        public Guna2Panel bill_panel_parent
        {
            get { return select_item_panel; }
        }
        public FlowLayoutPanel bill_panel
        {
            get { return flowLayoutPanel1; }
        }
        public Guna2Panel panel_Main
        {
            get { return panel_Main; }
        }
        public Label label_total
        {
            get { return total; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seatBtn.Hide();
             _form1 = this;
            nameGuestService = label2.Text;
            label1.Text = "29 Jan 2022 3:37pm";
        }
       
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ChangeLayout(cb,DashBoard_products_panel,0,80);
            _form1 = this;
        }

        private void ChangeLayout( Form panelChild , Guna2Panel panelParent, int x, int y )
        {
            panelChild.Show();
            panelChild.TopLevel = false;
            panelParent.Controls.Add(panelChild);
            panelChild.Location = new Point(x,y);
            panelChild.BringToFront();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            ChangeLayout(d, DashBoard_products_panel,0,80);
            _form1 = this;
        }

        //tab concession
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChangeLayout(tk, DashBoard_products_panel,0,80);
            _form1 = this;
            seatBtn.Show();
        }
        // tab ticket
        private void guna2Button1_Click(object sender, EventArgs e)
        {
          tk.Hide();
            seatBtn.Hide();

        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {
            _form1 = this;
            int idShowTime = 0;

            // dem so luong ve 
            int count = 0;
            string rap = null;
            string name = null;
            string starShow = null;
            string endShow = null;
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if(item is ticket_Item)
                {
                    count++;
                    if(count == 1)
                    {
                        ticket_Item tick = item as ticket_Item;
                        idShowTime = (int)tick.Tag;
                        name = tick.filmName;
                        rap = tick.screen;
                        starShow = tick.showTime;
                        endShow = tick.endTime;

                    }
                }
            }
            if (count > 0)
            {
               
                    s = new seat(name,starShow,endShow,rap,count);
            // do du lieu cac ghe da duoc dat 
            POS_galaxyDataSetTableAdapters.orderFilmTableAdapter order = new POS_galaxyDataSetTableAdapters.orderFilmTableAdapter();
                   
                    DataTable table = order.getSeatOrdered(idShowTime);

                    foreach (DataRow item in table.Rows)
                    {
                        string[] split = item[3].ToString().Split(' ');
                        string seat = split[1];
                        string row =  split[0];
                   
                    if (split[0] == "A")
                        {
                            foreach (Guna2Button btn in s.guna2Panel12.Controls)
                            {
                                if (btn.Text == split[1])
                                {
                                    btn.FillColor = Color.White;
                                }
                            }
                            
                        }
                        if (split[0] == "B")
                        {
                            foreach (Guna2Button btn in s.guna2Panel11.Controls)
                            {
                                if (btn.Text ==split[1])
                                {
                                    btn.FillColor = Color.White;
                                }
                            }
                        }
                        if (split[0] == "C")
                        {
                            foreach (Guna2Button btn in s.guna2Panel10.Controls)
                            {
                                if (btn.Text == split[1])
                                {
                                btn.FillColor = Color.White;
                                }
                              
                            }
                        }
                        if (split[0] == "D")
                        {
                            foreach (Guna2Button btn in s.guna2Panel9.Controls)
                            {
                                if (btn.Text == split[1])
                                {
                                    btn.FillColor = Color.White;
                                }
                            }
                        }
                        if (split[0] == "E")
                        {
                            foreach (Guna2Button btn in s.guna2Panel8.Controls)
                            {
                                if (btn.Text == split[1])
                                {
                                    btn.FillColor = Color.White;
                                }
                            }
                        }
                        if (split[0] == "F")
                        {
                            foreach (Guna2Button btn in s.guna2Panel7.Controls)
                            {
                                if (btn.Text == split[1])
                                {
                                    btn.FillColor = Color.White;
                                }
                            }
                        }
                    
             ///// /////////
                }
                    s.Show();
                    s.TopLevel = false;
                    this.Controls.Add(s);
                    s.Location = new Point(0, 0);
                    s.BringToFront();
            }
            else
            {
                MessageBox.Show("chọn vé trước khi chọn ghế", "Thông báo",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //snack
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            ChangeLayout(sn, DashBoard_products_panel,0,80);
            _form1 = this;
        }
        //fastfood
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            ChangeLayout(ff, DashBoard_products_panel,0,80);
            _form1 = this;
        }
        //voucher
        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            ChangeLayout(v, DashBoard_products_panel,0,80);
            _form1 = this;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            ChangeLayout(pop, DashBoard_products_panel, 0, 80);
            _form1 = this;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _form1 = this;

            if (bill_panel.Controls.Count == 0)
            {
                MessageBox.Show("lỗi", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////////////////////////KIEM TRA VE DA THEM CHO CHUA///////////////////////////
            foreach (var item in bill_panel.Controls)
            {
                if (item is ticket_Item)
                {
                    ticket_Item tkI = item as ticket_Item;
                    if (tkI.seatLabel.Text == "_")
                    {
                        MessageBox.Show("chưa chọn ghế", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                }
            }



            Form form = new Form();
            try
            {
                Pay pay = new Pay(total.Text);

                form.StartPosition = FormStartPosition.Manual;
                form.BackColor = Color.Black;
                form.Location = this.Location;
                form.Width = this.Width;
                form.Height = this.Height;
                form.Opacity = .50d;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
                pay.TopMost = true;
                form.ShowInTaskbar = false;
                pay.Owner = form;
                pay.ShowDialog();
                pay.BringToFront();


                form.Dispose();
                // test them san pham vao bill trong csdl
                //  int detail;
                int product = 0;
                foreach (var item in flowLayoutPanel1.Controls)
                {
                    product++;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            ChangeLayout(pro, DashBoard_products_panel, 0, 80);
            _form1 = this;
        }

        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<detailCombo> list = new List<detailCombo>();
            foreach (var item in bill_panel_parent.Controls)
            {
                if (item is detailCombo)
                {
                    list.Add((detailCombo)item);
                }
            }
            foreach (var item in list)
            {
                bill_panel_parent.Controls.Remove(item);
            }
            label_total.Text = "00";
        }
        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                total.Text = "0";
                seatBtn.Hide();
                tk.Hide();
            cb.Hide();
            d.Hide();
            ff.Hide();
            sn.Hide();
            v.Hide();
            pro.Hide();
            resetMenuItem();
                flowLayoutPanel1.Controls.Clear();
                List<detailCombo> list = new List<detailCombo>();
                foreach (var item in bill_panel_parent.Controls)
                {
                    if (item is detailCombo)
                    {
                        list.Add((detailCombo)item);
                    }
                }
                foreach (var item in list)
                {
                    bill_panel_parent.Controls.Remove(item);
                }

                s.Hide();

            }
            catch (Exception)
            {

            }
          
        }
        private void resetMenuItem()
        {
            flowLayoutPanel1.Controls.Clear();
            total.Text = "0";
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
      Login lg = new Login();
            lg.Show();
            lg.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();

        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("lỗi", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void total_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(total.Text) < 0)
            {
                total.Text = "0.0";
            }
        }
    }
}
