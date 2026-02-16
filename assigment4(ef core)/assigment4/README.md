# EF Core Airline Management Assignment

This project demonstrates **Eager Loading** and **Join Operators** in Entity Framework Core 9.0 targeting .NET 9.

## Project Structure

### Models
- **Airline**: Main entity representing airlines with navigation properties to Aircrafts, Employees, Transactions, and Phones
- **Aircraft**: Represents aircraft with relationship to Airline and Routes
- **Route**: Flight routes assigned to specific aircraft
- **Employee**: Airline employees with their qualifications
- **Qualification**: Employee certifications and skills
- **Transaction**: Financial transactions for airlines
- **Phone**: Contact phone numbers for airlines

### Database Context
- **AirlineDbContext**: Configures relationships and seeds initial data
- Uses SQL Server LocalDB for development
- Database: `AirlineDb`

## Section A: Eager Loading Queries

### 1. EgyptAir with Aircrafts and Routes
```csharp
var egyptAir = context.Airlines
    .Include(a => a.Aircrafts)
        .ThenInclude(ac => ac.Routes)
    .FirstOrDefault(a => a.Name == "EgyptAir");
```
Loads EgyptAir airline with all its aircraft and each aircraft's routes using nested Include.

### 2. Airlines with Employees and Qualifications
```csharp
var airlinesWithEmployees = context.Airlines
    .Include(a => a.Employees)
        .ThenInclude(e => e.Qualifications)
    .ToList();
```
Loads all airlines with their employees and each employee's qualifications.

### 3. Airlines with Filtered Transactions (Amount > 10000)
```csharp
var airlinesWithTransactions = context.Airlines
    .Include(a => a.Transactions.Where(t => t.Amount > 10000))
    .ToList();
```
Loads all airlines but only includes transactions where Amount exceeds 10,000 using filtered Include.

### 4. Routes with Aircraft Models
```csharp
var routesWithAircraft = context.Routes
    .Include(r => r.Aircraft)
    .ToList();
```
Loads all routes with their assigned aircraft information.

### 5. Aircrafts with Airline and Phones
```csharp
var aircraftsWithAirlinePhones = context.Aircrafts
    .Include(ac => ac.Airline)
        .ThenInclude(a => a.Phones)
    .ToList();
```
Loads all aircraft with their owning airline and the airline's phone numbers.

## Section B: Join Operators

### 1. Employees with Airline Names
```csharp
var employeesWithAirline = from employee in context.Employees
                          join airline in context.Airlines
                          on employee.AirlineId equals airline.Id
                          select new { ... };
```
Lists all employees with their airline name using LINQ join.

### 2. Routes with Aircraft and Airline
```csharp
var routesWithAircraftAndAirline = from route in context.Routes
                                   join aircraft in context.Aircrafts
                                   on route.AircraftId equals aircraft.Id
                                   join airline in context.Airlines
                                   on aircraft.AirlineId equals airline.Id
                                   select new { ... };
```
Shows routes with aircraft model and owning airline using multiple joins.

### 3. Airlines with Aircraft Models
```csharp
var airlinesWithAircraftModels = from airline in context.Airlines
                                join aircraft in context.Aircrafts
                                on airline.Id equals aircraft.AirlineId
                                select new { ... };
```
Groups aircraft models by airline.

### 4. Filtered Transactions with Airlines (Amount > 20000)
```csharp
var transactionsWithAirline = from transaction in context.Transactions
                             join airline in context.Airlines
                             on transaction.AirlineId equals airline.Id
                             where transaction.Amount > 20000
                             select new { ... };
```
Shows high-value transactions (>20,000) with airline information.

## Running the Project

1. Ensure SQL Server LocalDB is installed
2. Run the project: `dotnet run`
3. The database will be automatically created and seeded with sample data
4. All queries will execute and display results in the console

## Sample Data Included

- 3 Airlines: EgyptAir, Emirates, Lufthansa
- 6 Aircraft models across airlines
- 6 Flight routes
- 5 Employees with various positions
- 8 Qualifications for employees
- 7 Financial transactions
- 4 Phone numbers for airlines

## Technologies Used

- .NET 9.0
- Entity Framework Core 9.0
- SQL Server LocalDB
- C# 13.0
