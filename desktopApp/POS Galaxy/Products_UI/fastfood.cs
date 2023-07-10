using POS_Galaxy.User_Controls;
using System;
using System.Data;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace POS_Galaxy.Products_UI
{
    public partial class fastfood : Form
    {
       
        public static fastfood _fastfood;

        public FlowLayoutPanel flowLayoutPanel
        {
            get {  return flowLayoutPanel1; }
        }
        public fastfood()
        {
            InitializeComponent();
            loadData();
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
        private void loadData()
        {
            POS_galaxyDataSetTableAdapters.ProductTableAdapter a = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
            DataTable dt = a.GetDataByCatory(1);

            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr[5];
                string name = dr[0].ToString();
                Image image = byteToImage((byte[])dr[4]);
                decimal price = (decimal)dr[2];

                fastFood_uc uc = new fastFood_uc(id, name, image, String.Format("{0:0,0}", price));
                uc.Show();
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}
