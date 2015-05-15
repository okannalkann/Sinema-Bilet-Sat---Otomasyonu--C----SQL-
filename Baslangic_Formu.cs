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
    public partial class Baslangic_Formu : Form
    {
        public Baslangic_Formu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        public static string kasiyer_adi;
        public void btnPersonelGiris_Click(object sender, EventArgs e)
        {
            try
            {
                LblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();
               if(radio_personel.Checked==true)
               {
       
                con.Open();
                SqlParameter prm1 = new SqlParameter("@P1", txt_kullanici_Adi.Text);
                SqlParameter prm2 = new SqlParameter("@P2", txt_Sifre.Text);
                string sql = "select * FROM Personeller WHERE k_adi=@P1 and sifre=@P2";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                kasiyer_adi = txt_kullanici_Adi.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    {
                    
                    MessageBox.Show("Giriş Başarılı.. Hoşgeldin " + txt_kullanici_Adi.Text);
                    this.Hide();
                    Form Filmler = new FilmSec();
                    Filmler.ShowDialog();
                    con.Close();
                    }
                    else
                    {
                    MessageBox.Show("Veritabanında böyle bir kullanıcı bulunamadı");
                    con.Close();
                    }con.Close();
               }
               if (radio_Yonetim.Checked == true)
               {
                   LblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();
                   con.Open();
                   SqlParameter prm1 = new SqlParameter("@P1", txt_kullanici_Adi.Text);
                   SqlParameter prm2 = new SqlParameter("@P2", txt_Sifre.Text);
                   string sql = "select * FROM Yonetim_Calisani WHERE k_adi=@P1 and sifre=@P2";
                   SqlCommand cmd = new SqlCommand(sql, con);
                   cmd.Parameters.Add(prm1);
                   cmd.Parameters.Add(prm2);
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   if (dt.Rows.Count > 0)
                   {

                       MessageBox.Show("Giriş Başarılı.. Hoşgeldin " + txt_kullanici_Adi.Text);
                       Form YonetimFormu = new YonetimFormu();
                       this.Hide();
                       YonetimFormu.ShowDialog();
                       con.Close();

                   }
                   else
                   {
                       MessageBox.Show("Veritabanında böyle bir kullanıcı bulunamadı");

                       con.Close();
                   }
                   con.Close();
               }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        SqlConnection bag = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True");

        private void restoreet()
        {
            bag.Open();
            SqlCommand sorgual = new SqlCommand("RESTORE DATABASE [EnSonSinemaBiletSatis] FROM  DISK = N'C:\\Program Files (x86)\\database\\EnSonSinemaBiletSatis.bak' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10", bag);
            sorgual.ExecuteNonQuery();
            bag.Close();
        }
        private void btnPersonelCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        private void Saat_Gosterici_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            txt_kullanici_Adi.Focus();
            Saat_Gosterici.Start();
            try
            {
                restoreet();
            }
            catch (Exception)
            {
                restoreet();
               
            }
        }

        private void txtPer_K_Adi_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                {
                    txt_Sifre.Focus();
                }
            
        }

        private void txt_Per_Sifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                        if (radio_personel.Checked == true)
                        {
                            if (e.KeyCode == Keys.Enter)
                            {
                                try
                                {

                                    LblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();
                                    con.Open();
                                    SqlParameter prm1 = new SqlParameter("@P1", txt_kullanici_Adi.Text);
                                    SqlParameter prm2 = new SqlParameter("@P2", txt_Sifre.Text);
                                    string sql = "select * FROM Personeller WHERE k_adi=@P1 and sifre=@P2";
                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    cmd.Parameters.Add(prm1);
                                    cmd.Parameters.Add(prm2);
                                    kasiyer_adi = txt_kullanici_Adi.Text;
                                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {

                                        MessageBox.Show("Giriş Başarılı.. Hoşgeldin " + txt_kullanici_Adi.Text);
                                        Form Filmler = new FilmSec();
                                        Filmler.ShowDialog();
                                        con.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Veritabanında böyle bir kullanıcı bulunamadı");
                                        con.Close();
                                    } con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    con.Close();
                                }
                            }
                        }
                        else if (radio_Yonetim.Checked == true)
                        {
                            LblSaat.Text = (DateTime.Now.Hour) + ":" + (DateTime.Now.Minute) + ":" + (DateTime.Now.Second).ToString();
                            con.Open();
                            SqlParameter prm1 = new SqlParameter("@P1", txt_kullanici_Adi.Text);
                            SqlParameter prm2 = new SqlParameter("@P2", txt_Sifre.Text);
                            string sql = "select * FROM Yonetim_Calisani WHERE k_adi=@P1 and sifre=@P2";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.Add(prm1);
                            cmd.Parameters.Add(prm2);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                MessageBox.Show("Giriş Başarılı.. Hoşgeldin " + txt_kullanici_Adi.Text);
                                Form YonetimFormu = new YonetimFormu();
                                YonetimFormu.ShowDialog();
                                con.Close();

                            }
                            else
                            {
                                MessageBox.Show("Veritabanında böyle bir kullanıcı bulunamadı");

                                con.Close();
                            }
                            con.Close();
                        }
                    }
                }
            }
 
    }

