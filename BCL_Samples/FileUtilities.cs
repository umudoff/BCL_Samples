using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCL_Samples
{
    class FileUtilities
    {

        public static void ProcessFile( string source)
        {
            
            var fInfo = new FileInfo(source);
            Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.FileInfoMessage, fInfo.Name, fInfo.CreationTime)
               );
            
            var folder= Path.Combine(fInfo.Directory.ToString(), "default");
            var destination= Path.Combine(folder, fInfo.Name);
            MoveFile(fInfo.FullName.ToString(), destination);


        }
        public static void MoveFile(string source, string destination)
        {
             
            try
            {
                File.Move(source, destination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (File.Exists(destination))
            {
                Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.FileMovedSuccessMessage, source, destination));
            }
            else
            {
                Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.FileMovedFailureMessage, source, destination));
            }

        }

        
    }
}
