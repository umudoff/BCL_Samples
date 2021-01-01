using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BCL_Samples
{
    class Program
    {
        private static List<FileSystemWatcher> fileWatchers= new List<FileSystemWatcher>();

        public static void InitWatchers(DirElementCollection directories)
        {
            foreach (DirElement d in directories)
            {
                var watcher = new FileSystemWatcher();
                watcher.Path = d.Path;
                watcher.NotifyFilter = NotifyFilters.FileName;
                watcher.Created += (object sender, FileSystemEventArgs e) => {
                    FileUtilities.ProcessFile(e.FullPath);
                };
                watcher.EnableRaisingEvents = true;
                fileWatchers.Add(watcher);
            }

        }
        static void Main(string[] args)
        {
            var config = (BCL_ConfigurationSection)ConfigurationManager.GetSection("simpleSection");
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.DefaultThreadCurrentCulture = config.Culture;
            CultureInfo.DefaultThreadCurrentUICulture = config.Culture;
            CultureInfo.CurrentUICulture = config.Culture;
            CultureInfo.CurrentCulture = config.Culture;      
            var rm = new ResourceManager("BCL_Samples.Resources.LogMessages",typeof(Program).Assembly);           
            var mes = BCL_Samples.Resources.LogMessages.StopExecution;
            Console.WriteLine(rm.GetString("StopExecution"));
            
            FileUtilities.InitRules(config.Rules);
            InitWatchers(config.Dirs);

            Console.ReadLine();
   
        }

        

    }
}
