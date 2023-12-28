using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multytool
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static async Task Main() // Modification de void Main() à Task Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string value = WindowsIdentity.GetCurrent().User.Value;
            string pcname = Environment.UserName;         
            string pastebinContent = await GetPastebinContent(); // Modification ici pour attendre le contenu de Pastebin

            bool flag = pastebinContent.Contains(value);

            if (flag)
            {
                MessageBox.Show("Vous avez été banni de multytool.", "Multytool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        private static async Task<string> GetPastebinContent() // Modification pour retourner une tâche avec le contenu
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage result = await httpClient.GetAsync("https://pastebin.com/raw/cs9UYTqE");
                    bool isSuccessStatusCode = result.IsSuccessStatusCode;
                    if (isSuccessStatusCode)
                    {
                        return await result.Content.ReadAsStringAsync(); // Modification ici pour attendre la lecture du contenu
                    }
                    MessageBox.Show("Veuillez vous connecter à internet");
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Veuillez vous connecter à internet");
                    Environment.Exit(0);
                }
                return string.Empty;
            }
        }

      
        
    }
}
