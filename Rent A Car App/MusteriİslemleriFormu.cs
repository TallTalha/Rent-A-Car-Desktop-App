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
    public partial class MusteriİslemleriFormu : MetroFramework.Forms.MetroForm
    {
        public MusteriİslemleriFormu(int _id)
        {
            InitializeComponent();

            SqlConnection baglantim = new SqlConnection(@"Data Source=T4PARS\SQLEXPRESS;Initial Catalog=RentACarDatabase;Integrated Security=True");
            baglantim.Open();
            SqlCommand cmd = new SqlCommand("SELECT Takip_ID, tf.Plaka as Plakam, Marka_Adi, Model_Adi, Sinif_Adi, Vites_Adi, Yakit_Adi, Hizmet_Bedeli, Zaman_Damgasi, Alis_Tarihi, Alis_Saati, " +
                " İade_Tarihi,  İade_Saati FROM Takip_Formları as tf " +
                " join Arabalar as a ON tf.Plaka = a.Plaka "+
                " join Araba_Markalari as amark ON a.Marka_ID = amark.Marka_ID "+
                " join Araba_Modelleri as amod ON a.Model_ID = amod.Model_ID "+
                " join Araba_Siniflari as asnf ON a.Sinif_ID = asnf.Sinif_ID "+
                " join Vites_Tipleri as vt ON a.Vites_ID = vt.Vites_ID "+
                " join Yakit_Tipleri as yt ON a.Yakit_ID = yt.Yakit_ID "+
                " WHERE tf.Musteri_ID="+_id+" ", baglantim);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem nitelik = new ListViewItem(reader["Takip_ID"].ToString());
                nitelik.SubItems.Add(reader["Plakam"].ToString());
                nitelik.SubItems.Add(reader["Marka_Adi"].ToString());
                nitelik.SubItems.Add(reader["Model_Adi"].ToString());
                nitelik.SubItems.Add(reader["Sinif_Adi"].ToString());
                nitelik.SubItems.Add(reader["Vites_Adi"].ToString());
                nitelik.SubItems.Add(reader["Yakit_Adi"].ToString());
                nitelik.SubItems.Add(reader["Hizmet_Bedeli"].ToString());
                nitelik.SubItems.Add(reader["Zaman_Damgasi"].ToString());
                nitelik.SubItems.Add(reader["Alis_Tarihi"].ToString());
                nitelik.SubItems.Add(reader["Alis_Saati"].ToString());
                nitelik.SubItems.Add(reader["İade_Tarihi"].ToString());
                nitelik.SubItems.Add(reader["İade_Saati"].ToString());

                listView1.Items.Add(nitelik);


            }
            reader.Close();
            baglantim.Close();  

        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
