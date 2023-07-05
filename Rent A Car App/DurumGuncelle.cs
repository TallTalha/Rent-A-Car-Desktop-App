using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car_App
{
    public partial class DurumGuncelle : MetroFramework.Forms.MetroForm
    {
        public string plaka { get; set; }
        public string durum { get; set; }
        public DurumGuncelle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            if(!metroRadioButton1.Checked  && !metroRadioButton2.Checked)
            {
                MessageBox.Show("Pasif/Aktif seçimini yapmadan işlemi gerçekleştiremezsiniz.","Seçim Yapın",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {   
                
                plaka = textBox1.Text;
                if (metroRadioButton1.Checked)
                {
                    durum=metroRadioButton1.Text; //Pasif
                }
                else durum=metroRadioButton2.Text; //Aktif

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
