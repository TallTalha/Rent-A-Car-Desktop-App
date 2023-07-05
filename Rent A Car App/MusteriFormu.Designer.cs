namespace Rent_A_Car_App
{
    partial class MusteriFormu
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
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sinif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VitesTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YakitTipi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fiyat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tamamlaButonu = new System.Windows.Forms.Button();
            this.islemlerButonu = new System.Windows.Forms.Button();
            this.alisTarihi = new System.Windows.Forms.DateTimePicker();
            this.iadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.saatListesi1 = new System.Windows.Forms.ComboBox();
            this.saatListesi2 = new System.Windows.Forms.ComboBox();
            this.araButonu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sinifSecim = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vitesSecim = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yakitSecim = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hesaplaButonu = new System.Windows.Forms.Button();
            this.cikisButonu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Marka,
            this.Model,
            this.Sinif,
            this.VitesTipi,
            this.YakitTipi,
            this.Fiyat});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(175, 128);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1080, 720);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Marka
            // 
            this.Marka.Text = "                Marka";
            this.Marka.Width = 180;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            this.Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Model.Width = 180;
            // 
            // Sinif
            // 
            this.Sinif.Text = "Sınıf";
            this.Sinif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sinif.Width = 180;
            // 
            // VitesTipi
            // 
            this.VitesTipi.Text = "Vites Tipi";
            this.VitesTipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VitesTipi.Width = 180;
            // 
            // YakitTipi
            // 
            this.YakitTipi.Text = "Yakıt Tipi";
            this.YakitTipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.YakitTipi.Width = 180;
            // 
            // Fiyat
            // 
            this.Fiyat.Text = "Günlük Ücreti";
            this.Fiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Fiyat.Width = 140;
            // 
            // tamamlaButonu
            // 
            this.tamamlaButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tamamlaButonu.BackColor = System.Drawing.Color.DarkTurquoise;
            this.tamamlaButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.tamamlaButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tamamlaButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamamlaButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tamamlaButonu.Location = new System.Drawing.Point(1260, 339);
            this.tamamlaButonu.Name = "tamamlaButonu";
            this.tamamlaButonu.Size = new System.Drawing.Size(173, 72);
            this.tamamlaButonu.TabIndex = 8;
            this.tamamlaButonu.Text = "Seçimi Tamamla";
            this.tamamlaButonu.UseMnemonic = false;
            this.tamamlaButonu.UseVisualStyleBackColor = false;
            this.tamamlaButonu.Click += new System.EventHandler(this.tamamlaButonu_Click);
            this.tamamlaButonu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tamamlaButonu_MouseMove);
            // 
            // islemlerButonu
            // 
            this.islemlerButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.islemlerButonu.BackColor = System.Drawing.Color.DarkOrange;
            this.islemlerButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.islemlerButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.islemlerButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.islemlerButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.islemlerButonu.Location = new System.Drawing.Point(1260, 443);
            this.islemlerButonu.Name = "islemlerButonu";
            this.islemlerButonu.Size = new System.Drawing.Size(173, 72);
            this.islemlerButonu.TabIndex = 9;
            this.islemlerButonu.Text = "İşlemlerin";
            this.islemlerButonu.UseMnemonic = false;
            this.islemlerButonu.UseVisualStyleBackColor = false;
            this.islemlerButonu.Click += new System.EventHandler(this.islemlerButonu_Click);
            // 
            // alisTarihi
            // 
            this.alisTarihi.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alisTarihi.CustomFormat = "";
            this.alisTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.alisTarihi.Location = new System.Drawing.Point(285, 88);
            this.alisTarihi.MinDate = new System.DateTime(2022, 12, 15, 0, 0, 0, 0);
            this.alisTarihi.Name = "alisTarihi";
            this.alisTarihi.Size = new System.Drawing.Size(200, 21);
            this.alisTarihi.TabIndex = 10;
            this.alisTarihi.ValueChanged += new System.EventHandler(this.alisTarihi_ValueChanged);
            // 
            // iadeTarihi
            // 
            this.iadeTarihi.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iadeTarihi.CustomFormat = "";
            this.iadeTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iadeTarihi.Location = new System.Drawing.Point(657, 88);
            this.iadeTarihi.MinDate = new System.DateTime(2022, 12, 15, 0, 0, 0, 0);
            this.iadeTarihi.Name = "iadeTarihi";
            this.iadeTarihi.Size = new System.Drawing.Size(200, 21);
            this.iadeTarihi.TabIndex = 11;
            this.iadeTarihi.ValueChanged += new System.EventHandler(this.iadeTarihi_ValueChanged);
            // 
            // saatListesi1
            // 
            this.saatListesi1.FormattingEnabled = true;
            this.saatListesi1.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.saatListesi1.Location = new System.Drawing.Point(487, 88);
            this.saatListesi1.Name = "saatListesi1";
            this.saatListesi1.Size = new System.Drawing.Size(121, 21);
            this.saatListesi1.TabIndex = 12;
            this.saatListesi1.SelectedIndexChanged += new System.EventHandler(this.saatListesi1_SelectedIndexChanged);
            // 
            // saatListesi2
            // 
            this.saatListesi2.FormattingEnabled = true;
            this.saatListesi2.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.saatListesi2.Location = new System.Drawing.Point(860, 88);
            this.saatListesi2.Name = "saatListesi2";
            this.saatListesi2.Size = new System.Drawing.Size(121, 21);
            this.saatListesi2.TabIndex = 13;
            // 
            // araButonu
            // 
            this.araButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.araButonu.BackColor = System.Drawing.Color.DarkOrange;
            this.araButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.araButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.araButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.araButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.araButonu.Location = new System.Drawing.Point(1024, 74);
            this.araButonu.Name = "araButonu";
            this.araButonu.Size = new System.Drawing.Size(120, 48);
            this.araButonu.TabIndex = 14;
            this.araButonu.Text = "Ara";
            this.araButonu.UseMnemonic = false;
            this.araButonu.UseVisualStyleBackColor = false;
            this.araButonu.Click += new System.EventHandler(this.araButonu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(349, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Alış Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(509, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Alış Saati";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(721, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "İade Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(884, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "İade Saati";
            // 
            // sinifSecim
            // 
            this.sinifSecim.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.sinifSecim.CheckBoxes = true;
            this.sinifSecim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.sinifSecim.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sinifSecim.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.sinifSecim.HideSelection = false;
            this.sinifSecim.Location = new System.Drawing.Point(12, 128);
            this.sinifSecim.MultiSelect = false;
            this.sinifSecim.Name = "sinifSecim";
            this.sinifSecim.Size = new System.Drawing.Size(156, 205);
            this.sinifSecim.TabIndex = 19;
            this.sinifSecim.UseCompatibleStateImageBehavior = false;
            this.sinifSecim.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Araç Sınıfları";
            this.columnHeader1.Width = 152;
            // 
            // vitesSecim
            // 
            this.vitesSecim.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.vitesSecim.CheckBoxes = true;
            this.vitesSecim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.vitesSecim.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vitesSecim.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.vitesSecim.HideSelection = false;
            this.vitesSecim.Location = new System.Drawing.Point(12, 339);
            this.vitesSecim.Name = "vitesSecim";
            this.vitesSecim.Size = new System.Drawing.Size(156, 205);
            this.vitesSecim.TabIndex = 20;
            this.vitesSecim.UseCompatibleStateImageBehavior = false;
            this.vitesSecim.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Vites Tipleri";
            this.columnHeader2.Width = 152;
            // 
            // yakitSecim
            // 
            this.yakitSecim.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.yakitSecim.CheckBoxes = true;
            this.yakitSecim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.yakitSecim.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yakitSecim.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.yakitSecim.HideSelection = false;
            this.yakitSecim.Location = new System.Drawing.Point(12, 550);
            this.yakitSecim.Name = "yakitSecim";
            this.yakitSecim.Size = new System.Drawing.Size(156, 205);
            this.yakitSecim.TabIndex = 21;
            this.yakitSecim.UseCompatibleStateImageBehavior = false;
            this.yakitSecim.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Yakıt Tipleri";
            this.columnHeader3.Width = 152;
            // 
            // hesaplaButonu
            // 
            this.hesaplaButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hesaplaButonu.BackColor = System.Drawing.Color.DarkOrange;
            this.hesaplaButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.hesaplaButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hesaplaButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hesaplaButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hesaplaButonu.Location = new System.Drawing.Point(1260, 550);
            this.hesaplaButonu.Name = "hesaplaButonu";
            this.hesaplaButonu.Size = new System.Drawing.Size(173, 72);
            this.hesaplaButonu.TabIndex = 22;
            this.hesaplaButonu.Text = "Hesapla";
            this.hesaplaButonu.UseMnemonic = false;
            this.hesaplaButonu.UseVisualStyleBackColor = false;
            this.hesaplaButonu.Click += new System.EventHandler(this.hesaplaButonu_Click);
            // 
            // cikisButonu
            // 
            this.cikisButonu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cikisButonu.BackColor = System.Drawing.Color.OrangeRed;
            this.cikisButonu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cikisButonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cikisButonu.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cikisButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cikisButonu.Location = new System.Drawing.Point(580, 865);
            this.cikisButonu.Name = "cikisButonu";
            this.cikisButonu.Size = new System.Drawing.Size(270, 72);
            this.cikisButonu.TabIndex = 23;
            this.cikisButonu.Text = "Oturumu Kapat";
            this.cikisButonu.UseMnemonic = false;
            this.cikisButonu.UseVisualStyleBackColor = false;
            this.cikisButonu.Click += new System.EventHandler(this.cikisButonu_Click);
            // 
            // MusteriFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 960);
            this.Controls.Add(this.cikisButonu);
            this.Controls.Add(this.hesaplaButonu);
            this.Controls.Add(this.yakitSecim);
            this.Controls.Add(this.vitesSecim);
            this.Controls.Add(this.sinifSecim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.araButonu);
            this.Controls.Add(this.saatListesi2);
            this.Controls.Add(this.saatListesi1);
            this.Controls.Add(this.iadeTarihi);
            this.Controls.Add(this.alisTarihi);
            this.Controls.Add(this.islemlerButonu);
            this.Controls.Add(this.tamamlaButonu);
            this.Controls.Add(this.listView1);
            this.Name = "MusteriFormu";
            this.Text = "MusteriFormu";
            this.Load += new System.EventHandler(this.MusteriFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button tamamlaButonu;
        private System.Windows.Forms.Button islemlerButonu;
        private System.Windows.Forms.DateTimePicker alisTarihi;
        private System.Windows.Forms.DateTimePicker iadeTarihi;
        private System.Windows.Forms.ComboBox saatListesi1;
        private System.Windows.Forms.ComboBox saatListesi2;
        private System.Windows.Forms.Button araButonu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.ColumnHeader Sinif;
        private System.Windows.Forms.ColumnHeader VitesTipi;
        private System.Windows.Forms.ColumnHeader YakitTipi;
        private System.Windows.Forms.ColumnHeader Fiyat;
        private System.Windows.Forms.ListView sinifSecim;
        private System.Windows.Forms.ListView vitesSecim;
        private System.Windows.Forms.ListView yakitSecim;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button hesaplaButonu;
        private System.Windows.Forms.Button cikisButonu;
    }
}