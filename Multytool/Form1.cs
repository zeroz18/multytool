using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multytool
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

      
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            // URL du premier pastebin (RAW) version
            string urlPastebin1 = "https://pastebin.com/raw/nAMZEPP3";
            // URL du deuxième pastebin (RAW) download
            string urlPastebin2 = "https://pastebin.com/raw/gYE3vava";
            // Téléchargement du contenu du premier pastebin
            string contenuPastebin = DownloadString(urlPastebin1);
            // Stockage du contenu du premier pastebin dans la variable version-pastebin
            string versionPastebin = contenuPastebin.Trim();
            // Variable version avec une valeur par défaut
            string version = "V1.1.5";
            // Vérification si version et version-pastebin sont différentes
            if (version != versionPastebin)
            {
                version = versionPastebin;
                OpenUrlInBrowser(urlPastebin2);
            }

            Form2 form2 = new Form2();
            form2.Show();
            MessageBox.Show("Multytool a été correctement chargé", "Multytool", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        // Fonction pour télécharger le contenu d'une URL
        static string DownloadString(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        // Fonction pour ouvrir une URL dans le navigateur par défaut
        static void OpenUrlInBrowser(string url)
        {
            try
            {
                MessageBox.Show("Nouvelle version trouvée");
                Process.Start(url);
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez vous connecter a interet pour effectuer la MAJ");
                Application.Exit();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
    }
}