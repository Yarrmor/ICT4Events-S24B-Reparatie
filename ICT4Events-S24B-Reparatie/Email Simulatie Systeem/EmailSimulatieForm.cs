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
    public partial class EmailSimulatieForm : Form
    {
        public Algemeen algemeen { get; set; }
        EmailSimulatie emailSimulatie;

        public EmailSimulatieForm(Algemeen algemeen)
        {
            InitializeComponent();
            this.algemeen = algemeen;

            btnAnnuleerReservering.Enabled = false;
            btnBetaalReservering.Enabled = false;
            btnVerifieerAccount.Enabled = false;

            emailSimulatie = new EmailSimulatie(algemeen);

            VerversEmails();
        }

        /// <summary>
        /// Haalt alle emails op en voegt deze toe aan de combobox.
        /// </summary>
        public void VerversEmails()
        {
            cbxEmails.Items.Clear();

            foreach (Email e in algemeen.Emails)
            {
                cbxEmails.Items.Add(e.Titel);
            }
        }

        /// <summary>
        /// Selecteert een email met meegegeven index,
        /// update velden met inhoud van geselecteerde
        /// email.
        /// </summary>
        /// <param name="i"></param>
        private void SelecteerEmail(int i)
        {
            emailSimulatie.SelecteerEmail(i);

            Email e = emailSimulatie.GeselecteerdeEmail;

            lblGeselecteerdeEmailOnderwerp.Text = e.Onderwerp;
            tbxGeselecteerdeEmailInhoud.Text = e.Inhoud;

            VerversKnoppen(e);

        }

        /// <summary>
        /// Zet de knoppen Verifieer, Betaal, Annuleer op enabled/disabled
        /// gebaseerd op de status van het account(rfid).
        /// </summary>
        /// <param name="rfid"></param>
        private void VerversKnoppen(Email e)
        {
            DatabaseManager dm = new DatabaseManager();

            if (e.Onderwerp == "Wachtwoordherstel ICT4Events")
            {
                btnAnnuleerReservering.Enabled = false;
                btnBetaalReservering.Enabled = false;
                btnMateriaalReserveren.Enabled = false;
                btnVerifieerAccount.Enabled = false;
                btnWijzigWachtwoord.Enabled = true;
            }
            else
            {
                // Verander ww knop
                btnWijzigWachtwoord.Enabled = false;

                // Verifieer knop
                int accountVerifieerd = dm.VerkrijgAccountVerifieerd(e.Rfid);

                btnVerifieerAccount.Enabled = (accountVerifieerd == 0);
                btnMateriaalReserveren.Enabled = (accountVerifieerd == 1);

                // Betaal/annuleer knop
                AccountType? accountType = dm.VerkrijgAccountType(e.Rfid, algemeen.Evenement.ID);
                bool reserveringBetaald = true;
                if (accountType == AccountType.Groepshoofd)
                    reserveringBetaald = dm.VerkrijgReserveringBetaald(e.Rfid, algemeen.Evenement.ID);

                btnBetaalReservering.Enabled = !reserveringBetaald;
                btnAnnuleerReservering.Enabled = !reserveringBetaald;
            }

        }

        /// <summary>
        /// selecteert de gewenste email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecteerEmail(cbxEmails.SelectedIndex);
        }

        /// <summary>
        /// Verifieert het account van de geselecteerde email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerifieerAccount_Click(object sender, EventArgs e)
        {
            VerifieerAccountForm vaf = new VerifieerAccountForm(emailSimulatie);
            vaf.ShowDialog();
        }

        /// <summary>
        /// Betaalt de reservering van de geselecteerde email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBetaalReservering_Click(object sender, EventArgs e)
        {
            emailSimulatie.BetaalReservering();
        }

        /// <summary>
        /// Annuleert de reservering van de geselecteerde email.
        /// Ververst de emails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuleerReservering_Click(object sender, EventArgs e)
        {
            if (emailSimulatie.AnnuleerReservering())
                MessageBox.Show("Uw reservering is geannuleerd!");
            VerversEmails();
        }

        /// <summary>
        /// Prompt een venster om het wachtwoord van het bijbehorende account te veranderen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWijzigWachtwoord_Click(object sender, EventArgs e)
        {

        }

        private void btnMateriaalReserveren_Click(object sender, EventArgs e)
        {
            algemeen.LogIn(emailSimulatie.GeselecteerdeEmail.Rfid);
            MateriaalReserverenForm mrf = new MateriaalReserverenForm(algemeen);
        }
    }
}
