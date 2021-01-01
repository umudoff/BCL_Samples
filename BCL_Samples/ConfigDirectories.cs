using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL_Samples
{
    class ConfigDirectories
    {
    }
    public class DirElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
        }


    }

    public class DirElementCollection : ConfigurationElementCollection
    {

        [ConfigurationProperty("defaultDirectory")]
        public string DefaultDirectory {
            get { return (string)this["defaultDirectory"]; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DirElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DirElement)element).Path;
        }

    }
}
