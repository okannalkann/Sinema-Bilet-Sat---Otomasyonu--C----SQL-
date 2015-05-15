using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Sinema_Bilet_Satis
{
    public partial class yazdır : Form
    {
        public yazdır()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void yazdır_Load(object sender, EventArgs e)
        {
            con.Open();
            biletkes_filmadi.Text = BiletSatis.Yazdir_film_adi;
            biletkes_salon.Text = BiletSatis.Yazdir_salon_adi;
            biletkes_fiyat.Text = BiletSatis.Yazdir_fiyat2;
            biletkes_koltuklar.Text = BiletSatis.Yazdir_koltuklar2;
            biletkes_tarih.Text = BiletSatis.satis_tarihi_bilet_yazdirma;
            biletkes_seans.Text = BiletSatis.Yazdir_seans_adi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                CaptureScreen();             
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
