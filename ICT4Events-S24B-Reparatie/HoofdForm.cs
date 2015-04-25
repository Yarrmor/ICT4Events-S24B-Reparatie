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
        private Algemeen alg;

        public HoofdForm()
        {
            alg = new Algemeen(this);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MediaSharingForm media = new MediaSharingForm(alg, new MediaSharingSysteem(alg.Evenement.ID));
            media.Show();
        }
    }
}
