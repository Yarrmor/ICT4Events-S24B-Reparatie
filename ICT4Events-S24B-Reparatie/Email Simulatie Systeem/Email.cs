using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Email
    {
        public string Rfid { get; set; }
        public string Onderwerp { get; set; }
        public string Titel { get { return Rfid + " - " + Onderwerp; } }

        public string Inhoud { get; set; }

        public int EventID { get; set; }

        public Email(string rfid, int eventID, string onderwerp, string inhoud)
        {
            Rfid = rfid;
            Onderwerp = onderwerp;
            Inhoud = inhoud;
            EventID = eventID;
        }
    }
}
