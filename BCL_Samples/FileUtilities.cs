using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BCL_Samples
{
    class FileUtilities
    {
        public class Rule
        {
            public RuleElement RuleElement;
            public int matchesCount;
           public  Rule(RuleElement r)
            {
                this.RuleElement = r;
                matchesCount = 0;
            }

        }

        private static List<Rule> rulesConfig = new List<Rule>();
        private static List<FileSystemWatcher> fileWatchers = new List<FileSystemWatcher>();
        private static FileInfo defaultPath;
        public static void InitWatchers(DirElementCollection directories)
        {
            defaultPath = new FileInfo(directories.DefaultDirectory);
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
        public static void InitRules(RulesElementCollection rules)
        {
            foreach (RuleElement r in rules)
            {
                Rule rule = new Rule(r);
                rulesConfig.Add(rule);
            }

        }

        public static void ProcessFile(string source)
        {
            bool isFileMoved = false;
            var fInfo = new FileInfo(source);
           
            foreach (var rule in rulesConfig)
            {
               var match = Regex.Match(fInfo.Name, rule.RuleElement.FileNamePattern);
                if (match.Success)
                {
                    rule.matchesCount++;
                    isFileMoved = true;
                    Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.RuleMatches, rule.RuleElement.FileNamePattern, fInfo.Name));
                    string extension = Path.GetExtension(fInfo.Name);
                    string destination="";
                    var folder = rule.RuleElement.DestinationDirectory.ToString();
                    string fName =Path.GetFileNameWithoutExtension(fInfo.Name);
                    
                    if (rule.RuleElement.AddMoveDate)
                    {
                        var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        fName = string.Concat(fName, $"_{DateTime.Now.ToString("yyyyMMdd")}");                           
                    }

                    if (rule.RuleElement.AddFileIndex)
                    {
                        var fIndex = "_"+rule.matchesCount.ToString();
                        fName = string.Concat(string.Concat(fName, fIndex), extension);
                    }

                    destination = Path.Combine(folder, string.Concat(fName, extension));

                    MoveFile(fInfo.FullName.ToString(), destination);                
                }
                else
                {
                    Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.RuleNotMatches, rule.RuleElement.FileNamePattern, fInfo.Name));
                }

                if (!isFileMoved)
                {
                    var destination = Path.Combine(defaultPath.ToString(), fInfo.Name);
                    MoveFile(fInfo.FullName.ToString(), destination);
                }
            }
            Console.WriteLine(string.Format(BCL_Samples.Resources.LogMessages.FileInfoMessage, fInfo.Name, fInfo.CreationTime));
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
