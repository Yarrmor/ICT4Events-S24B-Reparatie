namespace ICT4Events_S24B_Reparatie
{
    partial class AccountLijst
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
            this.lbxAccounts = new System.Windows.Forms.ListBox();
            this.btnVerwijder = new System.Windows.Forms.Button();
            this.btVoegToe = new System.Windows.Forms.Button();
            this.btBanUnban = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxAccounts
            // 
            this.lbxAccounts.FormattingEnabled = true;
            this.lbxAccounts.Location = new System.Drawing.Point(13, 13);
            this.lbxAccounts.Name = "lbxAccounts";
            this.lbxAccounts.Size = new System.Drawing.Size(327, 303);
            this.lbxAccounts.TabIndex = 0;
            this.lbxAccounts.SelectedIndexChanged += new System.EventHandler(this.lbxAccounts_SelectedIndexChanged);
            // 
            // btnVerwijder
            // 
            this.btnVerwijder.Location = new System.Drawing.Point(12, 322);
            this.btnVerwijder.Name = "btnVerwijder";
            this.btnVerwijder.Size = new System.Drawing.Size(75, 23);
            this.btnVerwijder.TabIndex = 1;
            this.btnVerwijder.Text = "Verwijder";
            this.btnVerwijder.UseVisualStyleBackColor = true;
            // 
            // btVoegToe
            // 
            this.btVoegToe.Location = new System.Drawing.Point(93, 322);
            this.btVoegToe.Name = "btVoegToe";
            this.btVoegToe.Size = new System.Drawing.Size(75, 23);
            this.btVoegToe.TabIndex = 2;
            this.btVoegToe.Text = "VoegToe";
            this.btVoegToe.UseVisualStyleBackColor = true;
            this.btVoegToe.Click += new System.EventHandler(this.btVoegToe_Click);
            // 
            // btBanUnban
            // 
            this.btBanUnban.Location = new System.Drawing.Point(174, 322);
            this.btBanUnban.Name = "btBanUnban";
            this.btBanUnban.Size = new System.Drawing.Size(75, 23);
            this.btBanUnban.TabIndex = 3;
            this.btBanUnban.Text = "Ban/Unban";
            this.btBanUnban.UseVisualStyleBackColor = true;
            // 
            // AccountLijst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 356);
            this.Controls.Add(this.btBanUnban);
            this.Controls.Add(this.btVoegToe);
            this.Controls.Add(this.btnVerwijder);
            this.Controls.Add(this.lbxAccounts);
            this.Name = "AccountLijst";
            this.Text = "AccountLijst";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAccounts;
        private System.Windows.Forms.Button btnVerwijder;
        private System.Windows.Forms.Button btVoegToe;
        private System.Windows.Forms.Button btBanUnban;
    }
}