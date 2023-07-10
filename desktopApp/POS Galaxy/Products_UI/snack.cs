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
using POS_Galaxy.User_Controls;

namespace POS_Galaxy.Products_UI
{
    public partial class snack : Form
    {
        public snack()
        {
            InitializeComponent();
            loaddata();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Form1._form1.panel_Dashboard.Controls.Remove(this);
        }
        Image byteToImage(byte[] b)
        {
            MemoryStream a = new MemoryStream(b);
            return Image.FromStream(a);
        }
        private void loaddata()
        {
            POS_galaxyDataSetTableAdapters.ProductTableAdapter a = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
            DataTable dt = a.GetDataByLon(6);

            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr[5];
                string name = dr[0].ToString();
                Image image = byteToImage((byte[])dr[4]);
                decimal price = (decimal)dr[2];

                snack_uc uc = new snack_uc(id, name, String.Format("{0:0,0}", price), image);
                uc.Show();
                flowLayoutPanel1.Controls.Add(uc);
            }

        }
    }
}
