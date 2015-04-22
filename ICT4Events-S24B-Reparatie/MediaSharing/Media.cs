using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class Media
    {
        public int MediaID { get; set; }
        public string Naam { get; set; }
        public Bestand Bestand { get; set; }
        public int CategorieID { get; set; }
        public string Beschrijving { get; set; }
        public Account Uploader { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Verborgen { get; set; }
        public int EventID { get; set; }

        private DatabaseManager dm;

        //Media zonder bestand
        public Media(int mediaID, string naam, int categorieID, string beschrijving, Account uploader, DateTime uploadDate, int eventID, bool verborgen)
        {
            this.MediaID = mediaID;
            this.Naam = naam;
            this.CategorieID = categorieID;
            this.Beschrijving = beschrijving;
            this.Uploader = uploader;
            this.EventID = eventID;
            this.UploadDate = uploadDate;
            this.Verborgen = verborgen;

            this.dm = new DatabaseManager();
        }

        //Media met bestand
        public Media(int mediaID, string naam, Bestand bestand, int categorieID, string beschrijving, Account uploader, DateTime uploadDate, int eventID, bool verborgen)
        {
            this.MediaID = mediaID;
            this.Naam = naam;
            this.Bestand = bestand;
            this.CategorieID = categorieID;
            this.Beschrijving = beschrijving;
            this.Uploader = uploader;
            this.UploadDate = uploadDate;
            this.EventID = eventID;
            this.Verborgen = verborgen;

            this.dm = new DatabaseManager();
        }

        /// <summary>
        /// Geeft een string met naam, likes en dislikes van de geselecteerde media
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Naam + " L:" + dm.VerkrijgLikes(this.MediaID) + " D:" + dm.VerkrijgDisLikes(this.MediaID);
        }

        public bool Stem(int score)
        {
            return this.dm.Stem(this.MediaID, score);
        }
    }
}
