using Microsoft.EntityFrameworkCore;
using assigment4.Data;
using assigment4.Models;

namespace assigment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AirlineDbContext())
            {
                context.Database.EnsureCreated();


                Console.WriteLine("1. EgyptAir with all aircrafts and routes:");
                Console.WriteLine(new string('-', 60));
                
                var egyptAir = context.Airlines
                    .Include(a => a.Aircrafts)
                        .ThenInclude(ac => ac.Routes)
                    .FirstOrDefault(a => a.Name == "EgyptAir");

                if (egyptAir != null)
                {
                    Console.WriteLine($"Airline: {egyptAir.Name} ({egyptAir.Country})");
                    foreach (var aircraft in egyptAir.Aircrafts)
                    {
                        Console.WriteLine($"  Aircraft: {aircraft.Model} (Capacity: {aircraft.Capacity})");
                        foreach (var route in aircraft.Routes)
                        {
                            Console.WriteLine($"    Route: {route.Origin} -> {route.Destination} ({route.Distance} km)");
                        }
                    }
                }
                Console.WriteLine();

                Console.WriteLine("2. All airlines with employees and their qualifications:");
                Console.WriteLine(new string('-', 60));
                
                var airlinesWithEmployees = context.Airlines
                    .Include(a => a.Employees)
                        .ThenInclude(e => e.Qualifications)
                    .ToList();

                foreach (var airline in airlinesWithEmployees)
                {
                    Console.WriteLine($"Airline: {airline.Name}");
                    foreach (var employee in airline.Employees)
                    {
                        Console.WriteLine($"  Employee: {employee.Name} - {employee.Position}");
                        foreach (var qualification in employee.Qualifications)
                        {
                            Console.WriteLine($"    Qualification: {qualification.Name} ({qualification.Level})");
                        }
                    }
                }
                Console.WriteLine();

                Console.WriteLine("3. All airlines with transactions (Amount > 10000):");
                Console.WriteLine(new string('-', 60));
                
                var airlinesWithTransactions = context.Airlines
                    .Include(a => a.Transactions.Where(t => t.Amount > 10000))
                    .ToList();

                foreach (var airline in airlinesWithTransactions)
                {
                    Console.WriteLine($"Airline: {airline.Name}");
                    if (airline.Transactions.Any())
                    {
                        foreach (var transaction in airline.Transactions)
                        {
                            Console.WriteLine($"  Transaction ID: {transaction.Id}, Amount: {transaction.Amount:C}, Description: {transaction.Description}, Date: {transaction.Date:yyyy-MM-dd}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  No transactions > 10000");
                    }
                }
                Console.WriteLine();

                Console.WriteLine("4. All routes with aircraft models:");
                Console.WriteLine(new string('-', 60));
                
                var routesWithAircraft = context.Routes
                    .Include(r => r.Aircraft)
                    .ToList();

                foreach (var route in routesWithAircraft)
                {
                    Console.WriteLine($"Route: {route.Origin} -> {route.Destination} | Aircraft: {route.Aircraft.Model}");
                }
                Console.WriteLine();

                Console.WriteLine("5. All aircrafts with airline and phones:");
                Console.WriteLine(new string('-', 60));
                
                var aircraftsWithAirlinePhones = context.Aircrafts
                    .Include(ac => ac.Airline)
                        .ThenInclude(a => a.Phones)
                    .ToList();

                foreach (var aircraft in aircraftsWithAirlinePhones)
                {
                    Console.WriteLine($"Aircraft: {aircraft.Model} | Airline: {aircraft.Airline.Name}");
                    foreach (var phone in aircraft.Airline.Phones)
                    {
                        Console.WriteLine($"  Phone: {phone.Number} ({phone.Type})");
                    }
                }
                Console.WriteLine();


                Console.WriteLine("1. All employees with airline name:");
                Console.WriteLine(new string('-', 60));
                
                var employeesWithAirline = from employee in context.Employees
                                          join airline in context.Airlines
                                          on employee.AirlineId equals airline.Id
                                          select new
                                          {
                                              EmployeeName = employee.Name,
                                              Position = employee.Position,
                                              AirlineName = airline.Name
                                          };

                foreach (var item in employeesWithAirline)
                {
                    Console.WriteLine($"{item.EmployeeName} - {item.Position} | Airline: {item.AirlineName}");
                }
                Console.WriteLine();

                Console.WriteLine("2. All routes with aircraft model and airline:");
                Console.WriteLine(new string('-', 60));
                
                var routesWithAircraftAndAirline = from route in context.Routes
                                                   join aircraft in context.Aircrafts
                                                   on route.AircraftId equals aircraft.Id
                                                   join airline in context.Airlines
                                                   on aircraft.AirlineId equals airline.Id
                                                   select new
                                                   {
                                                       RouteOrigin = route.Origin,
                                                       RouteDestination = route.Destination,
                                                       AircraftModel = aircraft.Model,
                                                       AirlineName = airline.Name
                                                   };

                foreach (var item in routesWithAircraftAndAirline)
                {
                    Console.WriteLine($"Route: {item.RouteOrigin} -> {item.RouteDestination} | Aircraft: {item.AircraftModel} | Airline: {item.AirlineName}");
                }
                Console.WriteLine();

                Console.WriteLine("3. Each airline with its aircraft models:");
                Console.WriteLine(new string('-', 60));
                
                var airlinesWithAircraftModels = from airline in context.Airlines
                                                join aircraft in context.Aircrafts
                                                on airline.Id equals aircraft.AirlineId
                                                select new
                                                {
                                                    AirlineName = airline.Name,
                                                    AircraftModel = aircraft.Model
                                                };

                var groupedAirlines = airlinesWithAircraftModels.ToList().GroupBy(x => x.AirlineName);
                foreach (var group in groupedAirlines)
                {
                    Console.WriteLine($"Airline: {group.Key}");
                    foreach (var item in group)
                    {
                        Console.WriteLine($"  - {item.AircraftModel}");
                    }
                }
                Console.WriteLine();

                Console.WriteLine("4. Transactions (Amount > 20000) with airline name:");
                Console.WriteLine(new string('-', 60));
                
                var transactionsWithAirline = from transaction in context.Transactions
                                             join airline in context.Airlines
                                             on transaction.AirlineId equals airline.Id
                                             where transaction.Amount > 20000
                                             select new
                                             {
                                                 TransactionId = transaction.Id,
                                                 Amount = transaction.Amount,
                                                 Description = transaction.Description,
                                                 AirlineName = airline.Name
                                             };

                foreach (var item in transactionsWithAirline)
                {
                    Console.WriteLine($"Transaction ID: {item.TransactionId} | Amount: {item.Amount:C} | Description: {item.Description} | Airline: {item.AirlineName}");
                }
                Console.WriteLine();

            }
        }
    }
}
