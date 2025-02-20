using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_Project1
{
    public class Statistics
    {
        public Dictionary<String, CityInfo> CityCatalogue = new Dictionary<String, CityInfo>();

        //constructor
        public Statistics(string fileName, string fileType)
        {
            DataModeler dm = new DataModeler();

            CityCatalogue = dm.ParseFile(fileName, fileType);
        }


        //displays all cities with a given name
        public void DisplayCityInformation(string CityName)
        {
            bool foundCity = false;


            foreach (var city in CityCatalogue)
            {
                if (city.Key == CityName)
                {
                    CityInfo cityOutput = city.Value;
                   
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"City ID: {cityOutput.CityID}\n" +
                                      $"City name and province: {cityOutput.CityName}, {cityOutput.GetProvince()}\n" +
                                      $"City Location: {cityOutput.GetLocation()}\n" +
                                      $"City Population: {cityOutput.GetPopulation()}\n" +
                                      $"City Ascii: {cityOutput.CityAscii}");
                
                    foundCity = true;
                }
            }

            if (!foundCity)
            {
                Console.WriteLine($"no cities by the name {CityName} are in our data.");
            }
        }


        //displays the name and population of the city with the highest population in a province
        public void DisplayLargestPopulationCity(string province)
        {
            bool foundProvince = false;
            int cityID = -1;
            int highestPop = 0;

            foreach (var city in CityCatalogue)
            {
                if(city.Value.GetProvince() == province)
                {
                    if(city.Value.GetPopulation() > highestPop)
                    {
                        highestPop = city.Value.GetPopulation();
                        cityID = city.Value.CityID;
                    }
                    foundProvince = true;
                }
            }

            if (!foundProvince)
            {
                Console.WriteLine($"no province by the name {province} exists in our data.");
            }
            else
            {
                foreach (var city in CityCatalogue)
                {
                    if (city.Value.CityID == cityID)
                    {
                        Console.WriteLine($"city with largest popultion in {city.Value.GetProvince()}: {city.Value.CityName} {city.Value.CityName} popualtion: {city.Value.GetPopulation()}");
                        break;
                    }
                }
            }
        }
       
        //displays the name and population of the city with the lowest population in a province
        public void DisplaySmallestPopulationCity(string province)
        {
            bool foundProvince = false;
            bool temp = false;
            int cityID = -1;
            int lowestPop = 0;

            foreach (var city in CityCatalogue)
            {
                if (city.Value.GetProvince() == province)
                {
                    //getting a baseline value
                    if(!temp)
                    {
                        lowestPop = city.Value.GetPopulation();
                        temp = true;
                    }

                    if (city.Value.GetPopulation() < lowestPop)
                    {
                        lowestPop = city.Value.GetPopulation();
                        cityID = city.Value.CityID;
                    }
                    foundProvince = true;
                }
            }

            if (!foundProvince)
            {
                Console.WriteLine($"no province by the name {province} exists in our data.");
            }
            else
            {
                foreach (var city in CityCatalogue)
                {
                    if (city.Value.CityID == cityID)
                    {
                        Console.WriteLine($"city with lowest popultion in {city.Value.GetProvince()}: {city.Value.CityName} popualtion: {city.Value.GetPopulation()}");
                        break;
                    }
                }
            }
        }

        public void CompareCitiesPopulations(string city1, string city2)
        {
            int popCity1 = 0;
            int popCity2 = 0;
            bool foundCity1 = false;
            bool foundCity2 = false;

            foreach (var city in CityCatalogue)
            {
                if(city.Key == city1)
                {
                    popCity1 = city.Value.GetPopulation();
                    foundCity1 = true;
                }
                else if (city.Key == city2)
                {
                    popCity2 = city.Value.GetPopulation();
                    foundCity2 = true;
                }

                if (foundCity1 && foundCity2)
                    break;
            }

            if(popCity1 > popCity2) 
                Console.WriteLine($"{city1}'s population of {popCity1} is greater than {city2}'s population of {popCity2}");
            else
                Console.WriteLine($"{city2}'s population of {popCity2} is greater than {city1}'s population of {popCity1}");

        }

        //will take the input, validate it has actual data, then print a url to the console that when clicked,
        //will show the location on a map
        public void ShowCityOnMap(string city, string province)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(province))
            {
                Console.WriteLine("Invalid city or province.");
                return;
            }

            // Create a URL for Google Maps
            string query = Uri.EscapeDataString($"{city}, {province}");
            string googleMapsUrl = $"https://www.google.com/maps/search/?api=1&query={query}";

            Console.WriteLine($"Opening map for: {city}, {province}");
            Console.WriteLine($"URL: {googleMapsUrl}");

            // Open the URL in the default web browser
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = googleMapsUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            { Console.WriteLine($"Error opening map: {ex.Message}"); }
        }

        public void CalculateDistanceBetweenCities(string city1, string city2)
        {

        }




    }
}
