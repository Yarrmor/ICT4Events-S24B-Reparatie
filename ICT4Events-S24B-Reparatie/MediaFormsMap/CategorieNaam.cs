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
    public partial class CategorieNaam : Form
    {
        public CategorieNaam()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maakt een nieuwe categorie aan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategorieMaakAan_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
