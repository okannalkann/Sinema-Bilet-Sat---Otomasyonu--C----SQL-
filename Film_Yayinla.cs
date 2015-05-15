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
    public partial class Film_Yayinla : Form
    {
        public Film_Yayinla()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=EnSonSinemaBiletSatis;Integrated Security=True");

        void bilgiAl(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            con.Open();
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
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[2].ToString());
            }
            con.Close();
        }

        private void Film_Yayinla_Load(object sender, EventArgs e)
        {

            bilgiAl("SELECT * FROM Filmler", combo_Film_Adi);
            bilgiAl("SELECT * FROM Salonlar", combo_Film_Salon);
            bilgiAl("SELECT * FROM Seanslar", combo_Film_Seans);
        }
        
            bool kayitvarmi(string sorgu)
            {
                bool kayit=false;
                SqlCommand varmi=new SqlCommand(sorgu,con);
                SqlDataReader dr=varmi.ExecuteReader();
                while(dr.Read())
                kayit=true;//Kayıt Varsa True Olacaktır
                dr.Close();
                return kayit;
                }

                

        private void btn_film_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlParameter prm2 = new SqlParameter("@P2", combo_Film_Salon.Text);
                SqlParameter prm3 = new SqlParameter("@P3", combo_Film_Seans.Text);
                string sql = "select * from Yayinlanan_Filmler where Salon=@P2 and Seans=@P3";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add(prm3);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   MessageBox.Show("Bu seans doludur");

                    con.Close();
                }
                else
                {
                    string sql2 = "INSERT INTO Yayinlanan_Filmler(Film_Adi,Salon,Seans) VALUES('" + combo_Film_Adi.Text + "','" + combo_Film_Salon.Text + "','" + combo_Film_Seans.Text + "')";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(combo_Film_Adi.Text + " / " + combo_Film_Salon.Text + " / " + combo_Film_Seans.Text + " Filmi eklendi");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("HATA:" + EX.Message);
                throw;
            }
        }
        
    }
}
