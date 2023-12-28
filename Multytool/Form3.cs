using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multytool
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            ;
            this.Hide();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.* |Batch file (*.bat) |*.bat |VBS file (*.vbs |*.vbs |Data file (*.dat) |*.dat";
            saveFileDialog1.Title = "Enregistrer le fichier texte";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private async void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers MTF (*.mtf)|*.mtf|Tous les fichiers (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;

                    // Lecture du contenu du fichier sélectionné de manière asynchrone
                    string fileContent = await Task.Run(() => File.ReadAllText(filePath));

                    // Affichage du contenu dans le RichTextBox
                    richTextBox1.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'ouverture du fichier : " + ex.Message);
                }
            }
        }
    }
    
}
