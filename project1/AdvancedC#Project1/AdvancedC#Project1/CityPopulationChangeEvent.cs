using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace AdvancedC_Project1
{
    public class CityPopulationChangeEvent
    {
        /*         
        // Event declaration
        public event EventHandler<string> PopulationChanged;

        // Method to trigger the event
        public void UpdatePopulation(string cityName, long oldPopulation, long newPopulation, string fileType)
        {
            OnPopulationChanged($"City: {cityName}, Old Population: {oldPopulation}, New Population: {newPopulation}, File Type: {fileType}");
        }

        protected virtual void OnPopulationChanged(string message)
        {
            PopulationChanged?.Invoke(this, message);
        }
         */


        // Event declaration
        public event EventHandler<string> PopulationChanged;

        // Method to trigger the event and write to the selected file type
        public void UpdatePopulation(Dictionary<string, CityInfo> cityCatalogue, string cityName, int newPopulation, string fileName, string fileType)
        {
            try
            {
                CityInfo cityInfo = cityCatalogue[cityName];
                int oldPopulation = cityInfo.GetPopulation();

                // Construct the message
                string message = $"City: {cityName}, Old Population: {oldPopulation}, New Population: {newPopulation}, File Type: {fileType}";

                // Write to the selected file type
                WriteToFile(cityCatalogue, fileName, fileType);

                // Trigger the event
                OnPopulationChanged(message);
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("City not found in the catalogue.");
            }

        }

        protected virtual void OnPopulationChanged(string message)
        {
            PopulationChanged?.Invoke(this, message);
        }

        private void WriteToFile(Dictionary<string, CityInfo> cityCatalogue, string fileName, string fileType)
        {
            string filePath = Path.Combine("data", fileName);

            switch (fileType.ToLower())
            {
                case "csv":
                    WriteToCsvFile(cityCatalogue, filePath);
                    break;
                case "json":
                    WriteToJsonFile(cityCatalogue, filePath);
                    break;
                case "xml":
                    WriteToXmlFile(cityCatalogue, filePath);
                    break;
                default:
                    throw new ArgumentException("Invalid file type. Supported types: CSV, JSON, XML.");
            }
        }

        private void WriteToCsvFile(Dictionary<string, CityInfo> cityCatalogue, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("city,city_ascii,lat,lng,admin_name,population,id");
                foreach (var city in cityCatalogue.Values)
                {
                    writer.WriteLine($"{city.CityName},{city.CityAscii},{city.GetLocation()[0]},{city.GetLocation()[1]},{city.GetProvince()},{city.GetPopulation()},{city.CityID}");
                }
            }
        }

        private void WriteToJsonFile(Dictionary<string, CityInfo> cityCatalogue, string filePath)
        {
            var citiesData = cityCatalogue.Values.Select(city => new
            {
                city = city.CityName,
                city_ascii = city.CityAscii,
                lat = city.GetLocation()[0],
                lng = city.GetLocation()[1],
                admin_name = city.GetProvince(),
                population = city.GetPopulation(),
                id = city.CityID
            }).ToList();

            string json = JsonConvert.SerializeObject(citiesData, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void WriteToXmlFile(Dictionary<string, CityInfo> cityCatalogue, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("CanadaCities");
            doc.AppendChild(root);

            foreach (var city in cityCatalogue.Values)
            {
                XmlElement cityNode = doc.CreateElement("CanadaCity");

                AddXmlNode(doc, cityNode, "city", city.CityName);
                AddXmlNode(doc, cityNode, "city_ascii", city.CityAscii);
                AddXmlNode(doc, cityNode, "lat", city.GetLocation()[0].ToString());
                AddXmlNode(doc, cityNode, "lng", city.GetLocation()[1].ToString());
                AddXmlNode(doc, cityNode, "admin_name", city.GetProvince());
                AddXmlNode(doc, cityNode, "population", city.GetPopulation().ToString());
                AddXmlNode(doc, cityNode, "id", city.CityID.ToString());

                root.AppendChild(cityNode);
            }

            doc.Save(filePath);
        }

        private void AddXmlNode(XmlDocument doc, XmlElement parent, string name, string value)
        {
            XmlElement node = doc.CreateElement(name);
            node.InnerText = value;
            parent.AppendChild(node);
        }
    }
}