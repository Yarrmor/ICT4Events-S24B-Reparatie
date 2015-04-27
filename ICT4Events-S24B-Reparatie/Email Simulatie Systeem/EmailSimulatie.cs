using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class EmailSimulatie
    {
        private Algemeen algemeen;

        public Email GeselecteerdeEmail { get; set; }

        public EmailSimulatie(Algemeen algemeen)
        {
            this.algemeen = algemeen;
        }

        /// <summary>
        /// Geeft de gelecteerde email mee.  
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Email SelecteerEmail(int i)
        {
            GeselecteerdeEmail = algemeen.Emails[i];

            return GeselecteerdeEmail;
        }

        /// <summary>
        /// Haalt op of het meegegeven account verifieerd is
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool VerkrijgAccountGeverifieerd(string rfid)
        {
            DatabaseManager dm = new DatabaseManager();

            return (dm.VerkrijgAccountVerifieerd(rfid) == 1);
        }

        /// <summary>
        /// Haalt op of de reservering al is betaald van de meegegeven gegevens.
        /// </summary>
        /// <returns></returns>
        public bool VerkrijgReserveringBetaald()
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.VerkrijgReserveringBetaald(GeselecteerdeEmail.Rfid, GeselecteerdeEmail.EventID);
        }

        /// <summary>
        /// Stuurt de rfid van de geselecteerde email naar de database.
        /// </summary>
        public void VerifieerAccount(string rfid, string voornaam, string achternaam, string roepnaam, string wachtwoord)
        {
            DatabaseManager dm = new DatabaseManager();

            dm.VerifieerAccount(rfid, voornaam, achternaam, roepnaam, wachtwoord);
        }

        /// <summary>
        /// Stuurt de rfid en eventID van de geselecteerde email naar de database.
        /// </summary>
        /// <returns></returns>
        public bool BetaalReservering()
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.BetaalReservering(GeselecteerdeEmail.Rfid, GeselecteerdeEmail.EventID);
        }

        /// <summary>
        /// Annuleert de reservering van de geselecteerde mail en verwijdert de mails die erbij horen.
        /// </summary>
        /// <returns></returns>
        public bool AnnuleerReservering()
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.AnnuleerReservering(GeselecteerdeEmail.Rfid, GeselecteerdeEmail.EventID);
        }
    }
}
