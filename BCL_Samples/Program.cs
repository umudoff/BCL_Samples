using System;
using System.Collections.Generic;
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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var culture = new CultureInfo("ru-RU");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
           
            var rm = new ResourceManager("BCL_Samples.Resources.LogMessages",typeof(Program).Assembly);
            var ca = DateTime.Now;
            
            var mes = BCL_Samples.Resources.LogMessages.StopExecution;
            Console.WriteLine(rm.GetString("StopExecution"));

            var watcher = new FileSystemWatcher();
            watcher.Path= @"C:\test_202012";
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Created+= (object sender, FileSystemEventArgs e)=> {
                  FileUtilities.ProcessFile(e.FullPath);
             };

            watcher.EnableRaisingEvents = true;

            Console.ReadLine();

        }

        

    }
}
