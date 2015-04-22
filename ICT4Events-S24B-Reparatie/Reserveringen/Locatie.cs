using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        public string Telefoonnummer { get; set; }
        public string Plaats { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }

        private DatabaseManager dm;

        public Locatie(int locatieID, string telefoonnummer, string plaats, string straat, string huisnummer)
        {
            this.LocatieID = locatieID;
            this.Telefoonnummer = telefoonnummer;
            this.Plaats = plaats;
            this.Straat = straat;
            this.Huisnummer = huisnummer;

            this.dm = new DatabaseManager();
        }
    }
}
