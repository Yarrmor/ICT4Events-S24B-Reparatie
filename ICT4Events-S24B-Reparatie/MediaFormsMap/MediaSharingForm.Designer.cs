namespace ICT4Events_S24B_Reparatie
{
    partial class MediaSharingForm
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
            this.gbxCategorie = new System.Windows.Forms.GroupBox();
            this.btnVerwijderCategorie = new System.Windows.Forms.Button();
            this.btnNieuwCategorie = new System.Windows.Forms.Button();
            this.lbxCategorie = new System.Windows.Forms.ListBox();
            this.gbxMedia = new System.Windows.Forms.GroupBox();
            this.lbxMedia = new System.Windows.Forms.ListBox();
            this.gbxFilters = new System.Windows.Forms.GroupBox();
            this.tbxZoekCategorie = new System.Windows.Forms.TextBox();
            this.tbxZoekMedia = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbxCategorie.SuspendLayout();
            this.gbxMedia.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCategorie
            // 
            this.gbxCategorie.Controls.Add(this.btnRefresh);
            this.gbxCategorie.Controls.Add(this.tbxZoekCategorie);
            this.gbxCategorie.Controls.Add(this.btnVerwijderCategorie);
            this.gbxCategorie.Controls.Add(this.btnNieuwCategorie);
            this.gbxCategorie.Controls.Add(this.lbxCategorie);
            this.gbxCategorie.Location = new System.Drawing.Point(12, 30);
            this.gbxCategorie.Name = "gbxCategorie";
            this.gbxCategorie.Size = new System.Drawing.Size(200, 483);
            this.gbxCategorie.TabIndex = 0;
            this.gbxCategorie.TabStop = false;
            this.gbxCategorie.Text = "Categorieën";
            // 
            // btnVerwijderCategorie
            // 
            this.btnVerwijderCategorie.Location = new System.Drawing.Point(6, 437);
            this.btnVerwijderCategorie.Name = "btnVerwijderCategorie";
            this.btnVerwijderCategorie.Size = new System.Drawing.Size(188, 40);
            this.btnVerwijderCategorie.TabIndex = 2;
            this.btnVerwijderCategorie.Text = "Verwijder Categorie";
            this.btnVerwijderCategorie.UseVisualStyleBackColor = true;
            this.btnVerwijderCategorie.Click += new System.EventHandler(this.btnVerwijderCategorie_Click);
            // 
            // btnNieuwCategorie
            // 
            this.btnNieuwCategorie.Location = new System.Drawing.Point(6, 389);
            this.btnNieuwCategorie.Name = "btnNieuwCategorie";
            this.btnNieuwCategorie.Size = new System.Drawing.Size(188, 42);
            this.btnNieuwCategorie.TabIndex = 1;
            this.btnNieuwCategorie.Text = "Maak nieuw categorie aan";
            this.btnNieuwCategorie.UseVisualStyleBackColor = true;
            this.btnNieuwCategorie.Click += new System.EventHandler(this.btnNieuwCategorie_Click);
            // 
            // lbxCategorie
            // 
            this.lbxCategorie.FormattingEnabled = true;
            this.lbxCategorie.Location = new System.Drawing.Point(7, 46);
            this.lbxCategorie.Name = "lbxCategorie";
            this.lbxCategorie.Size = new System.Drawing.Size(187, 290);
            this.lbxCategorie.TabIndex = 0;
            this.lbxCategorie.SelectedIndexChanged += new System.EventHandler(this.lbxCategorie_SelectedIndexChanged);
            // 
            // gbxMedia
            // 
            this.gbxMedia.Controls.Add(this.tbxZoekMedia);
            this.gbxMedia.Controls.Add(this.lbxMedia);
            this.gbxMedia.Location = new System.Drawing.Point(219, 30);
            this.gbxMedia.Name = "gbxMedia";
            this.gbxMedia.Size = new System.Drawing.Size(415, 483);
            this.gbxMedia.TabIndex = 1;
            this.gbxMedia.TabStop = false;
            this.gbxMedia.Text = "Media";
            // 
            // lbxMedia
            // 
            this.lbxMedia.FormattingEnabled = true;
            this.lbxMedia.Location = new System.Drawing.Point(6, 46);
            this.lbxMedia.Name = "lbxMedia";
            this.lbxMedia.Size = new System.Drawing.Size(403, 433);
            this.lbxMedia.TabIndex = 0;
            this.lbxMedia.SelectedIndexChanged += new System.EventHandler(this.lbxMedia_SelectedIndexChanged);
            // 
            // gbxFilters
            // 
            this.gbxFilters.Location = new System.Drawing.Point(641, 30);
            this.gbxFilters.Name = "gbxFilters";
            this.gbxFilters.Size = new System.Drawing.Size(173, 260);
            this.gbxFilters.TabIndex = 2;
            this.gbxFilters.TabStop = false;
            this.gbxFilters.Text = "Filters";
            // 
            // tbxZoekCategorie
            // 
            this.tbxZoekCategorie.Location = new System.Drawing.Point(7, 20);
            this.tbxZoekCategorie.Name = "tbxZoekCategorie";
            this.tbxZoekCategorie.Size = new System.Drawing.Size(187, 20);
            this.tbxZoekCategorie.TabIndex = 3;
            this.tbxZoekCategorie.TextChanged += new System.EventHandler(this.tbxZoekCategorie_TextChanged);
            // 
            // tbxZoekMedia
            // 
            this.tbxZoekMedia.Location = new System.Drawing.Point(7, 20);
            this.tbxZoekMedia.Name = "tbxZoekMedia";
            this.tbxZoekMedia.Size = new System.Drawing.Size(402, 20);
            this.tbxZoekMedia.TabIndex = 1;
            this.tbxZoekMedia.TextChanged += new System.EventHandler(this.tbxZoekMedia_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(7, 343);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(187, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // MediaSharingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 525);
            this.Controls.Add(this.gbxFilters);
            this.Controls.Add(this.gbxMedia);
            this.Controls.Add(this.gbxCategorie);
            this.Name = "MediaSharingForm";
            this.Text = "Media Applictie Beheer";
            this.gbxCategorie.ResumeLayout(false);
            this.gbxCategorie.PerformLayout();
            this.gbxMedia.ResumeLayout(false);
            this.gbxMedia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCategorie;
        private System.Windows.Forms.Button btnVerwijderCategorie;
        private System.Windows.Forms.Button btnNieuwCategorie;
        private System.Windows.Forms.ListBox lbxCategorie;
        private System.Windows.Forms.GroupBox gbxMedia;
        private System.Windows.Forms.ListBox lbxMedia;
        private System.Windows.Forms.GroupBox gbxFilters;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox tbxZoekCategorie;
        private System.Windows.Forms.TextBox tbxZoekMedia;


    }
}