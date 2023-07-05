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
using System.Threading;

namespace Rent_A_Car_App
{
    public partial class MusteriFormu : MetroFramework.Forms.MetroForm
    {
        string tc = null;
        int id = 0;
        public MusteriFormu(string _adsoyad,string _tc, int _id)
        {
            InitializeComponent();
            string msg = "Hoş geldin " + _adsoyad;  // Müüşterinin karşılaşacağı ilk sayfa
            this.Text = msg;
            string adsoyad = _adsoyad;
            tc = _tc;
            id = _id;
            
            string saat = DateTime.Now.AddHours(1).ToLongTimeString();
            saatListesi1.SelectedItem = saat.Substring(0, 2) + ":00";
            saatListesi2.SelectedItem = saat.Substring(0, 2) + ":00";
            iadeTarihi.Value = DateTime.Now.AddDays(1);
            alisTarihi.Value = DateTime.Now.Date;
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi," +
                " MvS.Fiyat from Modeller_ve_Siniflar as MvS join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID join Araba_Markalari as" +
                " A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID join Vites_Tipleri as V_Tip on" +
                " MvS.Vites_ID = V_Tip.Vites_ID join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID where MvS.Pasif_Adet > 0", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Fiyat"].ToString());

                listView1.Items.Add(nitelik);


            }
            reader.Close();



            SqlCommand cmd1 = new SqlCommand("SELECT Sinif_Adi FROM Araba_Siniflari", baglantim);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {

                ListViewItem nitelik2 = new ListViewItem(reader1["Sinif_Adi"].ToString());

                sinifSecim.Items.Add(nitelik2); ;
            }

            reader1.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT Vites_Adi FROM Vites_Tipleri", baglantim);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                ListViewItem nitelik3 = new ListViewItem(reader2["Vites_Adi"].ToString());

                vitesSecim.Items.Add(nitelik3); ;

            }
            reader2.Close();
            SqlCommand cmd3 = new SqlCommand("SELECT Yakit_Adi FROM Yakit_Tipleri", baglantim);

            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                ListViewItem nitelik4 = new ListViewItem(reader3["Yakit_Adi"].ToString());

