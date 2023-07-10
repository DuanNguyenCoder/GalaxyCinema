using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS_Galaxy.Products_UI;
using POS_Galaxy.User_Controls;
namespace POS_Galaxy.ComboItem_UI
{
    public partial class selectSnack : Form
    {
        POS_galaxyDataSetTableAdapters.ProductTableAdapter pro = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
        public selectSnack()
        {
            InitializeComponent();
        }

      
        private void selectSnack_Load(object sender, EventArgs e)
        {
            DataTable table = pro.GetDataByCatory(6);
            foreach (DataRow item in table.Rows)
            {
           
                selectSnack_item snack = new selectSnack_item(item[0].ToString());
                snack.Tag = (int)item[5];
                snack.Show();
               flowLayoutPanel1.Controls.Add(snack);
            }

        }
    }
}
