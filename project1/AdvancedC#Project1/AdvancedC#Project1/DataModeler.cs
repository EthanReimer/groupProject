using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_Project1
{
    public class DataModeler
    {
        //Parse XML method
        public void ParseXML(string fileName)
        {
            Console.WriteLine($"Parsing XML file: {fileName}");
        }

        //Parse JSON method
        public void ParseJSON(string fileName)
        {
            Console.WriteLine($"Parsing JSON file: {fileName}");
        }

        //Parse CSV method
        public void ParseCSV(string fileName)
        {
            Console.WriteLine($"Parsing CSV file: {fileName}");
        }

        //Delegate for parsing methods
        public delegate void ParsingMethod(string fileName);

        //Parse file method, switch cases for file types
        public Dictionary<string, CityInfo> ParseFile(string fileName, string fileType)
        {
            ParsingMethod parser = null;

            switch (fileType.ToLower())
            {
                case "xml":
                    parser = ParseXML;
                    break;
                case "json":
                    parser = ParseJSON;
                    break;
                case "csv":
                    parser = ParseCSV;
                    break;
                default:
                    throw new ArgumentException("Invalid file type.");
            }

            parser(fileName);

            return new Dictionary<string, CityInfo>();
        }
    }
}
