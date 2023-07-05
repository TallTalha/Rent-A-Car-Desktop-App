using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rent_A_Car_App
{
    public partial class PersonelAracİslemleriFormu : MetroFramework.Forms.MetroForm
    {
        public string Plate = null;
        public string Durum = null;
        public PersonelAracİslemleriFormu()
        {
            InitializeComponent();

            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ButunAraclarınTablosu", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Plaka"].ToString());
                nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Durum"].ToString());


                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ButunAraclarınTablosu", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Plaka"].ToString());
                nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Durum"].ToString());


                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlakaGoreAramaFormu formum = new PlakaGoreAramaFormu("Plakaya Göre Arama Ekranı");
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Plate = formum.plaka;
                

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ButunAraclarınTablosu  WHERE Plaka=@PLATE", baglantim);
                cmd.Parameters.AddWithValue("@PLATE", Plate);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    listView1.Items.Clear();
                    ListViewItem nitelik = new ListViewItem(reader["Plaka"].ToString());
                    nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Durum"].ToString());


                    listView1.Items.Add(nitelik);


                }
                else
                {
                    MessageBox.Show(Plate + " Bu plakaya sahip bir araç yok!", "Hatalı Plaka!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                baglantim.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ButunAktifAraclarınTablosu", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Plaka"].ToString());
                nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Durum"].ToString());


                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ButunPasifAraclarınTablosu", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Plaka"].ToString());
                nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Durum"].ToString());


                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void islemlerButonu_Click(object sender, EventArgs e)
        {
            DurumGuncelle formum = new DurumGuncelle();
            
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Plate = formum.plaka;
                this.Durum = formum.durum;
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM ButunAraclarınTablosu  WHERE Plaka=@PLATE", baglantim);
                cmd2.Parameters.AddWithValue("@PLATE", Plate);
                SqlDataReader reader = cmd2.ExecuteReader();
                
                if (reader.Read())
                {
                    reader.Close();
                    SqlCommand cmd;
                    if (Durum == "Pasif")
                    {
                        cmd = new SqlCommand("EXEC changeStatePassiveAndUpdate @PLATE", baglantim);
                    }
                    else
                    {
                        cmd = new SqlCommand("EXEC changeStateActiveAndUpdate @PLATE", baglantim);
                    }
                    cmd.Parameters.AddWithValue("@PLATE", Plate);
                    cmd.ExecuteNonQuery();
                    button7_Click(sender, new EventArgs());


                }
                else
                {
                    MessageBox.Show(Plate + " Bu plakaya sahip bir araç yok!", "Hatalı Plaka!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglantim.Close();

            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AracEkleFormu formum = new AracEkleFormu();

            formum.ShowDialog();
           
        }
        public bool buPlakaVarMi(string _plaka)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Plaka FROM Arabalar WHERE Plaka='" + _plaka + "'", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                baglantim.Close();
                return true;
            }
            else
            {
                baglantim.Close();
                return false;
                
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            PlakaGoreAramaFormu formum = new PlakaGoreAramaFormu("Araç Silme Ekranı");
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Plate = formum.plaka;

                if (buPlakaVarMi(Plate))
                {
                    SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                    baglantim.Open();
                    SqlCommand cmd = new SqlCommand("DELETE  FROM Arabalar  WHERE Plaka=@PLATE", baglantim);
                    cmd.Parameters.AddWithValue("@PLATE", Plate);
                    cmd.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show(Plate + " Bu plakaya sahip bir araç kaydı silindi!", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Plate + " Bu plakaya sahip bir araç yok!", "Hatalı Plaka!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                
            }
        }
    }
}
