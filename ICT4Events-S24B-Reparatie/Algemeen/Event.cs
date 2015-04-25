using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Event
    {
        public int ID { get; set; }
        public Locatie Locatie { get; set; }
        public string Naam { get; set; }
        public DateTime DatumStart { get; set; }
        public DateTime DatumEind { get; set; }


        private DatabaseManager dm;

        public Event(int eventID, Locatie locatie, string naam, DateTime datumStart, DateTime datumEind)
        {
            this.ID = eventID;
            this.Locatie = locatie;
            this.Naam = naam;
            this.DatumStart = datumStart;
            this.DatumEind = datumEind;

            this.dm = new DatabaseManager();
        }

        public List<Categorie> Categories()
        {
            return this.dm.VerkrijgCategorieënEvent(this.ID);
        }

        /// <summary>
        /// Geeft een lijst met alle media van het meegegeven event
        /// </summary>
        /// <returns></returns>
        public List<Media> Media()
        {
            return this.dm.VerkrijgMediaEvent(this.ID);
        }


        /// <summary>
        /// Geeft een lijst met alle meldingen van het meegegeven event
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Melding> Meldingen()
        {
            return this.dm.VerkrijgMeldingenEvent(this.ID);
        }


        /// <summary>
        /// Geeft het aantal resterende dagen van een event.
        /// </summary>
        /// <returns></returns>
        public List<DateTime> DateTimes()
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime datum = DatumStart.Date;

            do
            {
                dates.Add(datum);
                datum = datum.AddDays(1);
            } while (datum.Date != DatumEind.Date);

            return dates;
        }
    }
}