                yakitSecim.Items.Add(nitelik4);

            }
            reader3.Close();
            baglantim.Close();



        }

        private void MusteriFormu_Load(object sender, EventArgs e)
        {

        }

        private void alisTarihi_ValueChanged(object sender, EventArgs e)
        {
            iadeTarihi.Value = alisTarihi.Value.AddDays(1);
            DateTime alis = alisTarihi.Value;
            if (alis < DateTime.Now.Date)
            {
                alisTarihi.Value = DateTime.Now.Date;
                MessageBox.Show("Alış tarihi olarak, bugünün tarihinden daha önceki\nbir tarihi seçemezsiniz.","Geçersiz Seçim",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void saatListesi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime alis = alisTarihi.Value;
            saatListesi2.SelectedIndex = saatListesi1.SelectedIndex;
            string saat = DateTime.Now.AddHours(1).ToLongTimeString();
            int indexOfNow = saatListesi1.Items.IndexOf(saat.Substring(0, 2) + ":00");
            if (saatListesi1.SelectedIndex < indexOfNow && alis<=DateTime.Now.Date)
            {
                saatListesi1.SelectedIndex = indexOfNow;
                MessageBox.Show(DateTime.Now.ToLongTimeString()+" Şuanki saattin öncesinde olacak şekilde saat seçimi yapamazsınız.", "Geçersiz Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }




        private void araButonu_Click(object sender, EventArgs e)
        {

            
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();

            string siniflar = null;
            string yakitlar = null;
            string vitesler = null;
            if (sinifSecim.CheckedItems.Count > 0 && vitesSecim.CheckedItems.Count > 0 && yakitSecim.CheckedItems.Count > 0)
            {
                listView1.Items.Clear();
                for (int i = 0; i < sinifSecim.CheckedItems.Count; i++)
                {
                    string x = sinifSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    siniflar += "'" + x3 + "',";

                }
                siniflar = siniflar.Remove(siniflar.Length - 1);
                for (int i = 0; i < vitesSecim.CheckedItems.Count; i++)
                {
                    string x = vitesSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    vitesler += "'" + x3 + "',";

                }
                vitesler = vitesler.Remove(vitesler.Length - 1);
                for (int i = 0; i < yakitSecim.CheckedItems.Count; i++)
                {
                    string x = yakitSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    yakitlar += "'" + x3 + "',";

                }
                yakitlar = yakitlar.Remove(yakitlar.Length - 1);



                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and A_Snf.Sinif_Adi IN (" + siniflar + ") " +
                    "and V_Tip.Vites_Adi IN (" + vitesler + ") " +
                    "and Y_Tip.Yakit_Adi IN (" + yakitlar + ")", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count > 0 && vitesSecim.CheckedItems.Count > 0 && yakitSecim.CheckedItems.Count == 0)
            {
                listView1.Items.Clear();
                for (int i = 0; i < sinifSecim.CheckedItems.Count; i++)
                {
                    string x = sinifSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    siniflar += "'" + x3 + "',";

                }
                siniflar = siniflar.Remove(siniflar.Length - 1);
                for (int i = 0; i < vitesSecim.CheckedItems.Count; i++)
                {
                    string x = vitesSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    vitesler += "'" + x3 + "',";

                }
                vitesler = vitesler.Remove(vitesler.Length - 1);




                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and A_Snf.Sinif_Adi IN (" + siniflar + ") " +
                    "and V_Tip.Vites_Adi IN (" + vitesler + ") ", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count > 0 && vitesSecim.CheckedItems.Count == 0 && yakitSecim.CheckedItems.Count > 0)
            {
                listView1.Items.Clear();
                for (int i = 0; i < sinifSecim.CheckedItems.Count; i++)
                {
                    string x = sinifSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    siniflar += "'" + x3 + "',";

                }
                siniflar = siniflar.Remove(siniflar.Length - 1);

                for (int i = 0; i < yakitSecim.CheckedItems.Count; i++)
                {
                    string x = yakitSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    yakitlar += "'" + x3 + "',";

                }
                yakitlar = yakitlar.Remove(yakitlar.Length - 1);



                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and A_Snf.Sinif_Adi IN (" + siniflar + ") +" +
                    "and Y_Tip.Yakit_Adi IN (" + yakitlar + ")", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count == 0 && vitesSecim.CheckedItems.Count > 0 && yakitSecim.CheckedItems.Count > 0)
            {

                listView1.Items.Clear();
                for (int i = 0; i < vitesSecim.CheckedItems.Count; i++)
                {
                    string x = vitesSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    vitesler += "'" + x3 + "',";

                }
                vitesler = vitesler.Remove(vitesler.Length - 1);
                for (int i = 0; i < yakitSecim.CheckedItems.Count; i++)
                {
                    string x = yakitSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    yakitlar += "'" + x3 + "',";

                }
                yakitlar = yakitlar.Remove(yakitlar.Length - 1);



                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and V_Tip.Vites_Adi IN (" + vitesler + ") " +
                    "and Y_Tip.Yakit_Adi IN (" + yakitlar + ")", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count > 0 && vitesSecim.CheckedItems.Count == 0 && yakitSecim.CheckedItems.Count == 0)
            {
                listView1.Items.Clear();
                for (int i = 0; i < sinifSecim.CheckedItems.Count; i++)
                {
                    string x = sinifSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    siniflar += "'" + x3 + "',";

                }
                siniflar = siniflar.Remove(siniflar.Length - 1);




                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and A_Snf.Sinif_Adi IN (" + siniflar + ") ", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count == 0 && vitesSecim.CheckedItems.Count > 0 && yakitSecim.CheckedItems.Count == 0)
            {

                listView1.Items.Clear();
                for (int i = 0; i < vitesSecim.CheckedItems.Count; i++)
                {
                    string x = vitesSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    vitesler += "'" + x3 + "',";

                }
                vitesler = vitesler.Remove(vitesler.Length - 1);




                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and V_Tip.Vites_Adi IN (" + vitesler + ") ", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else if (sinifSecim.CheckedItems.Count == 0 && vitesSecim.CheckedItems.Count == 0 && yakitSecim.CheckedItems.Count > 0)
            {

                listView1.Items.Clear();
                for (int i = 0; i < yakitSecim.CheckedItems.Count; i++)
                {
                    string x = yakitSecim.CheckedItems[i].ToString();
                    string x2 = x.Remove(0, 15);
                    string x3 = x2.Remove(x2.Length - 1);
                    yakitlar += "'" + x3 + "',";

                }
                yakitlar = yakitlar.Remove(yakitlar.Length - 1);



                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, MvS.Fiyat " +
                    "from Modeller_ve_Siniflar as MvS " +
                    "join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID " +
                    "join Araba_Markalari as A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID " +
                    "join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID " +
                    "join Vites_Tipleri as V_Tip on MvS.Vites_ID = V_Tip.Vites_ID join" +
                    " Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID " +
                    "where MvS.Pasif_Adet > 0 " +
                    "and Y_Tip.Yakit_Adi IN (" + yakitlar + ")", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();


                baglantim.Close();

            }
            else {
                listView1.Items.Clear();
                SqlCommand cmd = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi," +
                " MvS.Fiyat from Modeller_ve_Siniflar as MvS join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID join Araba_Markalari as" +
                " A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID join Vites_Tipleri as V_Tip on" +
                " MvS.Vites_ID = V_Tip.Vites_ID join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID where MvS.Pasif_Adet > 0", baglantim);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem nitelik = new ListViewItem(reader["Marka_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                    nitelik.SubItems.Add(reader["Fiyat"].ToString());

                    listView1.Items.Add(nitelik);


                }
                reader.Close();
                baglantim.Close();
            }
            



        }
        private string seciliAlan ()
        {
            string bilgiler = null;
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    string x = listView1.Items[listView1.SelectedItems[0].Index].SubItems[i].ToString();
                    string x2 = x.Remove(0, 18);
                    string x3 = x2.Remove(x2.Length - 1);
                    bilgiler += x3 + ",";
                }
                bilgiler = bilgiler.Remove(bilgiler.Length - 1);
                return bilgiler;
            }
            else return "Seçilmemiş!,!Seçilmemiş,!Seçilmemiş,!Seçilmemiş,!Seçilmemiş,!Seçilmemiş";


        }



        private void tamamlaButonu_Click(object sender, EventArgs e)
        {
            if (!(listView1.SelectedItems.Count > 0))
            {
                MessageBox.Show("Önce araç seçin.",
                                "Bilgi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                string[] carProps = seciliAlan().Split(',');
                // [0] = Marka adı [1]=Model adı [2]=Sınıf adı [3]=Vites adı [4]=Yakıt adı [5]=Ücret 
                string plaka = null;

                DateTime alis = alisTarihi.Value;   //gün farkını hesaplamak için DateTime objesine atamalar.
                DateTime iade = iadeTarihi.Value;

                TimeSpan timeSpan = (iade - alis);

                string hour1 = saatListesi1.SelectedItem.ToString();
                string hour2 = saatListesi2.SelectedItem.ToString();


                int fark = Convert.ToInt32(timeSpan.TotalDays); //Gün ve gün farkını çarpmak içi int'e çevrim
                int fiyat = Convert.ToInt32(carProps[5]);
                int toplam_ucret = 0;

                if (fark >= 30) // 30 GÜNDEN FALZA KİRLAMA YAPILIRSA %20 İNDİRİM UYGULANIR
                {
                    toplam_ucret = fiyat * fark * 20 / 100;


                }
                else if (fark >= 15 && fark < 30) //15 GÜNDEN FALZA KİRLAMA YAPILIRSA %10 İNDİRİM UYGULANIR
                {
                    toplam_ucret = fiyat * fark * 10 / 100;

                }
                else toplam_ucret = fiyat * fark; // 15 GÜNDEN AZ KİRLAMA YAPILIRSA  İNDİRİM UYGULANMAZ

                DialogResult result;
                result = MessageBox.Show("İşlemi onaylıyor musunuz ?" +
                                "\nKirladığnız aracın bilgileri;"
                                + "\n-Marka:" + carProps[0] +
                                "\n-Model:" + carProps[1] +
                                "\n-Sınıf:" + carProps[2] +
                                "\n-Vites Tipi:" + carProps[3] +
                                "\n-Yakıt Tipi" + carProps[4] +
                                "\n-PLAKA : " + plaka +
                                "\nToplam Ücret(Gün*Günlük Ücret)=" + toplam_ucret.ToString() +
                                "\n\nBu bilgileri onaylıyor musnuz ?",
                                "Bilgi",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                if (listView1.SelectedItems.Count > 0 && result == DialogResult.Yes)
                {


                    SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                    baglantim.Open();
                    SqlCommand cmd = new SqlCommand("EXEC getPlateWithAttOfSelectedCar '" + carProps[0] + "','" + carProps[1] + "','" + carProps[2] + "','" + carProps[3] + "','" + carProps[4] + "'", baglantim);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        plaka = reader["Plaka"].ToString();

                    }
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand("EXEC changeStateActiveAndUpdate '" + plaka + "'", baglantim);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Takip_Formları(Musteri_ID,Musteri_TCKN,Plaka,Alis_Tarihi,İade_Tarihi,Hizmet_Bedeli,Zaman_Damgasi,Alis_Saati,İade_Saati) " +
                        "VALUES(@CUSTOMER_ID, @TCKN, @PLATE, @Purchase_Date, @Return_Date, @Service_Fee, @Time_Stamp, @Purchase_Hour, @Return_Hour)", baglantim);
                    cmd3.Parameters.AddWithValue("@CUSTOMER_ID", id);
                    cmd3.Parameters.AddWithValue("@TCKN", tc);
                    cmd3.Parameters.AddWithValue("@PLATE", plaka);
                    cmd3.Parameters.AddWithValue("@Purchase_Date", alis);
                    cmd3.Parameters.AddWithValue("@Return_Date", iade);
                    cmd3.Parameters.AddWithValue("@Service_Fee", toplam_ucret);
                    cmd3.Parameters.AddWithValue("@Time_Stamp", DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString());
                    cmd3.Parameters.AddWithValue("@Purchase_Hour", hour1);
                    cmd3.Parameters.AddWithValue("@Return_Hour", hour2);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show( //Veritabanına kayıt eklendi. İşlemin başarı ile sonuçlandığını bildiren mesaj.
                                "Kirladığnız aracın bilgileri;"
                                + "\n-Marka:" + carProps[0] +
                                "\n-Model:" + carProps[1] +
                                "\n-Sınıf:" + carProps[2] +
                                "\n-Vites Tipi:" + carProps[3] +
                                "\n-Yakıt Tipi" + carProps[4] +
                                "\n-PLAKA : " + plaka +
                                "\nToplam Ücret(Gün*Günlük Ücret)=" + toplam_ucret.ToString() +
                                "\n\nBu bilgilere 'İşlemlerin' sayfasından da ulaşabilirsiniz.",
                                "İşlem Başarılı!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                    listView1.Items.Clear();
                    SqlCommand cmd4 = new SqlCommand("SELECT Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi," +
                    " MvS.Fiyat from Modeller_ve_Siniflar as MvS join Araba_Modelleri A_Mod on MvS.Model_ID = A_Mod.Model_ID join Araba_Markalari as" +
                    " A_Mar on A_Mod.Marka_ID = A_Mar.Marka_ID join Araba_Siniflari as A_Snf on MvS.Sinif_ID = A_Snf.Sinif_ID join Vites_Tipleri as V_Tip on" +
                    " MvS.Vites_ID = V_Tip.Vites_ID join Yakit_Tipleri as Y_Tip on MvS.Yakit_ID = Y_Tip.Yakit_ID where MvS.Pasif_Adet > 0", baglantim);

                    SqlDataReader reader4 = cmd4.ExecuteReader();
                    while (reader4.Read())
                    {
                        ListViewItem nitelik = new ListViewItem(reader4["Marka_Adi"].ToString());
                        nitelik.SubItems.Add(reader4["Model_Adi"].ToString());
                        nitelik.SubItems.Add(reader4["Sinif_Adi"].ToString());
                        nitelik.SubItems.Add(reader4["Vites_Adi"].ToString());
                        nitelik.SubItems.Add(reader4["Yakit_Adi"].ToString());
                        nitelik.SubItems.Add(reader4["Fiyat"].ToString());

                        listView1.Items.Add(nitelik);


                    }
                    reader4.Close();
                    baglantim.Close();

                }


            }


        }

        private void hesaplaButonu_Click(object sender, EventArgs e)
        {
            if (!(listView1.SelectedItems.Count > 0))
            {
                MessageBox.Show("Önce araç seçin.",
                                "Bilgi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                int fark = 0;
                string[] carProps = seciliAlan().Split(',');
                int fiyat = Convert.ToInt32(carProps[5]);


                DateTime alis = alisTarihi.Value;
                DateTime iade = iadeTarihi.Value;
                TimeSpan timeSpan = (iade - alis);
                fark = Convert.ToInt32(timeSpan.TotalDays);
                int toplam_ucret = 0;

                if (fark >= 30) // 30 GÜNDEN FALZA KİRLAMA YAPILIRSA %20 İNDİRİM UYGULANIR
                {
                    toplam_ucret = fiyat * fark * 20 / 100;


                }
                else if (fark >= 15 && fark < 30) //15 GÜNDEN FALZA KİRLAMA YAPILIRSA %10 İNDİRİM UYGULANIR
                {
                    toplam_ucret = fiyat * fark * 10 / 100;

                }
                else toplam_ucret = fiyat * fark; // 15 GÜNDEN AZ KİRLAMA YAPILIRSA  İNDİRİM UYGULANMAZ


                MessageBox.Show(carProps[0] + " " + carProps[1] + " Modelindeki araç için:" +
                    "\nAracın Günlük Ücreti: " + carProps[5] +
                    "\nKiralanan Gün Sayısı: " + fark +
                    "\n\nToplam Ücret: " + toplam_ucret
                     , "Tutar", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }


        }

        private void iadeTarihi_ValueChanged(object sender, EventArgs e)
        {
            DateTime iade = iadeTarihi.Value;
            DateTime alis = alisTarihi.Value;
            if (iade < alis.AddDays(1) )
            {
                iadeTarihi.Value = alisTarihi.Value.AddDays(1);
                MessageBox.Show("İade tarihi olarak, alış tarihinden daha önceki\nbir tarihi seçemezsiniz.", "Geçersiz Seçim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void islemlerButonu_Click(object sender, EventArgs e)
        {
            MusteriİslemleriFormu musteriİslemleriFormu = new MusteriİslemleriFormu(id);
            musteriİslemleriFormu.ShowDialog();
        }

        Thread th;
        public void ana(object obj)
        {
            Application.Run(new AnaGirisFormu());
        }
        private void cikisButonu_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(ana);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void tamamlaButonu_MouseMove(object sender, MouseEventArgs e)
        {
            tamamlaButonu.Enabled = true;
           
            
            
        }
    }
}
