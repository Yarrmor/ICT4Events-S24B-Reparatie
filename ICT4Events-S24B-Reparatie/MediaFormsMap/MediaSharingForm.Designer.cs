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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbxZoekCategorie = new System.Windows.Forms.TextBox();
            this.btnVerwijderCategorie = new System.Windows.Forms.Button();
            this.btnNieuwCategorie = new System.Windows.Forms.Button();
            this.lbxCategorie = new System.Windows.Forms.ListBox();
            this.gbxMedia = new System.Windows.Forms.GroupBox();
            this.tbxZoekMedia = new System.Windows.Forms.TextBox();
            this.lbxMedia = new System.Windows.Forms.ListBox();
            this.gbxFilters = new System.Windows.Forms.GroupBox();
            this.gbxFilterCategorie = new System.Windows.Forms.GroupBox();
            this.cbxFilterCategorie = new System.Windows.Forms.ComboBox();
            this.rbnFilterCategorie = new System.Windows.Forms.RadioButton();
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.rbnFilterDatum = new System.Windows.Forms.RadioButton();
            this.rbnFilterDislikes = new System.Windows.Forms.RadioButton();
            this.rbnFilterLikes = new System.Windows.Forms.RadioButton();
            this.rbnFilterNaam = new System.Windows.Forms.RadioButton();
            this.gbxSoort = new System.Windows.Forms.GroupBox();
            this.rbnSortDesc = new System.Windows.Forms.RadioButton();
            this.rbnSortAsc = new System.Windows.Forms.RadioButton();
            this.gbxZoekWoord = new System.Windows.Forms.GroupBox();
            this.tbxFilterZoekWoord = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.rbnFilterZoekNaam = new System.Windows.Forms.RadioButton();
            this.rbnFilterZoekBeschrijving = new System.Windows.Forms.RadioButton();
            this.gbxCategorie.SuspendLayout();
            this.gbxMedia.SuspendLayout();
            this.gbxFilters.SuspendLayout();
            this.gbxFilterCategorie.SuspendLayout();
            this.gbxFilter.SuspendLayout();
            this.gbxSoort.SuspendLayout();
            this.gbxZoekWoord.SuspendLayout();
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
            // tbxZoekCategorie
            // 
            this.tbxZoekCategorie.Location = new System.Drawing.Point(7, 20);
            this.tbxZoekCategorie.Name = "tbxZoekCategorie";
            this.tbxZoekCategorie.Size = new System.Drawing.Size(187, 20);
            this.tbxZoekCategorie.TabIndex = 3;
            this.tbxZoekCategorie.TextChanged += new System.EventHandler(this.tbxZoekCategorie_TextChanged);
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
            // tbxZoekMedia
            // 
            this.tbxZoekMedia.Location = new System.Drawing.Point(7, 20);
            this.tbxZoekMedia.Name = "tbxZoekMedia";
            this.tbxZoekMedia.Size = new System.Drawing.Size(402, 20);
            this.tbxZoekMedia.TabIndex = 1;
            this.tbxZoekMedia.TextChanged += new System.EventHandler(this.tbxZoekMedia_TextChanged);
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
            this.gbxFilters.Controls.Add(this.gbxFilterCategorie);
            this.gbxFilters.Controls.Add(this.gbxFilter);
            this.gbxFilters.Controls.Add(this.gbxZoekWoord);
            this.gbxFilters.Location = new System.Drawing.Point(641, 30);
            this.gbxFilters.Name = "gbxFilters";
            this.gbxFilters.Size = new System.Drawing.Size(197, 323);
            this.gbxFilters.TabIndex = 2;
            this.gbxFilters.TabStop = false;
            this.gbxFilters.Text = "Filters";
            // 
            // gbxFilterCategorie
            // 
            this.gbxFilterCategorie.Controls.Add(this.cbxFilterCategorie);
            this.gbxFilterCategorie.Controls.Add(this.rbnFilterCategorie);
            this.gbxFilterCategorie.Location = new System.Drawing.Point(7, 239);
            this.gbxFilterCategorie.Name = "gbxFilterCategorie";
            this.gbxFilterCategorie.Size = new System.Drawing.Size(184, 78);
            this.gbxFilterCategorie.TabIndex = 3;
            this.gbxFilterCategorie.TabStop = false;
            this.gbxFilterCategorie.Text = "Categorie";
            // 
            // cbxFilterCategorie
            // 
            this.cbxFilterCategorie.FormattingEnabled = true;
            this.cbxFilterCategorie.Location = new System.Drawing.Point(7, 44);
            this.cbxFilterCategorie.Name = "cbxFilterCategorie";
            this.cbxFilterCategorie.Size = new System.Drawing.Size(171, 21);
            this.cbxFilterCategorie.TabIndex = 1;
            // 
            // rbnFilterCategorie
            // 
            this.rbnFilterCategorie.AutoSize = true;
            this.rbnFilterCategorie.Location = new System.Drawing.Point(7, 20);
            this.rbnFilterCategorie.Name = "rbnFilterCategorie";
            this.rbnFilterCategorie.Size = new System.Drawing.Size(109, 17);
            this.rbnFilterCategorie.TabIndex = 0;
            this.rbnFilterCategorie.TabStop = true;
            this.rbnFilterCategorie.Text = "Filter op categorie";
            this.rbnFilterCategorie.UseVisualStyleBackColor = true;
            // 
            // gbxFilter
            // 
            this.gbxFilter.Controls.Add(this.rbnFilterDatum);
            this.gbxFilter.Controls.Add(this.rbnFilterDislikes);
            this.gbxFilter.Controls.Add(this.rbnFilterLikes);
            this.gbxFilter.Controls.Add(this.rbnFilterNaam);
            this.gbxFilter.Controls.Add(this.gbxSoort);
            this.gbxFilter.Location = new System.Drawing.Point(6, 119);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(185, 114);
            this.gbxFilter.TabIndex = 2;
            this.gbxFilter.TabStop = false;
            this.gbxFilter.Text = "Filter";
            // 
            // rbnFilterDatum
            // 
            this.rbnFilterDatum.AutoSize = true;
            this.rbnFilterDatum.Location = new System.Drawing.Point(6, 89);
            this.rbnFilterDatum.Name = "rbnFilterDatum";
            this.rbnFilterDatum.Size = new System.Drawing.Size(76, 17);
            this.rbnFilterDatum.TabIndex = 4;
            this.rbnFilterDatum.Text = "Datum (ID)";
            this.rbnFilterDatum.UseVisualStyleBackColor = true;
            // 
            // rbnFilterDislikes
            // 
            this.rbnFilterDislikes.AutoSize = true;
            this.rbnFilterDislikes.Location = new System.Drawing.Point(6, 66);
            this.rbnFilterDislikes.Name = "rbnFilterDislikes";
            this.rbnFilterDislikes.Size = new System.Drawing.Size(61, 17);
            this.rbnFilterDislikes.TabIndex = 3;
            this.rbnFilterDislikes.TabStop = true;
            this.rbnFilterDislikes.Text = "Dislikes";
            this.rbnFilterDislikes.UseVisualStyleBackColor = true;
            // 
            // rbnFilterLikes
            // 
            this.rbnFilterLikes.AutoSize = true;
            this.rbnFilterLikes.Location = new System.Drawing.Point(6, 43);
            this.rbnFilterLikes.Name = "rbnFilterLikes";
            this.rbnFilterLikes.Size = new System.Drawing.Size(50, 17);
            this.rbnFilterLikes.TabIndex = 2;
            this.rbnFilterLikes.TabStop = true;
            this.rbnFilterLikes.Text = "Likes";
            this.rbnFilterLikes.UseVisualStyleBackColor = true;
            // 
            // rbnFilterNaam
            // 
            this.rbnFilterNaam.AutoSize = true;
            this.rbnFilterNaam.Checked = true;
            this.rbnFilterNaam.Location = new System.Drawing.Point(6, 19);
            this.rbnFilterNaam.Name = "rbnFilterNaam";
            this.rbnFilterNaam.Size = new System.Drawing.Size(53, 17);
            this.rbnFilterNaam.TabIndex = 1;
            this.rbnFilterNaam.TabStop = true;
            this.rbnFilterNaam.Text = "Naam";
            this.rbnFilterNaam.UseVisualStyleBackColor = true;
            // 
            // gbxSoort
            // 
            this.gbxSoort.Controls.Add(this.rbnSortDesc);
            this.gbxSoort.Controls.Add(this.rbnSortAsc);
            this.gbxSoort.Location = new System.Drawing.Point(98, 19);
            this.gbxSoort.Name = "gbxSoort";
            this.gbxSoort.Size = new System.Drawing.Size(81, 68);
            this.gbxSoort.TabIndex = 0;
            this.gbxSoort.TabStop = false;
            this.gbxSoort.Text = "Sort";
            // 
            // rbnSortDesc
            // 
            this.rbnSortDesc.AutoSize = true;
            this.rbnSortDesc.Location = new System.Drawing.Point(7, 44);
            this.rbnSortDesc.Name = "rbnSortDesc";
            this.rbnSortDesc.Size = new System.Drawing.Size(54, 17);
            this.rbnSortDesc.TabIndex = 1;
            this.rbnSortDesc.TabStop = true;
            this.rbnSortDesc.Text = "DESC";
            this.rbnSortDesc.UseVisualStyleBackColor = true;
            // 
            // rbnSortAsc
            // 
            this.rbnSortAsc.AutoSize = true;
            this.rbnSortAsc.Checked = true;
            this.rbnSortAsc.Location = new System.Drawing.Point(7, 20);
            this.rbnSortAsc.Name = "rbnSortAsc";
            this.rbnSortAsc.Size = new System.Drawing.Size(46, 17);
            this.rbnSortAsc.TabIndex = 0;
            this.rbnSortAsc.TabStop = true;
            this.rbnSortAsc.Text = "ASC";
            this.rbnSortAsc.UseVisualStyleBackColor = true;
            // 
            // gbxZoekWoord
            // 
            this.gbxZoekWoord.Controls.Add(this.rbnFilterZoekBeschrijving);
            this.gbxZoekWoord.Controls.Add(this.rbnFilterZoekNaam);
            this.gbxZoekWoord.Controls.Add(this.tbxFilterZoekWoord);
            this.gbxZoekWoord.Location = new System.Drawing.Point(6, 20);
            this.gbxZoekWoord.Name = "gbxZoekWoord";
            this.gbxZoekWoord.Size = new System.Drawing.Size(185, 93);
            this.gbxZoekWoord.TabIndex = 1;
            this.gbxZoekWoord.TabStop = false;
            this.gbxZoekWoord.Text = "ZoekWoord";
            // 
            // tbxFilterZoekWoord
            // 
            this.tbxFilterZoekWoord.Location = new System.Drawing.Point(6, 67);
            this.tbxFilterZoekWoord.Name = "tbxFilterZoekWoord";
            this.tbxFilterZoekWoord.Size = new System.Drawing.Size(175, 20);
            this.tbxFilterZoekWoord.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(641, 359);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(197, 39);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // rbnFilterZoekNaam
            // 
            this.rbnFilterZoekNaam.AutoSize = true;
            this.rbnFilterZoekNaam.Checked = true;
            this.rbnFilterZoekNaam.Location = new System.Drawing.Point(7, 20);
            this.rbnFilterZoekNaam.Name = "rbnFilterZoekNaam";
            this.rbnFilterZoekNaam.Size = new System.Drawing.Size(53, 17);
            this.rbnFilterZoekNaam.TabIndex = 1;
            this.rbnFilterZoekNaam.TabStop = true;
            this.rbnFilterZoekNaam.Text = "Naam";
            this.rbnFilterZoekNaam.UseVisualStyleBackColor = true;
            // 
            // rbnFilterZoekBeschrijving
            // 
            this.rbnFilterZoekBeschrijving.AutoSize = true;
            this.rbnFilterZoekBeschrijving.Location = new System.Drawing.Point(7, 43);
            this.rbnFilterZoekBeschrijving.Name = "rbnFilterZoekBeschrijving";
            this.rbnFilterZoekBeschrijving.Size = new System.Drawing.Size(82, 17);
            this.rbnFilterZoekBeschrijving.TabIndex = 2;
            this.rbnFilterZoekBeschrijving.TabStop = true;
            this.rbnFilterZoekBeschrijving.Text = "Beschrijving";
            this.rbnFilterZoekBeschrijving.UseVisualStyleBackColor = true;
            // 
            // MediaSharingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 525);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.gbxFilters);
            this.Controls.Add(this.gbxMedia);
            this.Controls.Add(this.gbxCategorie);
            this.Name = "MediaSharingForm";
            this.Text = "Media Applictie Beheer";
            this.gbxCategorie.ResumeLayout(false);
            this.gbxCategorie.PerformLayout();
            this.gbxMedia.ResumeLayout(false);
            this.gbxMedia.PerformLayout();
            this.gbxFilters.ResumeLayout(false);
            this.gbxFilterCategorie.ResumeLayout(false);
            this.gbxFilterCategorie.PerformLayout();
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            this.gbxSoort.ResumeLayout(false);
            this.gbxSoort.PerformLayout();
            this.gbxZoekWoord.ResumeLayout(false);
            this.gbxZoekWoord.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.GroupBox gbxSoort;
        private System.Windows.Forms.RadioButton rbnSortDesc;
        private System.Windows.Forms.RadioButton rbnSortAsc;
        private System.Windows.Forms.GroupBox gbxZoekWoord;
        private System.Windows.Forms.TextBox tbxFilterZoekWoord;
        private System.Windows.Forms.GroupBox gbxFilterCategorie;
        private System.Windows.Forms.RadioButton rbnFilterCategorie;
        private System.Windows.Forms.RadioButton rbnFilterDatum;
        private System.Windows.Forms.RadioButton rbnFilterDislikes;
        private System.Windows.Forms.RadioButton rbnFilterLikes;
        private System.Windows.Forms.RadioButton rbnFilterNaam;
        private System.Windows.Forms.ComboBox cbxFilterCategorie;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.RadioButton rbnFilterZoekBeschrijving;
        private System.Windows.Forms.RadioButton rbnFilterZoekNaam;


    }
}