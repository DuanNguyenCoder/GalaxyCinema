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
    public partial class drink_lon : Form
    {
        public drink_lon()
        {
            InitializeComponent();
            loadData();
        }
        Image byteToImage(byte[] b)
        {
            MemoryStream a = new MemoryStream(b);
            return Image.FromStream(a);
        }
        private void loadData()
        {
            POS_galaxyDataSetTableAdapters.ProductTableAdapter a = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
            DataTable dt = a.GetDataByLon(3);

            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr[5];
                string name = dr[0].ToString();
                Image image = byteToImage((byte[])dr[4]);
                decimal price = (decimal)dr[2];

                drink_lon_chai_uc uc = new drink_lon_chai_uc(id,name, String.Format("{0:0,0}", price), image);
                uc.Show();
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}
