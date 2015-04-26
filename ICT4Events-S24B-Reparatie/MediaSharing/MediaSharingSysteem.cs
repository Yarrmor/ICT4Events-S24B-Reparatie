using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ICT4Events_S24B_Reparatie
{
    public class MediaSharingSysteem
    {
        public List<Media> MediaLijst { get; set; }
        public List<Media> MediaLijstFiltered { get; set; }
        public List<Categorie> CategorieLijst { get; set; }
        public List<Melding> Meldingen { get; set; }
        public int EventID { get; set; }
        public Media GeselecteerdeMedia { get; set; }

        private DatabaseManager dm;

        /// <summary>
        /// Maakt een nieuwe MediaSharingSysteem aan. Verkrijgt eenmalig de nieuwste lijst van media en categorieën
        /// </summary>
        /// <param name="eventID"></param>
        public MediaSharingSysteem(int eventID)
        {
            this.dm = new DatabaseManager();

            this.EventID = eventID;
            Update();
            this.MediaLijstFiltered = new List<Media>();
        }

        #region NieuweMediaCatMeldingen...

        /// <summary>
        /// Update alle lijsten met de nieuwste gegevens uit de database.
        /// </summary>
        public void Update()
        {
            VerkrijgCategorieën();
            VerkrijgMediaLijst();
            VerkrijgMeldingenLijst();
        }

        /// <summary>
        /// Update alleen de categorieën en media.
        /// </summary>
        public void UpdateCatMedia()
        {
            VerkrijgCategorieën();
            VerkrijgMediaLijst();
        }

        /// <summary>
        /// Verkrijgt de nieuwste lijst met categorieën
        /// </summary>
        public void VerkrijgCategorieën()
        {
            this.CategorieLijst = this.dm.VerkrijgCategorieënEvent(this.EventID);
            if (CategorieLijst == null)
            {
                CategorieLijst = new List<Categorie>();
            }
        }

        /// <summary>
        /// Verkrijgt de nieuwste lijst met media
        /// </summary>
        public void VerkrijgMediaLijst()
        {
            this.MediaLijst = this.dm.VerkrijgMediaEvent(this.EventID);
            if (MediaLijst == null)
            {
                MediaLijst = new List<Media>();
            }
        }

        /// <summary>
        /// Verkrijgt de nieuwe lijst met meldingen.
        /// </summary>
        public void VerkrijgMeldingenLijst()
        {
            this.Meldingen = this.dm.VerkrijgMeldingenEvent(this.EventID);
            if (Meldingen == null)
            {
                Meldingen = new List<Melding>();
            }
        }

        #endregion

        #region Categorie
        /// <summary>
        /// Zorgt er voor dat een nieuwe categorie wordt toegevoegd.
        /// </summary>
        /// <param name="categorieNR"></param>
        /// <param name="naam"></param>
        public bool VoegCategorieToe(string naam, Account acc)
        {
            if (BestaatCategorieNiet(naam) && naam != "_Main" && naam != "_main")
            {
                dm.VoegCategorieToe(new Categorie(VerkrijgCategorieID(), naam, "lalaalalalalal", acc), this.EventID);
                UpdateCatMedia();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Er wordt een categorie toegevoegd indien deze nog niet bestaat
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="categorie"></param>
        /// <returns></returns>

        public bool VoegCategorieToe(string naam, Categorie categorie, Account acc)
        {
            if (BestaatCategorieNiet(naam) && naam != "_Main" && naam != "_main")
            {
                dm.VoegCategorieToe(new Categorie(VerkrijgCategorieID(), categorie, naam, "lalalaalalal", acc), this.EventID);
                UpdateCatMedia();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verwijderd een categorie met de bijbehorende subcategories.
        /// </summary>
        /// <param name="cat"></param>
        public void VerwijderCategorie(Categorie cat)
        {
            VerwijderSubCategories(cat);
            dm.VerwijderCategorie(cat.ID);
        }

        /// <summary>
        /// Verkrijgt een categorie op basis van de listbox string.
        /// </summary>
        /// <param name="categorieString"></param>
        /// <returns></returns>
        public Categorie VerkrijgCategorie(string categorieString)
        {
            foreach (Categorie c in CategorieLijst)
            {
                if (c.ToString() == categorieString)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Verkrijgt een categorie op basis van ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Categorie VerkrijgCategorie(int ID)
        {
            foreach (Categorie c in CategorieLijst)
            {
                if (c.ID == ID)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Verkrijgt de categorie m.b.v de categorienaam.
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public Categorie VerkrijgCatNaam(string naam)
        {
            foreach (Categorie c in CategorieLijst)
            {
                if (c.Naam == naam)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Kijkt of de categorie naam al bestaat of niet.
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        private bool BestaatCategorieNiet(string naam)
        {
            foreach (Categorie c in CategorieLijst)
            {
                if (c.Naam == naam)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verkrijgt het volgende beschikbare categorieNR
        /// </summary>
        /// <returns></returns>
        private int VerkrijgCategorieID()
        {
            int nieuweCategorie = dm.NieuwCategorieID();
            if (nieuweCategorie < 1)
            {
                CategorieLijst.OrderBy(x => x.ID).ToList();
                nieuweCategorie = 1;
                foreach (Categorie c in CategorieLijst)
                {
                    if (c != null)
                    {
                        if (nieuweCategorie == c.ID)
                        {
                            nieuweCategorie++;
                        }
                    }
                }
            }
            return nieuweCategorie;
        }


        /// <summary>
        /// Verwijdert alle subcategories van deze categorie.
        /// </summary>
        /// <param name="cat"></param>
        public void VerwijderSubCategories(Categorie cat)
        {
            foreach (Categorie c in CategorieLijst.ToList())
            {
                if (c.Parent == cat)
                {
                    VerwijderSubCategories(c);
                    dm.VerwijderCategorie(c.ID);
                    //***Database connectie voor het verwijderen van categoriën in de database.
                }
            }
        }


        /// <summary>
        /// Verwijderd een categorie.
        /// </summary>
        /// <param name="index">Welke categorie</param>
        public void CategorieVerwijderen(int catID)
        {
            CategorieLijst.Remove(VerkrijgCategorie(catID));
            dm.VerwijderCategorie(catID);
        }
        #endregion

        #region Melding

        /// <summary>
        /// Er owordt een melding toegevoegd
        /// </summary>
        /// <param name="melding"></param>
        /// <returns></returns>
        public bool VoegMeldingToe(Melding melding)
        {
            return dm.VoegMeldingToe(melding);
        }

        /// <summary>
        /// Haalt de meldingen van een geselecteerde media weg.
        /// </summary>
        /// <param name="m"></param>
        public void VerwijderMeldingen(Media m)
        {
            foreach (Melding meld in Meldingen.ToList())
            {
                if (meld.MediaID == m.MediaID)
                {
                    VerwijderMelding(meld);
                }
            }
        }

        /// <summary>
        /// Er wordt een melding verwijdert
        /// </summary>
        /// <param name="melding"></param>
        /// <returns></returns>
        public bool VerwijderMelding(Melding melding)
        {
            return dm.VerwijderMelding(melding);
        }
        #endregion

        #region Media

        public Media VerkrijgMedia(int ID)
        {
            foreach (Media m in MediaLijst)
            {
                if (m.MediaID == ID)
                {
                    return m;
                }
            }
            return null;
        }

        public bool VerwijderMedia(Media media)
        {
            VerwijderMeldingen(media);
            bool verwijderd = dm.VerwijderMedia(media.MediaID);
            UpdateCatMedia();
            return verwijderd;
        }

        public void DownloadMedia()
        {
            string location = SaveFile();
            if (location != "")
            {
                File.Copy(GeselecteerdeMedia.Bestand.Pad, location);
            }
        }

        private string SaveFile()
        {
            SaveFileDialog fd = new SaveFileDialog();

            string bestandstype = GeselecteerdeMedia.Bestand.Type;

            fd.FileName = GeselecteerdeMedia.Naam + bestandstype;
            fd.Filter = bestandstype + " file|*" + bestandstype;
            DialogResult d = fd.ShowDialog();
            string file = "";
            if (d == DialogResult.OK)
            {
                file = fd.FileName;
            }
            return file;
        }

        #endregion Media

        #region Filter
        /// <summary>
        /// Filtert de huidige lijst met media op een filter string
        /// </summary>
        /// <param name="filter"></param>
        public void FilterMedia(string filter, bool naam)
        {
            if (naam)
                FilterMediaNaam(filter);
            else
                FilterMediaBeschrijving(filter);
        }

        private void FilterMediaNaam(string filter)
        {
            foreach (Media m in MediaLijstFiltered.ToList())
            {
                if (m.Naam.IndexOf(filter) < 0)
                {
                    MediaLijstFiltered.Remove(m);
                }
            }
        }

        private void FilterMediaBeschrijving(string filter)
        {
            foreach (Media m in MediaLijstFiltered.ToList())
            {
                if (m.Beschrijving.IndexOf(filter) < 0)
                {
                    MediaLijstFiltered.Remove(m);
                }
            }
        }

        /// <summary>
        /// Filtert de huidige lijst met media op een categorieID
        /// </summary>
        /// <param name="categorieID"></param>
        public void FilterCategorie(int categorieID)
        {
            foreach (Media m in MediaLijstFiltered.ToList())
            {
                if (m.CategorieID != categorieID)
                {
                    MediaLijstFiltered.Remove(m);
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

            foreach (Media media in this.MediaLijst)
            {
                if (media.Beschrijving.Contains(filter) && media.CategorieID == categorieID)
                {
                    this.MediaLijstFiltered.Add(media);
                }
            }
        }
        #endregion
    }
}
