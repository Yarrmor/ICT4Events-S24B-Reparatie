namespace ICT4Events_S24B_Reparatie
{
    partial class ReserveringForm
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
            this.btnMateriaalReserveren = new System.Windows.Forms.Button();
            this.btnPlaatsReserveren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMateriaalReserveren
            // 
            this.btnMateriaalReserveren.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMateriaalReserveren.Location = new System.Drawing.Point(218, 12);
            this.btnMateriaalReserveren.Name = "btnMateriaalReserveren";
            this.btnMateriaalReserveren.Size = new System.Drawing.Size(200, 200);
            this.btnMateriaalReserveren.TabIndex = 2;
            this.btnMateriaalReserveren.Text = "Materiaal\r\nreserveren";
            this.btnMateriaalReserveren.UseVisualStyleBackColor = true;
            this.btnMateriaalReserveren.Click += new System.EventHandler(this.btnMateriaalReserveren_Click);
            // 
            // btnPlaatsReserveren
            // 
            this.btnPlaatsReserveren.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaatsReserveren.Location = new System.Drawing.Point(12, 12);
            this.btnPlaatsReserveren.Name = "btnPlaatsReserveren";
            this.btnPlaatsReserveren.Size = new System.Drawing.Size(200, 200);
            this.btnPlaatsReserveren.TabIndex = 1;
            this.btnPlaatsReserveren.Text = "Plaats\r\nreserveren";
            this.btnPlaatsReserveren.UseVisualStyleBackColor = true;
            this.btnPlaatsReserveren.Click += new System.EventHandler(this.btnPlaatsReserveren_Click);
            // 
            // ReserveringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 222);
            this.Controls.Add(this.btnMateriaalReserveren);
            this.Controls.Add(this.btnPlaatsReserveren);
            this.Name = "ReserveringForm";
            this.Text = "Selecteer een keuze";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMateriaalReserveren;
        private System.Windows.Forms.Button btnPlaatsReserveren;
    }
}