using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_Project1
{
    public class Statistics
    {
        //Properties
        public Dictionary<string, CityInfo> CityCatalogue { get; set; }

        //Constructor that takes in a file name and file type and parses the file
        public Statistics(string fileName, string fileType)
        {
            DataModeler dataModeler = new DataModeler();
            CityCatalogue = dataModeler.ParseFile(fileName, fileType);
        }

        //***City Methods***
        public void DisplayCityInformation(string cityName) 
        {
            
        }

        public void DisplayLargestPopulationCity() 
        {

        }

        public void DisplaySmallestPopulationCity()
        {

        }

        public void CompareCitiesPopulation() 
        {

        }

        public void ShowCityOnMap() 
        {

        }

        public void CalculateDistanceBetweenCities()
        {

        }

        //***Province Methods***
        public void DisplayProvincePopulation(string provinceName)
        {

        }

        public void DisplayProvinceCities(string provinceName)
        {

        }

        public void RankProvincesByPopulation()
        {

        }

        public void RankProvincesByCities() 
        {

        }
    }
}
