using CefSharp;
using CefSharp.WinForms;
using System;
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
    public partial class test : Form
    {
        private ChromiumWebBrowser webBrowser;
        public test()
        {
            InitializeComponent();
            // Khởi tạo trình duyệt web nhúng
            Cef.Initialize(new CefSettings());

            // Tạo và cấu hình trình duyệt web
            webBrowser = new ChromiumWebBrowser();
            webBrowser.Dock = DockStyle.Fill;

            // Thêm trình duyệt web vào Form
            Controls.Add(webBrowser);

            // Tải trang web chứa video YouTube
            string videoId = "5AsJJl7Bhvc";
            string embedUrl = $"https://www.youtube.com/embed/{videoId}";
            webBrowser.Load(embedUrl);
        }
    }
}
