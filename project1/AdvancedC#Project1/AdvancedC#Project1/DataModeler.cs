using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace AdvancedC_Project1
{
    public class DataModeler
    {
        //Parse XML method
        public Dictionary<string, CityInfo> ParseXML(string fileName)
        {
            Dictionary<string, CityInfo> cityCatalogue = new Dictionary<string, CityInfo>();
            XmlDocument doc = new XmlDocument();

            doc.Load(Path.Combine("data", fileName));
            XmlNodeList cityNodes = doc.SelectNodes("//CanadaCity");

            foreach (XmlNode cityNode in cityNodes)
            {
                string? cityName = cityNode.SelectSingleNode("city")?.InnerText;
                string? cityAscii = cityNode.SelectSingleNode("city_ascii")?.InnerText;
                double latitude = double.Parse(cityNode.SelectSingleNode("lat")?.InnerText);
                double longitude = double.Parse(cityNode.SelectSingleNode("lng")?.InnerText);
                int population = int.Parse(cityNode.SelectSingleNode("population")?.InnerText);
                int cityID = int.Parse(cityNode.SelectSingleNode("id")?.InnerText);
                string? province = cityNode.SelectSingleNode("admin_name")?.InnerText;

                CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude);

                cityCatalogue[cityName] = cityInfo;
            }
            return cityCatalogue;
        }

        //Parse JSON method
        public Dictionary<string, CityInfo> ParseJSON(string fileName)
        {
            //Read the JSON file from the data folder
            string filePath = Path.Combine("data", fileName);
            string jsonContent = File.ReadAllText(filePath);

            var citiesData = JsonConvert.DeserializeObject<List<dynamic>>(jsonContent);

            //Create a dictionary to hold CityInfo objects
            Dictionary<string, CityInfo> cityCatalogue = new Dictionary<string, CityInfo>();

            //Populate the dictionary
            foreach (var cityData in citiesData)
            {
                string cityName = cityData.city;
                string cityAscii = cityData.city_ascii;
                double? latitudeNull = cityData.lat;
                double? longitudeNull = cityData.lng;
                string province = cityData.admin_name;
                int? populationNull = cityData.population;
                int? cityIDNull = cityData.id;

                //Gives a default value of 0 if the value is null
                /*Unhandled exception. Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
                Cannot convert null to 'int'(also double) because it is a non-nullable value type*/
                double latitude = latitudeNull ?? 0.0; 
                double longitude = longitudeNull ?? 0.0;
                int population = populationNull ?? 0;
                int cityID = cityIDNull ?? 0; 

                CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude);

                //Add to the dictionary
                cityCatalogue[cityName] = cityInfo;
            }

            return cityCatalogue;
        }

        //Parse CSV method
        public Dictionary<string, CityInfo> ParseCSV(string fileName)
        {
            Dictionary<string, CityInfo> cityCatalogue = new Dictionary<string, CityInfo>();
            using (StreamReader reader = new StreamReader(Path.Combine("data", fileName)))
            {
                string headerLine = reader.ReadLine(); // Read the header
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(','); // Split by comma

                    string cityName = fields[0].Trim();
                    string cityAscii = fields[1].Trim();
                    double latitude = double.Parse(fields[2].Trim());
                    double longitude = double.Parse(fields[3].Trim());
                    string province = fields[5].Trim();
                    int population = int.TryParse(fields[7].Trim(), out int pop) ? pop : 0;
                    int cityID = int.Parse(fields[8].Trim());

                    CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude);
                    cityCatalogue[cityName] = cityInfo;
                }
            }
            return cityCatalogue;
        }

        //Delegate for parsing methods
        public delegate Dictionary<string, CityInfo> ParsingMethod(string fileName);

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

            return parser(fileName);
        }
    }
}
