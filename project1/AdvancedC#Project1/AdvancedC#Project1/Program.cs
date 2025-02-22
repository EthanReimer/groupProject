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
        Console.WriteLine("- To start program from the beginning, enter ‘restart’ at any prompt");
        Console.WriteLine("- You will be presented with a numbered list of options. Please enter a value, when prompted, to a corresponding file name, file type or data querying routine.");
        Console.WriteLine("Fetching list of available file names to be processed and queried...\n");

        Console.WriteLine("1) Canadacities-CSV");
        Console.WriteLine("2) Canadacities-JSON");
        Console.WriteLine("3) Canadacities-XML");

        Console.Write("\nSelect an option from the list above (e.g. 1, 2): ");

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

        // Stage 2
        Console.WriteLine($"\nA city catalogue has now been populated from the {fileName} file.");
        Console.WriteLine("\nFetching list of available data querying routines that can be run on the " + fileName + " file.\n");
        DisplayQueryOptions(fileName);
        int queryChoice = int.Parse(Console.ReadLine());


        Statistics stats = new Statistics(fileName, fileType);
        switch (queryChoice)
        {
            case 1:
                Console.Write("\nEnter city name to display information: ");
                string cityName = Console.ReadLine();
                stats.DisplayCityInformation(cityName);
                break;
            case 2:
                Console.Write("\nEnter province name to display cities: ");
                string province1 = Console.ReadLine();
                stats.DisplayProvinceCities(province1);
                break;
            case 3:
                Console.Write("\nEnter province name to calculate population: ");
                string province2 = Console.ReadLine();
                stats.DisplayProvincePopulation(province2);
                break;
            case 4:
                Console.Write("\nEnter two city names, separated by a comma, to see which city has the larger population (e.g. London, Toronto): ");
                string[] cities = Console.ReadLine().Split(',');
                if (cities.Length == 2)
                {
                    stats.CompareCitiesPopulations(cities[0].Trim(), cities[1].Trim());
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter two city names.");
                }
                break;
            case 5:
                Console.Write("\nEnter two city names, separated by a comma, to calculate distance (e.g. London, Toronto): ");
                string[] distanceCities = Console.ReadLine().Split(',');
                if (distanceCities.Length == 2)
                {
                    stats.CalculateDistanceBetweenCities(distanceCities[0].Trim(), distanceCities[1].Trim());
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter two city names.");
                }
                break;
            case 6:
                Console.WriteLine("Restarting program...");
                Main(args);
                return;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }


        // Method to display query options based on file name
        static void DisplayQueryOptions(string fileName)
        {
            Console.WriteLine("1) Display City Information");
            Console.WriteLine("2) Display Province Countries");
            Console.WriteLine("3) Calculate Province Population");
            Console.WriteLine("4) Match Cities Population");
            Console.WriteLine("5) Distance Between Cities");
            Console.WriteLine("6) Restart Program And Choose Another File Or File Type To Query");
            Console.Write($"\nSelect a data query routine from the list above for the {fileName} file (e.g. 1,2): ");
        }
    }
}


