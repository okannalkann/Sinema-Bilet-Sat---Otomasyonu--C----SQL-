namespace Sinema_Bilet_Satis
{
    partial class Baslangic_Formu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Baslangic_Formu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_personel = new System.Windows.Forms.RadioButton();
            this.radio_Yonetim = new System.Windows.Forms.RadioButton();
            this.txt_Sifre = new System.Windows.Forms.TextBox();
            this.txt_kullanici_Adi = new System.Windows.Forms.TextBox();
            this.lblPersonelKullanıcıAdı = new System.Windows.Forms.Label();
            this.btnPersonelCıkıs = new System.Windows.Forms.Button();
            this.btnPersonelGiris = new System.Windows.Forms.Button();
            this.lblPersonelSifre = new System.Windows.Forms.Label();
            this.LblSaat = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Saat_Gosterici = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radio_personel);
            this.groupBox1.Controls.Add(this.radio_Yonetim);
            this.groupBox1.Controls.Add(this.txt_Sifre);
            this.groupBox1.Controls.Add(this.txt_kullanici_Adi);
            this.groupBox1.Controls.Add(this.lblPersonelKullanıcıAdı);
            this.groupBox1.Controls.Add(this.btnPersonelCıkıs);
            this.groupBox1.Controls.Add(this.btnPersonelGiris);
            this.groupBox1.Controls.Add(this.lblPersonelSifre);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(224, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 179);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş";
            // 
            // radio_personel
            // 
            this.radio_personel.AutoSize = true;
            this.radio_personel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radio_personel.ForeColor = System.Drawing.Color.Snow;
            this.radio_personel.Location = new System.Drawing.Point(16, 103);
            this.radio_personel.Name = "radio_personel";
            this.radio_personel.Size = new System.Drawing.Size(89, 24);
            this.radio_personel.TabIndex = 17;
            this.radio_personel.TabStop = true;
            this.radio_personel.Text = "Personel";
            this.radio_personel.UseVisualStyleBackColor = true;
            // 
            // radio_Yonetim
            // 
            this.radio_Yonetim.AutoSize = true;
            this.radio_Yonetim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radio_Yonetim.ForeColor = System.Drawing.Color.Snow;
            this.radio_Yonetim.Location = new System.Drawing.Point(123, 104);
            this.radio_Yonetim.Name = "radio_Yonetim";
            this.radio_Yonetim.Size = new System.Drawing.Size(86, 24);
            this.radio_Yonetim.TabIndex = 18;
            this.radio_Yonetim.TabStop = true;
            this.radio_Yonetim.Text = "Yönetim";
            this.radio_Yonetim.UseVisualStyleBackColor = true;
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Sifre.Location = new System.Drawing.Point(110, 76);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.PasswordChar = '*';
            this.txt_Sifre.Size = new System.Drawing.Size(150, 22);
            this.txt_Sifre.TabIndex = 14;
            this.txt_Sifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Per_Sifre_KeyDown);
            // 
            // txt_kullanici_Adi
            // 
            this.txt_kullanici_Adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_kullanici_Adi.Location = new System.Drawing.Point(111, 37);
            this.txt_kullanici_Adi.Name = "txt_kullanici_Adi";
            this.txt_kullanici_Adi.Size = new System.Drawing.Size(150, 22);
            this.txt_kullanici_Adi.TabIndex = 13;
            this.txt_kullanici_Adi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPer_K_Adi_KeyDown);
            // 
            // lblPersonelKullanıcıAdı
            // 
            this.lblPersonelKullanıcıAdı.AutoSize = true;
            this.lblPersonelKullanıcıAdı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPersonelKullanıcıAdı.Location = new System.Drawing.Point(6, 39);
            this.lblPersonelKullanıcıAdı.Name = "lblPersonelKullanıcıAdı";
            this.lblPersonelKullanıcıAdı.Size = new System.Drawing.Size(101, 20);
            this.lblPersonelKullanıcıAdı.TabIndex = 10;
            this.lblPersonelKullanıcıAdı.Text = "Kullanıcı Adı :";
            // 
            // btnPersonelCıkıs
            // 
            this.btnPersonelCıkıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelCıkıs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPersonelCıkıs.Location = new System.Drawing.Point(123, 138);
            this.btnPersonelCıkıs.Name = "btnPersonelCıkıs";
            this.btnPersonelCıkıs.Size = new System.Drawing.Size(101, 32);
            this.btnPersonelCıkıs.TabIndex = 12;
            this.btnPersonelCıkıs.Text = "Çıkış";
            this.btnPersonelCıkıs.UseVisualStyleBackColor = true;
            this.btnPersonelCıkıs.Click += new System.EventHandler(this.btnPersonelCıkıs_Click);
            // 
            // btnPersonelGiris
            // 
            this.btnPersonelGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelGiris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPersonelGiris.Location = new System.Drawing.Point(16, 138);
            this.btnPersonelGiris.Name = "btnPersonelGiris";
            this.btnPersonelGiris.Size = new System.Drawing.Size(101, 32);
            this.btnPersonelGiris.TabIndex = 7;
            this.btnPersonelGiris.Text = "Giriş";
            this.btnPersonelGiris.UseVisualStyleBackColor = true;
            this.btnPersonelGiris.Click += new System.EventHandler(this.btnPersonelGiris_Click);
            // 
            // lblPersonelSifre
            // 
            this.lblPersonelSifre.AutoSize = true;
            this.lblPersonelSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPersonelSifre.Location = new System.Drawing.Point(6, 78);
            this.lblPersonelSifre.Name = "lblPersonelSifre";
            this.lblPersonelSifre.Size = new System.Drawing.Size(98, 20);
            this.lblPersonelSifre.TabIndex = 11;
            this.lblPersonelSifre.Text = "Şifre             :";
            // 
            // LblSaat
            // 
            this.LblSaat.AutoSize = true;
            this.LblSaat.BackColor = System.Drawing.Color.Transparent;
            this.LblSaat.Font = new System.Drawing.Font("Kristen ITC", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LblSaat.Location = new System.Drawing.Point(418, 9);
            this.LblSaat.Name = "LblSaat";
            this.LblSaat.Size = new System.Drawing.Size(85, 40);
            this.LblSaat.TabIndex = 24;
            this.LblSaat.Text = "Saat";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(21, 9);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(93, 71);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 23;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Visible = false;
            // 
            // Saat_Gosterici
            // 
            this.Saat_Gosterici.Interval = 50;
            this.Saat_Gosterici.Tick += new System.EventHandler(this.Saat_Gosterici_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(154, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 46);
            this.label1.TabIndex = 26;
            this.label1.Text = "Hoş Geldiniz";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 173);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // Baslangic_Formu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(552, 289);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblSaat);
            this.Controls.Add(this.PictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Baslangic_Formu";
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPersonelKullanıcıAdı;
        private System.Windows.Forms.Button btnPersonelCıkıs;
        private System.Windows.Forms.Button btnPersonelGiris;
        private System.Windows.Forms.Label lblPersonelSifre;
        private System.Windows.Forms.Label LblSaat;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Timer Saat_Gosterici;
        private System.Windows.Forms.TextBox txt_Sifre;
        private System.Windows.Forms.TextBox txt_kullanici_Adi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton radio_personel;
        private System.Windows.Forms.RadioButton radio_Yonetim;
    }
}