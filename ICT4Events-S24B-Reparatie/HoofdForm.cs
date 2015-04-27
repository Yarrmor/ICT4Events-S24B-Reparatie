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
    public partial class HoofdForm : Form
    {

        public Algemeen Algemeen { get; set; }

        MenuStrip ms = new MenuStrip();

        private MediaSharingForm media;

        public HoofdForm()
        {
            InitializeComponent();

            Algemeen = new Algemeen(this);

            MaakMenuBalk();
        }

        /// <summary>
        /// Er wordt gekeken of er kan worden ingelogd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInloggen_Click(object sender, EventArgs e)
        {
            if(Algemeen.Account == null)
            {
                Algemeen.LogIn();
                if(Algemeen.Account != null)
                {
                    btnInloggen.Text = "Uitloggen";
                }
            }
            else if(Algemeen.Account != null)
            {
                Algemeen.LogUit();
                if(Algemeen.Account == null)
                {
                    btnInloggen.Text = "Inloggen";
                }
            }
        }

        /// <summary>
        /// Het reserveringsform wordt geopend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReserveringen_Click(object sender, EventArgs e)
        {
            ReserveringForm reserveringForm = new ReserveringForm(Algemeen);
            reserveringForm.ShowDialog();
        }

        /// <summary>
        /// Het emailsimulatie form wordt geopend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmailApplicatie_Click(object sender, EventArgs e)
        {
            EmailSimulatieForm emailForm = new EmailSimulatieForm(Algemeen);
            emailForm.ShowDialog();
        }

        /// <summary>
        /// De toegangscontrole form wordt geopend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToegangscontrole_Click(object sender, EventArgs e)
        {
            ToegangscontroleForm toegangsControleForm = new ToegangscontroleForm(Algemeen);
            toegangsControleForm.ShowDialog();
        }

        public void MaakMenuBalk()
        {
            Algemeen.MaakMenuBalk(this, ms);
        }

        public void UpdateMenuBalk()
        {
            Algemeen.UpdateMenuBalk(this, ms);
            if (this.media != null)
            {
                this.media.Close();
            }
        }

        private void btnMediaApplicatie_Click(object sender, EventArgs e)
        {
            if (Algemeen.Account != null)
            {
                media = new MediaSharingForm(Algemeen, new MediaSharingSysteem(Algemeen.Evenement.ID));
                media.ShowDialog();
            }
            else
            {
                MessageBox.Show("Om dit gedeelte te kunnen bekijken moet je ingelogd zijn.");
            }
        }
    }
}
