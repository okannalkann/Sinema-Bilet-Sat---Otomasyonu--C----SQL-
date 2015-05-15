namespace Sinema_Bilet_Satis
{
    partial class Film_Yayinla
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
            this.btn_film_ekle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_Film_Adi = new System.Windows.Forms.ComboBox();
            this.combo_Film_Salon = new System.Windows.Forms.ComboBox();
            this.combo_Film_Seans = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_film_ekle
            // 
            this.btn_film_ekle.Location = new System.Drawing.Point(108, 191);
            this.btn_film_ekle.Name = "btn_film_ekle";
            this.btn_film_ekle.Size = new System.Drawing.Size(79, 28);
            this.btn_film_ekle.TabIndex = 0;
            this.btn_film_ekle.Text = "Ekle";
            this.btn_film_ekle.UseVisualStyleBackColor = true;
            this.btn_film_ekle.Click += new System.EventHandler(this.btn_film_ekle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Film Adi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seans";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Salon";
            // 
            // combo_Film_Adi
            // 
            this.combo_Film_Adi.FormattingEnabled = true;
            this.combo_Film_Adi.Location = new System.Drawing.Point(108, 102);
            this.combo_Film_Adi.Name = "combo_Film_Adi";
            this.combo_Film_Adi.Size = new System.Drawing.Size(170, 21);
            this.combo_Film_Adi.TabIndex = 6;
            // 
            // combo_Film_Salon
            // 
            this.combo_Film_Salon.FormattingEnabled = true;
            this.combo_Film_Salon.Location = new System.Drawing.Point(108, 134);
            this.combo_Film_Salon.Name = "combo_Film_Salon";
            this.combo_Film_Salon.Size = new System.Drawing.Size(170, 21);
            this.combo_Film_Salon.TabIndex = 7;
            // 
            // combo_Film_Seans
            // 
            this.combo_Film_Seans.FormattingEnabled = true;
            this.combo_Film_Seans.Location = new System.Drawing.Point(108, 164);
            this.combo_Film_Seans.Name = "combo_Film_Seans";
            this.combo_Film_Seans.Size = new System.Drawing.Size(170, 21);
            this.combo_Film_Seans.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kristen ITC", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 51);
            this.label5.TabIndex = 9;
            this.label5.Text = "FİLM YAYINLA";
            // 
            // Film_Yayinla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(400, 238);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_Film_Seans);
            this.Controls.Add(this.combo_Film_Salon);
            this.Controls.Add(this.combo_Film_Adi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_film_ekle);
            this.Name = "Film_Yayinla";
            this.Text = "Film_Yayinla";
            this.Load += new System.EventHandler(this.Film_Yayinla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_film_ekle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_Film_Adi;
        private System.Windows.Forms.ComboBox combo_Film_Salon;
        private System.Windows.Forms.ComboBox combo_Film_Seans;
        private System.Windows.Forms.Label label5;
    }
}