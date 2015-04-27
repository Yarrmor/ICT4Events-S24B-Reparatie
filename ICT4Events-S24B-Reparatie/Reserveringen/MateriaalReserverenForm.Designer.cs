namespace ICT4Events_S24B_Reparatie
{
    partial class MateriaalReserverenForm
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
            this.lbxMaterialen = new System.Windows.Forms.ListBox();
            this.lblNaam = new System.Windows.Forms.Label();
            this.lblNaamData = new System.Windows.Forms.Label();
            this.lblVoorraad = new System.Windows.Forms.Label();
            this.lblVoorraadData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrijsData = new System.Windows.Forms.Label();
            this.lblDatumBegin = new System.Windows.Forms.Label();
            this.dtpBeginDatum = new System.Windows.Forms.DateTimePicker();
            this.lblDatumEind = new System.Windows.Forms.Label();
            this.dtpEindDatum = new System.Windows.Forms.DateTimePicker();
            this.btnMateriaalReserveren = new System.Windows.Forms.Button();
            this.btnKlaarReserveren = new System.Windows.Forms.Button();
            this.btnVeranderPrijs = new System.Windows.Forms.Button();
            this.btnMateriaalToevoegen = new System.Windows.Forms.Button();
            this.gbxMateriaalReserveren = new System.Windows.Forms.GroupBox();
            this.tbxNieuwePrijs = new System.Windows.Forms.TextBox();
            this.gbxMateriaalToevoegen = new System.Windows.Forms.GroupBox();
            this.tbxMateriaalBeschrijvingToevoegen = new System.Windows.Forms.TextBox();
            this.lblMateriaalBeschrijvingToevoegen = new System.Windows.Forms.Label();
            this.lblMateriaalPrijsToevoegen = new System.Windows.Forms.Label();
            this.tbxMateriaalPrijsToevoegen = new System.Windows.Forms.TextBox();
            this.tbxMateriaalNaamToevoegen = new System.Windows.Forms.TextBox();
            this.lblMateriaalNaamToevoegen = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbxUitgeleendMateriaal = new System.Windows.Forms.ListBox();
            this.btnVerversUitgeleendMateriaal = new System.Windows.Forms.Button();
            this.gbxUitgeleendMateriaal = new System.Windows.Forms.GroupBox();
            this.gbxMateriaalReserveren.SuspendLayout();
            this.gbxMateriaalToevoegen.SuspendLayout();
            this.gbxUitgeleendMateriaal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxMaterialen
            // 
            this.lbxMaterialen.FormattingEnabled = true;
            this.lbxMaterialen.Location = new System.Drawing.Point(27, 31);
            this.lbxMaterialen.Name = "lbxMaterialen";
            this.lbxMaterialen.Size = new System.Drawing.Size(563, 524);
            this.lbxMaterialen.TabIndex = 11;
            this.lbxMaterialen.SelectedIndexChanged += new System.EventHandler(this.lbxMaterialen_SelectedIndexChanged);
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(6, 16);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(35, 13);
            this.lblNaam.TabIndex = 12;
            this.lblNaam.Text = "Naam";
            // 
            // lblNaamData
            // 
            this.lblNaamData.AutoSize = true;
            this.lblNaamData.Location = new System.Drawing.Point(64, 16);
            this.lblNaamData.Name = "lblNaamData";
            this.lblNaamData.Size = new System.Drawing.Size(45, 13);
            this.lblNaamData.TabIndex = 28;
            this.lblNaamData.Text = "<naam>";
            // 
            // lblVoorraad
            // 
            this.lblVoorraad.AutoSize = true;
            this.lblVoorraad.Location = new System.Drawing.Point(6, 42);
            this.lblVoorraad.Name = "lblVoorraad";
            this.lblVoorraad.Size = new System.Drawing.Size(50, 13);
            this.lblVoorraad.TabIndex = 29;
            this.lblVoorraad.Text = "Voorraad";
            // 
            // lblVoorraadData
            // 
            this.lblVoorraadData.AutoSize = true;
            this.lblVoorraadData.Location = new System.Drawing.Point(64, 42);
            this.lblVoorraadData.Name = "lblVoorraadData";
            this.lblVoorraadData.Size = new System.Drawing.Size(77, 13);
            this.lblVoorraadData.TabIndex = 30;
            this.lblVoorraadData.Text = "<hoeveelheid>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Prijs";
            // 
            // lblPrijsData
            // 
            this.lblPrijsData.AutoSize = true;
            this.lblPrijsData.Location = new System.Drawing.Point(64, 67);
            this.lblPrijsData.Name = "lblPrijsData";
            this.lblPrijsData.Size = new System.Drawing.Size(37, 13);
            this.lblPrijsData.TabIndex = 34;
            this.lblPrijsData.Text = "<prijs>";
            // 
            // lblDatumBegin
            // 
            this.lblDatumBegin.AutoSize = true;
            this.lblDatumBegin.Location = new System.Drawing.Point(6, 89);
            this.lblDatumBegin.Name = "lblDatumBegin";
            this.lblDatumBegin.Size = new System.Drawing.Size(26, 13);
            this.lblDatumBegin.TabIndex = 37;
            this.lblDatumBegin.Text = "Van";
            // 
            // dtpBeginDatum
            // 
            this.dtpBeginDatum.Location = new System.Drawing.Point(67, 89);
            this.dtpBeginDatum.Name = "dtpBeginDatum";
            this.dtpBeginDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpBeginDatum.TabIndex = 38;
            // 
            // lblDatumEind
            // 
            this.lblDatumEind.AutoSize = true;
            this.lblDatumEind.Location = new System.Drawing.Point(6, 117);
            this.lblDatumEind.Name = "lblDatumEind";
            this.lblDatumEind.Size = new System.Drawing.Size(23, 13);
            this.lblDatumEind.TabIndex = 39;
            this.lblDatumEind.Text = "Tot";
            // 
            // dtpEindDatum
            // 
            this.dtpEindDatum.Location = new System.Drawing.Point(67, 115);
            this.dtpEindDatum.Name = "dtpEindDatum";
            this.dtpEindDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpEindDatum.TabIndex = 40;
            // 
            // btnMateriaalReserveren
            // 
            this.btnMateriaalReserveren.Location = new System.Drawing.Point(67, 167);
            this.btnMateriaalReserveren.Name = "btnMateriaalReserveren";
            this.btnMateriaalReserveren.Size = new System.Drawing.Size(137, 34);
            this.btnMateriaalReserveren.TabIndex = 41;
            this.btnMateriaalReserveren.Text = "Materiaal reserveren";
            this.btnMateriaalReserveren.UseVisualStyleBackColor = true;
            this.btnMateriaalReserveren.Click += new System.EventHandler(this.btnMateriaalReserveren_Click);
            // 
            // btnKlaarReserveren
            // 
            this.btnKlaarReserveren.Location = new System.Drawing.Point(236, 167);
            this.btnKlaarReserveren.Name = "btnKlaarReserveren";
            this.btnKlaarReserveren.Size = new System.Drawing.Size(137, 34);
            this.btnKlaarReserveren.TabIndex = 42;
            this.btnKlaarReserveren.Text = "Klaar Reserveren";
            this.btnKlaarReserveren.UseVisualStyleBackColor = true;
            this.btnKlaarReserveren.Click += new System.EventHandler(this.btnKlaarReserveren_Click);
            // 
            // btnVeranderPrijs
            // 
            this.btnVeranderPrijs.Location = new System.Drawing.Point(190, 57);
            this.btnVeranderPrijs.Name = "btnVeranderPrijs";
            this.btnVeranderPrijs.Size = new System.Drawing.Size(117, 26);
            this.btnVeranderPrijs.TabIndex = 43;
            this.btnVeranderPrijs.Text = "Prijs Wijzigen";
            this.btnVeranderPrijs.UseVisualStyleBackColor = true;
            this.btnVeranderPrijs.Click += new System.EventHandler(this.btnVeranderPrijs_Click);
            // 
            // btnMateriaalToevoegen
            // 
            this.btnMateriaalToevoegen.ForeColor = System.Drawing.Color.Red;
            this.btnMateriaalToevoegen.Location = new System.Drawing.Point(130, 175);
            this.btnMateriaalToevoegen.Name = "btnMateriaalToevoegen";
            this.btnMateriaalToevoegen.Size = new System.Drawing.Size(137, 41);
            this.btnMateriaalToevoegen.TabIndex = 44;
            this.btnMateriaalToevoegen.Text = "Materiaal Toevoegen";
            this.btnMateriaalToevoegen.UseVisualStyleBackColor = true;
            this.btnMateriaalToevoegen.Click += new System.EventHandler(this.btnMateriaalToevoegen_Click);
            // 
            // gbxMateriaalReserveren
            // 
            this.gbxMateriaalReserveren.Controls.Add(this.tbxNieuwePrijs);
            this.gbxMateriaalReserveren.Controls.Add(this.lblNaam);
            this.gbxMateriaalReserveren.Controls.Add(this.lblNaamData);
            this.gbxMateriaalReserveren.Controls.Add(this.btnKlaarReserveren);
            this.gbxMateriaalReserveren.Controls.Add(this.btnVeranderPrijs);
            this.gbxMateriaalReserveren.Controls.Add(this.btnMateriaalReserveren);
            this.gbxMateriaalReserveren.Controls.Add(this.lblVoorraad);
            this.gbxMateriaalReserveren.Controls.Add(this.lblVoorraadData);
            this.gbxMateriaalReserveren.Controls.Add(this.label4);
            this.gbxMateriaalReserveren.Controls.Add(this.dtpEindDatum);
            this.gbxMateriaalReserveren.Controls.Add(this.lblPrijsData);
            this.gbxMateriaalReserveren.Controls.Add(this.lblDatumEind);
            this.gbxMateriaalReserveren.Controls.Add(this.lblDatumBegin);
            this.gbxMateriaalReserveren.Controls.Add(this.dtpBeginDatum);
            this.gbxMateriaalReserveren.Location = new System.Drawing.Point(624, 31);
            this.gbxMateriaalReserveren.Name = "gbxMateriaalReserveren";
            this.gbxMateriaalReserveren.Size = new System.Drawing.Size(462, 226);
            this.gbxMateriaalReserveren.TabIndex = 45;
            this.gbxMateriaalReserveren.TabStop = false;
            this.gbxMateriaalReserveren.Text = "Materiaal Reserveren";
            // 
            // tbxNieuwePrijs
            // 
            this.tbxNieuwePrijs.Location = new System.Drawing.Point(313, 61);
            this.tbxNieuwePrijs.Name = "tbxNieuwePrijs";
            this.tbxNieuwePrijs.Size = new System.Drawing.Size(100, 20);
            this.tbxNieuwePrijs.TabIndex = 47;
            // 
            // gbxMateriaalToevoegen
            // 
            this.gbxMateriaalToevoegen.Controls.Add(this.tbxMateriaalBeschrijvingToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.lblMateriaalBeschrijvingToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.lblMateriaalPrijsToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.tbxMateriaalPrijsToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.tbxMateriaalNaamToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.lblMateriaalNaamToevoegen);
            this.gbxMateriaalToevoegen.Controls.Add(this.btnMateriaalToevoegen);
            this.gbxMateriaalToevoegen.Location = new System.Drawing.Point(624, 285);
            this.gbxMateriaalToevoegen.Name = "gbxMateriaalToevoegen";
            this.gbxMateriaalToevoegen.Size = new System.Drawing.Size(402, 222);
            this.gbxMateriaalToevoegen.TabIndex = 46;
            this.gbxMateriaalToevoegen.TabStop = false;
            this.gbxMateriaalToevoegen.Text = "Materiaal Toevoegen";
            // 
            // tbxMateriaalBeschrijvingToevoegen
            // 
            this.tbxMateriaalBeschrijvingToevoegen.Location = new System.Drawing.Point(104, 127);
            this.tbxMateriaalBeschrijvingToevoegen.Name = "tbxMateriaalBeschrijvingToevoegen";
            this.tbxMateriaalBeschrijvingToevoegen.Size = new System.Drawing.Size(100, 20);
            this.tbxMateriaalBeschrijvingToevoegen.TabIndex = 50;
            // 
            // lblMateriaalBeschrijvingToevoegen
            // 
            this.lblMateriaalBeschrijvingToevoegen.AutoSize = true;
            this.lblMateriaalBeschrijvingToevoegen.Location = new System.Drawing.Point(34, 130);
            this.lblMateriaalBeschrijvingToevoegen.Name = "lblMateriaalBeschrijvingToevoegen";
            this.lblMateriaalBeschrijvingToevoegen.Size = new System.Drawing.Size(64, 13);
            this.lblMateriaalBeschrijvingToevoegen.TabIndex = 49;
            this.lblMateriaalBeschrijvingToevoegen.Text = "Beschrijving";
            // 
            // lblMateriaalPrijsToevoegen
            // 
            this.lblMateriaalPrijsToevoegen.AutoSize = true;
            this.lblMateriaalPrijsToevoegen.Location = new System.Drawing.Point(39, 87);
            this.lblMateriaalPrijsToevoegen.Name = "lblMateriaalPrijsToevoegen";
            this.lblMateriaalPrijsToevoegen.Size = new System.Drawing.Size(25, 13);
            this.lblMateriaalPrijsToevoegen.TabIndex = 48;
            this.lblMateriaalPrijsToevoegen.Text = "prijs";
            // 
            // tbxMateriaalPrijsToevoegen
            // 
            this.tbxMateriaalPrijsToevoegen.Location = new System.Drawing.Point(104, 87);
            this.tbxMateriaalPrijsToevoegen.Name = "tbxMateriaalPrijsToevoegen";
            this.tbxMateriaalPrijsToevoegen.Size = new System.Drawing.Size(100, 20);
            this.tbxMateriaalPrijsToevoegen.TabIndex = 47;
            // 
            // tbxMateriaalNaamToevoegen
            // 
            this.tbxMateriaalNaamToevoegen.Location = new System.Drawing.Point(104, 46);
            this.tbxMateriaalNaamToevoegen.Name = "tbxMateriaalNaamToevoegen";
            this.tbxMateriaalNaamToevoegen.Size = new System.Drawing.Size(100, 20);
            this.tbxMateriaalNaamToevoegen.TabIndex = 46;
            // 
            // lblMateriaalNaamToevoegen
            // 
            this.lblMateriaalNaamToevoegen.AutoSize = true;
            this.lblMateriaalNaamToevoegen.Location = new System.Drawing.Point(39, 49);
            this.lblMateriaalNaamToevoegen.Name = "lblMateriaalNaamToevoegen";
            this.lblMateriaalNaamToevoegen.Size = new System.Drawing.Size(35, 13);
            this.lblMateriaalNaamToevoegen.TabIndex = 45;
            this.lblMateriaalNaamToevoegen.Text = "Naam";
            // 
            // lbxUitgeleendMateriaal
            // 
            this.lbxUitgeleendMateriaal.FormattingEnabled = true;
            this.lbxUitgeleendMateriaal.Location = new System.Drawing.Point(17, 19);
            this.lbxUitgeleendMateriaal.Name = "lbxUitgeleendMateriaal";
            this.lbxUitgeleendMateriaal.Size = new System.Drawing.Size(301, 329);
            this.lbxUitgeleendMateriaal.TabIndex = 47;
            // 
            // btnVerversUitgeleendMateriaal
            // 
            this.btnVerversUitgeleendMateriaal.Location = new System.Drawing.Point(83, 353);
            this.btnVerversUitgeleendMateriaal.Name = "btnVerversUitgeleendMateriaal";
            this.btnVerversUitgeleendMateriaal.Size = new System.Drawing.Size(137, 34);
            this.btnVerversUitgeleendMateriaal.TabIndex = 48;
            this.btnVerversUitgeleendMateriaal.Text = "Ververs";
            this.btnVerversUitgeleendMateriaal.UseVisualStyleBackColor = true;
            this.btnVerversUitgeleendMateriaal.Click += new System.EventHandler(this.btnVerversUitgeleendMateriaal_Click);
            // 
            // gbxUitgeleendMateriaal
            // 
            this.gbxUitgeleendMateriaal.Controls.Add(this.lbxUitgeleendMateriaal);
            this.gbxUitgeleendMateriaal.Controls.Add(this.btnVerversUitgeleendMateriaal);
            this.gbxUitgeleendMateriaal.Location = new System.Drawing.Point(1109, 39);
            this.gbxUitgeleendMateriaal.Name = "gbxUitgeleendMateriaal";
            this.gbxUitgeleendMateriaal.Size = new System.Drawing.Size(324, 424);
            this.gbxUitgeleendMateriaal.TabIndex = 49;
            this.gbxUitgeleendMateriaal.TabStop = false;
            this.gbxUitgeleendMateriaal.Text = "UitgeleendMateriaal";
            // 
            // MateriaalReserverenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 618);
            this.Controls.Add(this.gbxUitgeleendMateriaal);
            this.Controls.Add(this.gbxMateriaalToevoegen);
            this.Controls.Add(this.gbxMateriaalReserveren);
            this.Controls.Add(this.lbxMaterialen);
            this.Name = "MateriaalReserverenForm";
            this.Text = "MaterialenReserveringForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MateriaalReserverenForm_FormClosing);
            this.gbxMateriaalReserveren.ResumeLayout(false);
            this.gbxMateriaalReserveren.PerformLayout();
            this.gbxMateriaalToevoegen.ResumeLayout(false);
            this.gbxMateriaalToevoegen.PerformLayout();
            this.gbxUitgeleendMateriaal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMaterialen;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Label lblNaamData;
        private System.Windows.Forms.Label lblVoorraad;
        private System.Windows.Forms.Label lblVoorraadData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrijsData;
        private System.Windows.Forms.Label lblDatumBegin;
        private System.Windows.Forms.DateTimePicker dtpBeginDatum;
        private System.Windows.Forms.Label lblDatumEind;
        private System.Windows.Forms.DateTimePicker dtpEindDatum;
        private System.Windows.Forms.Button btnMateriaalReserveren;
        private System.Windows.Forms.Button btnKlaarReserveren;
        private System.Windows.Forms.Button btnVeranderPrijs;
        private System.Windows.Forms.Button btnMateriaalToevoegen;
        private System.Windows.Forms.GroupBox gbxMateriaalReserveren;
        private System.Windows.Forms.GroupBox gbxMateriaalToevoegen;
        private System.Windows.Forms.Label lblMateriaalPrijsToevoegen;
        private System.Windows.Forms.TextBox tbxMateriaalPrijsToevoegen;
        private System.Windows.Forms.TextBox tbxMateriaalNaamToevoegen;
        private System.Windows.Forms.Label lblMateriaalNaamToevoegen;
        private System.Windows.Forms.TextBox tbxMateriaalBeschrijvingToevoegen;
        private System.Windows.Forms.Label lblMateriaalBeschrijvingToevoegen;
        private System.Windows.Forms.TextBox tbxNieuwePrijs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lbxUitgeleendMateriaal;
        private System.Windows.Forms.Button btnVerversUitgeleendMateriaal;
        private System.Windows.Forms.GroupBox gbxUitgeleendMateriaal;
    }
}