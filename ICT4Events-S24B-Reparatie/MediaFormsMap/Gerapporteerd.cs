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
    public partial class Gerapporteerd : Form
    {
        private Algemeen alg;
        private MediaSharingSysteem md;

        public Gerapporteerd(Algemeen alg, MediaSharingSysteem md)
        {
            this.alg = alg;
            this.md = md;

            InitializeComponent();
            WeergeefMeldingen();
        }

        /// <summary>
        /// Haalt de meldingen op
        /// </summary>
        private void WeergeefMeldingen()
        {
            md.VerkrijgMeldingenLijst();
            lbxGerapporteerd.Items.Clear();
            foreach (Melding m in md.Meldingen)
            {
                lbxGerapporteerd.Items.Add(m.ToString());
            }
        }

        /// <summary>
        /// Laat de geselecteerde media zien in een nieuw form
        /// Laat zien wie de melder van de melding is.
        /// Laat de toelichting zien van de melding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxGerapporteerd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxGerapporteerd.SelectedItem != null)
            {
                foreach (Melding m in md.Meldingen)
                {
                    if (lbxGerapporteerd.SelectedItem.ToString() == m.ToString())
                    {
                        lblMelder.Text = m.Account.Roepnaam;
                        tbxToelichting.Text = m.Toelichting;
                        MediaSharingFormMediaForm msmf = new MediaSharingFormMediaForm(alg, md.VerkrijgMedia(m.MediaID), md);
                        msmf.Location = new Point(this.Location.X + this.Width + 100, this.Location.Y);
                        msmf.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Verwijdert de meldingen en weergeeft ze vervolgens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerwijderMelding_Click(object sender, EventArgs e)
        {
            if (lbxGerapporteerd.SelectedItem != null)
            {
                foreach (Melding m in md.Meldingen.ToList())
                {
                    if (lbxGerapporteerd.SelectedItem.ToString() == m.ToString())
                    {
                        md.VerwijderMelding(m);
                        //throw new NotImplementedException();
                    }
                }
            }
            WeergeefMeldingen();
        }

        /// <summary>
        /// Weergeeft de meldingen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WeergeefMeldingen();
        }
    }
}
