// See https://aka.ms/new-console-template for more information
using AdvancedC_Project1;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Program functionality");
        Console.WriteLine("---------------------\n");
        Console.WriteLine("- To exit program, enter 'exit' at any prompt");
        Console.WriteLine("- To start program from the begining enter 'restart' at any prompt");
        Console.WriteLine("- You will be presented with a numbered list of options. Please enter a value, when prompted, to a coresponding file name, file type or data querying routine.");
        Console.WriteLine("Fetching list of available file names to be processed and queried...\n");

        Console.WriteLine("1) Canadacities-CSV");
        Console.WriteLine("2) Canadacities-JSON");
        Console.WriteLine("3) Canadacities-XML");

        Console.WriteLine("\nSelect an option from the list above (e.g. 1, 2)");

        int choice = int.Parse(Console.ReadLine());
        string fileType = "";
        string fileName = "";

        switch (choice)
        {
            case 1:
                fileType = "csv";
                fileName = "Canadacities.csv"; 
                break;
            case 2:
                fileType = "json";
                fileName = "Canadacities-JSON.json";
                break;
            case 3:
                fileType = "xml";
                fileName = "Canadacities-XML.xml"; 
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Statistics stats = new Statistics(fileName, fileType);
        //test to see if it works
        //foreach (var city in stats.CityCatalogue)
        //{
        //    CityInfo cityInfo = city.Value; 

        //    Console.WriteLine($"City Name: {cityInfo.CityName}");
        //    Console.WriteLine($"City Ascii: {cityInfo.CityAscii}");
        //    Console.WriteLine($"City ID: {cityInfo.CityID}");
        //    Console.WriteLine($"Population: {cityInfo.GetPopulation()}");
        //    Console.WriteLine($"Province: {cityInfo.GetProvince()}");

        //    double[] location = cityInfo.GetLocation();
        //    Console.WriteLine($"Latitude: {location[0]}");
        //    Console.WriteLine($"Longitude: {location[1]}");

        //}
    }
}


