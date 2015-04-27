using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class ReserveringSysteem
    {
        public Algemeen Algemeen { get; set; }

        public ReserveringSysteem(Algemeen algemeen)
        {
            this.Algemeen = algemeen;
        }

        public List<Plek> VerkrijgBeschikbarePlekken(List<string> filters)
        {
            DatabaseManager dm = new DatabaseManager();

            List<Plek> plekken = dm.VerkrijgBeschikbarePlekken(Algemeen.Evenement.ID, Algemeen.Evenement.Locatie);

            List<Plek> gefilterdePlekken = new List<Plek>();

            foreach (Plek plek in plekken)
            {
                bool isGeschikt = true;

                foreach (string filter in filters)
                {
                    if (!plek.Beschrijving.Contains(filter))
                        isGeschikt = false;
                }

                if (isGeschikt)
                    gefilterdePlekken.Add(plek);
            }

            return gefilterdePlekken;
        }

        public int HaalPrijsOp(int plekID)
        {
            DatabaseManager dm = new DatabaseManager();

            // Kan korter ik (text van geselecteerde item in integer meegeven
            Plek plek = dm.HaalPlekOp(plekID, Algemeen.Evenement.Locatie);

            return plek.Prijs;
        }

        public int HaalTotaalPrijsOp(int dagPrijs, DateTime? beginDatum, DateTime? eindDatum)
        {
            if (beginDatum.HasValue && eindDatum.HasValue)
            {
                int aantalDagen = 1;
                DateTime? controleerDatum = beginDatum;

                while (controleerDatum.Value.DayOfYear != eindDatum.Value.DayOfYear)
                {
                    aantalDagen++;
                    controleerDatum = controleerDatum.Value.AddDays(1);
                }

                return aantalDagen * dagPrijs;
            }
            else
                return 0;
        }

        public Plek HaalPlekOp(int plekID)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.HaalPlekOp(plekID, Algemeen.Evenement.Locatie);
        }

        public bool VoegReserveringToe(ReserveringPlaats reservering)
        {

            DatabaseManager dm = new DatabaseManager();

            dm.VoegAccountToe(reservering.Groepshoofd as Account, Algemeen.Evenement.ID);
            dm.VoegGroepshoofdToe(reservering.Groepshoofd);

            return dm.VoegPlekReserveringToe(reservering);
        }

        public List<DateTime> VerkrijgDatums()
        {
            return Algemeen.Evenement.DateTimes();
        }
    }
}
