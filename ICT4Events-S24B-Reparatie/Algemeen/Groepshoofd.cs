using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Groepshoofd : Account
    {
        public string Telefoonnummer { get; set; }
        public string Plaats { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }

        public Groepshoofd(string rfid, int accountID, string email, string roepnaam, string voornaam, string achternaam, AccountType type, string telefoonnummer, string plaats, string straat, string huisnummer, bool verbannen)
            : base(rfid, accountID, email, roepnaam, type, verbannen)
        {
            this.Telefoonnummer = telefoonnummer;
            this.Plaats = plaats;
            this.Straat = straat;
            this.Huisnummer = huisnummer;
            base.Voornaam = voornaam;
            base.Achternaam = achternaam;
        }
        /// <summary>
        /// Haalt een lijst op van de groepsleden van het meegegeven groepshoofd
        /// </summary>
        /// <returns></returns>
        public List<Groepslid> Groepsleden()
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.GroepsledenVanGroepshoofd(Rfid);
        }
    }
}
