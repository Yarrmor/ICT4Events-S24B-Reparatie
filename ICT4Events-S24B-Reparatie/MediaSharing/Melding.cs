using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Melding
    {
        public Account Account { get; set; }
        public int MediaID { get; set; }
        public string Toelichting { get; set; }
        public DateTime Datum { get; set; }

        private DatabaseManager dm;

        public Melding(Account account, int mediaID, string toelichting, DateTime datum)
        {
            this.dm = new DatabaseManager();

            this.Account = account;
            this.MediaID = mediaID;
            this.Toelichting = toelichting;
            this.Datum = datum;
        }

        /// <summary>
        /// Geeft een string terug met de media naam en de uploader naam.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Media: " + MediaID + " Door: " + Account.Roepnaam;
        }

        public bool Rapporteer()
        {
            return this.dm.VoegMeldingToe(this);
        }
    }
}
