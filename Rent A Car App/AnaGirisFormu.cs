using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Threading;

namespace Rent_A_Car_App
{
    public partial class AnaGirisFormu : MetroFramework.Forms.MetroForm
    {
        Thread th;
        public AnaGirisFormu()
        {
            InitializeComponent();
        }
        public void personel(object obj)
        {
            Application.Run(new PersonelGirisFormu());
        }
        public void uye(object obj)
        {
            Application.Run(new UyeGirisFormu());
        }
        public void yeniUye(object obj)
        {
            Application.Run(new YeniUyeGirisFormu());
        }

        private void personelGiris_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(personel);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void uyeGiris_Click(object sender, EventArgs e)
        {

            this.Close();
            th = new Thread(uye);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }
        private void yeniUyeGiris_Click(object sender, EventArgs e)
        {

            this.Close();
            th = new Thread(yeniUye);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

       
    }
}
