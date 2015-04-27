using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Toegangscontrole
    {
        private Algemeen algemeen;
        private DatabaseManager dm;
        private RFIDLezer rfidLezer;
        private ToegangscontroleForm toegangscontroleForm;

        public Toegangscontrole(Algemeen algemeen, ToegangscontroleForm toegangscontroleForm)
        {
            this.algemeen = algemeen;

            dm = new DatabaseManager();

            this.toegangscontroleForm = toegangscontroleForm;

            rfidLezer = new RFIDLezer(this);

        }

        /// <summary>
        /// Haalt de reserveringsplaats op van de meegegeven rfid
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public ReserveringPlaats VerkrijgReserveringPlaats(string rfid)
        {
            return dm.VerkrijgReserveringPlaats(rfid);
        }

        /// <summary>
        /// Controlleert of het rfid gescand is en zet het rfid aanwezig of afwezig.
        /// </summary>
        /// <param name="rfid"></param>
        public void RFIDGescand(string rfid)
        {
            if (toegangscontroleForm.Scannen)
                toegangscontroleForm.RFIDGescand(rfid);
        }
        //private bool ZetAanwezig(string rfid)
        //{
        //    return dm.ZetAanwezig(rfid);
        //}

        //private bool ZetAfwezig(string rfid)
        //{
        //    return dm.ZetAfwezig(rfid);
        //}

        /// <summary>
        /// Geeft het rfid mee die op betaald moet worden gezet
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool ZetBetaald(string rfid)
        {
            return dm.ZetBetaald(rfid, algemeen.Evenement.ID);
        }

        public bool ZetAanwezig(string rfid)
        {
            return dm.ZetAanwezig(rfid, algemeen.Evenement.ID);
        }

        /// <summary>
        /// Geeft het rfid mee waarvan de reservering moet worden geannuleerd
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool AnnuleringReservering(string rfid)
        {
            return dm.AnnuleringReservering(rfid, algemeen.Evenement.ID);
        }

        public List<Account> Aanwezigen(int eventID)
        {
            return dm.VerkrijgAanwezigen(eventID);
        }

        //public List<Account> Afwezig()
        //{
        //    return dm.VerkrijgAfwezig();
        //}

        /// <summary>
        /// Haalt de details op van het acccount van de meegegeven rfid
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public Account VerkrijgGroepslid(string rfid)
        {
            return dm.VerkrijgAccountDetailsToegang(rfid);
        }

        /// <summary>
        /// Sluit de rfid lezer
        /// </summary>
        public void Sluit()
        {
            rfidLezer.Sluit();
        }
    }
}
