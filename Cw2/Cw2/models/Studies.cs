using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.models
{
    public class Studies
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("mode")]
        public string Mode { get; set; }
    }

    public class StudiesMap : ClassMap<Studies>
    {
        public StudiesMap()
        {
            Map(m => m.Name);
            Map(m => m.Mode);
        }
        

    }
}
