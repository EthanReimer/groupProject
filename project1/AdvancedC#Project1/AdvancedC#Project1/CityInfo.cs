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
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityAscii { get; set; }
        private int Population { get; set; }
        private string Province { get; set; }
        private double Latitude { get; set; }
        private double Longitude { get; set; }


        //constructor
        public CityInfo(int id, string CN, string CA, int POP, string P, double Lat, double Lon )
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
