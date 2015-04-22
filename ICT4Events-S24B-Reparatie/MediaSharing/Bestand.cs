using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Bestand
    {
        public string Type { get; set; }
        public string Pad { get; set; }

        private DatabaseManager dm;

        public Bestand(string type, string pad)
        {
            this.Type = type;
            this.Pad = pad;

            this.dm = new DatabaseManager();
        }
    }
}
