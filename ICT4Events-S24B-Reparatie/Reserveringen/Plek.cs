using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Plek
    {
        public int PlekID { get; set; }
        public Locatie Locatie { get; set; }
        public int Prijs { get; set; }
        public string Beschrijving { get; set; }

        private DatabaseManager dm;

        public Plek(int plekID, Locatie locatie, int prijs, string beschrijving)
        {
            this.PlekID = plekID;
            this.Locatie = locatie;
            this.Prijs = prijs;
            this.Beschrijving = beschrijving;

            this.dm = new DatabaseManager();
        }

        /// <summary>
        /// Geeft de nieuwe prijs van een plek mee
        /// </summary>
        /// <param name="prijs"></param>
        /// <returns></returns>
        public bool WijzigPlekPrijs(int prijs)
        {
            return this.dm.WijzigPlekPrijs(this.PlekID, prijs);
        }
    }
}
