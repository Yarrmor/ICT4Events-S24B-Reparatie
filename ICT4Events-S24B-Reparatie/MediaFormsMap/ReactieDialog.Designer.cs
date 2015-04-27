namespace ICT4Events_S24B_Reparatie
{
    partial class ReactieDialog
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
            this.tbxReactieBericht = new System.Windows.Forms.TextBox();
            this.lblBericht = new System.Windows.Forms.Label();
            this.btnPlaatsReactie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxReactieBericht
            // 
            this.tbxReactieBericht.Location = new System.Drawing.Point(56, 14);
            this.tbxReactieBericht.Multiline = true;
            this.tbxReactieBericht.Name = "tbxReactieBericht";
            this.tbxReactieBericht.Size = new System.Drawing.Size(320, 92);
            this.tbxReactieBericht.TabIndex = 5;
            // 
            // lblBericht
            // 
            this.lblBericht.AutoSize = true;
            this.lblBericht.Location = new System.Drawing.Point(7, 17);
            this.lblBericht.Name = "lblBericht";
            this.lblBericht.Size = new System.Drawing.Size(43, 13);
            this.lblBericht.TabIndex = 4;
            this.lblBericht.Text = "Bericht:";
            // 
            // btnPlaatsReactie
            // 
            this.btnPlaatsReactie.Location = new System.Drawing.Point(382, 12);
            this.btnPlaatsReactie.Name = "btnPlaatsReactie";
            this.btnPlaatsReactie.Size = new System.Drawing.Size(75, 94);
            this.btnPlaatsReactie.TabIndex = 3;
            this.btnPlaatsReactie.Text = "Plaats Reactie";
            this.btnPlaatsReactie.UseVisualStyleBackColor = true;
            this.btnPlaatsReactie.Click += new System.EventHandler(this.btnPlaatsReactie_Click);
            // 
            // ReactieDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 118);
            this.Controls.Add(this.tbxReactieBericht);
            this.Controls.Add(this.lblBericht);
            this.Controls.Add(this.btnPlaatsReactie);
            this.Name = "ReactieDialog";
            this.Text = "ReactieDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbxReactieBericht;
        private System.Windows.Forms.Label lblBericht;
        private System.Windows.Forms.Button btnPlaatsReactie;
    }
}