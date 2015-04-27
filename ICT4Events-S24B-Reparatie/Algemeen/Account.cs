using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Account
    {
        public string Rfid { get; set; }
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string Roepnaam { get; set; }
        public AccountType Type { get; set; }

        // Extra gegevens (profiel)

        public Geslacht Geslacht { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public bool Verbannen { get; set; }

        private DatabaseManager dm;

        public Account(string rfid, int accountID, string email, string roepnaam, AccountType type, bool verbannen)
        {
            this.dm = new DatabaseManager();

            ZetAccountDetails(rfid, accountID, email, roepnaam, type, verbannen);
        }

        public Account(string rfid, int accountID, string email, string roepnaam, AccountType type, Geslacht geslacht, string voornaam, string achternaam, DateTime geboorteDatum, bool verbannen)
        {
            this.dm = new DatabaseManager();

            ZetAccountDetails(rfid, accountID, email, roepnaam, type, verbannen);
            Geslacht = geslacht;
            Voornaam = voornaam;
            Achternaam = achternaam;
            GeboorteDatum = geboorteDatum;
        }

        // Alleen om groepshoofd te bewaren:
        public Account(string rfid)
        {
            this.dm = new DatabaseManager();

            Rfid = rfid;
        }

        private void ZetAccountDetails(string rfid, int accountID, string email, string roepnaam, AccountType type, bool verbannen)
        {
            Rfid = rfid;
            AccountID = accountID;
            Email = email;
            Roepnaam = roepnaam;
            Type = type;
            Verbannen = verbannen;
        }

        private void WijzigProfielDetails(string email, string roepnaam, string voornaam, string achternaam, DateTime geboorteDatum)
        {
            Email = email;
            Roepnaam = roepnaam;
            Voornaam = voornaam;
            Achternaam = achternaam;
            GeboorteDatum = geboorteDatum;

            this.dm.WijzigProfielDetails(email);
        }
        /// <summary>
        /// Ban zet de waarde van verbannen voor deze account naar True.
        /// </summary>
        public void Ban()
        {
            this.Verbannen = true;
            BanUnBan(true);
        }

        /// <summary>
        /// UnBan zet de waarde van verbannen voor deze account naar False.
        /// </summary>

        public void UnBan()
        {
            this.Verbannen = false;
            BanUnBan(false);
        }


        /// <summary>
        /// Haalt op of het account gebant
        /// </summary>
        /// <param name="verban"></param>

        private void BanUnBan(bool verban)
        {
            this.dm.Verban(this.AccountID, verban);
        }

        public bool Verwijder(int EventID)
        {
            return this.dm.VerwijderAccount(AccountID, EventID);
        }

        public override string ToString()
        {
            return AccountID + ", " + Roepnaam + "| Verbannen:" + Verbannen.ToString();
        }
    }
}
