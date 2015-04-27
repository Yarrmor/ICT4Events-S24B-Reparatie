namespace ICT4Events_S24B_Reparatie
{
    partial class Rapporteer
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
            this.lblToelichting = new System.Windows.Forms.Label();
            this.tbxToelichting = new System.Windows.Forms.TextBox();
            this.btnRapporteer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblToelichting
            // 
            this.lblToelichting.AutoSize = true;
            this.lblToelichting.Location = new System.Drawing.Point(13, 13);
            this.lblToelichting.Name = "lblToelichting";
            this.lblToelichting.Size = new System.Drawing.Size(62, 13);
            this.lblToelichting.TabIndex = 0;
            this.lblToelichting.Text = "Toelichting:";
            // 
            // tbxToelichting
            // 
            this.tbxToelichting.Location = new System.Drawing.Point(82, 13);
            this.tbxToelichting.Multiline = true;
            this.tbxToelichting.Name = "tbxToelichting";
            this.tbxToelichting.Size = new System.Drawing.Size(332, 112);
            this.tbxToelichting.TabIndex = 1;
            // 
            // btnRapporteer
            // 
            this.btnRapporteer.Location = new System.Drawing.Point(420, 11);
            this.btnRapporteer.Name = "btnRapporteer";
            this.btnRapporteer.Size = new System.Drawing.Size(104, 114);
            this.btnRapporteer.TabIndex = 2;
            this.btnRapporteer.Text = "rapporteer";
            this.btnRapporteer.UseVisualStyleBackColor = true;
            this.btnRapporteer.Click += new System.EventHandler(this.btnRapporteer_Click);
            // 
            // Rapporteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 137);
            this.Controls.Add(this.btnRapporteer);
            this.Controls.Add(this.tbxToelichting);
            this.Controls.Add(this.lblToelichting);
            this.Name = "Rapporteer";
            this.Text = "Rapporteer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToelichting;
        private System.Windows.Forms.TextBox tbxToelichting;
        private System.Windows.Forms.Button btnRapporteer;
    }
}