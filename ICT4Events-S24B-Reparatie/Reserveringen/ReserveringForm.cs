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
    public partial class ReserveringForm : Form, ILoginSysteem
    {
        private Algemeen algemeen;

        public ReserveringForm(Algemeen algemeen)
        {
            InitializeComponent();
            this.algemeen = algemeen;
        }

        /// <summary>
        /// Het plekreserverings form wordt geopend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaatsReserveren_Click(object sender, EventArgs e)
        {
            PlaatsReserveringForm plaatsReserveringForm = new PlaatsReserveringForm(algemeen);
            plaatsReserveringForm.ShowDialog();
        }

        /// <summary>
        /// Het materiaalreservering form wordt geopend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMateriaalReserveren_Click(object sender, EventArgs e)
        {
            if (algemeen.Account == null)
            {
                MessageBox.Show("U moet ingelogd zijn om materiaal te reserveren!");
                return;
            }
            MateriaalReserverenForm materiaalReserverenForm = new MateriaalReserverenForm(algemeen);
            materiaalReserverenForm.ShowDialog();
        }

        public void MaakMenuBalk()
        {
            MenuStrip ms = new MenuStrip();

            algemeen.MaakMenuBalk(this, ms);
        }

        public void UpdateMenuBalk()
        {
            throw new NotImplementedException();
        }
    }
}
