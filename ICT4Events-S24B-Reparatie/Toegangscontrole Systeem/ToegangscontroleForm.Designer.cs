namespace ICT4Events_S24B_Reparatie
{
    partial class ToegangscontroleForm
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
            this.gbxGescandeRFID = new System.Windows.Forms.GroupBox();
            this.gbxReservering = new System.Windows.Forms.GroupBox();
            this.btnReserveringAnnuleren = new System.Windows.Forms.Button();
            this.lblGescandeGroepshoofd = new System.Windows.Forms.Label();
            this.lblGescandePeriode = new System.Windows.Forms.Label();
            this.lblGescandeCampingplaats = new System.Windows.Forms.Label();
            this.chkBetaald = new System.Windows.Forms.CheckBox();
            this.lblBetaald = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.lblCampingplaats = new System.Windows.Forms.Label();
            this.lblGroepshoofd = new System.Windows.Forms.Label();
            this.lblGescandeRoepnaam = new System.Windows.Forms.Label();
            this.lblGescandeNaam = new System.Windows.Forms.Label();
            this.lblGescandeRFID = new System.Windows.Forms.Label();
            this.lblRoepnaam = new System.Windows.Forms.Label();
            this.lblNaam = new System.Windows.Forms.Label();
            this.lblRFID = new System.Windows.Forms.Label();
            this.gbxScanSimulatie = new System.Windows.Forms.GroupBox();
            this.tbxScanRFID = new System.Windows.Forms.TextBox();
            this.btnScanRFID = new System.Windows.Forms.Button();
            this.btnAanwezigen = new System.Windows.Forms.Button();
            this.lbxAanwezigen = new System.Windows.Forms.ListBox();
            this.gbxAanwezigen = new System.Windows.Forms.GroupBox();
            this.gbxGescandeRFID.SuspendLayout();
            this.gbxReservering.SuspendLayout();
            this.gbxScanSimulatie.SuspendLayout();
            this.gbxAanwezigen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxGescandeRFID
            // 
            this.gbxGescandeRFID.Controls.Add(this.gbxReservering);
            this.gbxGescandeRFID.Controls.Add(this.lblGescandeRoepnaam);
            this.gbxGescandeRFID.Controls.Add(this.lblGescandeNaam);
            this.gbxGescandeRFID.Controls.Add(this.lblGescandeRFID);
            this.gbxGescandeRFID.Controls.Add(this.lblRoepnaam);
            this.gbxGescandeRFID.Controls.Add(this.lblNaam);
            this.gbxGescandeRFID.Controls.Add(this.lblRFID);
            this.gbxGescandeRFID.Location = new System.Drawing.Point(12, 68);
            this.gbxGescandeRFID.Name = "gbxGescandeRFID";
            this.gbxGescandeRFID.Size = new System.Drawing.Size(362, 195);
            this.gbxGescandeRFID.TabIndex = 3;
            this.gbxGescandeRFID.TabStop = false;
            this.gbxGescandeRFID.Text = "Gescande RFID";
            // 
            // gbxReservering
            // 
            this.gbxReservering.Controls.Add(this.btnReserveringAnnuleren);
            this.gbxReservering.Controls.Add(this.lblGescandeGroepshoofd);
            this.gbxReservering.Controls.Add(this.lblGescandePeriode);
            this.gbxReservering.Controls.Add(this.lblGescandeCampingplaats);
            this.gbxReservering.Controls.Add(this.chkBetaald);
            this.gbxReservering.Controls.Add(this.lblBetaald);
            this.gbxReservering.Controls.Add(this.lblPeriode);
            this.gbxReservering.Controls.Add(this.lblCampingplaats);
            this.gbxReservering.Controls.Add(this.lblGroepshoofd);
            this.gbxReservering.Location = new System.Drawing.Point(8, 91);
            this.gbxReservering.Name = "gbxReservering";
            this.gbxReservering.Size = new System.Drawing.Size(347, 96);
            this.gbxReservering.TabIndex = 7;
            this.gbxReservering.TabStop = false;
            this.gbxReservering.Text = "Reservering";
            // 
            // btnReserveringAnnuleren
            // 
            this.btnReserveringAnnuleren.Location = new System.Drawing.Point(189, 65);
            this.btnReserveringAnnuleren.Name = "btnReserveringAnnuleren";
            this.btnReserveringAnnuleren.Size = new System.Drawing.Size(152, 23);
            this.btnReserveringAnnuleren.TabIndex = 8;
            this.btnReserveringAnnuleren.Text = "Reservering annuleren";
            this.btnReserveringAnnuleren.UseVisualStyleBackColor = true;
            this.btnReserveringAnnuleren.Click += new System.EventHandler(this.btnReserveringAnnuleren_Click);
            // 
            // lblGescandeGroepshoofd
            // 
            this.lblGescandeGroepshoofd.AutoSize = true;
            this.lblGescandeGroepshoofd.Location = new System.Drawing.Point(104, 20);
            this.lblGescandeGroepshoofd.Name = "lblGescandeGroepshoofd";
            this.lblGescandeGroepshoofd.Size = new System.Drawing.Size(0, 13);
            this.lblGescandeGroepshoofd.TabIndex = 7;
            // 
            // lblGescandePeriode
            // 
            this.lblGescandePeriode.AutoSize = true;
            this.lblGescandePeriode.Location = new System.Drawing.Point(104, 49);
            this.lblGescandePeriode.Name = "lblGescandePeriode";
            this.lblGescandePeriode.Size = new System.Drawing.Size(0, 13);
            this.lblGescandePeriode.TabIndex = 6;
            // 
            // lblGescandeCampingplaats
            // 
            this.lblGescandeCampingplaats.AutoSize = true;
            this.lblGescandeCampingplaats.Location = new System.Drawing.Point(104, 35);
            this.lblGescandeCampingplaats.Name = "lblGescandeCampingplaats";
            this.lblGescandeCampingplaats.Size = new System.Drawing.Size(0, 13);
            this.lblGescandeCampingplaats.TabIndex = 5;
            // 
            // chkBetaald
            // 
            this.chkBetaald.AutoSize = true;
            this.chkBetaald.Location = new System.Drawing.Point(107, 65);
            this.chkBetaald.Name = "chkBetaald";
            this.chkBetaald.Size = new System.Drawing.Size(15, 14);
            this.chkBetaald.TabIndex = 4;
            this.chkBetaald.UseVisualStyleBackColor = true;
            this.chkBetaald.CheckedChanged += new System.EventHandler(this.chkBetaald_CheckedChanged);
            // 
            // lblBetaald
            // 
            this.lblBetaald.AutoSize = true;
            this.lblBetaald.Location = new System.Drawing.Point(50, 64);
            this.lblBetaald.Name = "lblBetaald";
            this.lblBetaald.Size = new System.Drawing.Size(46, 13);
            this.lblBetaald.TabIndex = 3;
            this.lblBetaald.Text = "Betaald:";
            // 
            // lblPeriode
            // 
            this.lblPeriode.AutoSize = true;
            this.lblPeriode.Location = new System.Drawing.Point(52, 49);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(46, 13);
            this.lblPeriode.TabIndex = 2;
            this.lblPeriode.Text = "Periode:";
            // 
            // lblCampingplaats
            // 
            this.lblCampingplaats.AutoSize = true;
            this.lblCampingplaats.Location = new System.Drawing.Point(19, 35);
            this.lblCampingplaats.Name = "lblCampingplaats";
            this.lblCampingplaats.Size = new System.Drawing.Size(79, 13);
            this.lblCampingplaats.TabIndex = 1;
            this.lblCampingplaats.Text = "Campingplaats:";
            // 
            // lblGroepshoofd
            // 
            this.lblGroepshoofd.AutoSize = true;
            this.lblGroepshoofd.Location = new System.Drawing.Point(27, 20);
            this.lblGroepshoofd.Name = "lblGroepshoofd";
            this.lblGroepshoofd.Size = new System.Drawing.Size(71, 13);
            this.lblGroepshoofd.TabIndex = 0;
            this.lblGroepshoofd.Text = "Groepshoofd:";
            // 
            // lblGescandeRoepnaam
            // 
            this.lblGescandeRoepnaam.AutoSize = true;
            this.lblGescandeRoepnaam.Location = new System.Drawing.Point(100, 58);
            this.lblGescandeRoepnaam.Name = "lblGescandeRoepnaam";
            this.lblGescandeRoepnaam.Size = new System.Drawing.Size(0, 13);
            this.lblGescandeRoepnaam.TabIndex = 6;
            // 
            // lblGescandeNaam
            // 
            this.lblGescandeNaam.AutoSize = true;
            this.lblGescandeNaam.Location = new System.Drawing.Point(100, 45);
            this.lblGescandeNaam.Name = "lblGescandeNaam";
            this.lblGescandeNaam.Size = new System.Drawing.Size(0, 13);
            this.lblGescandeNaam.TabIndex = 5;
            // 
            // lblGescandeRFID
            // 
            this.lblGescandeRFID.AutoSize = true;
            this.lblGescandeRFID.Location = new System.Drawing.Point(100, 32);
            this.lblGescandeRFID.Name = "lblGescandeRFID";
            this.lblGescandeRFID.Size = new System.Drawing.Size(0, 13);
            this.lblGescandeRFID.TabIndex = 4;
            // 
            // lblRoepnaam
            // 
            this.lblRoepnaam.AutoSize = true;
            this.lblRoepnaam.Location = new System.Drawing.Point(6, 58);
            this.lblRoepnaam.Name = "lblRoepnaam";
            this.lblRoepnaam.Size = new System.Drawing.Size(89, 13);
            this.lblRoepnaam.TabIndex = 3;
            this.lblRoepnaam.Text = "Media roepnaam:";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(56, 45);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(38, 13);
            this.lblNaam.TabIndex = 1;
            this.lblNaam.Text = "Naam:";
            // 
            // lblRFID
            // 
            this.lblRFID.AutoSize = true;
            this.lblRFID.Location = new System.Drawing.Point(59, 32);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(35, 13);
            this.lblRFID.TabIndex = 0;
            this.lblRFID.Text = "RFID:";
            // 
            // gbxScanSimulatie
            // 
            this.gbxScanSimulatie.Controls.Add(this.tbxScanRFID);
            this.gbxScanSimulatie.Controls.Add(this.btnScanRFID);
            this.gbxScanSimulatie.Location = new System.Drawing.Point(12, 12);
            this.gbxScanSimulatie.Name = "gbxScanSimulatie";
            this.gbxScanSimulatie.Size = new System.Drawing.Size(362, 45);
            this.gbxScanSimulatie.TabIndex = 2;
            this.gbxScanSimulatie.TabStop = false;
            this.gbxScanSimulatie.Text = "Scan simulatie";
            // 
            // tbxScanRFID
            // 
            this.tbxScanRFID.Location = new System.Drawing.Point(88, 18);
            this.tbxScanRFID.Name = "tbxScanRFID";
            this.tbxScanRFID.ReadOnly = true;
            this.tbxScanRFID.Size = new System.Drawing.Size(202, 20);
            this.tbxScanRFID.TabIndex = 1;
            // 
            // btnScanRFID
            // 
            this.btnScanRFID.Location = new System.Drawing.Point(7, 16);
            this.btnScanRFID.Name = "btnScanRFID";
            this.btnScanRFID.Size = new System.Drawing.Size(75, 23);
            this.btnScanRFID.TabIndex = 0;
            this.btnScanRFID.Text = "Scan RFID";
            this.btnScanRFID.UseVisualStyleBackColor = true;
            this.btnScanRFID.Click += new System.EventHandler(this.btnScanRFID_Click);
            // 
            // btnAanwezigen
            // 
            this.btnAanwezigen.Location = new System.Drawing.Point(281, 19);
            this.btnAanwezigen.Name = "btnAanwezigen";
            this.btnAanwezigen.Size = new System.Drawing.Size(75, 23);
            this.btnAanwezigen.TabIndex = 4;
            this.btnAanwezigen.Text = "Aanwezigen";
            this.btnAanwezigen.UseVisualStyleBackColor = true;
            this.btnAanwezigen.Click += new System.EventHandler(this.btnAanwezigen_Click);
            // 
            // lbxAanwezigen
            // 
            this.lbxAanwezigen.FormattingEnabled = true;
            this.lbxAanwezigen.Location = new System.Drawing.Point(6, 19);
            this.lbxAanwezigen.Name = "lbxAanwezigen";
            this.lbxAanwezigen.Size = new System.Drawing.Size(269, 160);
            this.lbxAanwezigen.TabIndex = 5;
            // 
            // gbxAanwezigen
            // 
            this.gbxAanwezigen.Controls.Add(this.lbxAanwezigen);
            this.gbxAanwezigen.Controls.Add(this.btnAanwezigen);
            this.gbxAanwezigen.Location = new System.Drawing.Point(12, 269);
            this.gbxAanwezigen.Name = "gbxAanwezigen";
            this.gbxAanwezigen.Size = new System.Drawing.Size(362, 185);
            this.gbxAanwezigen.TabIndex = 6;
            this.gbxAanwezigen.TabStop = false;
            this.gbxAanwezigen.Text = "Aanwezigen";
            // 
            // ToegangscontroleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 465);
            this.Controls.Add(this.gbxAanwezigen);
            this.Controls.Add(this.gbxGescandeRFID);
            this.Controls.Add(this.gbxScanSimulatie);
            this.Name = "ToegangscontroleForm";
            this.Text = "Toegangscontrole";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToegangscontroleForm_FormClosing);
            this.gbxGescandeRFID.ResumeLayout(false);
            this.gbxGescandeRFID.PerformLayout();
            this.gbxReservering.ResumeLayout(false);
            this.gbxReservering.PerformLayout();
            this.gbxScanSimulatie.ResumeLayout(false);
            this.gbxScanSimulatie.PerformLayout();
            this.gbxAanwezigen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxGescandeRFID;
        private System.Windows.Forms.GroupBox gbxReservering;
        private System.Windows.Forms.Button btnReserveringAnnuleren;
        private System.Windows.Forms.Label lblGescandeGroepshoofd;
        private System.Windows.Forms.Label lblGescandePeriode;
        private System.Windows.Forms.Label lblGescandeCampingplaats;
        private System.Windows.Forms.CheckBox chkBetaald;
        private System.Windows.Forms.Label lblBetaald;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Label lblCampingplaats;
        private System.Windows.Forms.Label lblGroepshoofd;
        private System.Windows.Forms.Label lblGescandeRoepnaam;
        private System.Windows.Forms.Label lblGescandeNaam;
        private System.Windows.Forms.Label lblGescandeRFID;
        private System.Windows.Forms.Label lblRoepnaam;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Label lblRFID;
        private System.Windows.Forms.GroupBox gbxScanSimulatie;
        private System.Windows.Forms.TextBox tbxScanRFID;
        private System.Windows.Forms.Button btnScanRFID;
        private System.Windows.Forms.Button btnAanwezigen;
        private System.Windows.Forms.ListBox lbxAanwezigen;
        private System.Windows.Forms.GroupBox gbxAanwezigen;
    }
}