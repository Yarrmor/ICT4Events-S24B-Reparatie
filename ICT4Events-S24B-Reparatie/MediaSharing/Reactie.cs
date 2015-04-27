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
        public int MediaID { get; set; }
        public Account Account { get; set; }
        public string Bericht { get; set; }
        public Reactie ReactieOp { get; set; }
        public DateTime Datum { get; set; }

        private DatabaseManager dm;

        public Reactie(int reactieID, int mediaID, Account account, string bericht, Reactie reactieOp, DateTime datum)
        {
            this.dm = new DatabaseManager();

            this.ReactieID = reactieID;
            this.MediaID = mediaID;
            this.Account = account;
            this.Bericht = bericht;
            this.ReactieOp = reactieOp;
            this.Datum = datum;
        }

        public Reactie(int reactieID, int mediaID, Account account, string bericht, DateTime datum)
        {
            this.dm = new DatabaseManager();

            this.ReactieID = reactieID;
            this.MediaID = mediaID;
            this.Account = account;
            this.Bericht = bericht;
            this.Datum = datum;
        }

        //evt likes erbij.
        public override string ToString()
        {
            if (Bericht.Length < 51)
            {
                return VerkrijgParent() + Account.Roepnaam + ": " + ReactieID + "." + Bericht + "...";
            }
            else
            {
                return VerkrijgParent() + Account.Roepnaam + ": " + ReactieID + "." + Bericht.Substring(0, 50) + "...";
            }
        }

        /// <summary>
        /// Verkrijgt de string weergave voor de listbox reactie.
        /// </summary>
        /// <returns></returns>
        private string VerkrijgParent()
        {
            if (ReactieOp == null)
            {
                return "";
            }
            else if (ReactieOp.ReactieOp == null)
            {
                return "-";
            }
            else
            {
                return "-" + ReactieOp.VerkrijgParent();
            }
        }
    }
}
