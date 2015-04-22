using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class ReserveringPlaats
    {
        public Groepshoofd Groepshoofd { get; set; }
        public Plek Plek { get; set; }
        public Event Event { get; set; }
        public DateTime DatumStart { get; set; }
        public DateTime DatumEind { get; set; }
        public bool Betaald { get; set; }

        private DatabaseManager dm;

        public ReserveringPlaats(Groepshoofd groepshoofd, Plek plek, Event event_, DateTime datumStart, DateTime datumEind, bool betaald)
        {
            this.Groepshoofd = groepshoofd;
            this.Plek = plek;
            this.Event = event_;
            this.DatumStart = datumStart;
            this.DatumEind = datumEind;
            this.Betaald = betaald;

            this.dm = new DatabaseManager();
        }
    }
}
