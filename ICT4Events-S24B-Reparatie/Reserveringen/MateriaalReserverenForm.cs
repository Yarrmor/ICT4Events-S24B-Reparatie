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
        private bool uitlogNaSluiten;
        public Materiaal mtest;

        public List<Materiaal> mats;
        public MateriaalReserverenForm(Algemeen alg)
        {
            DatabaseManager dm = new DatabaseManager();
            mats = dm.VerkrijgMateriaal(alg.Evenement.ID);
            this.algemeen = alg;
            InitializeComponent();
            gbxUitgeleendMateriaal.Visible = false;
            gbxMateriaalToevoegen.Visible = false;
            
          //  if (alg.Account == null)
          //  {
             //   if(alg.Account.Type == AccountType.Beheerder)
              //  {
                    gbxUitgeleendMateriaal.Visible = true;
                    gbxMateriaalToevoegen.Visible = true;
              //  }
           // }
            VerversMaterialen();
            
        }

        public MateriaalReserverenForm(Algemeen alg, bool b)
        {
            DatabaseManager dm = new DatabaseManager();
            mats = dm.VerkrijgMateriaal(alg.Evenement.ID);
            this.algemeen = alg;
            InitializeComponent();
            gbxUitgeleendMateriaal.Visible = false;
            gbxMateriaalToevoegen.Visible = false;

            //  if (alg.Account == null)
            //  {
            //   if(alg.Account.Type == AccountType.Beheerder)
            //  {
            gbxUitgeleendMateriaal.Visible = true;
            gbxMateriaalToevoegen.Visible = true;
            //  }
            // }
            VerversMaterialen();
            uitlogNaSluiten = b;
        }

        private void btnMateriaalReserveren_Click(object sender, EventArgs e)
        {
            if(lbxMaterialen.SelectedItem != null)
            {
                Materiaal m = mtest;
                DatabaseManager dm = new DatabaseManager();
                
                
                ReserveringMateriaal r = new ReserveringMateriaal(m.NietUitgeleendExemplaar(), algemeen.Account, dtpBeginDatum.Value.Date, dtpEindDatum.Value.Date, false);
                if (dm.VoegMateriaalReserveringToe(r))
                {
                    MessageBox.Show("materiaal reservering succesvol toegevoegd");
                }
                else
                {
                    MessageBox.Show("kon het amteriaal niet toevoegen.");
                }
            }
           
        }

        private void btnMateriaalToevoegen_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            dm.VoegMateriaalToe(new Materiaal(dm.VerkrijgNieuwMateriaalID(),tbxMateriaalNaamToevoegen.Text, tbxMateriaalBeschrijvingToevoegen.Text, Convert.ToInt32(tbxMateriaalPrijsToevoegen.Text)));
            VerversMaterialen();
        }

        private void VerversMaterialen()
        {
            lbxMaterialen.Items.Clear();
            DatabaseManager dm = new DatabaseManager();
            mats = dm.VerkrijgMateriaal(algemeen.Evenement.ID);
            foreach(Materiaal m in mats)
            {
                lbxMaterialen.Items.Add(m.ToString());
            }
            
        }

        private void btnVeranderPrijs_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            Materiaal m = mtest;
            if(m != null)
            {

                dm.WijzigMateriaalPrijs(m, Convert.ToInt32(tbxNieuwePrijs.Text));
                
                    mtest.Prijs = Convert.ToInt32(tbxNieuwePrijs.Text);
                
            }
            else
            {
                MessageBox.Show("geen materiaal geselecteerd");
            }
            UpdateData(mtest);
            
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
                 lbxUitgeleendMateriaal.Items.Add("ExemplaarID :" + ex.ExemplaarID.ToString());
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
                        mtest = ma;
                    }
                }
            }
            

        }
        private void UpdateData(Materiaal mat)
        {
            DatabaseManager dm = new DatabaseManager();
            mats = dm.VerkrijgMateriaal(algemeen.Evenement.ID);
            lblNaamData.Text = Convert.ToString(mat.Naam);
            lblPrijsData.Text = Convert.ToString(mat.Prijs);
            lblVoorraadData.Text = Convert.ToString(dm.ExemplarenVanMateriaal(mat.MateriaalID).Count);

        }

        private void btnKlaarReserveren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MateriaalReserverenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(uitlogNaSluiten)
            {
                algemeen.LogUit();
            }
        }
    }
}
