using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace POS_Galaxy.User_Controls
{
    public partial class momopay : UserControl
    {
        private string Total;
        public momopay(string total)
        {
            InitializeComponent();
            Total = total.Replace(",", "");
         
        }


        private Image ResizeImage(Image img, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_height, new_width);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.DrawImage(img, 0, 0, new_width, new_height);
            return new_image;
        }

        private void momopay_Load(object sender, EventArgs e)
        {
            string qrcode_text = $"2|99|0985029643|Nguyen Van Duan|duannguyen242@gmail.com|0|0|{Total}";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 200, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);
            Bitmap logo = ResizeImage(Properties.Resources.MoMo_Logo, 35, 35) as Bitmap;
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            guna2PictureBox1.Image = bitmap;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
