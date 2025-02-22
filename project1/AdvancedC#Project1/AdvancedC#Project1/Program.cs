using AdvancedC_Project1;
using System;

// TO DO:
// 2) Make sure everything works.
// 3) Work on the infinite loop! Remember that the user can enter 'exit' or 'restart' at any prompt, so string choice, THEN int.TryParse
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
        CityPopulationChangeEvent populationEvent = new CityPopulationChangeEvent();
        populationEvent.PopulationChanged += (sender, message) => Console.WriteLine(message);
        switch (queryChoice)
        {
            case 1:
                Console.Write("\nEnter city name to display information: ");
                stats.DisplayCityInformation(Console.ReadLine());
                break;
            case 2:
                Console.Write("\nEnter province name to display cities: ");
                stats.DisplayProvinceCities(Console.ReadLine());
                break;
            case 3:
                Console.Write("\nEnter province name to calculate population: ");
                stats.DisplayProvincePopulation(Console.ReadLine());
                break;
            case 4:
                Console.Write("\nEnter two city names, separated by a comma, to compare populations: ");
                var cities = Console.ReadLine().Split(',');
                if (cities.Length == 2) stats.CompareCitiesPopulations(cities[0].Trim(), cities[1].Trim());
                else Console.WriteLine("Invalid input.");
                break;
            case 5:
                Console.Write("\nEnter two city names, separated by a comma, to calculate distance: ");
                var distanceCities = Console.ReadLine().Split(',');
                if (distanceCities.Length == 2) stats.CalculateDistanceBetweenCities(distanceCities[0].Trim(), distanceCities[1].Trim());
                else Console.WriteLine("Invalid input.");
                break;
            case 6:
                Console.Write("\nEnter city and province to show on map (e.g. Toronto, Ontario): ");
                var location = Console.ReadLine().Split(',');
                if (location.Length == 2) stats.ShowCityOnMap(location[0].Trim(), location[1].Trim());
                else Console.WriteLine("Invalid input.");
                break;
            case 7:
                Console.Write("\nEnter province name to display the smallest population city: ");
                stats.DisplaySmallestPopulationCity(Console.ReadLine());
                break;
            case 8:
                Console.Write("\nEnter province name to display the largest population city: ");
                stats.DisplayLargestPopulationCity(Console.ReadLine());
                break;
            case 9:
                stats.RankProvincesByPopulation();
                break;
            case 10:
                stats.RankProvincesByCities();
                break;
            case 11:
                Console.Write("\nEnter province name to get its capital: ");
                stats.GetCapital(Console.ReadLine());
                break;
            // Not so sure about this one
            case 12:
                Console.Write("\nEnter city name to update population: ");
                string cityName = Console.ReadLine();
                Console.Write("Enter new population: ");
                if (long.TryParse(Console.ReadLine(), out long newPopulation))
                {
                    var city = stats.CityCatalogue.ContainsKey(cityName) ? stats.CityCatalogue[cityName] : null;
                    if (city != null)
                    {
                        long oldPopulation = city.GetPopulation();
                        populationEvent.UpdatePopulation(cityName, oldPopulation, newPopulation, fileName);
                    }
                    else
                    {
                        Console.WriteLine("City not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid population input.");
                }
                break;
            case 13:
                Console.WriteLine("Restarting program...");
                Main(args);
                return;
            default:
                Console.WriteLine("Invalid choice.");
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
            Console.WriteLine("6) Show City on Map");
            Console.WriteLine("7) Display Smallest Population City");
            Console.WriteLine("8) Display Largest Population City");
            Console.WriteLine("9) Rank Provinces by Population");
            Console.WriteLine("10) Rank Provinces by Number of Cities");
            Console.WriteLine("11) Get Capital of a Province");
            Console.WriteLine("12) Update City Population");
            Console.WriteLine("13) Restart Program And Choose Another File Or File Type To Query");
            Console.Write($"\nSelect a data query routine from the list above for the {fileName} file (e.g. 1,2): ");
        }

    }
}


