﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Galaxy.Products_UI
{
    public partial class promotion : Form
    {
        public promotion()
        {
            InitializeComponent();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Form1._form1.panel_Dashboard.Controls.Remove(this);
        }
    }
}
