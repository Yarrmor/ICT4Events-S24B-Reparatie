using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events_S24B_Reparatie
{
    public partial class MediaSharingForm : Form, ILoginSysteem
    {
        private Algemeen algemeen;
        private MediaSharingSysteem md;
        private MenuStrip ms;
        private DatabaseManager dm;

        public MediaSharingForm(Algemeen alg, MediaSharingSysteem md)
        {
            this.algemeen = alg;
            this.md = md;
            InitializeComponent();
            MaakMenuBalk();
            WeergeefCategories();
            MediaListBox();
            VulCategorieComboBox();
        }

        /// <summary>
        /// Indien je op een categorie klikt dan laat het de media van die categoriën zien.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCategorie.SelectedItem != null)
            {
                if (lbxCategorie.SelectedItem.ToString() != "_Main")
                {
                    VerkrijgMediaGeselecteerdeCategorie();
                }
                else
                {
                    MediaListBox();
                }
            }
        }

        /// <summary>
        /// Maakt een nieuw categorie aan en plaats die in de categorie listbox. Als er een categorie is geselecteerd wordt daar een subcategorie onder gezet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNieuwCategorie_Click(object sender, EventArgs e)
        {
            if (lbxCategorie.SelectedItem != null)
            {
                if (lbxCategorie.SelectedItem.ToString() != "_Main") 
                {
                    VoegCategorieToe(md.VerkrijgCategorie(lbxCategorie.SelectedItem.ToString()));
                }
                else
                {
                    VoegCategorieToe();
                }
            }
            else
            {
                VoegCategorieToe();
            }
        }

        #region Categorie

        /// <summary>
        /// Voegt een hoofd categorie toe.
        /// </summary>
        private void VoegCategorieToe()
        {
            if (md.VoegCategorieToe(VerkrijgCategorieNaam(), algemeen.Account))
            {
                WeergeefCategories();
            }
            else
            {
                MessageBox.Show("Categorie Bestaat al!");
            }
        }

        /// <summary>
        /// Voegt een categorie toe aan een categorie.
        /// </summary>
        /// <param name="c"></param>
        private void VoegCategorieToe(Categorie c)
        {
            if (md.VoegCategorieToe(VerkrijgCategorieNaam(), c, algemeen.Account))
            {
                WeergeefCategories();
            }
            else
            {
                MessageBox.Show("Categorie Bestaat al!");
            }
        }

        /// <summary>
        /// Laat all categoriën zien.
        /// </summary>
        private void WeergeefCategories()
        {
            lbxCategorie.Items.Clear();
            lbxCategorie.Items.Add("_Main");
            foreach (Categorie c in md.CategorieLijst)
            {
                if (!InListBox(c.ToString()))
                {
                    //lbxCategorie.Items.Add(c.ToString());
                    VoegCategoriesToe(c);
                }
            }
        }

        /// <summary>
        /// Kijkt of de categorie al voorkomt in de listbox.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool InListBox(string item)
        {
            foreach(var l in lbxCategorie.Items)
            {
                if (l.ToString() == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Voegt categorie toe aan listbox.
        /// </summary>
        /// <param name="c"></param>
        private void VoegCategoriesToe(Categorie c)
        {
            lbxCategorie.Items.Add(c.ToString());
            AddSubCategories(c);
        }

        /// <summary>
        /// Voegt Subcategories van een categorie toe aan listbox.
        /// </summary>
        /// <param name="cat"></param>
        private void AddSubCategories(Categorie cat)
        {
            foreach (Categorie c in md.CategorieLijst)
            {
                if (c.Parent == cat)
                {
                    VoegCategoriesToe(c);
                }
            }
        }

        /// <summary>
        /// Laat een dialoog zien waarin je een categorienaam in kan vullen.
        /// </summary>
        /// <returns>De naam van de categorie die is ingevuld in het dialoog.</returns>
        private string VerkrijgCategorieNaam()
        {
            CategorieNaam cn = new CategorieNaam();

            string naam = "";

            if (cn.ShowDialog(this) == DialogResult.OK)
            {
                naam = cn.tbxCategorieNaam.Text;
            }

            cn.Dispose();

            return naam;
        }
        #endregion

        private void VerkrijgMediaGeselecteerdeCategorie()
        {
            foreach (Categorie c in md.CategorieLijst)
            {
                if (c.ToString() == lbxCategorie.SelectedItem.ToString())
                {
                    MediaListBox(c);
                }
            }
        }

        /// <summary>
        /// Voegt alle media van een categorie toe aan de media listbox!
        /// </summary>
        /// <param name="c"></param>
        private void MediaListBox(Categorie c)
        {
            lbxMedia.Items.Clear();
            foreach (Media m in md.MediaLijst)
            {
                if (m != null)
                {
                    if (m.CategorieID == c.ID && !m.Verborgen)
                    {
                        lbxMedia.Items.Add(m.ToString());
                    }
                    else if (m.CategorieID == c.ID && m.Verborgen && algemeen.Account.Type == AccountType.Beheerder)
                    {
                        lbxMedia.Items.Add(m.ToString());
                    }
                }
            }            
        }

        /// <summary>
        /// Haalt de media op
        /// </summary>
        private void MediaListBox()
        {
            lbxMedia.Items.Clear();
            foreach (Media m in md.MediaLijst)
            {
                if (m != null)
                {
                    lbxMedia.Items.Add(m.ToString());
                }
            }
        }

        /// <summary>
        /// Verwijdert de categorie en/of subcategorie als die er is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerwijderCategorie_Click(object sender, EventArgs e)
        {
            if (lbxCategorie.SelectedItem != null) //&& alg.Account.Type == AccountType.Beheerder
            {
                Categorie cat = md.VerkrijgCategorie(lbxCategorie.SelectedItem.ToString());
                md.VerwijderCategorie(cat);
                md.UpdateCatMedia();
                MediaListBox();
                WeergeefCategories();
            }
        }

        /// <summary>
        /// Laat de geselecteerde media zien in een nieuw form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Media m in md.MediaLijst)
            {
                if (lbxMedia.SelectedItem != null)
                {
                    if (m.ToString() == lbxMedia.SelectedItem.ToString())
                    {
                        MediaSharingFormMediaForm msmf = new MediaSharingFormMediaForm(algemeen, m, md);
                        msmf.Show();
                        break;
                    }
                }
            }
        }

        #region Menustrip

        /// <summary>
        /// Maakt een menu balk. 
        /// </summary>
        /// <param name="ms"></param>
        public void MenuBalk_MediaSharingForm(MenuStrip ms)
        {
            ms.Items.Add("Upload Media");
            ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_test);

            ms.Items.Add("Profiel");
            ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_Profiel);

            if (algemeen.Account.Type == AccountType.Beheerder)
            {
                ms.Items.Add("Gerapporteerd");
                ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_Gerapporteerd);

                ms.Items.Add("Account Lijst");
                ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_AccountLijst);
            }
        }

        /// <summary>
        /// Laat het profiel zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_Profiel(object sender, EventArgs e)
        {
            Profiel p = new Profiel(algemeen, algemeen.Account, md);
            p.Show();
        }

        /// <summary>
        /// Laat de lijst met accounts zien, alleen zichtbaar voor beheerder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_AccountLijst(object sender, EventArgs e)
        {
            AccountLijst a = new AccountLijst(algemeen, md);
            a.Show();
        }

        /// <summary>
        /// Laat de geraporteerde media zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_Gerapporteerd(object sender, EventArgs e)
        {
            md.VerkrijgMeldingenLijst();
            Gerapporteerd g = new Gerapporteerd(algemeen, md);
            g.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_test(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            UploadMedia um = new UploadMedia(md.CategorieLijst, @"F:\ProftaakS2\MediaSharing");

            if (um.ShowDialog() == DialogResult.OK)
            {
                Categorie cat = md.VerkrijgCatNaam(um.cbxMediaCategorie.Text);

                Media nieuwMedia = new Media(dm.NieuwMediaID(), um.tbxMediaTitel.Text, new Bestand(um.dest.Substring(um.dest.LastIndexOf(".")), um.dest), cat.ID,
                                        um.tbxMediaBeschrijving.Text, algemeen.Account, DateTime.Now, algemeen.Evenement.ID, false);
                /*(int mediaID, string naam, Bestand bestand, Categorie categorie, string beschrijving, Account uploader, DateTime uploadDate, Event event_, bool verborgen)*/

                dm.VoegMediaToe(nieuwMedia);
                md.UpdateCatMedia();
            }
            um.Dispose();
        }

        #endregion

        #region Filter

        private void VulLbxMediaFiltered()
        {
            lbxMedia.Items.Clear();
            foreach (Media m in md.MediaLijstFiltered)
            {
                lbxMedia.Items.Add(m.ToString());
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();

            bool ascending = CheckAscendingRBN();

            if (rbnFilterNaam.Checked)
            {
                md.MediaLijstFiltered = dm.FilterMedia(ascending, algemeen.Evenement.ID, "Naam");
            }
            else if (rbnFilterDatum.Checked)
            {
                md.MediaLijstFiltered = dm.FilterMedia(ascending, algemeen.Evenement.ID, "Datum");
            }
            else if (rbnFilterLikes.Checked)
            {
                md.MediaLijstFiltered = dm.FilterMedia(ascending, algemeen.Evenement.ID, "Likes");
            }
            else if (rbnFilterDislikes.Checked)
            {
                md.MediaLijstFiltered = dm.FilterMedia(ascending, algemeen.Evenement.ID, "DisLikes");
            }

            if (rbnFilterCategorie.Checked) md.FilterCategorie(md.VerkrijgCategorie(VerkrijgComboBoxText()).ID);
            if (tbxFilterZoekWoord.Text != "") md.FilterMedia(tbxFilterZoekWoord.Text, rbnFilterNaam.Checked);

            VulLbxMediaFiltered();
        }

        private string VerkrijgComboBoxText()
        {
            if (cbxFilterCategorie.SelectedItem != null)
            {
                return cbxFilterCategorie.SelectedItem.ToString();
            }
            else
            {
                return cbxFilterCategorie.Text;
            }
        }

        private bool CheckAscendingRBN()
        {
            if (rbnSortAsc.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VulCategorieComboBox()
        {
            bool first = true;
            foreach (Categorie c in md.CategorieLijst)
            {
                if (c != null)
                {
                    if (first == true)
                    {
                        first = false;
                        cbxFilterCategorie.Text = c.Naam;
                        cbxFilterCategorie.Items.Add(c.Naam);
                    }
                    else
                    {
                        cbxFilterCategorie.Items.Add(c.Naam);
                    }
                }
            }
        }

        #endregion

        public void MaakMenuBalk()
        {
            ms = new MenuStrip();
            algemeen.MaakMenuBalk(this, ms);
            MenuBalk_MediaSharingForm(ms);
        }

        public void UpdateMenuBalk()
        {
            throw new NotImplementedException();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            WeergeefCategories();
        }

        private void tbxZoekCategorie_TextChanged(object sender, EventArgs e)
        {
            if (tbxZoekCategorie.Text != "")
            {
                for (int n = lbxCategorie.Items.Count - 1; n >= 0; --n)
                {
                    if (lbxCategorie.Items[n].ToString().IndexOf(tbxZoekCategorie.Text) < 0)
                    {
                        lbxCategorie.Items.RemoveAt(n);
                    }
                }
            }
            else
            {
                WeergeefCategories();
            }
        }

        private void tbxZoekMedia_TextChanged(object sender, EventArgs e)
        {
            if (tbxZoekMedia.Text != "")
            {
                for (int n = lbxMedia.Items.Count - 1; n >= 0; --n)
                {
                    if (lbxMedia.Items[n].ToString().IndexOf(tbxZoekMedia.Text) < 0)
                    {
                        lbxMedia.Items.RemoveAt(n);
                    }
                }
            }
            else
            {
                if (lbxCategorie.SelectedItem == null)
                {
                    MediaListBox();
                }
                else
                {
                    VerkrijgMediaGeselecteerdeCategorie();
                }
            }
        }
    }
}
