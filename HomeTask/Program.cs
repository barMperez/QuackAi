#region using

using HomeTask.Models;
using HomeTask.Parsers;
using HomeTask.Services;

#endregion

namespace HomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var (jsonContent, maxCreationDate) = GetParameters(args);
                var jsonParser = new JsonParser();
                var ticketObject = jsonParser.ParseJson<TicketObject>(jsonContent);

                var categoryService = new CategoryService();

                if (ticketObject == null || ticketObject.Tickets == null || ticketObject.Tickets.Count == 0)
                    throw new Exception("No tickets found in the JSON file.");

                var categorizedTickets = categoryService.CategorizeTickets(ticketObject.Tickets);
                var expiredTickets = categoryService.GetTicketsBefore(ticketObject.Tickets, maxCreationDate);

                Console.WriteLine("Tickets Categories:");
                Console.WriteLine(categorizedTickets);

                Console.WriteLine("Expired Tickets:");
                Console.WriteLine(expiredTickets);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static (string jsonContent, DateTime maxCreationDate) GetParameters(string[] args)
        {
            try
            {
                if (args.Length != 2)
                    throw new Exception("Usage: dotnet run <path-to-json-file> <max-creation-date:dd-MM-yyyy>");

                var jsonPath = args[0];
                var maxCreationDateStr = args[1];

                if (jsonPath.EndsWith(".json") == false)
                    throw new Exception("File must be a JSON file.");


                if (!File.Exists(jsonPath))
                    throw new Exception($"File not found: {jsonPath}");


                if (!DateTime.TryParse(maxCreationDateStr, out var maxCreationDate))
                    throw new Exception($"Invalid date format: {maxCreationDateStr}");

                var jsonContent = File.ReadAllText(jsonPath);

                if (jsonContent.Length == 0)
                    throw new Exception("File is empty.");

                return (jsonContent, maxCreationDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
