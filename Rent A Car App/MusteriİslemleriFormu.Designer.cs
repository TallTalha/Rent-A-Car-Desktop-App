namespace Rent_A_Car_App
{
    partial class MusteriİslemleriFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.takipId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plaka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sinif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VitesTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YakitTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fiyat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zamanDamgasi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alisTarihi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iadeTarihi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.girGitButonu = new System.Windows.Forms.Button();
            this.saat1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saat2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.takipId,
            this.plaka,
            this.Marka,
            this.Model,
            this.Sinif,
            this.VitesTipi,
            this.YakitTipi,
            this.Fiyat,
            this.zamanDamgasi,
            this.alisTarihi,
            this.saat1,
            this.iadeTarihi,
            this.saat2});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1, 85);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1614, 720);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // takipId
            // 
            this.takipId.Text = "Fatura No";
            this.takipId.Width = 75;
            // 
            // plaka
            // 
            this.plaka.Text = "Araç Plakası";
            this.plaka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.plaka.Width = 108;
            // 
            // Marka
            // 
            this.Marka.Text = "Marka";
            this.Marka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Marka.Width = 92;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            this.Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Model.Width = 148;
            // 
            // Sinif
            // 
            this.Sinif.Text = "Sınıf";
            this.Sinif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sinif.Width = 125;
            // 
            // VitesTipi
            // 
            this.VitesTipi.Text = "Vites Tipi";
            this.VitesTipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VitesTipi.Width = 131;
            // 
            // YakitTipi
            // 
            this.YakitTipi.Text = "Yakıt Tipi";
            this.YakitTipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.YakitTipi.Width = 130;
            // 
            // Fiyat
            // 
            this.Fiyat.Text = "Toplam Ücret";
            this.Fiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Fiyat.Width = 113;
            // 
            // zamanDamgasi
            // 
            this.zamanDamgasi.Text = "Fatura Kesim Tarihi";
            this.zamanDamgasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zamanDamgasi.Width = 243;
            // 
            // alisTarihi
            // 
            this.alisTarihi.Text = "Alış Tarihi";
            this.alisTarihi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alisTarihi.Width = 105;
            // 
            // iadeTarihi
            // 
            this.iadeTarihi.Text = "İade Tarihi";
            this.iadeTarihi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iadeTarihi.Width = 106;
            // 
            // girGitButonu
            // 
            this.girGitButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.girGitButonu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.girGitButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.girGitButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.girGitButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girGitButonu.Location = new System.Drawing.Point(632, 848);
            this.girGitButonu.Name = "girGitButonu";
            this.girGitButonu.Size = new System.Drawing.Size(353, 75);
            this.girGitButonu.TabIndex = 5;
            this.girGitButonu.Text = "Geri git >>";
            this.girGitButonu.UseVisualStyleBackColor = false;
            this.girGitButonu.Click += new System.EventHandler(this.girGitButonu_Click);
            // 
            // saat1
            // 
            this.saat1.Text = "Alış Saati";
            this.saat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.saat1.Width = 114;
            // 
            // saat2
            // 
            this.saat2.Text = "İade Saati";
            this.saat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.saat2.Width = 92;
            // 
            // MusteriİslemleriFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 960);
            this.Controls.Add(this.girGitButonu);
            this.Controls.Add(this.listView1);
            this.Name = "MusteriİslemleriFormu";
            this.Text = "MusteriİslemleriFormu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader takipId;
        private System.Windows.Forms.ColumnHeader plaka;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.ColumnHeader Sinif;
        private System.Windows.Forms.ColumnHeader VitesTipi;
        private System.Windows.Forms.ColumnHeader YakitTipi;
        private System.Windows.Forms.ColumnHeader Fiyat;
        private System.Windows.Forms.ColumnHeader zamanDamgasi;
        private System.Windows.Forms.ColumnHeader alisTarihi;
        private System.Windows.Forms.ColumnHeader iadeTarihi;
        private System.Windows.Forms.Button girGitButonu;
        private System.Windows.Forms.ColumnHeader saat1;
        private System.Windows.Forms.ColumnHeader saat2;
    }
}