using System;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            //program parameters initialized with default values 
            string inputFile = "data.csv";
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

            Console.WriteLine(inputFile);
            Console.WriteLine(destPath);
            Console.WriteLine(format);
        

        }
    }
}
