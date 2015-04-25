namespace ICT4Events_S24B_Reparatie
{
    partial class Gerapporteerd
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
            this.lbxGerapporteerd = new System.Windows.Forms.ListBox();
            this.btnVerwijderMelding = new System.Windows.Forms.Button();
            this.gbxMeldingInformatie = new System.Windows.Forms.GroupBox();
            this.lblMelderr = new System.Windows.Forms.Label();
            this.tbxToelichting = new System.Windows.Forms.TextBox();
            this.lblToelichting = new System.Windows.Forms.Label();
            this.lblMelder = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbxMeldingInformatie.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxGerapporteerd
            // 
            this.lbxGerapporteerd.FormattingEnabled = true;
            this.lbxGerapporteerd.Location = new System.Drawing.Point(12, 12);
            this.lbxGerapporteerd.Name = "lbxGerapporteerd";
            this.lbxGerapporteerd.Size = new System.Drawing.Size(274, 225);
            this.lbxGerapporteerd.TabIndex = 0;
            this.lbxGerapporteerd.SelectedIndexChanged += new System.EventHandler(this.lbxGerapporteerd_SelectedIndexChanged);
            // 
            // btnVerwijderMelding
            // 
            this.btnVerwijderMelding.Location = new System.Drawing.Point(12, 389);
            this.btnVerwijderMelding.Name = "btnVerwijderMelding";
            this.btnVerwijderMelding.Size = new System.Drawing.Size(274, 31);
            this.btnVerwijderMelding.TabIndex = 1;
            this.btnVerwijderMelding.Text = "Verwijder melding";
            this.btnVerwijderMelding.UseVisualStyleBackColor = true;
            this.btnVerwijderMelding.Click += new System.EventHandler(this.btnVerwijderMelding_Click);
            // 
            // gbxMeldingInformatie
            // 
            this.gbxMeldingInformatie.Controls.Add(this.lblMelderr);
            this.gbxMeldingInformatie.Controls.Add(this.tbxToelichting);
            this.gbxMeldingInformatie.Controls.Add(this.lblToelichting);
            this.gbxMeldingInformatie.Controls.Add(this.lblMelder);
            this.gbxMeldingInformatie.Location = new System.Drawing.Point(12, 244);
            this.gbxMeldingInformatie.Name = "gbxMeldingInformatie";
            this.gbxMeldingInformatie.Size = new System.Drawing.Size(274, 130);
            this.gbxMeldingInformatie.TabIndex = 2;
            this.gbxMeldingInformatie.TabStop = false;
            this.gbxMeldingInformatie.Text = "Informatie";
            // 
            // lblMelderr
            // 
            this.lblMelderr.AutoSize = true;
            this.lblMelderr.Location = new System.Drawing.Point(71, 26);
            this.lblMelderr.Name = "lblMelderr";
            this.lblMelderr.Size = new System.Drawing.Size(0, 13);
            this.lblMelderr.TabIndex = 3;
            // 
            // tbxToelichting
            // 
            this.tbxToelichting.Enabled = false;
            this.tbxToelichting.Location = new System.Drawing.Point(74, 52);
            this.tbxToelichting.Multiline = true;
            this.tbxToelichting.Name = "tbxToelichting";
            this.tbxToelichting.Size = new System.Drawing.Size(194, 72);
            this.tbxToelichting.TabIndex = 2;
            // 
            // lblToelichting
            // 
            this.lblToelichting.AutoSize = true;
            this.lblToelichting.Location = new System.Drawing.Point(6, 55);
            this.lblToelichting.Name = "lblToelichting";
            this.lblToelichting.Size = new System.Drawing.Size(62, 13);
            this.lblToelichting.TabIndex = 1;
            this.lblToelichting.Text = "Toelichting:";
            // 
            // lblMelder
            // 
            this.lblMelder.AutoSize = true;
            this.lblMelder.Location = new System.Drawing.Point(6, 26);
            this.lblMelder.Name = "lblMelder";
            this.lblMelder.Size = new System.Drawing.Size(42, 13);
            this.lblMelder.TabIndex = 0;
            this.lblMelder.Text = "Melder:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 426);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(274, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Gerapporteerd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 466);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gbxMeldingInformatie);
            this.Controls.Add(this.btnVerwijderMelding);
            this.Controls.Add(this.lbxGerapporteerd);
            this.Name = "Gerapporteerd";
            this.Text = "Gerapporteerd";
            this.gbxMeldingInformatie.ResumeLayout(false);
            this.gbxMeldingInformatie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxGerapporteerd;
        private System.Windows.Forms.Button btnVerwijderMelding;
        private System.Windows.Forms.GroupBox gbxMeldingInformatie;
        private System.Windows.Forms.Label lblMelderr;
        private System.Windows.Forms.TextBox tbxToelichting;
        private System.Windows.Forms.Label lblToelichting;
        private System.Windows.Forms.Label lblMelder;
        private System.Windows.Forms.Button btnRefresh;
    }
}