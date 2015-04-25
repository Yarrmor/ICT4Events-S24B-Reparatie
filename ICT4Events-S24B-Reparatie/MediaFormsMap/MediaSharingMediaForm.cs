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
            if (alg.Account.Type != AccountType.Beheerder)
            {
                BeheerButtons();
            }
            else if (alg.Account != m.Uploader && alg.Account.Type != AccountType.Beheerder)
            {
                BeheerButtons();
                gbxBeheer.Enabled = false;
                gbxBeheer.Visible = false;
            }
        }

        private void BeheerButtons()
        {
            btnBan.Enabled = false;
            btnBan.Visible = false;
            btnMediaVerberg.Enabled = false;
            btnMediaVerberg.Visible = false;
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

            lblMediaVerborgen.Text = m.Verborgen.ToString();
            if (m.Verborgen == true) lblMediaVerborgen.ForeColor = Color.Red;
            else lblMediaVerborgen.ForeColor = Color.Green;

            VulComboBox();
        }

        /// <summary>
        /// Zet geselecteerde media naar dit zodat je altijd de juiste media kan downloaden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMediaBeschrijving_Click(object sender, EventArgs e)
        {
            md.GeselecteerdeMedia = m;
        }

        /// <summary>
        /// Wijzigt informatie van een media.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWijzig_Click(object sender, EventArgs e)
        {
            foreach (Media m in md.MediaLijst)
            {
                if (m == this.m)
                {
                    if (tbxNaam.Text != null) m.Naam = tbxNaam.Text;
                    if (cbxCategorie.Text != null) m.CategorieID = md.VerkrijgCatNaam(cbxCategorie.Text).ID;
                    if (tbxBeschrijving.Text != null) m.Beschrijving = tbxBeschrijving.Text;
                    this.m = m;
                    VerversInformatie();

                    /* Todo:
                     * -Verplaatsen van oude bestand naar nieuwe locatie.
                     * -Bestand path veranderen daarna.
                     * -bug teststen :(.
                     */
                }
            }
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
                RemoveMeldingen(m);
                md.VerwijderMedia(m);
                this.Dispose();
            }
        }

        /// <summary>
        /// Haalt de meldingen van een geselecteerde media weg.
        /// </summary>
        /// <param name="m"></param>
        private void RemoveMeldingen(Media m)
        {
            foreach (Melding meld in md.Meldingen.ToList())
            {
                if (meld.MediaID == m.MediaID)
                {
                    md.VerwijderMelding(meld);
                }
            }
        }

        /// <summary>
        /// De media wordt verborgen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaVerberg_Click(object sender, EventArgs e)
        {
            foreach (Media m in md.MediaLijst)
            {
                if (m == this.m)
                {
                    m.Verborgen = true;
                    this.m = m;
                    VerversInformatie();
                }
            }
        }

        /// <summary>
        /// Er wordt een reactie geplaatst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaatsReactie_Click(object sender, EventArgs e)
        {

        }

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
            p.Show();
        }

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
            r.Show();
        }

        private void ms_Download(object sender, EventArgs e)
        {
            string location = SaveFile();
            if (location != "")
            {
                File.Copy(md.GeselecteerdeMedia.Bestand.Pad, location);
            }
        }

        private string SaveFile()
        {
            SaveFileDialog fd = new SaveFileDialog();

            string bestandstype = md.GeselecteerdeMedia.Bestand.Type;

            fd.FileName = md.GeselecteerdeMedia.Naam + bestandstype;
            fd.Filter = bestandstype + " file|*" + bestandstype;
            DialogResult d = fd.ShowDialog();
            string file = "";
            if (d == DialogResult.OK)
            {
                file = fd.FileName;
            }
            return file;
        }
        #endregion

        public void MaakMenuBalk()
        {
            MenuStrip ms = new MenuStrip();
            alg.MaakMenuBalk(this, ms);
            MenuBalk_MediaSharingFormMediaForm(ms);
        }

        public void UpdateMenuBalk()
        {
            throw new NotImplementedException();
        }
    }
}
