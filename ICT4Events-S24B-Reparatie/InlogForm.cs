using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events_S24B_Reparatie
{
    public partial class InlogForm : Form
    {
        public Algemeen algemeen { get; set; }

        public InlogForm(Algemeen algemeen)
        {
            InitializeComponent();
            this.algemeen = algemeen;
        }

        /// <summary>
        /// Er wordt geprobeerd om in te loggen. Wanneer dit fout gaat wordt een foutmelding getoond
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInlog_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void lblWachtwoordVergeten_Click(object sender, EventArgs e)
        {
            if (algemeen.WachtwoordVergeten(tbxEmail.Text))
                MessageBox.Show("U heeft een e-mail ontvangen om uw wachtwoord te wijzigen.");
            else
                MessageBox.Show("Dit e-mail komt niet voor in ons systeem, of het account is nog niet geverifieerd!");
        }

        private void tbxWachtwoord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LogIn();
        }

        private void LogIn()
        {
            string foutmelding = algemeen.VerifieerLogin(tbxEmail.Text, tbxWachtwoord.Text);
            if (foutmelding != "")
                MessageBox.Show("Er is een fout opgetreden:\n" + foutmelding);
            else
                this.Close();
        }
    }
}
