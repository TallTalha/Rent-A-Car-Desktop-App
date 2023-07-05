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
    public partial class PersonelGirisFormu : MetroFramework.Forms.MetroForm
    {
        Thread th;
        int personel_id = 0;
        string personel_sifre = null;
        string personel_adi_soyadi = null;

        public PersonelGirisFormu()
        {
            InitializeComponent();
        }

        public void ana(object obj)
        {
            Application.Run(new AnaGirisFormu());
        }
        public void personelformu(object obj)
        {
            Application.Run(new PersonelFormu(personel_id,personel_adi_soyadi));
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
            personel_id = Convert.ToInt32(idTextBox.Text);
            personel_sifre = passwTextBox.Text;
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();// Veri tabanında sorgu yapabilmek için veritabanına bağlantı açılır.
            SqlCommand komutum1 = new SqlCommand("SELECT * FROM Personeller WHERE Personel_ID=@ID and Personel_Sifre =@PASSW ", baglantim); //Bağlantım nesnesi üzerindne sorgu iletilir.
            komutum1.Parameters.AddWithValue("@ID", personel_id); //TCKN parametresine, TC textbox'undan gelen veriyi atadık.
            komutum1.Parameters.AddWithValue("@PASSW", personel_sifre);
            SqlDataReader sqlDataReader1 = komutum1.ExecuteReader(); //Sorgudan ne geldiğini okumak için reader nesnesi oluşturulur.
            if (sqlDataReader1.Read())
            {
                personel_adi_soyadi = sqlDataReader1["Personel_Adi"].ToString().Trim() +" "+ sqlDataReader1["Personel_Soyadi"].ToString().Trim();
                baglantim.Close();


                this.Close();
                th = new Thread(personelformu);
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
           
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                && (int)e.KeyChar != 8 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }
    }
}
