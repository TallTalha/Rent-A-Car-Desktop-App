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
    public partial class TCyeGoreAramaFormu : MetroFramework.Forms.MetroForm
    {
        public string tc { get; set; }
        public TCyeGoreAramaFormu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tc = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                && (int)e.KeyChar != 8 && (int)e.KeyChar != 1

                ) e.Handled = true;
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
