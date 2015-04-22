using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Materiaal
    {
        public int MateriaalID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int Prijs { get; set; }

        private DatabaseManager dm;

        public Materiaal(int materiaalID, string naam, string beschrijving, int prijs)
        {
            this.MateriaalID = materiaalID;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Prijs = prijs;

            this.dm = new DatabaseManager();
        }

        /// <summary>
        /// Geeft een lijst van exemplaren terug
        /// </summary>
        /// <returns></returns>
        public List<Exemplaar> Exemplaren()
        {
            return this.dm.ExemplarenVanMateriaal(this.MateriaalID);
        }
    }
}
