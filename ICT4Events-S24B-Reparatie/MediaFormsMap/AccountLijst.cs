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
    public partial class AccountLijst : Form
    {
        public List<Account> accounts { get; set; }

        private Algemeen alg;
        private MediaSharingSysteem md;
        private DatabaseManager dm;

        public AccountLijst(Algemeen alg, MediaSharingSysteem md)
        {
            this.alg = alg;
            this.md = md;
            dm = new DatabaseManager();
            InitializeComponent();

            WeergeefAlleAccounts(dm.VerkrijgAlleAccounts(alg.Evenement.ID));
        }

        private void WeergeefAlleAccounts(List<Account> accountlijst)
        {
            this.accounts = accountlijst;

            lbxAccounts.Items.Clear();
            foreach (Account a in accounts)
            {
                lbxAccounts.Items.Add(a.ToString());
            }
        }

        /// <summary>
        /// Laat de profielen zien
        /// </summary>
        /// <param name="a"></param>
        private void LaatProfielZien(Account a)
        {
            Profiel p = new Profiel(alg, a, md);
            p.Show();
        }

        /// <summary>
        /// Laat de geselecteerde account zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxAccounts.SelectedItem != null)
            {
                foreach (Account a in accounts)
                {
                    if (lbxAccounts.SelectedItem.ToString() == a.ToString())
                    {
                        LaatProfielZien(a);
                    }
                }
            }
        }

        /// <summary>
        /// Button event voor het toevoegen van een account aan de database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoegToe_Click(object sender, EventArgs e)
        {
            Profiel p = new Profiel(alg, md);
            if (p.ShowDialog() == DialogResult.OK)
            {
                dm.VoegAccountToe(new Account(p.tbxRFID.Text, dm.VerkrijgNieuwAccountID(), p.tbxEmail.Text, p.tbxRoepNaam.Text, AccountTypeStringNaarEnum(p.cbxAccountType.Text), 
                    GeslachtStringNaarEnum(p.cbxGender.Text), p.tbxVoornaam.Text, p.tbxAchternaam.Text, p.dtpGeboorteDatum.Value, false), alg.Evenement.ID);
            }
        }

        /// <summary>
        /// Verwijderd het geselecteerde account uit de database en haalt een nieuwe accounts lijst op.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            if (lbxAccounts.SelectedItem != null)
            {
                foreach (Account a in accounts)
                {
                    if (a.ToString() == lbxAccounts.SelectedItem.ToString())
                    {
                        a.Verwijder(alg.Evenement.ID);
                        WeergeefAlleAccounts(dm.VerkrijgAlleAccounts(alg.Evenement.ID));
                    }
                }
            }
            else
            {
                MessageBox.Show("Er is niets geselcteerd");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WeergeefAlleAccounts(dm.VerkrijgAlleAccounts(alg.Evenement.ID));
        }

        /// <summary>
        /// Zet string om naar AccountType
        /// Meegegeven type moet overeen komen met een AccountType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private AccountType AccountTypeStringNaarEnum(string type)
        {
            AccountType accountType;
            Enum.TryParse(type, out accountType);

            return accountType;
        }

        /// <summary>
        /// Zet string om naar Geslacht
        /// Meegegeven geslacht moet overeen komen met een Geslacht
        /// "Man" of "Vrouw", niet "M" of "V"
        /// </summary>
        /// <param name="geslachtString"></param>
        /// <returns></returns>
        private Geslacht GeslachtStringNaarEnum(string geslachtString)
        {
            Geslacht geslacht;

            Enum.TryParse(geslachtString, out geslacht);

            return geslacht;
        }
    }
}
