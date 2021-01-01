using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL_Samples
{
    class ConfigRules
    {
    }

    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("fileNamePattern", IsRequired =true )]
        public string FileNamePattern
        {
            get { return (string)this["fileNamePattern"]; }
        }
        [ConfigurationProperty("destinationPath", IsKey =true,IsRequired =true)]
        public string DestinationDirectory
        {
            get { return (string)this["destinationPath"]; }
        }
        [ConfigurationProperty("addFileIndex", IsRequired =false)]
        public bool AddFileIndex
        {
            get { return (bool)this["addFileIndex"]; }
        }

        [ConfigurationProperty("addMoveDate", IsRequired = false)]
        public bool AddMoveDate
        {
            get { return (bool)this["addMoveDate"]; }
        }


         
    }

    public class RulesElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
               return((RuleElement)element).FileNamePattern;
        }

    }


    
}
