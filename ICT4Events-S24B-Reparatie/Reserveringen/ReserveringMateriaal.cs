using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class ReserveringMateriaal
    {
        public Exemplaar Exemplaar { get; set; }
        public Account Account { get; set; }
        public DateTime DatumStart { get; set; }
        public DateTime DatumEind { get; set; }
        public bool Betaald { get; set; }

        public ReserveringMateriaal(Exemplaar exemplaar, Account account, DateTime datumStart, DateTime datumEind, bool betaald)
        {
            this.Exemplaar = exemplaar;
            this.Account = account;
            this.DatumStart = datumStart;
            this.DatumEind = datumEind;
            this.Betaald = betaald;
        }
    }
}
