using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ICT4Events_S24B_Reparatie
{
    public partial class MediaSharingFormMediaForm : Form, ILoginSysteem
    {
        private Algemeen alg;
        private Media m;
        private MediaSharingSysteem md;
        private DatabaseManager dm;

        private List<Reactie> reacties;

        private ToolStripMenuItem InlogItem = new ToolStripMenuItem()
        {
            Name = "Inloggen",
            Text = "Inloggen",
            Alignment = ToolStripItemAlignment.Right
        };

        private ToolStripMenuItem UitlogItem = new ToolStripMenuItem()
        {
            Name = "Uitloggen",
            Text = "Uitloggen"
        };

        public MediaSharingFormMediaForm(Algemeen alg, Media m, MediaSharingSysteem md)
        {
            InitializeComponent();

            this.md = md;
            this.alg = alg;
            this.m = m;

            MaakMenuBalk();

            md.GeselecteerdeMedia = m;

            Visibility();
            VerversInformatie();
        }

        private void Visibility()
        {
            if (alg.Account != m.Uploader && alg.Account.Type != AccountType.Beheerder)
            {
                BeheerButtons();
                gbxBeheer.Enabled = false;
                gbxBeheer.Visible = false;
            }
            else if (alg.Account.Type != AccountType.Beheerder)
            {
                BeheerButtons();
            }
        }

        private void BeheerButtons()
        {
            btnBan.Enabled = false;
            btnBan.Visible = false;
            btnMediaVerberg.Enabled = false;
            btnMediaVerberg.Visible = false;
            btnVerwijder.Enabled = false;
            btnVerwijder.Visible = false;
        }

        /// <summary>
        /// Ververst informatie van dit media indien er iets wordt gewijzigt of het form wordt geladen.
        /// </summary>
        private void VerversInformatie()
        {
            DatabaseManager dm = new DatabaseManager();
            tbxMediaBeschrijving.Text = m.Beschrijving;
            lblMediaCategorie.Text = md.VerkrijgCategorie(m.CategorieID).Naam;
            lblMediaNaam.Text = m.Naam;
            lblMediaDisliked.Text = dm.VerkrijgDisLikes(this.m.MediaID).ToString(); //Query voor verkrijgen dislikes media.
            lblMediaLiked.Text = dm.VerkrijgLikes(this.m.MediaID).ToString(); //Query voor verkrijgen likes media.

            m.Uploader = dm.VerkrijgAccount(m.Uploader.AccountID, alg.Evenement.ID);

            if (m.Uploader.Verbannen)
            {
                lblMediaUploader.Text = m.Uploader.Roepnaam;
                lblMediaUploader.ForeColor = Color.Red;
                btnBan.Text = "Unban";
            }
            else
            {
                btnBan.Text = "Ban";
                lblMediaUploader.Text = m.Uploader.Roepnaam;
                lblMediaUploader.ForeColor = DefaultForeColor;
            }

            MediaVerborgen();
            WeergeefAlleReacties();
            VulComboBox();
        }

        private void MediaVerborgen()
        {
            DatabaseManager dm = new DatabaseManager();
            m.Verborgen = dm.MediaVerborgen(m.MediaID);
            lblMediaVerborgen.Text = m.Verborgen.ToString();
            if (m.Verborgen)
            {
                lblMediaVerborgen.ForeColor = Color.Red;
            }
            else
            {
                lblMediaVerborgen.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// Wijzigt informatie van een media.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWijzig_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            Media Wijzig;
            foreach (Media m in md.MediaLijst)
            {
                if (m == this.m)
                {
                    Wijzig = m;
                    if (tbxNaam.Text != null) Wijzig.Naam = tbxNaam.Text;
                    if (cbxCategorie.Text != null) Wijzig.CategorieID = md.VerkrijgCatNaam(cbxCategorie.Text).ID;
                    if (tbxBeschrijving.Text != null) Wijzig.Beschrijving = tbxBeschrijving.Text;
                    WijzigMedia(Wijzig, m);
                    VerversInformatie();

                    /* Todo: (EXTRA)
                     * -Verplaatsen van oude bestand naar nieuwe locatie.
                     * -Bestand path veranderen daarna.
                     */
                }
            }
        }

        private void WijzigMedia(Media Nieuw, Media Oud)
        {
            DatabaseManager dm = new DatabaseManager();
            if (dm.DisableFKReactie() && dm.DisableFKMelding())
            {
                if (dm.VerwijderMedia(Oud.MediaID))
                {
                    dm.VoegMediaToe(m);
                }
                else
                {
                    MessageBox.Show("Oude media kon niet worden verwijderd hierdoor vond deze wijziging niet plaats!");
                }
            }
            else
            {
                MessageBox.Show("FK_REACTIE_ID kon niet worden disabled, hierdoor vond de wijziging niet plaats!");
            }


            if (!dm.EnableFKReactie())
                MessageBox.Show("FK_REACTIE_MEDIAID kon niet worden enabled!");
            if (!dm.EnableFKMelding())
                MessageBox.Show("FK_MELDING_MEDIAID kon niet worden enabled!");
        }

        /// <summary>
        /// Vult de combobox van dit form met alle categorieën.
        /// </summary>
        private void VulComboBox()
        {
            bool first = true;
            foreach (Categorie c in md.CategorieLijst)
            {
                if (c != null)
                {
                    if (first == true)
                    {
                        first = false;
                        cbxCategorie.Text = c.Naam;
                        cbxCategorie.Items.Add(c.Naam);
                    }
                    else
                    {
                        cbxCategorie.Items.Add(c.Naam);
                    }
                }
            }
        }

        /// <summary>
        /// Verwijdert hele media indien er op de knop verwijder wordt gedrukt en daarna op ok wordt gedrukt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaVerwijder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je het zeker? Hiermee sluit je dit form.", "Verwijder media", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                md.VerwijderMedia(m);
                this.Dispose();
            }
        }

        //Todo: In mediasharingsysteem zetten.

        /// <summary>
        /// De media wordt verborgen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaVerberg_Click(object sender, EventArgs e)
        {
            if (m.Verborgen)
                md.VerbergMedia(m, false);
            else
                md.VerbergMedia(m, true);

            VerversInformatie();
        }

        //Todo: in mediasharingsysteem zetten.

        /// <summary>
        /// Wanneer de uploader nog niet verbannen is wordt deze verbannen na bevestiging. Als de uploader al verbannen is, is deze niet meer verbannen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBan_Click(object sender, EventArgs e)
        {
            if (!m.Uploader.Verbannen)
            {
                DialogResult dialogResult = MessageBox.Show("Weet je het zeker dat je deze persoon wilt verbannen?", "Ban:" + m.Uploader.Roepnaam, MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    m.Uploader.Ban();
                    VerversInformatie();
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Weet je het zeker dat je deze persoon wilt unbannen?", "Unban:" + m.Uploader.Roepnaam, MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    m.Uploader.UnBan();
                    VerversInformatie();
                }
            }
        }

        /// <summary>
        /// Laat het profiel van de uploader zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMediaUploader_Click(object sender, EventArgs e)
        {
            Profiel p = new Profiel(alg, m.Uploader, md);
            p.ShowDialog();
        }

        /// <summary>
        /// Geeft de media een like er bij.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaLike_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();

            if (m.Stem(alg.Account.AccountID, 1))
            {
                VerversInformatie();
            }
            else
            {
                MessageBox.Show("U heeft deze media al geliked!");
            }
        }

        /// <summary>
        /// Geeft de media een dislike der bij.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaDislike_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();

            if (m.Stem(alg.Account.AccountID, 0))
            {
                VerversInformatie();
            }
            else
            {
                MessageBox.Show("U heeft deze media al geliked!");
            }
        }

        #region Reacties

        /// <summary>
        /// Voegt een Reactie toe.
        /// </summary>
        private void VoegReactieToe()
        {
            DatabaseManager dm = new DatabaseManager();
            if (m.VoegReactieToe(new Reactie(dm.NieuwReactieID(), m.MediaID, alg.Account, VerkrijgBericht(), DateTime.Now)))
            {
                VerversInformatie();
            }
            else
            {
                MessageBox.Show("Reactie kon niet worden toegevoegd, dit probleem kan voorkomen wanneer de reactie al bestaat");
            }
        }

        /// <summary>
        /// Voegt een Reactie toe aan een Reactie
        /// </summary>
        /// <param name="c"></param>
        private void VoegReactieToe(Reactie r)
        {
            DatabaseManager dm = new DatabaseManager();
            if (m.VoegReactieToe(new Reactie(dm.NieuwReactieID(), m.MediaID, alg.Account, VerkrijgBericht(), r, DateTime.Now)))
            {
                VerversInformatie();
            }
            else
            {
                MessageBox.Show("Reactie kon niet worden toegevoegd, dit probleem kan voorkomen wanneer de reactie al bestaat");
            }
        }

        /// <summary>
        /// Laat een dialoog zien waarin je een categorienaam in kan vullen.
        /// </summary>
        /// <returns>De naam van de categorie die is ingevuld in het dialoog.</returns>
        private string VerkrijgBericht()
        {
            ReactieDialog rd = new ReactieDialog();

            string naam = "";

            if (rd.ShowDialog(this) == DialogResult.OK)
            {
                if (rd.tbxReactieBericht.Text != "")
                {
                    naam = rd.tbxReactieBericht.Text;
                }
                else
                {
                    MessageBox.Show("U heeft niets ingevuld");
                }
            }

            rd.Dispose();

            return naam;
        }

        /// <summary>
        /// Er wordt een reactie geplaatst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaatsReactie_Click(object sender, EventArgs e)
        {
            if (lbxReacties.SelectedItem != null)
            {
                if (lbxReacties.SelectedItem.ToString() != "_Reacties")
                {
                    VoegReactieToe(VerkrijgReactie(lbxReacties.SelectedItem.ToString()));
                }
                else
                {
                    VoegReactieToe();
                }
            }
            else
            {
                VoegReactieToe();
            }
        }

        public Reactie VerkrijgReactie(string ReactieString)
        {
            foreach (Reactie r in reacties)
            {
                if (r.ToString() == ReactieString)
                {
                    return r;
                }
            }
            return null;
        }

        private void WeergeefAlleReacties()
        {
            if (m.VerkrijgReacties() != null)
            {
                reacties = m.VerkrijgReacties();
            }
            lbxReacties.Items.Clear();
            lbxReacties.Items.Add("_Reactie");
            foreach (Reactie r in reacties)
            {
                if (r.MediaID == m.MediaID && !InListBox(r.ToString()))
                {
                    VoegReactiesToe(r);
                }
            }
        }

        private bool InListBox(string item)
        {
            foreach (var i in lbxReacties.Items)
            {
                if (i.ToString() == item)
                {
                    return true;
                }
            }
            return false;
        }

        private void VoegReactiesToe(Reactie r)
        {
            lbxReacties.Items.Add(r.ToString());
            VoegSubReactiesToe(r);
        }

        private void VoegSubReactiesToe(Reactie reactie)
        {
            foreach (Reactie r in reacties)
            {
                if (r.ReactieOp == reactie)
                {
                    VoegReactiesToe(r);
                }
            }
        }

        private void lbxReacties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxReacties.SelectedItem != null)
            {
                foreach (Reactie r in reacties)
                {
                    if (r.ToString() == lbxReacties.SelectedItem.ToString())
                    {
                        ShowReactie(r);
                    }
                }
            }
        }

        public void ShowReactie(Reactie r)
        {
            gbxReactie.Text = r.Account.Roepnaam;
            lblReactieDatum.Text = r.Datum.ToString();
            tbxReactie.Text = r.Bericht;
            lblReactieDislikes.Text = "Not Implemented";
            lblReactieLikes.Text = "Not Implemented";
        }

        #endregion

        #region menustrip
        public void MenuBalk_MediaSharingFormMediaForm(MenuStrip ms)
        {
            ms.Items.Add("Download Media");
            ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_Download);

            ms.Items.Add("Rapporteer");
            ms.Items[(ms.Items.Count - 1)].Click += new EventHandler(ms_Rapporteer);
        }

        private void ms_Rapporteer(object sender, EventArgs e)
        {
            Rapporteer r = new Rapporteer(alg, md.GeselecteerdeMedia, md);
            r.ShowDialog();
        }

        //Todo: In mediasharingsysteem download zetten.
        private void ms_Download(object sender, EventArgs e)
        {
            md.DownloadMedia();
        }

        #endregion

        public bool MaakMenuBalk(Form form, MenuStrip ms)
        {
            foreach (Control c in form.Controls)
            {
                c.Top += 20;
            }

            form.Height += 20;

            form.Controls.Add(ms);

            if (alg.Account != null)
            {
                InlogItem.Text = "Ingelogd als: " + alg.Account.Email;

                UitlogItem.Click += alg.uitlogItem_Click;

                InlogItem.DropDownItems.Add(UitlogItem);
            }
            else
            {
                InlogItem.Click += alg.inlogItem_Click;
            }

            ms.Items.Add(InlogItem);

            return (alg.Account != null);
        }

        public void MaakMenuBalk()
        {
            MenuStrip ms = new MenuStrip();
            MaakMenuBalk(this, ms);
            MenuBalk_MediaSharingFormMediaForm(ms);
        }

        public void UpdateMenuBalk()
        {
            throw new NotImplementedException();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VerversInformatie();
        }

        private void btnRefreshReacties_Click(object sender, EventArgs e)
        {
            WeergeefAlleReacties();
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            DatabaseManager dm = new DatabaseManager();
            if (lbxReacties.SelectedItem != null)
            {
                foreach (Reactie r in reacties)
                {
                    if (lbxReacties.SelectedItem.ToString() == r.ToString())
                    {
                        VerwijderReactie(r);
                    }
                }
            }
            VerversInformatie();
        }

        /// <summary>
        /// Verwijderd een Reactie met de bijbehorende SubReacties.
        /// </summary>
        /// <param name="cat"></param>
        public void VerwijderReactie(Reactie Reactie)
        {
            DatabaseManager dm = new DatabaseManager();
            VerwijderSubReacties(Reactie);
            dm.VerwijderReactie(Reactie.ReactieID);
        }

        /// <summary>
        /// Verwijdert alle subReacties van deze Reactie.
        /// </summary>
        /// <param name="cat"></param>
        public void VerwijderSubReacties(Reactie reactie)
        {
            DatabaseManager dm = new DatabaseManager();
            foreach (Reactie r in reacties.ToList())
            {
                if (r.ReactieOp == reactie)
                {
                    VerwijderSubReacties(r);
                    dm.VerwijderReactie(r.ReactieID);
                    //***Database connectie voor het verwijderen van categoriën in de database.
                }
            }
        }

        private void btnReactieLike_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nog niet geimplementeerd in de database.");
        }

        private void btnReactieDislike_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nog niet geimplementeerd in de database.");
        }
    }
}
