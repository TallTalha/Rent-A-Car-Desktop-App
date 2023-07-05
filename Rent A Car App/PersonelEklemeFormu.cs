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
    public partial class PersonelEklemeFormu : MetroFramework.Forms.MetroForm
    {
        public string _id { get; set; }
        public string _ad { get; set; }
        public string _soyad { get; set; }
        public string _sifre { get; set; }
        public string _telno { get; set; }
        public PersonelEklemeFormu()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) && !((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) // Türkçe ve UTF-8 karkaterleri
                    && (int)e.KeyChar != 252 && (int)e.KeyChar != 231 && (int)e.KeyChar != 246
                    && (int)e.KeyChar != 199 && (int)e.KeyChar != 214 && (int)e.KeyChar != 220
                    && (int)e.KeyChar != 305 && (int)e.KeyChar != 304 && (int)e.KeyChar != 286
                    && (int)e.KeyChar != 287 && (int)e.KeyChar != 350 && (int)e.KeyChar != 351
                    && (int)e.KeyChar != 8 && (int)e.KeyChar != 32 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) && !((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
                   && (int)e.KeyChar != 252 && (int)e.KeyChar != 231 && (int)e.KeyChar != 246
                   && (int)e.KeyChar != 199 && (int)e.KeyChar != 214 && (int)e.KeyChar != 220
                   && (int)e.KeyChar != 305 && (int)e.KeyChar != 304 && (int)e.KeyChar != 286
                   && (int)e.KeyChar != 287 && (int)e.KeyChar != 350 && (int)e.KeyChar != 351
                   && (int)e.KeyChar != 8 && (int)e.KeyChar != 32 && (int)e.KeyChar != 1

               ) e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (telno.Text.Length > 9)
            {
                if ((int)e.KeyChar != 8 && (int)e.KeyChar != 1) e.Handled = true;
                else e.Handled = false;
            }

            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                && (int)e.KeyChar != 8 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0; //Herhangi bir hata olması durumunda count arttırlır.

            if (ad.Text.Length < 1)
            {
                errorProvider1.SetError(ad, "Bu alan boş bırakılamaz. Lütfen adı girin.");
                count += 1;
            }
            else errorProvider1.Clear();

            if (soyad.Text.Length < 1)
            {
                errorProvider2.SetError(soyad, "Bu alan boş bırakılamaz. Lütfen soyadı girin.");
                count += 1;
            }
            else errorProvider2.Clear();

            if (sifre1.Text.Length < 6)
            {
                errorProvider3.SetError(sifre1, "Şifre en az 6 haneden oluşmalıdır.");
                count += 1;
            }
            else errorProvider3.Clear();

            if (sifre1.Text.Equals(sifre2.Text) == false)
            {
                errorProvider4.SetError(sifre2, "Şifre aynı değil.");
                count += 1;
            }
            else errorProvider4.Clear();


            if (telno.Text.Length != 10)
            {

                errorProvider5.SetError(telno, "Telefon numarsı 10 haneli olmalı.");
                count += 1;

            }
            else errorProvider5.Clear();

            if (count == 0)
            {
                _ad = ad.Text;
                _soyad = soyad.Text;
                _sifre = sifre1.Text;
                _telno = telno.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
