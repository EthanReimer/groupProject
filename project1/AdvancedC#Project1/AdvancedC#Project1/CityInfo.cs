using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public CityInfo(int id, string CN, string CA, int POP, string P, double Lat, double Lon)
        {
            this.CityID = id;
            this.CityName = CN;
            this.CityAscii = CA;
            this.Population = POP;
            this.Province = P;
            this.Latitude = Lat;
            this.Longitude = Lon;
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
