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


        [ConfigurationCollection(typeof(RuleElement), AddItemName = "rule")]
        [ConfigurationProperty("rules")]
        public RulesElementCollection Rules
        {
            get { return (RulesElementCollection)this["rules"]; }
        }


        [ConfigurationProperty("culture")]
        public CultureInfo Culture {
            get { return (CultureInfo)this["culture"]; } 
        }

    }

 
}
