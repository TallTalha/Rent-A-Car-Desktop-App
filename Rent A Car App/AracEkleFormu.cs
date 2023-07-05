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
    
    public partial class AracEkleFormu :  MetroFramework.Forms.MetroForm
    {
        public string plaka { get; set; }
        
        public string marka { get; set; }
        public string marka_id { get; set; }

        public string model { get; set; }
        public string model_id { get; set; }
        public string sinif { get; set; }
        public string sinif_id { get; set; }

        public string vites { get; set; }
        public string vites_id { get; set; }
        public string yakit { get; set; }
        public string yakit_id { get; set; }
        public AracEkleFormu()
        {
            InitializeComponent();

            
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT Marka_Adi FROM Araba_Markalari", baglantim);
            SqlDataReader reader = cmd2.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Marka_Adi"]);
            }
            baglantim.Close();

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) comboBox2.Enabled = false;
            else
            {
                model_id = null;
                comboBox2.Items.Clear();
                comboBox2.Enabled = true;
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();

                marka = comboBox1.SelectedItem.ToString();
                SqlCommand cmd1 = new SqlCommand("SELECT Marka_ID from Araba_Markalari where Marka_Adi=@Marka",baglantim);
                cmd1.Parameters.AddWithValue("@Marka", marka);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    marka_id = reader["Marka_ID"].ToString();
                }
                
                reader.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Araba_Modelleri WHERE Marka_ID="+marka_id, baglantim);
                
                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["Model_Adi"]);
                    model_id += reader["Model_ID"].ToString() + ",";
                }
                baglantim.Close();
                
            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) comboBox4.Enabled = false;
            else
            {
                sinif_id = null;
                comboBox4.Items.Clear();
                comboBox4.Enabled = true;
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();

                
                SqlCommand cmd1 = new SqlCommand("SELECT Sinif_ID FROM Modeller_ve_Siniflar WHERE Model_ID IN ("+ model_id+")", baglantim);
                
                SqlDataReader reader = cmd1.ExecuteReader();
               
                while (reader.Read())
                {
                    sinif_id += reader["Sinif_ID"].ToString()+",";
                   
                }
                reader.Close();
                
                SqlCommand cmd2 = new SqlCommand("SELECT Sinif_Adi FROM Araba_Siniflari WHERE Sinif_ID IN ("+sinif_id.Remove(sinif_id.Length-1)+") ", baglantim);
                
                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    comboBox4.Items.Add(reader["Sinif_Adi"]);
                }
                baglantim.Close();
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1) comboBox3.Enabled = false;
            else
            {
                vites_id = null;
                comboBox3.Items.Clear();
                comboBox3.Enabled = true;
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();

                
                SqlCommand cmd1 = new SqlCommand("SELECT Vites_ID FROM Modeller_ve_Siniflar WHERE  Model_ID IN (" + model_id+")", baglantim);
                
                SqlDataReader reader = cmd1.ExecuteReader();
                
                while (reader.Read())
                {
                    vites_id += reader["Vites_ID"].ToString() + ",";
                    
                }
                reader.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT Vites_Adi FROM Vites_Tipleri WHERE Vites_ID IN ("+vites_id.Remove(vites_id.Length-1)+") ", baglantim);
                
                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    comboBox3.Items.Add(reader["Vites_Adi"]);
                }
                baglantim.Close();
            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                comboBox5.Enabled = false;
                
            }
            else
            {
                yakit_id = null;
                comboBox5.Items.Clear();
                comboBox5.Enabled = true;
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();


                SqlCommand cmd1 = new SqlCommand("SELECT Yakit_ID FROM Modeller_ve_Siniflar WHERE Model_ID IN (" + model_id + ")", baglantim);

                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    yakit_id += reader["Yakit_ID"].ToString() + ",";

                }

                reader.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT Yakit_Adi FROM Yakit_Tipleri WHERE Yakit_ID IN (" + yakit_id.Remove(yakit_id.Length - 1) + ") ", baglantim);

                reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    comboBox5.Items.Add(reader["Yakit_Adi"]);
                }
                baglantim.Close();
            }
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            model = comboBox2.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Model_ID FROM Araba_Modelleri WHERE Model_Adi='"+comboBox2.SelectedItem.ToString()+"'",baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            model_id = reader["Model_ID"].ToString();
            reader.Close();
            baglantim.Close();
        }
        public bool buPlakaVarMi(string _plaka)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Plaka FROM Arabalar WHERE Plaka='"+_plaka+"'",baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                baglantim.Close();
                return true;
            }
            else { 
                baglantim.Close();
                return false;
            }
           


        }
        private bool secimlerYapildiMi()
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1) return true;
            else return false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 7 || textBox1.Text.Length > 8 )
            {
                MessageBox.Show("Plak bilgisini doğru uzunlukta girin!", "Plaka Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if(!secimlerYapildiMi()) MessageBox.Show("Bütün Alanlar Seçilmiş Olmalı!", "Seçimleri Yapın", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                plaka = textBox1.Text.ToUpper();
                if (!buPlakaVarMi(plaka))
                {
                    SqlCommand cmd = new SqlCommand("EXEC insertVehicle '" + plaka + "'," + marka_id + "," + model_id + "," + sinif_id + "," + vites_id + "," + yakit_id, baglantim);
                    cmd.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show("Kayıt Başarılı. Bilgiler;\n -Plaka: " + plaka + "'\n-Marka: " + marka + "\n-Model: " + model + "\n-Sınıf: " + sinif + "\n-Vites Tipi: " + vites + "\n-Yakıt Tipi: " + yakit, "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show(plaka + " Bu plaka zaten sistemde kayıtlı!", "Plaka Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            marka = comboBox1.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Marka_ID FROM Araba_Markalari WHERE Marka_Adi='" + comboBox1.SelectedItem.ToString() + "'", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            marka_id = reader["Marka_ID"].ToString();
            reader.Close();
            baglantim.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            sinif = comboBox4.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Sinif_ID FROM Araba_Siniflari WHERE Sinif_Adi='" + comboBox4.SelectedItem.ToString() + "'", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            sinif_id = reader["Sinif_ID"].ToString();
            reader.Close();
            baglantim.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            vites = comboBox3.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Vites_ID FROM Vites_Tipleri WHERE Vites_Adi='" + comboBox3.SelectedItem.ToString() + "'", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            vites_id = reader["Vites_ID"].ToString();
            reader.Close();
            baglantim.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            yakit = comboBox5.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Yakit_ID FROM Yakit_Tipleri WHERE Yakit_Adi='" + comboBox5.SelectedItem.ToString() + "'", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            yakit_id = reader["Yakit_ID"].ToString();
            reader.Close();
            baglantim.Close();
        }
    }
}
