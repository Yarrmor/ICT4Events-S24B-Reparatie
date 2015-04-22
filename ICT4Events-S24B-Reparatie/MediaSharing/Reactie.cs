using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Reactie
    {
        public int ReactieID { get; set; }
        public Media Media { get; set; }
        public Account Account { get; set; }
        public string Bericht { get; set; }
        public Reactie ReactieOp { get; set; }
        public DateTime Datum { get; set; }

        private DatabaseManager dm;

        public Reactie(int reactieID, Media media, Account account, string bericht, Reactie reactieOp, DateTime datum)
        {
            this.dm = new DatabaseManager();

            this.ReactieID = reactieID;
            this.Media = media;
            this.Account = account;
            this.Bericht = bericht;
            this.ReactieOp = reactieOp;
            this.Datum = datum;
        }

        public Reactie(Media media, Account account, string bericht, DateTime datum)
        {
            this.dm = new DatabaseManager();

            this.Media = media;
            this.Account = account;
            this.Bericht = bericht;
            this.Datum = datum;
        }

        public bool Plaats()
        {
            return this.dm.VoegReactieToe(this);
        }
    }
}
