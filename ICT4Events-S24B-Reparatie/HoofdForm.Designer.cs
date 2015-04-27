namespace ICT4Events_S24B_Reparatie
{
    partial class HoofdForm
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
            this.btnReserveringen = new System.Windows.Forms.Button();
            this.btnInloggen = new System.Windows.Forms.Button();
            this.btnMediaApplicatie = new System.Windows.Forms.Button();
            this.btnEmailApplicatie = new System.Windows.Forms.Button();
            this.btnToegangscontrole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReserveringen
            // 
            this.btnReserveringen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserveringen.Location = new System.Drawing.Point(12, 12);
            this.btnReserveringen.Name = "btnReserveringen";
            this.btnReserveringen.Size = new System.Drawing.Size(200, 200);
            this.btnReserveringen.TabIndex = 1;
            this.btnReserveringen.Text = "Reserveringen maken";
            this.btnReserveringen.UseVisualStyleBackColor = true;
            this.btnReserveringen.Click += new System.EventHandler(this.btnReserveringen_Click);
            // 
            // btnInloggen
            // 
            this.btnInloggen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInloggen.Location = new System.Drawing.Point(218, 12);
            this.btnInloggen.Name = "btnInloggen";
            this.btnInloggen.Size = new System.Drawing.Size(200, 200);
            this.btnInloggen.TabIndex = 2;
            this.btnInloggen.Text = "Inloggen";
            this.btnInloggen.UseVisualStyleBackColor = true;
            this.btnInloggen.Click += new System.EventHandler(this.btnInloggen_Click);
            // 
            // btnMediaApplicatie
            // 
            this.btnMediaApplicatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaApplicatie.Location = new System.Drawing.Point(424, 12);
            this.btnMediaApplicatie.Name = "btnMediaApplicatie";
            this.btnMediaApplicatie.Size = new System.Drawing.Size(200, 200);
            this.btnMediaApplicatie.TabIndex = 3;
            this.btnMediaApplicatie.Text = "Media Applicatie";
            this.btnMediaApplicatie.UseVisualStyleBackColor = true;
            this.btnMediaApplicatie.Click += new System.EventHandler(this.btnMediaApplicatie_Click);
            // 
            // btnEmailApplicatie
            // 
            this.btnEmailApplicatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailApplicatie.Location = new System.Drawing.Point(323, 218);
            this.btnEmailApplicatie.Name = "btnEmailApplicatie";
            this.btnEmailApplicatie.Size = new System.Drawing.Size(200, 200);
            this.btnEmailApplicatie.TabIndex = 5;
            this.btnEmailApplicatie.Text = "E-Mail Applicatie";
            this.btnEmailApplicatie.UseVisualStyleBackColor = true;
            this.btnEmailApplicatie.Click += new System.EventHandler(this.btnEmailApplicatie_Click);
            // 
            // btnToegangscontrole
            // 
            this.btnToegangscontrole.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToegangscontrole.Location = new System.Drawing.Point(117, 218);
            this.btnToegangscontrole.Name = "btnToegangscontrole";
            this.btnToegangscontrole.Size = new System.Drawing.Size(200, 200);
            this.btnToegangscontrole.TabIndex = 4;
            this.btnToegangscontrole.Text = "Toegangscontrole";
            this.btnToegangscontrole.UseVisualStyleBackColor = true;
            this.btnToegangscontrole.Click += new System.EventHandler(this.btnToegangscontrole_Click);
            // 
            // HoofdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 429);
            this.Controls.Add(this.btnEmailApplicatie);
            this.Controls.Add(this.btnToegangscontrole);
            this.Controls.Add(this.btnMediaApplicatie);
            this.Controls.Add(this.btnInloggen);
            this.Controls.Add(this.btnReserveringen);
            this.Name = "HoofdForm";
            this.Text = "ICT4Event Applicatie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReserveringen;
        private System.Windows.Forms.Button btnInloggen;
        private System.Windows.Forms.Button btnMediaApplicatie;
        private System.Windows.Forms.Button btnEmailApplicatie;
        private System.Windows.Forms.Button btnToegangscontrole;
    }
}

