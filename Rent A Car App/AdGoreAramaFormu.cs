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
    public partial class AdGoreAramaFormu : MetroFramework.Forms.MetroForm
    {
        public string ad { get; set; }
        public AdGoreAramaFormu()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ad = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
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

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
