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
    public partial class Rapporteer : Form
    {
        private Algemeen alg;
        private Media m;
        private MediaSharingSysteem md;

        public Rapporteer(Algemeen alg, Media m, MediaSharingSysteem md)
        {
            this.alg = alg;
            this.m = m;
            this.md = md;
            InitializeComponent();
        }

        /// <summary>
        /// Er wordt een nieuwe melding gemaakt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRapporteer_Click(object sender, EventArgs e)
        {
            md.VoegMeldingToe(new Melding(alg.Account, m.MediaID, tbxToelichting.Text, DateTime.Now));
            this.Dispose();
        }
    }
}
