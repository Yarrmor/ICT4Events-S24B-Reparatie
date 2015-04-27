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
    public partial class VerifieerAccountForm : Form
    {
        EmailSimulatie emailSimulatie;

        public VerifieerAccountForm(EmailSimulatie emailSimulatie)
        {
            InitializeComponent();

            this.emailSimulatie = emailSimulatie;

        }

        private void btnVerifieer_Click(object sender, EventArgs e)
        {
            if (tbxWachtwoord.Text != tbxWachtwoordVerifieren.Text)
            {
                MessageBox.Show("Wachtwoord komt niet overeen!");
                return;
            }
            emailSimulatie.VerifieerAccount(emailSimulatie.GeselecteerdeEmail.Rfid, tbxVoornaam.Text, tbxAchternaam.Text, tbxRoepnaam.Text, tbxWachtwoord.Text);

            MessageBox.Show("Uw account is geverifeerd, u kunt nu inloggen.");

            this.Close();
        }
    }
}
