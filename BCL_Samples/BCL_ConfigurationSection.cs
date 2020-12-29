using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL_Samples
{
    
    public class BCL_ConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("dirs")]
        public DirElementCollection Dirs
        {
            get { return (DirElementCollection)this["dirs"]; }

        }

        [ConfigurationProperty("culture")]
        public CultureInfo Culture {
            get { return (CultureInfo)this["culture"]; } 
        }

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
