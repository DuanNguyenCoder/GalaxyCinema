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
    public partial class findBarcode : UserControl
    {
        int showTimeID;
        object[] Obj;
        public findBarcode( object[] ob,int _showTimeID)
        {
            //string namefilm, string gia, string screen, string showtime, string endtime, string loaive
            showTimeID = _showTimeID;
            Obj = ob;
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "10806117")
            {
                MessageBox.Show("thành công", "Thông báo");
               ticket_Item item = new ticket_Item(new object[] {Obj[0].ToString(), "0.0" ,Obj[2].ToString(),Obj[3].ToString(),Obj[4].ToString(),"Movie50"});
                
                                item.Tag = showTimeID;
                                item.Show();
                                Form1._form1.bill_panel.Controls.Add(item);
                this.Hide();
            }else if(guna2TextBox1.Text == "10806118")
            {
                ticket_Item item = new ticket_Item(new object[] { Obj[0].ToString(), "35.000", Obj[2].ToString(), Obj[3].ToString(), Obj[4].ToString(),"MovieFree" });

                item.Tag = showTimeID;
                item.Show();
                Form1._form1.bill_panel.Controls.Add(item);
                MessageBox.Show("thành công", "Thông báo");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }
    }
}
