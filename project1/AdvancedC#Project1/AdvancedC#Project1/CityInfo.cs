using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Carl, Cody, Trish, Ethan
 * Date: 2025-02-17
 */

namespace AdvancedC_Project1
{
    public class CityInfo
    {
        //CityInfo variables
        public int CityID { get; }
        public string CityName { get; }
        public string CityAscii { get; }
        private int Population { get; }
        private string Province { get; }
        private double Latitude { get; }
        private double Longitude { get; }


        //constructor
        public CityInfo(int cityID, string cityName, string cityAscii, int population, string province, double latitude, double longitude)
        {
            this.CityID = cityID;
            this.CityName = cityName;
            this.CityAscii = cityAscii;
            this.Population = population;
            this.Province = province;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }


        public string GetProvince()
        {
            return this.Province;
        }

        public int GetPopulation()
        {
            return this.Population;
        }

        public double[] GetLocation()
        {
            return new double[] { this.Latitude, this.Longitude };
        }
    }
}
