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
    public partial class PersonelFormu : MetroFramework.Forms.MetroForm
    {
        int id = 0;
        Thread th;
        public PersonelFormu(int _id,string ad_soyad)
        {
            InitializeComponent();
            
            string msg = "Hoş geldin " + ad_soyad;  
            this.Text = msg;
            id = _id;
        }
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

        private void islemlerButonu_Click(object sender, EventArgs e)
        {
            PersonelMusteriİslemFormu formum = new PersonelMusteriİslemFormu();
            formum.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelAracİslemleriFormu formum = new PersonelAracİslemleriFormu();
            formum.ShowDialog();
        }

        public bool isAdmin(int _id)
        {
            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Yoneticiler WHERE Personel_ID=" + _id, baglantim);
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (isAdmin(id))
            {
                PersonelPersonelİşlemleriFormu formum = new PersonelPersonelİşlemleriFormu();
                formum.ShowDialog();
            }
            else MessageBox.Show("Bu işlemleri yapmaya yetkniz yok. Yöneticinize başvurun.","Yetki Dışı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
