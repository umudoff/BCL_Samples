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
            FileUtilities.InitWatchers(config.Dirs);

            Console.ReadLine();
   
        }

        

    }
}
