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
    public partial class Film_Yayindan_Kaldir : Form
    {
        public Film_Yayindan_Kaldir()
        {
            InitializeComponent();
        }  SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");
        void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        void FilmleriGetir()
        {
            baglantiKur();
            string kayit = "SELECT * from Yayinlanan_Filmler";
            SqlCommand komut = new SqlCommand(kayit, con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Film_Yayindan_Kaldir_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter("select * from Yayinlanan_Filmler", con);
            DataSet dtSet2 = new DataSet();
            dtAdapter2.Fill(dtSet2, "Yayinlanan_Filmler");
            dataGridView1.DataSource = dtSet2.Tables["Yayinlanan_Filmler"];
            FilmleriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantiKur();
                string kayit = "Delete From Yayinlanan_Filmler where Film_ID='" + txt_FilmID.Text + "'";
                SqlCommand komut = new SqlCommand(kayit, con);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Film Yayından Kaldırıldı.");
                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from Yayinlanan_Filmler", con);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "Yayinlanan_Filmler");
                dataGridView1.DataSource = dtSet.Tables["Yayinlanan_Filmler"];
            }
            catch (Exception EX)
            {
                MessageBox.Show("HATA" + EX.Message);
                throw;
            }


        }
        void filmleri_cek()
        {
            baglantiKur();

            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandText = "Select * from Yayinlanan_Filmler";
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                dr.Dispose();
                komut.Dispose();
                con.Close();
                txt_FilmID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            }
            else
            {
                komut.Dispose();
                con.Close();
                dr.Dispose();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            filmleri_cek();
        }
    }
}
