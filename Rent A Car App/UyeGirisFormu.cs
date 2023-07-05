using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace Rent_A_Car_App
{
    public partial class UyeGirisFormu : MetroFramework.Forms.MetroForm 
    {
        string Musteri_Adi;
        string Musteri_TC;
        int Musteri_ID;

        Thread th;
        public UyeGirisFormu()
        {
            InitializeComponent();
        }

        public void ana(object obj)
        {
            Application.Run(new AnaGirisFormu());
        }
        public void musteri(object obj)
        {
            Application.Run(new MusteriFormu(Musteri_Adi,Musteri_TC,Musteri_ID));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(ana);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        
        private void girişButonu_Click(object sender, EventArgs e)
        {

            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();// Veri tabanında sorgu yapabilmek için veritabanına bağlantı açılır.

            SqlCommand komutum1 = new SqlCommand("SELECT * FROM Musteriler WHERE TCKN=@TCKN and Musteri_Sifre =@PASSW ", baglantim); //Bağlantım nesnesi üzerindne sorgu iletilir.
            komutum1.Parameters.AddWithValue("@TCKN", musteriTCno.Text); //TCKN parametresine, TC textbox'undan gelen veriyi atadık.
            komutum1.Parameters.AddWithValue("@PASSW", musteriSifre.Text); 
            SqlDataReader sqlDataReader1 = komutum1.ExecuteReader(); //Sorgudan ne geldiğini okumak için reader nesnesi oluşturulur.
            if (sqlDataReader1.Read())
            {
                Musteri_Adi = sqlDataReader1["Musteri_Adi"].ToString() +" "+sqlDataReader1["Musteri_Soyadi"].ToString();
                Musteri_TC = sqlDataReader1["TCKN"].ToString();
                Musteri_ID = (int)sqlDataReader1["Musteri_ID"];


                baglantim.Close();

                this.Close();
                th = new Thread(musteri);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                sqlDataReader1.Close();
                baglantim.Close(); 
                MessageBox.Show(
                            "Bilgileriniz uyuşmuyor.",
                            "Giriş Başarısız!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }

        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (musteriTCno.Text.Length > 10)
            {
                if ((int)e.KeyChar != 8 && (int)e.KeyChar != 1) e.Handled = true;
                else e.Handled = false;
            }
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                && (int)e.KeyChar != 8 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }
    }
}
