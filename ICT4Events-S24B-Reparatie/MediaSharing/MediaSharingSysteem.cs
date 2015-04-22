using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_S24B_Reparatie
{
    public class MediaSharingSysteem
    {
        public List<Media> MediaLijst { get; set; }
        public List<Media> MediaLijstFiltered { get; set; }
        public List<Categorie> CategorieLijst { get; set; }
        public int EventID { get; set; }

        private DatabaseManager dm;

        /// <summary>
        /// Maakt een nieuwe MediaSharingSysteem aan. Verkrijgt eenmalig de nieuwste lijst van media en categorieën
        /// </summary>
        /// <param name="eventID"></param>
        public MediaSharingSysteem(int eventID)
        {
            this.dm = new DatabaseManager();

            this.EventID = eventID;
            this.MediaLijst = this.dm.VerkrijgMediaEvent(this.EventID);
            this.MediaLijstFiltered = new List<Media>();
            this.CategorieLijst = this.dm.VerkrijgCategorieënEvent(this.EventID);
        }

        //#===# CATEGORIE #===#

        /// <summary>
        /// Verkrijgt de nieuwste lijst met categorieën
        /// </summary>
        public void VerkrijgCategorieën()
        {
            this.CategorieLijst = this.dm.VerkrijgCategorieënEvent(this.EventID);
        }

        /// <summary>
        /// Voegt een nieuwe categorie toe aan de database
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public bool VoegCategorieToe(Categorie categorie)
        {
            return this.dm.VoegCategorieToe(categorie, this.EventID);
        }

        //#===# MEDIA #===#

        /// <summary>
        /// Verkrijgt de nieuwste lijst met media
        /// </summary>
        public void VerkrijgMedia()
        {
            this.MediaLijst = this.dm.VerkrijgMediaEvent(this.EventID);
        }

        /// <summary>
        /// Filtert de huidige lijst met media op een filter string
        /// </summary>
        /// <param name="filter"></param>
        public void Filter(string filter)
        {
            this.MediaLijstFiltered.Clear();

            foreach(Media media in this.MediaLijst)
            {
                if(media.Beschrijving.Contains(filter))
                {
                    this.MediaLijstFiltered.Add(media);
                }
            }
        }

        /// <summary>
        /// Filtert de huidige lijst met media op een categorieID
        /// </summary>
        /// <param name="categorieID"></param>
        public void Filter(int categorieID)
        {
            this.MediaLijstFiltered.Clear();

            foreach (Media media in this.MediaLijst)
            {
                if (media.CategorieID == categorieID)
                {
                    this.MediaLijstFiltered.Add(media);
                }
            }
        }

        /// <summary>
        /// Filtert de huidige lijst met media op een filter string en categorieID
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="categorieID"></param>
        public void Filter(string filter, int categorieID)
        {
            this.MediaLijstFiltered.Clear();

            foreach(Media media in this.MediaLijst)
            {
                if(media.Beschrijving.Contains(filter) && media.CategorieID == categorieID)
                {
                    this.MediaLijstFiltered.Add(media);
                }
            }
        }
    }
}
