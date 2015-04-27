namespace ICT4Events_S24B_Reparatie
{
    partial class InlogForm
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
            this.lblWachtwoordVergeten = new System.Windows.Forms.Label();
            this.btnInlog = new System.Windows.Forms.Button();
            this.tbxWachtwoord = new System.Windows.Forms.TextBox();
            this.lblWachtwoord = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWachtwoordVergeten
            // 
            this.lblWachtwoordVergeten.AutoSize = true;
            this.lblWachtwoordVergeten.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWachtwoordVergeten.Location = new System.Drawing.Point(86, 94);
            this.lblWachtwoordVergeten.Name = "lblWachtwoordVergeten";
            this.lblWachtwoordVergeten.Size = new System.Drawing.Size(102, 12);
            this.lblWachtwoordVergeten.TabIndex = 11;
            this.lblWachtwoordVergeten.Text = "Wachtwoord vergeten?";
            this.lblWachtwoordVergeten.Click += new System.EventHandler(this.lblWachtwoordVergeten_Click);
            // 
            // btnInlog
            // 
            this.btnInlog.Location = new System.Drawing.Point(57, 115);
            this.btnInlog.Name = "btnInlog";
            this.btnInlog.Size = new System.Drawing.Size(75, 23);
            this.btnInlog.TabIndex = 10;
            this.btnInlog.Text = "Inloggen";
            this.btnInlog.UseVisualStyleBackColor = true;
            this.btnInlog.Click += new System.EventHandler(this.btnInlog_Click);
            // 
            // tbxWachtwoord
            // 
            this.tbxWachtwoord.Location = new System.Drawing.Point(7, 71);
            this.tbxWachtwoord.Name = "tbxWachtwoord";
            this.tbxWachtwoord.PasswordChar = '*';
            this.tbxWachtwoord.Size = new System.Drawing.Size(178, 20);
            this.tbxWachtwoord.TabIndex = 9;
            this.tbxWachtwoord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxWachtwoord_KeyPress);
            // 
            // lblWachtwoord
            // 
            this.lblWachtwoord.AutoSize = true;
            this.lblWachtwoord.Location = new System.Drawing.Point(58, 54);
            this.lblWachtwoord.Name = "lblWachtwoord";
            this.lblWachtwoord.Size = new System.Drawing.Size(68, 13);
            this.lblWachtwoord.TabIndex = 8;
            this.lblWachtwoord.Text = "Wachtwoord";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(7, 26);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(178, 20);
            this.tbxEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(62, 9);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(64, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-mail adres";
            // 
            // InlogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 147);
            this.Controls.Add(this.lblWachtwoordVergeten);
            this.Controls.Add(this.btnInlog);
            this.Controls.Add(this.tbxWachtwoord);
            this.Controls.Add(this.lblWachtwoord);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.lblEmail);
            this.Name = "InlogForm";
            this.Text = "Inloggen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWachtwoordVergeten;
        private System.Windows.Forms.Button btnInlog;
        private System.Windows.Forms.TextBox tbxWachtwoord;
        private System.Windows.Forms.Label lblWachtwoord;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblEmail;
    }
}