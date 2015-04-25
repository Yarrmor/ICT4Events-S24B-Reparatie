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

        private void btVoegToe_Click(object sender, EventArgs e)
        {
            Profiel p = new Profiel(alg, md);
            if (p.DialogResult == DialogResult.OK)
            {
                dm.VoegAccountToe(new Account(p.tbxRFID.Text, dm.VerkrijgNieuwAccountID(), p.tbxEmail.Text, p.tbRoepNaam.Text, AccountTypeStringNaarEnum(p.cbxAccountType.Text), GeslachtStringNaarEnum(p.cbxGender.Text), p.tbxVoornaam.Text, p.tbxAchternaam.Text, p.dtpGeboorteDatum.Value, false));
            }
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
