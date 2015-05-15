using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sinema_Bilet_Satis
{
    public partial class FilmSec : Form
    {
        public FilmSec()
        {
            InitializeComponent();
        }
        public static string film_Adi;
        public static string salon_Adi;
        public static string seans;
        public static string satis_tarihi;
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        private void FilmSec_Load(object sender, EventArgs e)
        {

        }
        void bilgiAl(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            baglantiKur();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[1].ToString());
            }
            con.Close();
        }
        void bilgiAl2(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            baglantiKur();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[2].ToString());
            }
            con.Close();
        }
        void bilgiAl3(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            baglantiKur();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[3].ToString());
            }
            con.Close();
        }
        private void comboSeans_Click(object sender, EventArgs e)
        {
            bilgiAl3("SELECT * FROM Yayinlanan_Filmler where Film_Adi='" + comboFilmAdi.Text + "'", comboSeans);
        }

        void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void comboFilmAdi_Click(object sender, EventArgs e)
        {
            bilgiAl("SELECT * FROM Yayinlanan_Filmler", comboFilmAdi);
        }

        private void comboSalonAdi_Click(object sender, EventArgs e)
        {
            bilgiAl2("SELECT * FROM Yayinlanan_Filmler where Film_Adi='" + comboFilmAdi.Text + "'", comboSalonAdi);
           
        }
        private void Bilet_Al_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboSalonAdi.SelectedIndex != -1 && comboFilmAdi.SelectedIndex != -1 && comboSeans.SelectedIndex != -1)
                {
                    BiletSatis Bilet_Satis = new BiletSatis();
                    Bilet_Satis.film_Adi = comboFilmAdi.Text;
                    Bilet_Satis.salon_Adi = comboSalonAdi.Text;
                    Bilet_Satis.seans = comboSeans.Text;
                    Bilet_Satis.salon_tarih = dateTimePicker1.Value.ToShortDateString();
                    satis_tarihi = dateTimePicker1.Value.ToShortDateString();
                    this.Hide();
                    Bilet_Satis.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen film bilgilerini eksiksiz doldurunuz.");
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message+".");
                throw;
            }
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baslangic_Formu bas = new Baslangic_Formu();
            bas.Show();
        }
    }
}
