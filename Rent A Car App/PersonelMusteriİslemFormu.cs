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
    public partial class PersonelMusteriİslemFormu : MetroFramework.Forms.MetroForm
    {   
        int Cust_ID = 0;
        string Cust_TC = null;
        string Cust_Name = null;
        string Cust_LName = null;
        string Cust_Passw = null;
        string Cust_Phone = null;

        
        public PersonelMusteriİslemFormu()
        {
            InitializeComponent();

            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                nitelik.SubItems.Add(reader["TCKN"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());
                

                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDyeGoreAramaFormu formum = new IDyeGoreAramaFormu();
            if( formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_ID = formum.id;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_ID=@ID", baglantim);
                cmd.Parameters.AddWithValue("@ID", Cust_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    listView1.Items.Clear();
                    ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                    nitelik.SubItems.Add(reader["TCKN"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());


                    listView1.Items.Add(nitelik);


                }
                else
                {
                    MessageBox.Show(Cust_ID+ " Bu ID ye sahip bir müşteri yok!","Hatalı ID",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                reader.Close();
                baglantim.Close();
            }
            
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                nitelik.SubItems.Add(reader["TCKN"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());


                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TCyeGoreAramaFormu formum = new TCyeGoreAramaFormu();
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_TC = formum.tc;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE TCKN=@TC", baglantim);
                cmd.Parameters.AddWithValue("@TC", Cust_TC);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    listView1.Items.Clear();
                    ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                    nitelik.SubItems.Add(reader["TCKN"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());


                    listView1.Items.Add(nitelik);


                }
                else
                {
                    MessageBox.Show(Cust_TC + " Bu TC ye sahip bir müşteri yok!", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                baglantim.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdGoreAramaFormu formum = new AdGoreAramaFormu();
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_Name = formum.ad;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_Adi=@NAME", baglantim);
                cmd.Parameters.AddWithValue("@NAME", Cust_Name);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    listView1.Items.Clear();
                    ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                    nitelik.SubItems.Add(reader["TCKN"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());


                    listView1.Items.Add(nitelik);


                }
                else
                {
                    MessageBox.Show(Cust_Name + " Bu ad bilgisine sahip bir müşteri yok!", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                baglantim.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoyadGoreAramaFormu formum = new SoyadGoreAramaFormu();
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_LName = formum.soyad;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_Soyadi=@LNAME", baglantim);
                cmd.Parameters.AddWithValue("@LNAME", Cust_LName);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    listView1.Items.Clear();
                    ListViewItem nitelik = new ListViewItem(reader["Musteri_ID"].ToString());
                    nitelik.SubItems.Add(reader["TCKN"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Soyadi"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Sifre"].ToString());
                    nitelik.SubItems.Add(reader["Musteri_Telefon"].ToString());


                    listView1.Items.Add(nitelik);


                }
                else
                {
                    MessageBox.Show(Cust_Name + " Bu soyad bilgisine sahip bir müşteri yok!", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                baglantim.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SifreGuncelleFormu formum = new SifreGuncelleFormu();
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_ID = formum.id;
                this.Cust_Passw = formum.newPassw;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_ID=@ID", baglantim);
                cmd.Parameters.AddWithValue("@ID", Cust_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {   
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand("UPDATE Musteriler SET Musteri_Sifre=@NEWPASSW WHERE Musteri_ID=@ID", baglantim);
                    cmd2.Parameters.AddWithValue("@NEWPASSW", Cust_Passw);
                    cmd2.Parameters.AddWithValue("@ID", Cust_ID);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show(Cust_ID + " Bu ID bilgisine sahip müşterinin şifresi "+Cust_Passw+" olarak güncellendi.", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand cmd3 = new SqlCommand("SELECT * FROM Musteriler", baglantim);

                    SqlDataReader reader2 = cmd3.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader2.Read())
                    {
                        ListViewItem nitelik = new ListViewItem(reader2["Musteri_ID"].ToString());
                        nitelik.SubItems.Add(reader2["TCKN"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Adi"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Soyadi"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Sifre"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Telefon"].ToString());


                        listView1.Items.Add(nitelik);


                    }
                    reader2.Close();
                    

                }
                else
                {
                    reader.Close();
                    MessageBox.Show(Cust_ID + " Bu ID bilgisine sahip bir müşteri olamdığı için işlem yapılmadı.", "Hatalı ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglantim.Close();
            }
        }

        private void islemlerButonu_Click(object sender, EventArgs e)
        {
            TelGuncelleFormu formum = new TelGuncelleFormu();
            if (formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cust_ID = formum.id;
                this.Cust_Phone = formum.newPhone;

                SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                baglantim.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_ID=@ID", baglantim);
                cmd.Parameters.AddWithValue("@ID", Cust_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand("UPDATE Musteriler SET Musteri_Telefon=@NEWPHONE WHERE Musteri_ID=@ID", baglantim);
                    cmd2.Parameters.AddWithValue("@NEWPHONE", Cust_Phone);
                    cmd2.Parameters.AddWithValue("@ID", Cust_ID);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show(Cust_ID + " Bu ID bilgisine sahip müşterinin telefon numarası\n" + Cust_Phone + " olarak güncellendi.", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand cmd3 = new SqlCommand("SELECT * FROM Musteriler", baglantim);

                    SqlDataReader reader2 = cmd3.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader2.Read())
                    {
                        ListViewItem nitelik = new ListViewItem(reader2["Musteri_ID"].ToString());
                        nitelik.SubItems.Add(reader2["TCKN"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Adi"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Soyadi"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Sifre"].ToString());
                        nitelik.SubItems.Add(reader2["Musteri_Telefon"].ToString());


                        listView1.Items.Add(nitelik);


                    }
                    reader2.Close();


                }
                else
                {
                    reader.Close();
                    MessageBox.Show(Cust_ID + " Bu ID bilgisine sahip bir müşteri olamdığı için işlem yapılmadı.", "Hatalı ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglantim.Close();
            }
        }
    }
}
