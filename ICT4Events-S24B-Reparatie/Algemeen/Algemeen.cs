using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ICT4Events_S24B_Reparatie
{
    public class Algemeen
    {
        #region Properties & Fields
        private string ConnectionPath;

        //list
        public Account Account { get; set; }

        //Deze objecten worden eigenlijk aangemaakt vanuit het hun behorende form maar voor het klassendiagram  hou ik die even zo.
        //private ReserveringSysteem reserveringen;
        //private Toegangscontrole toegangscontroleSysteem;

        //public List<Email> Emails { get; set; }

        public Event Evenement { get; set; }

        private HoofdForm hoofdForm;

        ToolStripMenuItem inlogItem = new ToolStripMenuItem()
        {
            Name = "Inloggen",
            Text = "Inloggen",
            Alignment = ToolStripItemAlignment.Right
        };
        ToolStripMenuItem uitlogItem = new ToolStripMenuItem()
        {
            Name = "Uitloggen",
            Text = "Uitloggen"
        };

        #endregion

        #region Constructor
        public Algemeen(HoofdForm hoofdForm)
        {
            this.hoofdForm = hoofdForm;

            Account = new Account("RFID", 1, "Mail@Mail.nl", "Koekert", AccountType.Groepshoofd, false);
            //Emails = new List<Email>();
            //Hardcoded eventID
            int eventID = 1;

            DatabaseManager dm = new DatabaseManager();
            Evenement = dm.VerkrijgEvent(eventID);
        }
        #endregion

        #region Methodes

        /*
        #region In- en uitloggen
        /// <summary>
        /// Geeft een inlogvenster weer im in te loggen
        /// </summary>
        public void LogIn()
        {
            InlogForm inlogForm = new InlogForm(this);
            inlogForm.ShowDialog();
        }
        /// <summary>
        /// Verifieert de ingevulde gegevens met de database.
        /// Indien verificatie succesvol is wordt this.account geüpdate.
        /// Return waarde is beschrijving foutmelding als string.
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public string VerifieerLogin(string mail, string wachtwoord)
        {
            bool valideGegevens = false;

            if (mail == "")
                return "U heeft geen e-mail adres ingevuld!";

            if (!mail.Contains("@") ||
                mail.LastIndexOf(".") <= mail.LastIndexOf("@") ||
                mail.LastIndexOf(".") == mail.Length - 1)
                return "U heeft geen geldig e-mail adres ingevuld!";

            if (wachtwoord == "")
                return "U heeft uw wachtwoord niet ingevuld!";


            DatabaseManager dm = new DatabaseManager();

            valideGegevens = dm.VerifieerLogin(mail, wachtwoord);

            if (valideGegevens)
            {
                Account = dm.AccountGegevens(mail, this.Evenement.ID);

                hoofdForm.UpdateMenuBalk();

                return "";
            }
            else
            {
                Account = null;
                return "De inloggegevens zijn onjuist!";
            }
        }
        /// <summary>
        /// Logt de gebruiker uit. Hierbij worden alle geöpende forms geüpdate of gesloten als een niet ingelogde gebruiker hier geen toegang tot heeft.
        /// </summary>
        public void LogUit()
        {
            Account = null;
            hoofdForm.UpdateMenuBalk();
        }
        #endregion*/

        #region Accounts beheren
        /// <summary>
        /// Voeg een account me de ingevulde gegevens toe aan de database via de bijbehorende DatabaseManager methodes
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="email"></param>
        /// <param name="roepnaam"></param>
        /// <param name="type"></param>
        public bool VoegAccountToe(string rfid, string email, string roepnaam, AccountType type, int eventID)
        {
            DatabaseManager dm = new DatabaseManager();

            if (dm.VoegAccountToe(rfid, email, roepnaam, type, eventID))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verwijdert het meegegeven account
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public bool VerwijderAccount(Account acc)
        {
            return VerwijderAccount(acc.AccountID, Evenement.ID);
        }

        public bool VerwijderAccount(int AccountID, int EventID)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.VerwijderAccount(AccountID, EventID);
        }

        /// <summary>
        /// Wijzigt het wachtwoord van een geselecteerd account.
        /// Verificatie moet vooraf gedaan worden!
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool WijzigWachtwoord(Account acc, string wachtwoord)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.WijzigWachtwoord(acc.Email, wachtwoord);
        }

        /// <summary>
        /// Wijzigt het wachtwoord van het huidige account.
        /// Verificatie moet vooraf gedaan worden!
        /// </summary>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool WijzigWachtwoord(string wachtwoord)
        {
            return WijzigWachtwoord(this.Account, wachtwoord);
        }

        /// <summary>
        /// Wijzigt het wachtwoord van het huidige account.
        /// Verificatie wordt door de databaseManager methode gedaan.
        /// Return waarde is of het veranderen gelukt is.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="huidigWachtwoord"></param>
        /// <param name="nieuwWachtwoord"></param>
        /// <returns></returns>
        public bool WijzigWachtwoord(string email, string huidigWachtwoord, string nieuwWachtwoord)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.WijzigWachtwoord(email, huidigWachtwoord, nieuwWachtwoord);
        }
        #endregion

        #region menubalk 
        
        /// <summary>
        /// Er wordt automatisch een menu balk gemaakt in de meegegeven form.
        /// Return waarde of is ingelogd of niet.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="ms"></param>
        public bool MaakMenuBalk(Form form, MenuStrip ms)
        {
            foreach (Control c in form.Controls)
            {
                c.Top += 20;
            }

            form.Height += 20;

            form.Controls.Add(ms);

            if (Account != null)
            {
                inlogItem.Text = "Ingelogd als: " + Account.Email;

                uitlogItem.Click += uitlogItem_Click;

                inlogItem.DropDownItems.Add(uitlogItem);
            }
            else
            {
                inlogItem.Click += inlogItem_Click;
            }

            ms.Items.Add(inlogItem);

            return (Account != null);
        }

        public void UpdateMenuBalk(Form form, MenuStrip ms)
        {
            if (Account != null)
            {
                inlogItem.Text = "Ingelogd als: " + Account.Email;
                inlogItem.Click -= inlogItem_Click;
                inlogItem.DropDownItems.Add(uitlogItem);
                uitlogItem.Click += uitlogItem_Click;
            }
            else
            {
                inlogItem.Text = "Inloggen";
                inlogItem.Click += inlogItem_Click;
                inlogItem.DropDownItems.Remove(uitlogItem);
                uitlogItem.Click -= uitlogItem_Click;
            }
        }

        void inlogItem_Click(object sender, EventArgs e)
        {
            //LogIn();
        }

        private void uitlogItem_Click(object sender, EventArgs e)
        {
            //LogUit();
        }
        
        #endregion

        public bool WachtwoordVergeten(string email)
        {
            DatabaseManager dm = new DatabaseManager();

            string rfid = dm.VerkrijgRFID(email);

            if (rfid != "")
            {
                if (dm.VerkrijgAccountVerifieerd(rfid) == 1)
                {
                    MaakEmailAan(rfid, "Wachtwoordherstel ICT4Events", "Geachte heer/mevrouw,\n\nEr is aangegeven dat u uw wachtwoord vergeten bent. Als u dit gedaan heeft, kunt u uw wachtwoord veranderen door de link hieronder te volgen.\nBent u dit niet? Negeer deze e-mail en meld dit aan de beheerder.");
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void MaakEmailAan(string rfid, string onderwerp, string inhoud)
        {
            //Emails.Add(new Email(rfid, Evenement.ID, onderwerp, inhoud));
        }

        /*
        /// <summary>
        /// De meegegeven email wordt verwijderd
        /// </summary>
        /// <param name="i"></param>
        public void VerwijderEmail(Email e)
        {
            //Emails.Remove(e);
        }*/
        #endregion
    }
}
