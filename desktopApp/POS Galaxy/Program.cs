using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Galaxy.Ticket_UI;
using System.Windows.Forms;
using POS_Galaxy.User_Controls;
using POS_Galaxy.Products_UI;
using POS_Galaxy.Login_UI;

namespace POS_Galaxy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
