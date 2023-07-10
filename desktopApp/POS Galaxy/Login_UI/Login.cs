using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Galaxy.Login_UI
{
    public partial class Login : Form
    {
        Form1 form1 = new Form1();
        Manager manager = new Manager();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text =="admin")
            {
                manager.Show();
            }
            else
            {

            form1.Show();
            }
            this.Hide();


        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
