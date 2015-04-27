namespace ICT4Events_S24B_Reparatie
{
    partial class EmailSimulatieForm
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
            this.lblSelecteerEmail = new System.Windows.Forms.Label();
            this.cbxEmails = new System.Windows.Forms.ComboBox();
            this.gbxGeselecteerdeEmail = new System.Windows.Forms.GroupBox();
            this.btnWijzigWachtwoord = new System.Windows.Forms.Button();
            this.btnAnnuleerReservering = new System.Windows.Forms.Button();
            this.btnBetaalReservering = new System.Windows.Forms.Button();
            this.btnVerifieerAccount = new System.Windows.Forms.Button();
            this.lblGeselecteerdeEmailOnderwerp = new System.Windows.Forms.Label();
            this.lblEmailOnderwerp = new System.Windows.Forms.Label();
            this.tbxGeselecteerdeEmailInhoud = new System.Windows.Forms.TextBox();
            this.gbxGeselecteerdeEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelecteerEmail
            // 
            this.lblSelecteerEmail.AutoSize = true;
            this.lblSelecteerEmail.Location = new System.Drawing.Point(12, 9);
            this.lblSelecteerEmail.Name = "lblSelecteerEmail";
            this.lblSelecteerEmail.Size = new System.Drawing.Size(87, 13);
            this.lblSelecteerEmail.TabIndex = 0;
            this.lblSelecteerEmail.Text = "Selecteer E-Mail:";
            // 
            // cbxEmails
            // 
            this.cbxEmails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmails.FormattingEnabled = true;
            this.cbxEmails.Location = new System.Drawing.Point(105, 6);
            this.cbxEmails.Name = "cbxEmails";
            this.cbxEmails.Size = new System.Drawing.Size(417, 21);
            this.cbxEmails.TabIndex = 1;
            this.cbxEmails.SelectedIndexChanged += new System.EventHandler(this.cbxEmails_SelectedIndexChanged);
            // 
            // gbxGeselecteerdeEmail
            // 
            this.gbxGeselecteerdeEmail.Controls.Add(this.btnWijzigWachtwoord);
            this.gbxGeselecteerdeEmail.Controls.Add(this.btnAnnuleerReservering);
            this.gbxGeselecteerdeEmail.Controls.Add(this.btnBetaalReservering);
            this.gbxGeselecteerdeEmail.Controls.Add(this.btnVerifieerAccount);
            this.gbxGeselecteerdeEmail.Controls.Add(this.lblGeselecteerdeEmailOnderwerp);
            this.gbxGeselecteerdeEmail.Controls.Add(this.lblEmailOnderwerp);
            this.gbxGeselecteerdeEmail.Controls.Add(this.tbxGeselecteerdeEmailInhoud);
            this.gbxGeselecteerdeEmail.Location = new System.Drawing.Point(12, 33);
            this.gbxGeselecteerdeEmail.Name = "gbxGeselecteerdeEmail";
            this.gbxGeselecteerdeEmail.Size = new System.Drawing.Size(510, 380);
            this.gbxGeselecteerdeEmail.TabIndex = 2;
            this.gbxGeselecteerdeEmail.TabStop = false;
            this.gbxGeselecteerdeEmail.Text = "Geselecteerde E-Mail:";
            // 
            // btnWijzigWachtwoord
            // 
            this.btnWijzigWachtwoord.Enabled = false;
            this.btnWijzigWachtwoord.Location = new System.Drawing.Point(124, 351);
            this.btnWijzigWachtwoord.Name = "btnWijzigWachtwoord";
            this.btnWijzigWachtwoord.Size = new System.Drawing.Size(112, 23);
            this.btnWijzigWachtwoord.TabIndex = 8;
            this.btnWijzigWachtwoord.Text = "Wijzig Wachtwoord";
            this.btnWijzigWachtwoord.UseVisualStyleBackColor = true;
            this.btnWijzigWachtwoord.Click += new System.EventHandler(this.btnWijzigWachtwoord_Click);
            // 
            // btnAnnuleerReservering
            // 
            this.btnAnnuleerReservering.Enabled = false;
            this.btnAnnuleerReservering.Location = new System.Drawing.Point(392, 351);
            this.btnAnnuleerReservering.Name = "btnAnnuleerReservering";
            this.btnAnnuleerReservering.Size = new System.Drawing.Size(112, 23);
            this.btnAnnuleerReservering.TabIndex = 7;
            this.btnAnnuleerReservering.Text = "Annuleer reservering";
            this.btnAnnuleerReservering.UseVisualStyleBackColor = true;
            this.btnAnnuleerReservering.Click += new System.EventHandler(this.btnAnnuleerReservering_Click);
            // 
            // btnBetaalReservering
            // 
            this.btnBetaalReservering.Enabled = false;
            this.btnBetaalReservering.Location = new System.Drawing.Point(274, 351);
            this.btnBetaalReservering.Name = "btnBetaalReservering";
            this.btnBetaalReservering.Size = new System.Drawing.Size(112, 23);
            this.btnBetaalReservering.TabIndex = 6;
            this.btnBetaalReservering.Text = "Betaal Reservering";
            this.btnBetaalReservering.UseVisualStyleBackColor = true;
            this.btnBetaalReservering.Click += new System.EventHandler(this.btnBetaalReservering_Click);
            // 
            // btnVerifieerAccount
            // 
            this.btnVerifieerAccount.Enabled = false;
            this.btnVerifieerAccount.Location = new System.Drawing.Point(6, 351);
            this.btnVerifieerAccount.Name = "btnVerifieerAccount";
            this.btnVerifieerAccount.Size = new System.Drawing.Size(112, 23);
            this.btnVerifieerAccount.TabIndex = 5;
            this.btnVerifieerAccount.Text = "Verifieer Account";
            this.btnVerifieerAccount.UseVisualStyleBackColor = true;
            this.btnVerifieerAccount.Click += new System.EventHandler(this.btnVerifieerAccount_Click);
            // 
            // lblGeselecteerdeEmailOnderwerp
            // 
            this.lblGeselecteerdeEmailOnderwerp.AutoSize = true;
            this.lblGeselecteerdeEmailOnderwerp.Location = new System.Drawing.Point(77, 17);
            this.lblGeselecteerdeEmailOnderwerp.Name = "lblGeselecteerdeEmailOnderwerp";
            this.lblGeselecteerdeEmailOnderwerp.Size = new System.Drawing.Size(130, 13);
            this.lblGeselecteerdeEmailOnderwerp.TabIndex = 4;
            this.lblGeselecteerdeEmailOnderwerp.Text = "Geen e-mail geselecteerd.";
            // 
            // lblEmailOnderwerp
            // 
            this.lblEmailOnderwerp.AutoSize = true;
            this.lblEmailOnderwerp.Location = new System.Drawing.Point(9, 17);
            this.lblEmailOnderwerp.Name = "lblEmailOnderwerp";
            this.lblEmailOnderwerp.Size = new System.Drawing.Size(62, 13);
            this.lblEmailOnderwerp.TabIndex = 3;
            this.lblEmailOnderwerp.Text = "Onderwerp:";
            // 
            // tbxGeselecteerdeEmailInhoud
            // 
            this.tbxGeselecteerdeEmailInhoud.Location = new System.Drawing.Point(6, 37);
            this.tbxGeselecteerdeEmailInhoud.Multiline = true;
            this.tbxGeselecteerdeEmailInhoud.Name = "tbxGeselecteerdeEmailInhoud";
            this.tbxGeselecteerdeEmailInhoud.ReadOnly = true;
            this.tbxGeselecteerdeEmailInhoud.Size = new System.Drawing.Size(498, 308);
            this.tbxGeselecteerdeEmailInhoud.TabIndex = 0;
            // 
            // EmailSimulatieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 424);
            this.Controls.Add(this.gbxGeselecteerdeEmail);
            this.Controls.Add(this.cbxEmails);
            this.Controls.Add(this.lblSelecteerEmail);
            this.Name = "EmailSimulatieForm";
            this.Text = "E-Mail (Simulatie)";
            this.gbxGeselecteerdeEmail.ResumeLayout(false);
            this.gbxGeselecteerdeEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelecteerEmail;
        private System.Windows.Forms.ComboBox cbxEmails;
        private System.Windows.Forms.GroupBox gbxGeselecteerdeEmail;
        private System.Windows.Forms.Label lblGeselecteerdeEmailOnderwerp;
        private System.Windows.Forms.Label lblEmailOnderwerp;
        private System.Windows.Forms.TextBox tbxGeselecteerdeEmailInhoud;
        private System.Windows.Forms.Button btnAnnuleerReservering;
        private System.Windows.Forms.Button btnBetaalReservering;
        private System.Windows.Forms.Button btnVerifieerAccount;
        private System.Windows.Forms.Button btnWijzigWachtwoord;
    }
}