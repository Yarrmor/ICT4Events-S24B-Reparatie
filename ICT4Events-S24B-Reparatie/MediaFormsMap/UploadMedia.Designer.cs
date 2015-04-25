namespace ICT4Events_S24B_Reparatie
{
    partial class UploadMedia
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
            this.tbxMediaTitel = new System.Windows.Forms.TextBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblUBestand = new System.Windows.Forms.Label();
            this.gbxBestand = new System.Windows.Forms.GroupBox();
            this.lblBestandNaam = new System.Windows.Forms.Label();
            this.btnBestandZoek = new System.Windows.Forms.Button();
            this.lblBeschrijving = new System.Windows.Forms.Label();
            this.tbxMediaBeschrijving = new System.Windows.Forms.TextBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cbxMediaCategorie = new System.Windows.Forms.ComboBox();
            this.btnMediaUpload = new System.Windows.Forms.Button();
            this.gbxBestand.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxMediaTitel
            // 
            this.tbxMediaTitel.Location = new System.Drawing.Point(58, 24);
            this.tbxMediaTitel.Name = "tbxMediaTitel";
            this.tbxMediaTitel.Size = new System.Drawing.Size(264, 20);
            this.tbxMediaTitel.TabIndex = 0;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(22, 27);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(30, 13);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Titel:";
            // 
            // lblUBestand
            // 
            this.lblUBestand.AutoSize = true;
            this.lblUBestand.Location = new System.Drawing.Point(6, 30);
            this.lblUBestand.Name = "lblUBestand";
            this.lblUBestand.Size = new System.Drawing.Size(49, 13);
            this.lblUBestand.TabIndex = 2;
            this.lblUBestand.Text = "Bestand:";
            // 
            // gbxBestand
            // 
            this.gbxBestand.Controls.Add(this.lblBestandNaam);
            this.gbxBestand.Controls.Add(this.btnBestandZoek);
            this.gbxBestand.Controls.Add(this.lblUBestand);
            this.gbxBestand.Location = new System.Drawing.Point(25, 62);
            this.gbxBestand.Name = "gbxBestand";
            this.gbxBestand.Size = new System.Drawing.Size(297, 71);
            this.gbxBestand.TabIndex = 3;
            this.gbxBestand.TabStop = false;
            this.gbxBestand.Text = "Bestand";
            // 
            // lblBestandNaam
            // 
            this.lblBestandNaam.AutoSize = true;
            this.lblBestandNaam.Location = new System.Drawing.Point(61, 30);
            this.lblBestandNaam.Name = "lblBestandNaam";
            this.lblBestandNaam.Size = new System.Drawing.Size(0, 13);
            this.lblBestandNaam.TabIndex = 4;
            // 
            // btnBestandZoek
            // 
            this.btnBestandZoek.Location = new System.Drawing.Point(216, 25);
            this.btnBestandZoek.Name = "btnBestandZoek";
            this.btnBestandZoek.Size = new System.Drawing.Size(75, 23);
            this.btnBestandZoek.TabIndex = 3;
            this.btnBestandZoek.Text = "Zoek";
            this.btnBestandZoek.UseVisualStyleBackColor = true;
            this.btnBestandZoek.Click += new System.EventHandler(this.btnBestandZoek_Click);
            // 
            // lblBeschrijving
            // 
            this.lblBeschrijving.AutoSize = true;
            this.lblBeschrijving.Location = new System.Drawing.Point(25, 154);
            this.lblBeschrijving.Name = "lblBeschrijving";
            this.lblBeschrijving.Size = new System.Drawing.Size(67, 13);
            this.lblBeschrijving.TabIndex = 4;
            this.lblBeschrijving.Text = "Beschrijving:";
            // 
            // tbxMediaBeschrijving
            // 
            this.tbxMediaBeschrijving.Location = new System.Drawing.Point(98, 151);
            this.tbxMediaBeschrijving.Multiline = true;
            this.tbxMediaBeschrijving.Name = "tbxMediaBeschrijving";
            this.tbxMediaBeschrijving.Size = new System.Drawing.Size(218, 127);
            this.tbxMediaBeschrijving.TabIndex = 5;
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(25, 304);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(55, 13);
            this.lblCategorie.TabIndex = 6;
            this.lblCategorie.Text = "Categorie:";
            // 
            // cbxMediaCategorie
            // 
            this.cbxMediaCategorie.FormattingEnabled = true;
            this.cbxMediaCategorie.Location = new System.Drawing.Point(98, 301);
            this.cbxMediaCategorie.Name = "cbxMediaCategorie";
            this.cbxMediaCategorie.Size = new System.Drawing.Size(218, 21);
            this.cbxMediaCategorie.TabIndex = 7;
            // 
            // btnMediaUpload
            // 
            this.btnMediaUpload.Location = new System.Drawing.Point(89, 340);
            this.btnMediaUpload.Name = "btnMediaUpload";
            this.btnMediaUpload.Size = new System.Drawing.Size(174, 51);
            this.btnMediaUpload.TabIndex = 8;
            this.btnMediaUpload.Text = "Upload Media";
            this.btnMediaUpload.UseVisualStyleBackColor = true;
            this.btnMediaUpload.Click += new System.EventHandler(this.btnMediaUpload_Click);
            // 
            // UploadMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 403);
            this.Controls.Add(this.btnMediaUpload);
            this.Controls.Add(this.cbxMediaCategorie);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.tbxMediaBeschrijving);
            this.Controls.Add(this.lblBeschrijving);
            this.Controls.Add(this.gbxBestand);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.tbxMediaTitel);
            this.Name = "UploadMedia";
            this.Text = "UploadMedia";
            this.gbxBestand.ResumeLayout(false);
            this.gbxBestand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblUBestand;
        private System.Windows.Forms.GroupBox gbxBestand;
        private System.Windows.Forms.Label lblBestandNaam;
        private System.Windows.Forms.Button btnBestandZoek;
        private System.Windows.Forms.Label lblBeschrijving;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.Button btnMediaUpload;
        public System.Windows.Forms.TextBox tbxMediaTitel;
        public System.Windows.Forms.TextBox tbxMediaBeschrijving;
        public System.Windows.Forms.ComboBox cbxMediaCategorie;
    }
}