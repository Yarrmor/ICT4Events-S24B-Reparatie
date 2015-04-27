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
    public partial class PlaatsReserveringForm : Form
    {
        public Algemeen Algemeen { get; set; }

        // Hardcoded plaatsfilters
        string[] plaatsFilters = new string[] { "Rustig", "Invalide" };

        List<DateTime> alleDatums = new List<DateTime>();
        DateTime? beginDatum;
        DateTime? eindDatum;

        ReserveringSysteem reserveringSysteem;

        /// <summary>
        /// Haalt de beschikbare datums op en maakt plekfilters beschikbaar
        /// </summary>
        /// <param name="algemeen"></param>
        public PlaatsReserveringForm(Algemeen algemeen)
        {
            InitializeComponent();

            foreach (string plaatsFilter in plaatsFilters)
            {
                clbFilters.Items.Add(plaatsFilter);
            }

            Algemeen = algemeen;

            reserveringSysteem = new ReserveringSysteem(algemeen);

            VerkrijgBeschikbareDatums();
        }

        /// <summary>
        /// Haalt een lijst op van beschikbare plekken met de geselecteerde filters
        /// </summary>
        private void VerkrijgBeschikbarePlekken()
        {
            if (beginDatum.HasValue && eindDatum.HasValue)
            {
                cbxBeschikbarePlaatsen.Items.Clear();

                List<string> filters = new List<string>();
                foreach (var filter in clbFilters.CheckedItems)
                {
                    filters.Add(filter.ToString());
                }

                List<Plek> plekList = reserveringSysteem.VerkrijgBeschikbarePlekken(filters, beginDatum, eindDatum);

                foreach (Plek p in plekList)
                    cbxBeschikbarePlaatsen.Items.Add(p.PlekID);
            }
            else
            {
                cbxBeschikbarePlaatsen.Items.Clear();
            }
            
        }


        /// <summary>
        /// Haalt een lijst op van alle beschikbare datums
        /// </summary>
        private void VerkrijgBeschikbareDatums()
        {
            cbxStartPeriode.Items.Clear();
            cbxEindPeriode.Items.Clear();

            alleDatums = reserveringSysteem.VerkrijgDatums();

            foreach (DateTime d in alleDatums)
                cbxStartPeriode.Items.Add(d.Date);
        }

        /// <summary>
        /// Haalt de datums op van de geselecteerde plek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxBeschikbarePlaatsen_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerversPrijs();
        }

        /// <summary>
        /// Vernieuwd de dag- en totaalprijs van de geselecteerde plaats
        /// </summary>
        private void VerversPrijs()
        {
            int i = reserveringSysteem.HaalPrijsOp(Convert.ToInt32(cbxBeschikbarePlaatsen.Items[cbxBeschikbarePlaatsen.SelectedIndex]));

            // Dagprijs van plaats
            int prijs = reserveringSysteem.HaalPrijsOp(i);
            lblDagPrijsWaarde.Text = "€" + prijs.ToString("c");

            // Totaalprijs van plaats en datums
            int totaalPrijs = reserveringSysteem.HaalTotaalPrijsOp(prijs, beginDatum, eindDatum);
            lblTotaalPrijsWaarde.Text = "€" + totaalPrijs.ToString();
        }

        /// <summary>
        /// Maakt het aantal textboxen voor e-mail adressen zichtbaar gebaseerd op het aantal personen in de nud.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudAantalPersonen_ValueChanged(object sender, EventArgs e)
        {
            TextBox[] tbxEmails = new TextBox[] { tbxEmailGroepslid1, tbxEmailGroepslid2, tbxEmailGroepslid3, tbxEmailGroepslid4 };

            for (int i = 1; i <= 4; i++)
                tbxEmails[i - 1].Enabled = (i <= (int)nudAantalPersonen.Value - 1 );

            foreach (TextBox tbx in tbxEmails)
            {
                if (!tbx.Enabled)
                    tbx.Text = "";
            }
        }

        /// <summary>
        /// Er wordt een plek gereserveerd indien alle velden zijn ingevuld
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReserveren_Click(object sender, EventArgs e)
        {
            //Hardcoded voor 1 account
            string rfid = "4a003767a8";
            //Hardcoded accID
            int accountID = 8;

            string roepnaam = "";
            string voornaam = tbxVoornaam.Text;
            string achternaam = tbxAchternaam.Text;
            AccountType accountType = AccountType.Groepshoofd;
            string telefoonnummer = tbxTelefoonnummer.Text;
            string plaats = tbxWoonplaats.Text;
            string straat = tbxStraatnaam.Text;
            string huisnummer = tbxHuisnummer.Text;
            string email = tbxEmail.Text;

            // Controleer ingevulde waarden
            string[] check = new string[] { roepnaam, voornaam, achternaam, telefoonnummer, plaats, straat, huisnummer, email };
            
            foreach (string s in check)
            {
                if (s == "")
                {
                    MessageBox.Show("U heeft een of meerdere velden leeg gelaten!");
                    return;
                }
            }

            // Haal de juiste plek op
            Plek geselecteerdePlek = reserveringSysteem.HaalPlekOp(Convert.ToInt32(cbxBeschikbarePlaatsen.SelectedItem.ToString()));

            // Probeer een reservering te plaatsen met een nieuw gemaakte groepshoofd account
            try
            {
                Groepshoofd groepsHoofd = new Groepshoofd(rfid, accountID, email, roepnaam, voornaam, achternaam, accountType, telefoonnummer, plaats, straat, huisnummer, false);
                ReserveringPlaats reserveringPlaats = new ReserveringPlaats(groepsHoofd, geselecteerdePlek, Algemeen.Evenement, beginDatum.Value, eindDatum.Value, false);
                if (!reserveringSysteem.VoegReserveringToe(reserveringPlaats))
                    throw new Exception("De reservering kan niet in de database geplaatst worden. Als u niet al een reservering hebt geplaatst, neem contact op met het helpdesk.");
                else
                {
                    Algemeen.MaakEmailAan(groepsHoofd.Rfid, "Reservering ICT4Events", "U heeft reeds een reservering geplaatst voor het ICT4Events Evenement.\n\nU kunt met onderstaande links uw reservering betalen en uw account activeren.\nInloggen ter plekke doet u met uw e-mail adres en wachtwoord ingevuld bij het verifieren.\n\nWilt u alvast materiaal reserveren? Volg onderstaande link om dit direct te doen. Hiervoor moet uw account wel eerst geverifieerd zijn.");
                    MessageBox.Show("Uw reservering is geplaatst! U heeft een e-mail ontvangen met verdere informatie.");
                    this.Close();
                }
             }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            
        }

        /// <summary>
        /// De eindperiode wordt geupdated. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxStartPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool datumGeselecteerd = (cbxStartPeriode.SelectedIndex != -1);

            cbxEindPeriode.Enabled = datumGeselecteerd;

            if (datumGeselecteerd)
            {
                beginDatum = alleDatums[cbxStartPeriode.SelectedIndex].Date;
                UpdateEindPeriode();
                VerversPrijs();
            }
            else
                beginDatum = null;

            VerversPrijs();
        }

        /// <summary>
        /// De eindperiode wordt geupdated
        /// </summary>
        private void UpdateEindPeriode()
        {
            cbxEindPeriode.Items.Clear();

            foreach (DateTime d in alleDatums)
            {
                if (d.Date >= beginDatum.Value.Date)
                    cbxEindPeriode.Items.Add(d);
            }

            cbxEindPeriode.SelectedIndex = -1;
            cbxEindPeriode.Text = "";

            VerversPrijs();
        }

        /// <summary>
        /// Einddatum wordt vastgesteld
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEindPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEindPeriode.SelectedIndex != -1)
            {
                eindDatum = cbxEindPeriode.Items[cbxEindPeriode.SelectedIndex] as DateTime?;

                VerversPrijs();
            }
            else
                eindDatum = null;
        }

        private void clbFilters_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            VerkrijgBeschikbarePlekken();
        }

        public void MaakMenuBalk()
        {
            throw new NotImplementedException();
        }

        public void UpdateMenuBalk()
        {
            throw new NotImplementedException();
        }
    }
}
