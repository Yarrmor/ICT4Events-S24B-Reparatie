using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICT4Events_S24B_Reparatie
{
    public class Categorie
    {
        public int ID { get; set; }
        public Account Acc { get; set; }
        public Categorie Parent { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        private DatabaseManager dm;

        //Parent heeft geen parent
        public Categorie(int ID, string naam, string beschrijving, Account acc)
        {
            this.ID = ID;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Acc = acc;

            this.dm = new DatabaseManager();
        }

        //Subcategorie heeft een parent
        public Categorie(int ID, Categorie parent, string naam, string beschrijving, Account acc)
        {
            this.ID = ID;
            this.Parent = parent;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Acc = acc;

            this.dm = new DatabaseManager();
        }

        /*
        public bool VoegToe(Categorie categorie)
        {
            return this.dm.VoegCategorieToe(categorie);
        }

        public bool Verwijder(Categorie categorie)
        {
            return this.dm.VerwijderCategorie(this.ID);
        }
        public List<Media> Media()
        {
            return this.dm.MediaVanCategorie(this.ID);
        }
        */

        public override string ToString()
        {
            return VerkrijgParent() + Naam;
        }

        /// <summary>
        /// Verkrijgt de string weergave voor de listbox categorie.
        /// </summary>
        /// <returns></returns>
        private string VerkrijgParent()
        {
            if (Parent == null)
            {
                return "";
            }
            else if (Parent.Parent == null)
            {
                return "-";
            }
            else
            {
                return "-" + Parent.VerkrijgParent();
            }
        }

        /// <summary>
        /// Geeft het pad van deze categorie.
        /// </summary>
        /// <returns></returns>
        public string CategorieString()
        {
            string test = VerkrijgPadString();
            return Path.Combine(VerkrijgPadString(), Naam);
        }

        /// <summary>
        /// Verkrijgt het pad van deze categorie.
        /// </summary>
        /// <returns></returns>

        private string VerkrijgPadString()
        {
            if (Parent != null)
            {
                if (Parent.Parent == null)
                {
                    return Parent.Naam;
                }
                else
                {
                    return Parent.CategorieString();
                }
            }
            else
            {
                return "";
            }
        }
    }
}
