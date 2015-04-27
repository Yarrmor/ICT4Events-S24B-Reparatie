namespace ICT4Events_S24B_Reparatie
{
    partial class CategorieNaam
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
            this.btnCategorieMaakAan = new System.Windows.Forms.Button();
            this.lblCategorieNaam = new System.Windows.Forms.Label();
            this.tbxCategorieNaam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCategorieMaakAan
            // 
            this.btnCategorieMaakAan.Location = new System.Drawing.Point(387, 12);
            this.btnCategorieMaakAan.Name = "btnCategorieMaakAan";
            this.btnCategorieMaakAan.Size = new System.Drawing.Size(75, 23);
            this.btnCategorieMaakAan.TabIndex = 0;
            this.btnCategorieMaakAan.Text = "Maak aan";
            this.btnCategorieMaakAan.UseVisualStyleBackColor = true;
            this.btnCategorieMaakAan.Click += new System.EventHandler(this.btnCategorieMaakAan_Click);
            // 
            // lblCategorieNaam
            // 
            this.lblCategorieNaam.AutoSize = true;
            this.lblCategorieNaam.Location = new System.Drawing.Point(12, 17);
            this.lblCategorieNaam.Name = "lblCategorieNaam";
            this.lblCategorieNaam.Size = new System.Drawing.Size(86, 13);
            this.lblCategorieNaam.TabIndex = 1;
            this.lblCategorieNaam.Text = "Categorie Naam:";
            // 
            // tbxCategorieNaam
            // 
            this.tbxCategorieNaam.Location = new System.Drawing.Point(104, 14);
            this.tbxCategorieNaam.Name = "tbxCategorieNaam";
            this.tbxCategorieNaam.Size = new System.Drawing.Size(277, 20);
            this.tbxCategorieNaam.TabIndex = 2;
            // 
            // CategorieNaam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 43);
            this.Controls.Add(this.tbxCategorieNaam);
            this.Controls.Add(this.lblCategorieNaam);
            this.Controls.Add(this.btnCategorieMaakAan);
            this.Name = "CategorieNaam";
            this.Text = "CategorieNaam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCategorieMaakAan;
        private System.Windows.Forms.Label lblCategorieNaam;
        public System.Windows.Forms.TextBox tbxCategorieNaam;
    }
}