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

    public partial class PersonelPersonelİşlemleriFormu : MetroFramework.Forms.MetroForm
    {
        public string MyId = null;
        public string myAd = null;
        public string mySoyad = null;
        public string mySsifre = null;
        public string myTelNo = null;

        public PersonelPersonelİşlemleriFormu()
        {
            InitializeComponent();

            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Personel_ID, Personel_Adi, Personel_Soyadi, Personel_Telefon FROM Personeller", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Personel_ID"].ToString());
                nitelik.SubItems.Add(reader["Personel_Adi"].ToString());
                nitelik.SubItems.Add(reader["Personel_Soyadi"].ToString());
                nitelik.SubItems.Add(reader["Personel_Telefon"].ToString());
               

                listView1.Items.Add(nitelik);
            }
            reader.Close();
            baglantim.Close();

        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Personel_ID, Personel_Adi, Personel_Soyadi, Personel_Telefon FROM Personeller", baglantim);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Personel_ID"].ToString());
                nitelik.SubItems.Add(reader["Personel_Adi"].ToString());
                nitelik.SubItems.Add(reader["Personel_Soyadi"].ToString());
                nitelik.SubItems.Add(reader["Personel_Telefon"].ToString());


                listView1.Items.Add(nitelik);
            }
            reader.Close();
            baglantim.Close();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            PersonelEklemeFormu formum = new PersonelEklemeFormu();

            if(formum.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.myAd = formum._ad;
                this.mySoyad = formum._soyad;
                this.mySsifre = formum._sifre;
                this.myTelNo = formum._telno;

                DialogResult result;
                
                result = MessageBox.Show("Ad: " + myAd + "\nSoyad: " + mySoyad + "\nŞifre: " + mySsifre + "\nTelno: " + myTelNo + "\nBu bilgiler ile personel kaydı yapılacak. Onaylıyor musunuz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               
                if (result == DialogResult.Yes)
                {
                    SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                    baglantim.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Personeller(Personel_Adi,Personel_Soyadi,Personel_Sifre,Personel_Telefon) " +
                        " VALUES('" + myAd + "','" + mySoyad + "','" + mySsifre + "','" + myTelNo + "')", baglantim);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("SELECT TOP 1 Personel_ID FROM Personeller ORDER BY Personel_ID DESC", baglantim);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        this.MyId = reader["Personel_ID"].ToString();
                    }
                    reader.Close();
                    baglantim.Close();
                    result = MessageBox.Show("Yeni personelin ID ve şifre biligisi;\n-ID: " + MyId + "\n-Şifre: " + mySsifre,
                    "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
            }

        }
        private string seciliAlan()
        {
            string bilgiler = null;
            for (int i = 0; i <= 3; i++)
            {
                string x = listView1.Items[listView1.SelectedItems[0].Index].SubItems[i].ToString();
                string x2 = x.Remove(0, 18);
                string x3 = x2.Remove(x2.Length - 1);
                bilgiler += x3 + ",";
            }
            bilgiler = bilgiler.Remove(bilgiler.Length - 1);
            return bilgiler;
        }
        private void button2_Click(object sender, EventArgs e)
        {   
            if(listView1.SelectedItems.Count > 0) 
            {
                string[] sutunlar = seciliAlan().Split(',');
                // [0] = Personel ID [1]=Personel adı [2]=Personel soyadı [3]=Personel Tel No
                DialogResult result;
                result = MessageBox.Show("ID: " + sutunlar[0] + "\nAd: " + sutunlar[1] + "\nSoyad: " + sutunlar[2] + "\nBu bilgilere sahip personeli sileceksiniz. Onaylıyor musunuz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
                    baglantim.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Personeller WHERE Personel_ID=" + sutunlar[0], baglantim);
                    cmd.ExecuteNonQuery();
                    baglantim.Close();
                }
            }
            else MessageBox.Show("Listeden seçim yaptıktan sonra bu işlemi gerçekleştirebilirsiniz.",
                    "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
