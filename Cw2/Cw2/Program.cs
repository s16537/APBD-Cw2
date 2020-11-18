using CsvHelper;
using Cw2.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            //program parameters initialized with default values 
            string inputFile = "dane.csv";
            string destPath = "result.xml";
            string format = "xml";
            foreach(string param in args)
            {
                bool inputInfo = param.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0;
                bool outputXML = param.IndexOf(".xml", StringComparison.OrdinalIgnoreCase) >= 0;
                bool outputJSON = param.IndexOf(".json", StringComparison.OrdinalIgnoreCase) >= 0;
                bool formatXML = string.Equals(param, "xml", StringComparison.OrdinalIgnoreCase);
                bool formatJSON = string.Equals(param, "json", StringComparison.OrdinalIgnoreCase);

                if (inputInfo)
                {
                    inputFile = param;
                }
                else if (outputXML)
                {
                    destPath = param;
                }
                else if (outputJSON)
                {
                    destPath = param;
                }
                else if (formatXML)
                {
                    format = param;
                }
                else if (formatJSON)
                {
                    format = param;
                }
            }

            //reading csv
            using (var reader = new StreamReader(inputFile))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Student student = new Student();
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<StudentMap>();
                List<Student> records = csv.GetRecords<Student>().ToList();

                Uczelnia uczelnia = new Uczelnia();
                uczelnia.students = records;

                //saving to XML
                FileStream writer = new FileStream(destPath, FileMode.Create);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Uczelnia), new XmlRootAttribute("uczelnia"));
                xmlSerializer.Serialize(writer, uczelnia);
                writer.Close();
            }

        

        }

    }
}
