namespace Rent_A_Car_App
{
    partial class AnaGirisFormu
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
            this.personelGiris = new System.Windows.Forms.Button();
            this.uyeGiris = new System.Windows.Forms.Button();
            this.yeniUyeGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personelGiris
            // 
            this.personelGiris.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.personelGiris.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.personelGiris.FlatAppearance.BorderSize = 2;
            this.personelGiris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.personelGiris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.personelGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personelGiris.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.personelGiris.Location = new System.Drawing.Point(417, 307);
            this.personelGiris.Name = "personelGiris";
            this.personelGiris.Size = new System.Drawing.Size(658, 101);
            this.personelGiris.TabIndex = 0;
            this.personelGiris.Text = "Personel Girişi";
            this.personelGiris.UseVisualStyleBackColor = false;
            this.personelGiris.Click += new System.EventHandler(this.personelGiris_Click);
            // 
            // uyeGiris
            // 
            this.uyeGiris.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.uyeGiris.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.uyeGiris.FlatAppearance.BorderSize = 2;
            this.uyeGiris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.uyeGiris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.uyeGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uyeGiris.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeGiris.Location = new System.Drawing.Point(417, 423);
            this.uyeGiris.Name = "uyeGiris";
            this.uyeGiris.Size = new System.Drawing.Size(658, 101);
            this.uyeGiris.TabIndex = 1;
            this.uyeGiris.Text = "Mevcut Üye Girişi";
            this.uyeGiris.UseVisualStyleBackColor = false;
            this.uyeGiris.Click += new System.EventHandler(this.uyeGiris_Click);
            // 
            // yeniUyeGiris
            // 
            this.yeniUyeGiris.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.yeniUyeGiris.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.yeniUyeGiris.FlatAppearance.BorderSize = 2;
            this.yeniUyeGiris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.yeniUyeGiris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.yeniUyeGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yeniUyeGiris.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yeniUyeGiris.Location = new System.Drawing.Point(417, 539);
            this.yeniUyeGiris.Name = "yeniUyeGiris";
            this.yeniUyeGiris.Size = new System.Drawing.Size(658, 101);
            this.yeniUyeGiris.TabIndex = 2;
            this.yeniUyeGiris.Text = "Yeni Üye Girişi";
            this.yeniUyeGiris.UseVisualStyleBackColor = false;
            this.yeniUyeGiris.Click += new System.EventHandler(this.yeniUyeGiris_Click);
            // 
            // AnaGirisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 960);
            this.Controls.Add(this.yeniUyeGiris);
            this.Controls.Add(this.uyeGiris);
            this.Controls.Add(this.personelGiris);
            this.Name = "AnaGirisFormu";
            this.Text = "Araç Kiralama Uygulaması";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button personelGiris;
        private System.Windows.Forms.Button uyeGiris;
        private System.Windows.Forms.Button yeniUyeGiris;
    }
}

