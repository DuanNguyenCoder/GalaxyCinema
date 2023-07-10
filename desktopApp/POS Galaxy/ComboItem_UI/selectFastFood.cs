using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Galaxy.User_Controls;

namespace POS_Galaxy.ComboItem_UI
{
    public partial class selectFastFood : Form
    {
        POS_galaxyDataSetTableAdapters.ProductTableAdapter pro = new POS_galaxyDataSetTableAdapters.ProductTableAdapter();
        public selectFastFood()
        {
            InitializeComponent();
        }

        private void selectFastFood_Load(object sender, EventArgs e)
        {
            DataTable table = pro.GetDataByCatory(1);
            foreach (DataRow item in table.Rows)
            {

                selectFastFood_Item snack = new selectFastFood_Item(item[0].ToString());
                snack.Tag = (int)item[5];
                snack.Show();
                flowLayoutPanel1.Controls.Add(snack);
            }
        }
    }
}
