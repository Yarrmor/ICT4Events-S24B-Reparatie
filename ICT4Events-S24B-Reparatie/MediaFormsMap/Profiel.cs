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
    public partial class Profiel : Form
    {
        private Account profiel;
        private MediaSharingSysteem md;

        /// <summary>
        /// Deze constructor is er voor om profielen te bekijken/wijzigen
        /// </summary>
        /// <param name="alg"></param>
        /// <param name="a"></param>
        /// <param name="md"></param>
        public Profiel(Algemeen alg, Account a, MediaSharingSysteem md)
        {
            this.md = md;

            InitializeComponent();

            btnVoegToe.Enabled = false;
            btnVoegToe.Visible = false;

            this.Text = "Profiel: " + a.Roepnaam;
            VulTypeBox();
            VulGenderBox();
            SetProfiel(a);
            this.profiel = a;

            if (alg.Account != a && alg.Account.Type != AccountType.Beheerder) 
                Lock();
            else if (alg.Account.Type != AccountType.Beheerder)
                DefaultLock();
        }

        public Profiel(Algemeen alg, MediaSharingSysteem md)
        {
            this.md = md;

            InitializeComponent();

            VulTypeBox();
            VulGenderBox();
            btnBan.Visible = false;
            btnBan.Enabled = false;
            btnWijzig.Visible = false;
            btnWijzig.Enabled = false;
            lblVerbannen.Visible = false;
        }

        /// <summary>
        /// De buttons, textboxes, combobox, datetypepicker worden gedisabled en/of verborgen
        /// </summary>
        private void Lock()
        {
            DefaultLock();
            btnWijzig.Visible = false;
            btnWijzig.Enabled = false;
            tbxAchternaam.Enabled = false;
            tbxRoepNaam.Enabled = false;
            tbxVoornaam.Enabled = false;
            cbxGender.Enabled = false;
            dtpGeboorteDatum.Enabled = false;
        }

        /// <summary>
        /// Buttons, textbox, combobox wordt gedisabled en/of verborgen
        /// </summary>
        private void DefaultLock()
        {
            btnBan.Visible = false;
            btnBan.Enabled = false;
            tbxRFID.Enabled = false;
            tbxEmail.Enabled = false;
            cbxAccountType.Enabled = false;
        }

        /// <summary>
        /// Controlleert of alle velden zijn ingevuld creeërt het account.
        /// </summary>
        /// <param name="a"></param>
        private void SetProfiel(Account a)
        {
            DateTime minDate = new DateTime(1875, 1, 1);

            if(a.Achternaam != null) tbxAchternaam.Text = a.Achternaam;
            tbxRFID.Text = a.Rfid;
            if (a.Roepnaam != null) tbxRoepNaam.Text = a.Roepnaam;
            //tbxTelefoonNR.Text = a.TelefoonNR.ToString();  //Verwijder dit maar als dit niet in account hoeft.
            if (a.Voornaam != null) tbxVoornaam.Text = a.Voornaam.ToString();
            cbxAccountType.Text = a.Type.ToString();
            cbxGender.Text = a.Geslacht.ToString();
            if (a.GeboorteDatum != null && a.GeboorteDatum > minDate) dtpGeboorteDatum.Value = a.GeboorteDatum;
            lblBan.Text = a.Verbannen.ToString();
            if (a.Email != null) tbxEmail.Text = a.Email;
        }

        /// <summary>
        /// Vult de combobox in
        /// </summary>
        private void VulTypeBox()
        {
            cbxAccountType.Items.Add(AccountType.Beheerder);
            cbxAccountType.Items.Add(AccountType.Groepshoofd);
            cbxAccountType.Items.Add(AccountType.Groepslid);
            cbxAccountType.Items.Add(AccountType.Medewerker);
        }

        /// <summary>
        /// vult de combobox in
        /// </summary>
        private void VulGenderBox()
        {
            cbxGender.Items.Add(Geslacht.Man);
            cbxGender.Items.Add(Geslacht.Vrouw);
        }

        /// <summary>
        /// account wordt gebant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBan_Click(object sender, EventArgs e)
        {
            Account update = profiel;
            SetBan(update);
            this.profiel = update;
        }

        /// <summary>
        ///  Wanneer het profiel nog niet verbannen is wordt deze verbannen na bevestiging. Als de uploader al verbannen is, is deze niet meer verbannen
        /// </summary>
        /// <param name="p"></param>
        private void SetBan(Account p)
        {
            if (!p.Verbannen)
            {
                DialogResult dialogResult = MessageBox.Show("Weet je het zeker dat je deze persoon wilt verbannen?", "Ban:" + p.Roepnaam, MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    p.Ban();
                    SetProfiel(p);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Weet je het zeker dat je deze persoon wilt unbannen?", "Unban:" + p.Roepnaam, MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    p.UnBan();
                    SetProfiel(p);
                }
            }
        }

        private void btnVoegToe_Click(object sender, EventArgs e)
        {
            if (tbxAchternaam.Text != "" && tbxEmail.Text != "" && tbxRFID.Text != "" && tbxRoepNaam.Text != "" && tbxVoornaam.Text != "" && cbxAccountType.Text != "" && cbxGender.Text != "" && dtpGeboorteDatum.Value != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Niet alle gegevens zijn ingevuld!");
            }
        }
    }
}
