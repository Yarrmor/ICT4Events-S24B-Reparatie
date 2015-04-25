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

namespace ICT4Event_S24GroepB
{
    public partial class UploadMedia : Form
    {
        private string path = "";
        public string dest = "";
        private List<Categorie> categorie;

        public UploadMedia(List<Categorie> categorie, string dest)
        {
            InitializeComponent();
            this.categorie = categorie;
            VulComboBox(categorie);
            this.dest = dest;
        }

        /// <summary>
        /// Vult de combobox in. Wanneer de categorie nog niet bestaat wordt deze aangemaakt.
        /// </summary>
        /// <param name="categorie"></param>
        private void VulComboBox(List<Categorie> categorie)
        {
            bool first = true;
            foreach (Categorie c in categorie)
            {
                if (c != null)
                {
                    if (first == true)
                    {
                        first = false;
                        cbxMediaCategorie.Text = c.Naam;
                        cbxMediaCategorie.Items.Add(c.Naam);
                    }
                    else
                    {
                        cbxMediaCategorie.Items.Add(c.Naam);
                    }
                }
            }
        }

        /// <summary>
        /// Wanneer alles is ingevuld wordt de media geüpload. Anders komt en melding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaUpload_Click(object sender, EventArgs e)
        {
            if (tbxMediaBeschrijving.Text != "" && tbxMediaTitel.Text != "" && path != "" && cbxMediaCategorie.Text != "")
            {
                UploadBestand();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Er is nog geen categorie aangemaakt of u bent heeft een van de volgende items niet ingevult: \n" +
                                "-De beschrijving \n" +
                                "-De Titel \n" +
                                "-Een bestand te selecteren \n" +
                                "-Een categorie te selecteren", "Upload niet succesvol!");
            }
        }

        /// <summary>
        /// Bepaalt de locatie van de media
        /// </summary>
        private void UploadBestand()
        {
            string locatie = VerkrijgLocatie();
            if (locatie != "")
            {
                if (!Directory.Exists(Path.Combine(dest, locatie)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, locatie));
                }

                dest = Path.Combine(Path.Combine(dest, locatie), Path.GetFileName(path));
                File.Copy(path, dest);
            }
            else
            {
                MessageBox.Show("Onbekende locatie!");
            }
        }

        /// <summary>
        /// Er wordt een dialog geopend waar je het gewenste bestand kunt kiezen om te uploaden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBestandZoek_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.filter = ""; moet nog worden teogevoegd, verzin wat filters vb: .xml file|*.xml
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                lblBestandNaam.Text = path;
            }
        }

        /// <summary>
        /// Er wordt gekeken of de categorie al in de combobox staat. 
        /// </summary>
        /// <returns></returns>
        private string VerkrijgLocatie()
        {
            foreach (Categorie c in categorie)
            {
                if (c.Naam == cbxMediaCategorie.Text)
                {
                    return c.CategorieString();
                }
            }
            return "";
        }
    }
}
