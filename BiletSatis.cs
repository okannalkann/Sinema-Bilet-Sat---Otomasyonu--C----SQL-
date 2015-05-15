using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace Sinema_Bilet_Satis
{
    public partial class BiletSatis : Form
    {
        public BiletSatis()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        public string film_Adi="";
        public string salon_Adi="";
        public string seans="";
        public string salon_tarih;
        public int bilet_fiyat;
        int filmID = 0;
        int salonID = 0;
        ArrayList koltuklar = new ArrayList();
        ArrayList iptalKoltuk = new ArrayList();
        //
        public static string Yazdir_fiyat2;
        public static string Yazdir_koltuklar2;
        public static string Yazdir_film_adi;
        public static string Yazdir_salon_adi;
        public static string Yazdir_seans_adi;
        
        //
        public static string kasiyer_adi2;
        
        public static string satis_tarihi_bilet_yazdirma;
 
        Baslangic_Formu baslangc_form = new Baslangic_Formu();
        
        void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }
        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            
            if (((Button)sender).BackColor == Color.Lime) // yesil
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Add(((Button)sender).Text);
                    if (radioOgrenci.Checked == true)
                    {
                        bilet_fiyat += 10;
                        txtFiyat.Text = bilet_fiyat.ToString();
                    }
                    else if (radioTam.Checked == true)
                    {
                        bilet_fiyat += 12;
                        txtFiyat.Text = bilet_fiyat.ToString();
                    }

                }
                koltukYazdir();
            }
            else if (((Button)sender).BackColor == Color.Orange) // turuncu
            {
                ((Button)sender).BackColor = Color.Lime;
                if (koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Remove(((Button)sender).Text);
                    if (radioOgrenci.Checked == true)
                    {
                        bilet_fiyat += -10;
                        txtFiyat.Text = bilet_fiyat.ToString();
                    }
                    else if (radioTam.Checked == true)
                    {
                        bilet_fiyat += -12;
                        txtFiyat.Text = bilet_fiyat.ToString();
                    }
                }
                koltukYazdir();
            }
            else // kırmızı
            {
                if (!iptalKoltuk.Contains(((Button)sender).Text))
                {
                    iptalKoltuk.Add(((Button)sender).Text);
                }
                else
                {
                    iptalKoltuk.Remove(((Button)sender).Text);
                }

                string koltuk = "";
                for (int i = 0; i < iptalKoltuk.Count; i++)
                {
                    koltuk += iptalKoltuk[i].ToString() + ",";
                }
                if (iptalKoltuk.Count >= 1)
                {
                    koltuk = koltuk.Remove(koltuk.Length - 1, 1);
                }
                txtKoltukIptal.Text = koltuk;
            }
        }

        void koltukYazdir()
        {
            string koltuk = "";
            for (int i = 0; i < koltuklar.Count; i++)
            {
                koltuk += koltuklar[i].ToString() + ",";
            }
            if (koltuklar.Count >= 1)
            {
                koltuk = koltuk.Remove(koltuk.Length - 1, 1);
            }
            txtKoltuk.Text = koltuk;
        }
        private void BiletSatis_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled=false;
            
            groupBox1.Enabled = false;
            Saat_Gosterici.Start();
            txtFilmAdi.Text = film_Adi;
            txtSalonAdi.Text = salon_Adi;
            txtSeans.Text = seans;
            dateTarih.Text = FilmSec.satis_tarihi;
            kasiyer_adi2 = Baslangic_Formu.kasiyer_adi;
            Yazdir_film_adi = film_Adi;
            dateTarih.Text = FilmSec.satis_tarihi;
            Yazdir_salon_adi = salon_Adi;
            Yazdir_seans_adi = seans;
            satis_tarihi_bilet_yazdirma = dateTarih.Text;
            filmID = Convert.ToInt32(araGetir("SELECT * FROM Filmler WHERE Film_Adi='" + film_Adi + "'"));
            salonID = Convert.ToInt32(araGetir("SELECT * FROM Salonlar WHERE Salon_Adi='" + salon_Adi + "'"));
            Dolu_Koltuk();
            Rezerve();
        }
        private void Saat_Gosterici_Tick(object sender, EventArgs e)
        {lblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();}
        string araGetir(string sql)
        {
            baglantiKur();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            oku.Read();
            string deger = oku[0].ToString();
            con.Close();
            return deger;
        }

        void biletAyir()
        {
            baglantiKur();
            for (int i = 0; i < koltuklar.Count; i++)
            {
                string sql = @"insert into Bilet_Satis(Ad_Soyad,Film_ID,Salon_ID,seans,Koltuklar,Tarih,Satis_Saati,Fiyat,Kasiyer_Adi)values
                (@Ad_Soyad,@Film_ID,@Salon_ID,@seans,@Koltuklar,@Tarih,@Satis_Saati,@Fiyat,@Kasiyer_Adi)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ad_Soyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@Film_ID", filmID);
                cmd.Parameters.AddWithValue("@Salon_ID", salonID);
                cmd.Parameters.AddWithValue("@seans", txtSeans.Text);
                this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Red;
                cmd.Parameters.AddWithValue("@Koltuklar", Convert.ToInt32(koltuklar[i]));
                cmd.Parameters.AddWithValue("@Tarih", dateTarih.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@Satis_Saati", lblSaat.Text);
                int Fiyat = 0;
                if (radioOgrenci.Checked == true)
                {
                    Fiyat = 10;
                }
                else if (radioTam.Checked == true)
                {
                    Fiyat = 12;
                }
                txtFiyat.Text = Fiyat.ToString();

                cmd.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);

                cmd.Parameters.AddWithValue("@Kasiyer_Adi", kasiyer_adi2);
                cmd.ExecuteNonQuery();
            }   con.Close();
        }
       
        
        private void BiletSat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKoltuk.Text != "")
                {
                    if (txtKoltuk.Text != "" && txtAdSoyad.Text != "")
                    {
                        biletAyir();
                        MessageBox.Show(txtAdSoyad.Text + " " + " bilgili kişinin " + txtKoltuk.Text + " no'lu koltukları ayrılmıştır");
                        Yazdir_koltuklar2 = txtKoltuk.Text;
                        Yazdir_fiyat2 = bilet_fiyat.ToString();
                        txtKoltuk.Text = "";
                        txtAdSoyad.Text = "";
                        txtFiyat.Text = "";
                        koltuklar.Clear();

                        yazdır yazdirma = new yazdır();
                        yazdirma.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tüm bilgileri eksiksiz doldurmalısınız.");
                    }
                }
                else
                {
                    MessageBox.Show("Koltuk numarasını seçmediniz.", "Dikkat");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        void Dolu_Koltuk()
        {
            baglantiKur();
            string sql = "SELECT * FROM Bilet_Satis WHERE Film_ID='" + filmID + "' AND Salon_ID='" + salonID + "' AND seans='" + seans + "'AND Tarih='" + dateTarih.Value.ToShortDateString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                string koltuk_No = oku[5].ToString();
                this.Controls.Find("btn" + koltuk_No, true)[0].BackColor = Color.Red;
            }
            con.Close();
        }
        void Rezerve()
        {
            
            baglantiKur();
            string sql = "SELECT * FROM Rezerve WHERE Film_ID='" + filmID + "' AND Salon_ID='" + salonID + "' AND seans='" + seans + "'AND Tarih='" + dateTarih.Value.ToShortDateString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                string koltuk_No = oku[5].ToString();
                this.Controls.Find("btn" + koltuk_No, true)[0].BackColor = Color.Pink;
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Rezervasyon_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKoltuk.Text != "")
                {
                    if (txtKoltuk.Text != "" && txtAdSoyad.Text != "")
                    {
                        biletRezerve();
                        MessageBox.Show(txtAdSoyad.Text + " " + " bilgili kişinin " + txtKoltuk.Text + " no'lu koltukları Rezerve Edilmiştir.");
                        txtKoltuk.Text = "";
                        txtAdSoyad.Text = "";
                        koltuklar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tüm bilgileri eksiksiz doldurmalısınız.");
                    }
                }
                else
                {
                    MessageBox.Show("Koltuk numarasını seçmediniz.", "Dikkat");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message+".");
                throw;
            }
           
        }
    
        void biletRezerve()
        {
            baglantiKur();
            for (int i = 0; i < koltuklar.Count; i++)
            {
                string sql = @"insert into Rezerve(Ad_Soyad,Film_ID,Salon_ID,seans,Koltuklar,Tarih,Satis_Saati,Fiyat)values(@Ad_Soyad,@Film_ID,@Salon_ID,@seans,@Koltuklar,@Tarih,@Satis_Saati,@Fiyat)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ad_Soyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@Film_ID", filmID);
                cmd.Parameters.AddWithValue("@Salon_ID", salonID);
                cmd.Parameters.AddWithValue("@seans", txtSeans.Text);
                this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Pink;
                cmd.Parameters.AddWithValue("@Koltuklar", Convert.ToInt32(koltuklar[i]));
                cmd.Parameters.AddWithValue("@Tarih", dateTarih.Text);
                cmd.Parameters.AddWithValue("@Satis_Saati", lblSaat.Text);
                int Fiyat = 0;
                if (radioOgrenci.Checked == true)
                {
                    Fiyat = 10 ;

                }
                else if (radioTam.Checked == true)
                {
                    Fiyat = 12 * i;  
                }
                txtFiyat.Text = Fiyat.ToString();
                cmd.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);
                cmd.ExecuteNonQuery();
                
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilmSec fs = new FilmSec();
            fs.Show();
            
        }
        private void Bilet_Iptal_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtKoltukIptal.Text != "")
                {
                    baglantiKur();
                    for (int i = 0; i < iptalKoltuk.Count; i++)
                    {
                        string sql = "DELETE FROM Bilet_Satis WHERE Koltuklar=" + Convert.ToInt32(iptalKoltuk[i]);
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        this.Controls.Find("btn" + iptalKoltuk[i].ToString(), true)[0].BackColor = Color.Lime;
                    }

                    con.Close();
                    iptalKoltuk.Clear();
                    MessageBox.Show(txtKoltuk.Text + " koltuk numaraları bileti iptal edilmiştir.");
                    txtKoltukIptal.Text = "";
                    txtAdSoyad.Text = "";

                }
                else
                {
                    MessageBox.Show("Koltuk numarasını seçmediniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message + ".");
                throw;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Open();
                }
                baglantiKur();
                string sql2 = "SELECT * FROM Rezerve WHERE Film_ID='" + filmID + "' AND Salon_ID='" + salonID + "' AND seans='" + seans + "'AND Tarih='" + dateTarih.Value.ToShortDateString() + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataReader oku5 = cmd2.ExecuteReader();
                while (oku5.Read())
                {
                    if (Convert.ToDateTime(oku5[7].ToString()).AddMinutes(15) >= DateTime.Now)
                    {
                        MessageBox.Show(oku5[1].ToString() + "  Kişinin  " + oku5[6].ToString() + "  Tarihli " + oku5[5] + " Koltuklarının Rezervesi dolmak üzere");
                    }
                    else
                    {

                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                throw;
            }
            
            
        }

        private void rezerve_iptal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKoltukIptal.Text != "")
                {
                    baglantiKur();
                    for (int i = 0; i < iptalKoltuk.Count; i++)
                    {
                        string sql = "DELETE FROM Rezerve WHERE Koltuklar=" + Convert.ToInt32(iptalKoltuk[i]);
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        this.Controls.Find("btn" + iptalKoltuk[i].ToString(), true)[0].BackColor = Color.Lime;
                    }

                    con.Close();
                    iptalKoltuk.Clear();
                    MessageBox.Show(txtKoltuk.Text + " koltuk numaraları bileti iptal edilmiştir.");
                    txtKoltukIptal.Text = "";
                    txtAdSoyad.Text = "";

                }
                else
                {
                    MessageBox.Show("Koltuk numarasını seçmediniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message + ".");
                throw;
            }
           
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void radioOgrenci_Click(object sender, EventArgs e)
        {
            if (radioOgrenci.Checked == true)
            {
                groupBox1.Enabled = true;
            }

        }

        private void radioTam_Click(object sender, EventArgs e)
        {
            if (radioTam.Checked == true)
            {
                groupBox1.Enabled = true;
            }
        }
    }
    
 
    }

