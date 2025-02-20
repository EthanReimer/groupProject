using Newtonsoft.Json;
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
        public void ParseCSV(string fileName)
        {
            Console.WriteLine($"Parsing CSV file: {fileName}");
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
                    break;
                case "json":
                    parser = ParseJSON;
                    break;
                case "csv":
                    break;
                default:
                    throw new ArgumentException("Invalid file type.");
            }

            return parser(fileName);
        }
    }
}
