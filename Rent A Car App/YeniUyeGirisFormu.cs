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
    public partial class YeniUyeGirisFormu : MetroFramework.Forms.MetroForm
    {
        Thread th;
        public YeniUyeGirisFormu()
        {
            InitializeComponent();
        }

        public void ana(object obj)
        {
            Application.Run(new AnaGirisFormu());
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(ana);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
        private void girişButonu_Click(object sender, EventArgs e)
        {

            int count = 0; //Herhangi bir hata olması durumunda count arttırlır.

            if (musteriAdi.Text.Length < 1)
            {
                errorProvider1.SetError(musteriAdi, "Bu alan boş bırakılamaz. Lütfen adınızı girin.");
                count += 1;
            }
            else errorProvider1.Clear();

            if (musteriSoyadi.Text.Length < 1)
            {
                errorProvider2.SetError(musteriSoyadi, "Bu alan boş bırakılamaz. Lütfen soyadınızı girin.");
                count += 1;
            }
            else errorProvider2.Clear();

            if (musteriSifresi1.Text.Length < 6)
            {
                errorProvider3.SetError(musteriSifresi1, "Şifreniz en az 6 haneden oluşmalıdır.");
                count += 1;
            }
            else errorProvider3.Clear();

            if (musteriSifresi1.Text.Equals(musteriSifresi2.Text) == false)
            {
                errorProvider4.SetError(musteriSifresi2, "Şifreniz aynı değil.");
                count += 1;
            }
            else errorProvider4.Clear();


            if (musteriTelNo.Text.Length != 10)
            {

                errorProvider5.SetError(musteriTelNo, "Telefon numaranız 10 haneli olmalı.");
                count += 1;

            }
            else errorProvider5.Clear();

            if (musteriTCno.Text.Length != 11)
            {

                errorProvider6.SetError(musteriTCno, "Vatandaşlık numaranız 11 haneli olmalı.");
                count += 1;

            }
            else errorProvider6.Clear();

            if (Dogum_Tarihi.Text.Length != 4)
            {

                errorProvider7.SetError(Dogum_Tarihi, "Doğum tarihiniz 4 haneli olmalı.");
                count += 1;

            }
            else errorProvider7.Clear();

            if (count == 0)
            { //Yukarıdaki if'lere girmediyse yani hiç hata yoksa count 0'dır. Artık kimlik ve veritabanı kontrolleri yapılabilir.

                //DATA BASE'E BAĞLANTI SAĞLAMAK İÇİN BİLDİRİLEN BAĞLANTI NESNESİ
                KimlikDogrula.KPSPublicSoapClient k = new KimlikDogrula.KPSPublicSoapClient();
                //TEXT BOX'LARDAN GELEN VERİLER
                string yeniMüsteri_adi = musteriAdi.Text;
                string yeniMüsteri_soyadi = musteriSoyadi.Text;
                long yeniMüsteri_TC = long.Parse(musteriTCno.Text);
                string yeniMüsteri_tel = musteriTelNo.Text;
                string yeniNüsteri_sifre = musteriSifresi1.Text;
                int Dogum_Yili = int.Parse(Dogum_Tarihi.Text);
                //BİLDRİM MESAJLARININ STRINGLERI
                string ValidateMessage = "Kaydınız başarılı. TC'niz ve şifreniz ile giriş yapabilirsiniz.\n\nTC:" + yeniMüsteri_TC + "\n\nŞifre:" + yeniNüsteri_sifre;
                string ErrorTCMessage = "Kaydınız başarısız!\nGirdiğiniz kimlik bilgileri hatalı.\nTC,AD,SOYAD ve Doğum yılı bilgilerini kontrol edin.";
                string ErrorDBMessage = "Sistemde zaten bu TC numarasına ait kayıt bulunmakta!\n\nTC:" + yeniMüsteri_TC + "\n\nLütfen TC'nizi kontrol edin.\nYanlışlık yoksa müşteri temsilcisinden yardım alınız.";
                //Burada mernis servisine bilgiler gönderilir. Mersiniz kontrol yaparak true/false değeri döndürür. Bu değer KimlikDoğrulama değişkenine attanır.
                bool KimlikDogrulama = k.TCKimlikNoDogrula(yeniMüsteri_TC, yeniMüsteri_adi, yeniMüsteri_soyadi, Dogum_Yili);


                if (KimlikDogrulama)
                { //Kimlik doğrulama sağlandıyda KimlikDoğrulama nesnesi true'dir. Artık bu blokta veritabanı kontrolleri sağlaabilir.

                    baglantim.Open();// Veri tabanında sorgu yapabilmek için veritabanına bağlantı açılır.

                    SqlCommand komutum = new SqlCommand("SELECT * FROM Musteriler WHERE TCKN =@TCKN", baglantim); //Bağlantım nesnesi üzerindne sorgu iletilir.
                    komutum.Parameters.AddWithValue("@TCKN", musteriTCno.Text); //TCKN parametresine, TC textbox'undan gelen veriyi atadık.
                    SqlDataReader sqlDataReader = komutum.ExecuteReader(); //Sorgudan ne geldiğini okumak için reader nesnesi oluşturulur.

                    if (sqlDataReader.Read())//AYNI TC'YE SAHİP BİR KAYIT ZATEN VERİTABANINDA VARSA, READ() fonksiyonu TRUE DÖNDÜRÜR.
                    {
                        baglantim.Close(); //VERİ TABANI İLE İŞİMİZ BİTTİ. BAĞALANTI KAPATILIR.

                        MessageBox.Show(
                            ErrorDBMessage,
                            "Kayıdınız Zaten Var!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else //READ FALSE DÖNDÜRDÜYSE BU TC YE AİT BİR KAYIT Yoktur, yeni kayıt veritabaına eklenir. Burada kayıt ekleme kodları bulunmakta.
                    {
                        sqlDataReader.Close();
                        //Müşteri tablosuna yeni kayıt eklemek için insert into komutunu çalıştırılacaktır.
                        SqlCommand ekleme = new SqlCommand("INSERT INTO Musteriler(TCKN,Musteri_Adi,Musteri_Soyadi,Musteri_Sifre,Musteri_Telefon,Dogum_Yili) VALUES(@TCKN, @NAME, @LNAME, @PASSW, @PHONE, @BIRTH) ", baglantim);
                        //Parametreler TEXT BOX'LARDAN alınarak ataması yapılır.
                        ekleme.Parameters.AddWithValue("@TCKN", musteriTCno.Text);
                        ekleme.Parameters.AddWithValue("@NAME", musteriAdi.Text);
                        ekleme.Parameters.AddWithValue("@LNAME", musteriSoyadi.Text);
                        ekleme.Parameters.AddWithValue("@PASSW", musteriSifresi1.Text);
                        ekleme.Parameters.AddWithValue("@PHONE", musteriTelNo.Text);
                        ekleme.Parameters.AddWithValue("@BIRTH", Dogum_Yili);
                        ekleme.ExecuteNonQuery();
                        baglantim.Close();//VERİ TABANI İLE İŞİMİZ BİTTİ. BAĞLANTI KAPATILIR.
                        MessageBox.Show( //Veritabanına kayıt eklendi. İşlemin başarı ile sonuçlandığını bildiren mesaj.
                            ValidateMessage,
                            "Kayıt Başarılı!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                else//Kimlik kontrolü hatalıysa direkt else'e atlar ve kimlik bilgileri hatalı mesajı gösterilir.
                {
                    MessageBox.Show(
                       ErrorTCMessage,
                       "Kayıt Başarısız",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning
                  );
                }



            }



        }




        private void musteriAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) && !((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) // Türkçe ve UTF-8 karkaterleri
                    && (int)e.KeyChar != 252 && (int)e.KeyChar != 231 && (int)e.KeyChar != 246
                    && (int)e.KeyChar != 199 && (int)e.KeyChar != 214 && (int)e.KeyChar != 220
                    && (int)e.KeyChar != 305 && (int)e.KeyChar != 304 && (int)e.KeyChar != 286
                    && (int)e.KeyChar != 287 && (int)e.KeyChar != 350 && (int)e.KeyChar != 351
                    && (int)e.KeyChar != 8 && (int)e.KeyChar != 32 && (int)e.KeyChar != 1

                ) e.Handled = true;

        }


        private void musteriSoyadi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) && !((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
                   && (int)e.KeyChar != 252 && (int)e.KeyChar != 231 && (int)e.KeyChar != 246
                   && (int)e.KeyChar != 199 && (int)e.KeyChar != 214 && (int)e.KeyChar != 220
                   && (int)e.KeyChar != 305 && (int)e.KeyChar != 304 && (int)e.KeyChar != 286
                   && (int)e.KeyChar != 287 && (int)e.KeyChar != 350 && (int)e.KeyChar != 351
                   && (int)e.KeyChar != 8 && (int)e.KeyChar != 32 && (int)e.KeyChar != 1

               ) e.Handled = true;


        }

        private void Dogum_Tarihi_Click(object sender, EventArgs e)
        {
            Dogum_Tarihi.Text = "";
        }

        private void musteriTCno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void musteriTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (musteriTelNo.Text.Length > 9)
            {
                if ((int)e.KeyChar != 8 && (int)e.KeyChar != 1) e.Handled = true;
                else e.Handled = false;
            }

            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                && (int)e.KeyChar != 8 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }

        private void Dogum_Tarihi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Dogum_Tarihi.Text.Length > 3)
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
