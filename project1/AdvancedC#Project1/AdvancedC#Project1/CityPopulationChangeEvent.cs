using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace AdvancedC_Project1
{
    public class CityPopulationChangeEvent
    {
             
        // Event declaration
        public event EventHandler<string> PopulationChanged;

        // Method to trigger the event
        public void UpdatePopulation(string cityName, long oldPopulation, long newPopulation, string fileName)
        {
            OnPopulationChanged($"The population of {cityName} will be updated from {oldPopulation} to {newPopulation} in {fileName}.");
        }

        protected virtual void OnPopulationChanged(string message)
        {
            PopulationChanged?.Invoke(this, message);
        }

    }
}