using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevOps_ChangeWorkItemType
{
    static class Program
    {
        const string _configFileName = "LocalData.json";
        const string _wiCacheFileName = "~WorkItems.json";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }

        public static string LocalConfigFilePath() => Path.Combine(Application.CommonAppDataPath, _configFileName);
        public static string LocalWICacheFilePath() => Path.Combine(Application.CommonAppDataPath, _wiCacheFileName);

    }
}
