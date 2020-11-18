using System;
using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using CsvHelper.Configuration;

namespace Cw2.models
{
    [Serializable]
    [XmlRootAttribute("student")]
    public class Student
    {
        private string indexNo;


        [XmlElement("fname")]
        public string FirstName { get; set; }

        [XmlElement("lname")]
        public string LastName { get; set; }

        [XmlAttribute("indexNumber")]
        public string IndexNo 
        {   get { return "s" + indexNo;  }
            set { indexNo = value;  }
        }

        [XmlElement("birthdate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("email")]
        public string Mail { get; set; }

        [XmlElement("mothersName")]
        public string MotherName { get; set; }

        [XmlElement("fathersName")]
        public string FatherName { get; set; }

        [XmlElement("studies")]
        public Studies Studies { get; set; }
    }

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Map(m => m.FirstName).Index(0);
            Map(m => m.LastName).Index(1);
            References<StudiesMap>(m => m.Studies);
            Map(m => m.IndexNo).Index(4);
            Map(m => m.BirthDate).Index(5);
            Map(m => m.Mail).Index(6);
            Map(m => m.MotherName).Index(7);
            Map(m => m.FatherName).Index(8);
        }
    }

}
