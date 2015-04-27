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
    public partial class MateriaalReserverenForm : Form
    {
        private Algemeen algemeen;
        private int firsttime = 1;

        public List<Materiaal> mats;
        public MateriaalReserverenForm(Algemeen alg)
        {
            DatabaseManager dm = new DatabaseManager();
            mats = dm.VerkrijgMateriaal(alg.Evenement.ID);
            this.algemeen = alg;
            InitializeComponent();
            gbxUitgeleendMateriaal.Visible = false;
            gbxMateriaalToevoegen.Visible = false;
            
            if (alg.Account == null)
            {
                if(alg.Account.Type == AccountType.Beheerder)
                {
                    gbxUitgeleendMateriaal.Visible = true;
                    gbxMateriaalToevoegen.Visible = true;
                }
            }
            VerversMaterialen();
            
        }

        private void btnMateriaalReserveren_Click(object sender, EventArgs e)
        {
            if(lbxMaterialen.SelectedItem != null)
            {
                Materiaal m = lbxMaterialen.SelectedItem as Materiaal;
                DatabaseManager dm = new DatabaseManager();
                
                
                ReserveringMateriaal r = new ReserveringMateriaal(m.NietUitgeleendExemplaar(), algemeen.Account, dtpBeginDatum.Value.Date, dtpEindDatum.Value.Date, false);
                if (dm.VoegMateriaalReserveringToe(r))
                {
                    MessageBox.Show("materiaal reservering succesvol toegevoegd");
                }
                else
                {
                    MessageBox.Show("we tried boyz");
                }
            }
           
        }

        private void btnMateriaalToevoegen_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            dm.VoegMateriaalToe(new Materiaal(dm.NieuwID("Materiaal"),tbxMateriaalNaamToevoegen.Text, tbxMateriaalBeschrijvingToevoegen.Text, Convert.ToInt32(tbxMateriaalPrijsToevoegen.Text)));
            VerversMaterialen();
        }

        private void VerversMaterialen()
        {
            lbxMaterialen.Items.Clear();
            DatabaseManager dm = new DatabaseManager();
           
            foreach(Materiaal m in mats)
            {
                lbxMaterialen.Items.Add(m.ToString());
            }
            
        }

        private void btnVeranderPrijs_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            Materiaal m = lbxMaterialen.SelectedItem as Materiaal;
            if(lbxMaterialen.SelectedItem is Materiaal)
            {
                dm.WijzigMateriaalPrijs(m, Convert.ToInt32(tbxNieuwePrijs.Text));
            }
            else
            {
                MessageBox.Show("geen materiaal geselecteerd");
            }
            
        }

        private void btnVerversUitgeleendMateriaal_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            List<Materiaal> materialen = dm.VerkrijgMateriaal(algemeen.Evenement.ID);
            foreach(Materiaal m in materialen)
            {
            List<Exemplaar> UitgeleendeExemplaren = dm.UitgeleendExemplaren(m.MateriaalID);
            foreach(Exemplaar ex in UitgeleendeExemplaren)
            {
                lbxUitgeleendMateriaal.Items.Add(ex);
            }
            }
            
        }

        private void lbxMaterialen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            if (lbxMaterialen.SelectedItem != null)
            {
                foreach (Materiaal ma in mats)
                {
                    if (ma.ToString() == lbxMaterialen.SelectedItem.ToString())
                    {
                        lblNaamData.Text = Convert.ToString(ma.Naam);
                        lblPrijsData.Text = Convert.ToString(ma.Prijs);
                        lblVoorraadData.Text = Convert.ToString(dm.ExemplarenVanMateriaal(ma.MateriaalID).Count);
                    }
                }
            }
            

        }

        private void btnKlaarReserveren_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
