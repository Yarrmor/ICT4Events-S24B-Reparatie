using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Exemplaar
    {
        public int ExemplaarID { get; set; }
        public Materiaal Materiaal { get; set; }
        public string Beschrijving { get; set; }

        private DatabaseManager dm;

        public Exemplaar(int exemplaarID, Materiaal materiaal, string beschrijving)
        {
            this.ExemplaarID = exemplaarID;
            this.Materiaal = materiaal;
            this.Beschrijving = beschrijving;

            this.dm = new DatabaseManager();
        }

        public bool LeenUit(int accountID, DateTime startDatum, DateTime eindDatum)
        {
            return false;
            //return this.dm.LeenUit(accountID, startDatum, eindDatum);
        }


    }
}
