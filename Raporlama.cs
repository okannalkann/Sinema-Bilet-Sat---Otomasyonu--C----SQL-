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
    public partial class Raporlama : Form
    {
        public Raporlama()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        public string Film_Adi__;
        int Film_ID;
        private void Raporlama_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EnSonSinemaBiletSatisDataSet.Bilet_Satis' table. You can move, or remove it, as needed.
            this.Bilet_SatisTableAdapter.Fill(this.EnSonSinemaBiletSatisDataSet.Bilet_Satis);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Bilet_Satis", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CrystalReport1 orpt = new CrystalReport1();
            orpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = orpt;
            con.Close();
            
        }
        void bilgiAl(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[0].ToString());
            }
            con.Close();
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            bilgiAl("Select Adi from Personeller", comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Length < 0)
                {
                    MessageBox.Show("Kasiyer Seçmediniz");
                }
                else
                {
                    con.Open();
                    string sql = "select * FROM Bilet_Satis WHERE Kasiyer_adi='" + comboBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    CrystalReport1 orpt = new CrystalReport1();
                    orpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = orpt;
                    con.Close();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("HATA" + EX.Message);
                throw;
            }
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sorgu = new SqlCommand("Select * from Bilet_Satis where Tarih BETWEEN '" + dateTimePicker1.Value.Day + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Year + "' AND '" + dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year + "'", con);
                //SqlCommand sorgu =new SqlCommand("Select * from Bilet_Satis where Tarih BETWEEN '" + dateTimePicker1.Value.ToShortDateString()+"' AND '" + dateTimePicker2.Value.ToShortDateString()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CrystalReport1 oRpt = new CrystalReport1();
                oRpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = oRpt;
                con.Close();


            }
            catch (Exception EX)
            {
                MessageBox.Show("HATA" + EX.Message);
                throw;
            }
        }
            void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            YonetimFormu yf = new YonetimFormu();
            yf.Show();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            bilgiAl("Select Film_Adi from Filmler", comboBox2);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try 
	        {
                if (comboBox2.Text.Length < 0)
        {
            MessageBox.Show("Film Seçmediniz");
        }
        else
        {
            Film_Adi__ = comboBox2.Text;
            Film_ID = Convert.ToInt32(araGetir("SELECT * FROM Filmler WHERE Film_Adi='" + Film_Adi__ + "'"));
            con.Open();
            string sql = "select * FROM Bilet_Satis WHERE Film_ID='" + Film_ID + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CrystalReport1 orpt = new CrystalReport1();
            orpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = orpt;
            con.Close();
        }
	}
	catch (Exception ex)
	{
        MessageBox.Show("HATA" + ex.Message);
		throw;
	}
        }
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
    }
}
