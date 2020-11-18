using Cw2.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2
{
    [Serializable]
    public class Uczelnia
    {   
        [XmlAttribute("createdAt")]
        public DateTime createdAt = DateTime.Now;

        [XmlAttribute("author")]
        public string author = "Daniel Staranowicz";

        [XmlArray("studenci")]
        [XmlArrayItem("student")]
        public List<Student> students { get; set; }
    }
}
