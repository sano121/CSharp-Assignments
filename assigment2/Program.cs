using System;

struct Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

struct Rectangle
{
    private double width;
    private double height;

    public double Width
    {
        get { return width; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Width cannot be negative.");
                return;
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Height cannot be negative.");
                return;
            }
            height = value;
        }
    }

    public double Area => width * height;

    public void DisplayInfo()
    {
        Console.WriteLine($"Width: {Width}, Height: {Height}, Area: {Area}");
    }
}

class BankAccount
{
    private double[] balances = new double[10];

    public string AccountNumber { get; private set; }
    public double Balance { get; private set; }

    public BankAccount(string accountNumber, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public double this[int index]
    {
        get { return balances[index]; }
        set { balances[index] = value; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount}. Remaining balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public bool HasSufficientFunds(double amount)
    {
        return Balance >= amount;
    }

    public void TransferTo(BankAccount target, double amount)
    {
        if (HasSufficientFunds(amount) && amount > 0)
        {
            Balance -= amount;
            target.Balance += amount;
            Console.WriteLine($"Transferred {amount} to {target.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Transfer failed.");
        }
    }

    public void DisplayAccount()
    {
        Console.WriteLine($"Account: {AccountNumber}, Balance: {Balance}");
    }
}

class Student
{
    private int[] grades = new int[5];

    public string Name { get; init; } = "";
    
    private int age;
    public int Age
    {
        get { return age; }
        init
        {
            if (value >= 0)
                age = value;
            else
                age = 0;
        }
    }

    public int this[int index]
    {
        get { return grades[index]; }
        set { grades[index] = value; }
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }

    public int YearsUntilGraduation(int graduationAge = 22)
    {
        return graduationAge - Age;
    }

    public void DisplayStudent()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}, Adult: {IsAdult()}");
    }
}

class Employee
{
    private double employeeSalary;
    private string[] skills = new string[10];

    public double Salary
    {
        get { return employeeSalary; }
        set
        {
            if (value >= 0)
                employeeSalary = value;
            else
                Console.WriteLine("Salary cannot be negative.");
        }
    }

    public string this[int index]
    {
        get { return skills[index]; }
        set { skills[index] = value; }
    }

    public void IncreaseSalary(double amount)
    {
        if (amount > 0)
        {
            employeeSalary += amount;
            Console.WriteLine($"Salary increased by {amount}. New salary: {employeeSalary}");
        }
    }

    public double AnnualSalary()
    {
        return employeeSalary * 12;
    }

    public double ApplyBonus(double percentage)
    {
        return employeeSalary + (employeeSalary * percentage / 100);
    }

    public void DisplayEmployee()
    {
        Console.WriteLine($"Salary: {employeeSalary}, Annual: {AnnualSalary()}");
    }
}

class Car
{
    private System.Collections.Generic.Dictionary<int, double> maintenanceCosts = new System.Collections.Generic.Dictionary<int, double>();

    public string Brand { get; set; } = "Toyota";
    public int Year { get; set; }

    public double this[int year]
    {
        get { return maintenanceCosts.ContainsKey(year) ? maintenanceCosts[year] : 0; }
        set { maintenanceCosts[year] = value; }
    }

    public void UpdateYear(int year)
    {
        if (year >= 1886)
            Year = year;
        else
            Console.WriteLine("Year must be 1886 or later.");
    }

    public int CarAge()
    {
        return DateTime.Now.Year - Year;
    }

    public bool IsClassic()
    {
        return CarAge() > 25;
    }

    public void DisplayCar()
    {
        Console.WriteLine($"Brand: {Brand}, Year: {Year}, Age: {CarAge()}, Classic: {IsClassic()}");
    }
}

class LibraryBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    private LibraryBook[] books = new LibraryBook[5];
    private int bookCount = 0;

    public LibraryBook()
    {
        Title = "";
        Author = "";
        ISBN = "";
        Year = 0;
        IsAvailable = true;
    }

    public LibraryBook(string title, string author, string isbn, int year, bool isAvailable = true)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
        IsAvailable = isAvailable;
    }

    public void AddBook(LibraryBook book)
    {
        if (bookCount < books.Length)
        {
            books[bookCount] = book;
            bookCount++;
            Console.WriteLine($"Book added: {book.Title}");
        }
        else
        {
            Console.WriteLine("Library is full.");
        }
    }

    public void BorrowBook(string isbn)
    {
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].ISBN == isbn)
            {
                if (books[i].IsAvailable)
                {
                    books[i].IsAvailable = false;
                    Console.WriteLine($"Book borrowed: {books[i].Title}");
                    return;
                }
                else
                {
                    Console.WriteLine("Book not available.");
                    return;
                }
            }
        }
        Console.WriteLine("Book not found.");
    }

    public void ReturnBook(string isbn)
    {
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].ISBN == isbn)
            {
                books[i].IsAvailable = true;
                Console.WriteLine($"Book returned: {books[i].Title}");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }

    public void FindBook(string title)
    {
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].Title.ToLower() == title.ToLower())
            {
                Console.WriteLine($"Found: Title: {books[i].Title}, Author: {books[i].Author}, Year: {books[i].Year}");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }

    public void ListAvailableBooks()
    {
        Console.WriteLine("Available Books:");
        bool foundAny = false;
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].IsAvailable)
            {
                Console.WriteLine($"Title: {books[i].Title}, Author: {books[i].Author}, Year: {books[i].Year}");
                foundAny = true;
            }
        }
        if (!foundAny)
            Console.WriteLine("No books available.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Task 1");
        Person[] people = new Person[3];
        people[0] = new Person { Name = "Ali", Age = 20 };
        people[1] = new Person { Name = "Sara", Age = 25 };
        people[2] = new Person { Name = "Omar", Age = 30 };

        foreach (var p in people)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }
    
        Console.WriteLine("Task 2");
        Console.Write("Enter X1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Enter Y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Enter X2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Enter Y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        Console.WriteLine($"Distance between points = {distance}");

        Console.WriteLine("Task 3");
        Person[] persons = new Person[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter name for person {i + 1}: ");
            string name = Console.ReadLine();
            Console.Write($"Enter age for person {i + 1}: ");
            int age = int.Parse(Console.ReadLine());
            persons[i] = new Person { Name = name, Age = age };
        }

        Person oldest = persons[0];
        for (int i = 1; i < persons.Length; i++)
        {
            if (persons[i].Age > oldest.Age)
                oldest = persons[i];
        }
        Console.WriteLine($"Oldest person: {oldest.Name}, Age: {oldest.Age}");

        Console.WriteLine("Task 4");
        Rectangle rect = new Rectangle();
        rect.Width = 10;
        rect.Height = 5;
        rect.DisplayInfo();
        rect.Width = -3;
        rect.Height = 8;
        rect.DisplayInfo();

        Console.WriteLine("Task 5: Bank Account");
        BankAccount acc1 = new BankAccount("ACC001", 1000);
        BankAccount acc2 = new BankAccount("ACC002", 500);
        acc1.Deposit(200);
        acc1.Withdraw(100);
        acc1.TransferTo(acc2, 300);
        acc1.DisplayAccount();
        acc2.DisplayAccount();
        acc1[0] = 1000;
        acc1[1] = 2000;
        Console.WriteLine($"USD: {acc1[0]}, EUR: {acc1[1]}");

        Console.WriteLine("Task 6");
        Student student = new Student { Name = "Arsany", Age = 20 };
        student[0] = 90;
        student[1] = 85;
        student.DisplayStudent();
        Console.WriteLine($"Grade 0: {student[0]}");
        Console.WriteLine($"Years until graduation: {student.YearsUntilGraduation()}");

        Console.WriteLine("Task 7");
        Employee emp = new Employee();
        emp.Salary = 5000;
        emp[0] = "C#";
        emp[1] = "SQL";
        emp.IncreaseSalary(500);
        emp.DisplayEmployee();
        Console.WriteLine($"Skill: {emp[1]}");
        Console.WriteLine($"With 10% bonus: {emp.ApplyBonus(10)}");

        Console.WriteLine(" Task 8");
        Car car = new Car();
        car.UpdateYear(1995);
        car[2020] = 500;
        car[2021] = 600;
        car.DisplayCar();
        Console.WriteLine($"Maintenance 2020: {car[2020]}");

        Console.WriteLine("Task 9");
        LibraryBook library = new LibraryBook();
        library.AddBook(new LibraryBook("C# Basics", "Ali", "001", 2020));
        library.AddBook(new LibraryBook("OOP Principles", "Sara", "002", 2021));
        library.AddBook(new LibraryBook("Advanced C#", "Omar", "003", 2022));
        
        library.BorrowBook("001");
        library.BorrowBook("001");
        library.ReturnBook("001");
        library.ListAvailableBooks();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
