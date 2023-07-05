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
    public partial class PlakaGoreAramaFormu : MetroFramework.Forms.MetroForm
    {
        public string plaka { get; set; }
        public PlakaGoreAramaFormu(string msg)
        {
            InitializeComponent();
            this.Text = msg;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            plaka = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void girGitButonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
