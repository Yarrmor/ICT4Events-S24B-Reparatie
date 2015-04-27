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
    public partial class ToegangscontroleForm : Form
    {
        public Algemeen Algemeen { get; set; }

        Toegangscontrole toegangscontrole;

        public bool Scannen { get; set; }

        public ToegangscontroleForm(Algemeen algemeen)
        {
            InitializeComponent();

            Algemeen = algemeen;

            Scannen = false;

            toegangscontrole = new Toegangscontrole(algemeen, this);
        }

        /// <summary>
        /// Reserveringsplaats van meegegeven rfid wordt geupdated
        /// </summary>
        /// <param name="rfid"></param>
        public void RFIDGescand(string rfid)
        {
            tbxScanRFID.Text = rfid;

            btnScanRFID.Enabled = true;
            Scannen = false;

            if(!toegangscontrole.ZetAanwezig(rfid))
            {
                MessageBox.Show("Actie mislukt.");
            }

            ReserveringPlaats rp = toegangscontrole.VerkrijgReserveringPlaats(tbxScanRFID.Text);

            UpdateLabels(rp);
        }

        /// <summary>
        /// Het rfid wordt gescand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScanRFID_Click(object sender, EventArgs e)
        {
            btnScanRFID.Enabled = false;
            Scannen = true;
        }

        /// <summary>
        /// De labels worden geupdated. 
        /// Wanneer er nog niet betaald is wordt de checkbox op false gezet
        /// </summary>
        /// <param name="rp"></param>
        private void UpdateLabels(ReserveringPlaats rp)
        {
            Account account = toegangscontrole.VerkrijgGroepslid(tbxScanRFID.Text);

            lblGescandeRFID.Text = account.Rfid;
            lblGescandeNaam.Text = account.Voornaam + " " + account.Achternaam;
            lblGescandeRoepnaam.Text = account.Roepnaam;

            lblGescandeGroepshoofd.Text = rp.Groepshoofd.Voornaam + " " + rp.Groepshoofd.Achternaam;
            lblGescandeCampingplaats.Text = rp.Plek.PlekID.ToString();
            lblGescandePeriode.Text = "Van: " + rp.DatumStart.ToString() + " Tot: " + rp.DatumEind.ToString();
            if (rp.Betaald)
            {
                chkBetaald.Checked = true;
                chkBetaald.Enabled = false;
                btnReserveringAnnuleren.Enabled = false;
            }
            else
            {
                chkBetaald.Checked = false;
            }
        }

        /// <summary>
        /// Er wordt geprobeert om te betalen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBetaald_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBetaald.Checked)
            {
                if (!toegangscontrole.ZetBetaald(lblGescandeRFID.Text))
                {
                    MessageBox.Show("Reservering op betaald zetten is mislukt.");
                }
            }
        }

        /// <summary>
        /// Er wordt geprobeerd om de reservering te annuleren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReserveringAnnuleren_Click(object sender, EventArgs e)
        {
            if (!toegangscontrole.AnnuleringReservering(lblGescandeRFID.Text))
            {
                MessageBox.Show("Annuleren van reservering is mislukt.");
            }
        }

        /// <summary>
        /// Het toegangscontrole form wordt gesloten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToegangscontroleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            toegangscontrole.Sluit();
        }

        private void btnAanwezigen_Click(object sender, EventArgs e)
        {
            lbxAanwezigen.Items.Clear();

            List<Account> aanwezigen = toegangscontrole.Aanwezigen(Algemeen.Evenement.ID);

            foreach(Account account in aanwezigen)
            {
                lbxAanwezigen.Items.Add(account.Rfid + " " + account.Voornaam + " " + account.Achternaam);
            }
        }

        //public void MaakMenuBalk()
        //{
        //    MenuStrip ms = new MenuStrip();

        //    Algemeen.MaakMenuBalk(this, ms);

        //}

        //public void UpdateMenuBalk()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
