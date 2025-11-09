using System;

enum Gender
{
    M,
    F
}

enum SecurityLevel
{
    Guest,
    Developer,
    Secretary,
    DBA
}

class HiringDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public HiringDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day:D2}/{Month:D2}/{Year}";
    }
}

class Employee
{
    private int id;
    private string name;
    private SecurityLevel securityLevel;
    private decimal salary;
    private HiringDate hireDate;
    private Gender gender;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value ?? ""; }
    }

    public SecurityLevel SecurityLevel
    {
        get { return securityLevel; }
        set { securityLevel = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value >= 0 ? value : 0; }
    }

    public HiringDate HireDate
    {
        get { return hireDate; }
        set { hireDate = value; }
    }

    public Gender Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public Employee()
    {
        name = "";
        hireDate = new HiringDate(1, 1, 2000);
    }

    public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HiringDate hireDate, Gender gender)
    {
        this.id = id;
        this.name = name;
        this.securityLevel = securityLevel;
        this.salary = salary >= 0 ? salary : 0;
        this.hireDate = hireDate;
        this.gender = gender;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Security: {SecurityLevel}, Salary: {string.Format("{0:C}", Salary)}, Hire Date: {HireDate}, Gender: {Gender}";
    }
}

class Appliance
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public double PowerUsage { get; set; }

    public Appliance(string brand, string model, double powerUsage)
    {
        if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Brand and Model cannot be empty");
        }
        if (powerUsage <= 0)
        {
            throw new ArgumentException("PowerUsage must be greater than 0");
        }

        Brand = brand;
        Model = model;
        PowerUsage = powerUsage;
    }



    public void TurnOn()
    {
        Console.WriteLine($"Appliance {Brand} {Model} is now ON");
    }

    public void TurnOff()
    {
        Console.WriteLine($"Appliance {Brand} {Model} is now OFF");
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Model: {Model}, Power: {PowerUsage}W");
    }
}

class WashingMachine : Appliance
{
    private double capacity;
    private int spinSpeed;

    public double Capacity
    {
        get { return capacity; }
        set { capacity = value > 0 ? value : 1; }
    }

    public int SpinSpeed
    {
        get { return spinSpeed; }
        set { spinSpeed = value > 0 ? value : 100; }
    }

    public bool HasDryer { get; set; }

    public WashingMachine(string brand, string model, double powerUsage, double capacity, int spinSpeed, bool hasDryer)
        : base(brand, model, powerUsage)
    {
        Capacity = capacity;
        SpinSpeed = spinSpeed;
        HasDryer = hasDryer;
    }


    public void StartWash()
    {
        Console.WriteLine($"Started washing with capacity {Capacity} kg");
    }

    public void Rinse()
    {
        Console.WriteLine("Rinsing clothes");
    }

    public void Spin()
    {
        if (SpinSpeed > 0)
        {
            Console.WriteLine($"Spinning at {SpinSpeed} rpm");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Capacity: {Capacity} kg, Spin: {SpinSpeed} rpm, Dryer: {HasDryer}");
    }
}

class Refrigerator : Appliance
{
    private double volume;
    private int temperature;

    public double Volume
    {
        get { return volume; }
        set { volume = value > 0 ? value : 100; }
    }

    public bool HasFreezer { get; set; }

    public int Temperature
    {
        get { return temperature; }
        set
        {
            if (value >= -5 && value <= 10)
                temperature = value;
        }
    }

    public Refrigerator(string brand, string model, double powerUsage, double volume, bool hasFreezer, int temperature)
        : base(brand, model, powerUsage)
    {
        Volume = volume;
        HasFreezer = hasFreezer;
        Temperature = temperature;
    }


    public void Cool()
    {
        if (Temperature <= 10)
        {
            Console.WriteLine($"Cooling to {Temperature}°C");
        }
    }

    public void Defrost()
    {
        Console.WriteLine("Defrosting...");
    }

    public void SetTemperature(int temp)
    {
        if (temp >= -5 && temp <= 10)
        {
            Temperature = temp;
            Console.WriteLine($"Temperature set to {temp}°C");
        }
        else
        {
            Console.WriteLine("Invalid temperature");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Volume: {Volume}L, Freezer: {HasFreezer}, Temp: {Temperature}°C");
    }
}

class Microwave : Appliance
{
    private int wattage;
    private int timer;

    public int Wattage
    {
        get { return wattage; }
        set { wattage = value > 0 ? value : 800; }
    }

    public bool HasGrill { get; set; }

    public int Timer
    {
        get { return timer; }
        set { timer = value >= 0 ? value : 0; }
    }

    public Microwave(string brand, string model, double powerUsage, int wattage, bool hasGrill, int timer)
        : base(brand, model, powerUsage)
    {
        Wattage = wattage;
        HasGrill = hasGrill;
        Timer = timer;
    }

    

    public void Heat()
    {
        if (Timer > 0)
        {
            Console.WriteLine($"Heating for {Timer} minutes at {Wattage} watts");
        }
    }

    public void Grill()
    {
        if (HasGrill)
        {
            Console.WriteLine("Grilling food");
        }
        else
        {
            Console.WriteLine("No grill available");
        }
    }

    public void Stop()
    {
        Console.WriteLine("Microwave stopped");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Wattage: {Wattage}W, Grill: {HasGrill}, Timer: {Timer} min");
    }
}

class AirConditioner : Appliance
{
    private int btu;
    private int fanSpeed;

    public int BTU
    {
        get { return btu; }
        set { btu = value > 0 ? value : 5000; }
    }

    public int FanSpeed
    {
        get { return fanSpeed; }
        set { fanSpeed = (value >= 1 && value <= 5) ? value : 3; }
    }

    public string Mode { get; set; }

    public AirConditioner(string brand, string model, double powerUsage, int btu, int fanSpeed, string mode)
        : base(brand, model, powerUsage)
    {
        BTU = btu;
        FanSpeed = fanSpeed;
        Mode = mode;
    }

    

    public void CoolRoom()
    {
        if (Mode == "Cool")
        {
            Console.WriteLine($"Cooling room with {BTU} BTU");
        }
        else
        {
            Console.WriteLine("Not in Cool mode");
        }
    }

    public void HeatRoom()
    {
        if (Mode == "Heat")
        {
            Console.WriteLine($"Heating room with {BTU} BTU");
        }
        else
        {
            Console.WriteLine("Not in Heat mode");
        }
    }

    public void ChangeFanSpeed(int speed)
    {
        if (speed >= 1 && speed <= 5)
        {
            FanSpeed = speed;
            Console.WriteLine($"Fan speed set to {speed}");
        }
        else
        {
            Console.WriteLine("Invalid speed");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"BTU: {BTU}, Fan: {FanSpeed}, Mode: {Mode}");
    }
}

class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = !string.IsNullOrWhiteSpace(value) ? value : "Unknown"; }
    }

    public int Age
    {
        get { return age; }
        set { age = value >= 0 ? value : 0; }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }


    public virtual void ShowDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Student : Person
{
    private string studentID;
    private string major;

    public string StudentID
    {
        get { return studentID; }
        set { studentID = !string.IsNullOrWhiteSpace(value) ? value : "N/A"; }
    }

    public string Major
    {
        get { return major; }
        set { major = !string.IsNullOrWhiteSpace(value) ? value : "Undeclared"; }
    }

    public Student(string name, int age, string studentID, string major)
        : base(name, age)
    {
        StudentID = studentID;
        Major = major;
    }

    

    public void Study()
    {
        Console.WriteLine($"Student {Name} is studying {Major}");
    }

    public override void ShowDetails()
    {
        base.ShowDetails();
        Console.WriteLine($"Student ID: {StudentID}, Major: {Major}");
    }
}

class GraduateStudent : Student
{
    private string thesisTitle;
    private string advisorName;

    public string ThesisTitle
    {
        get { return thesisTitle; }
        set { thesisTitle = !string.IsNullOrWhiteSpace(value) ? value : "TBD"; }
    }

    public string AdvisorName
    {
        get { return advisorName; }
        set { advisorName = !string.IsNullOrWhiteSpace(value) ? value : "Unassigned"; }
    }

    public GraduateStudent(string name, int age, string studentID, string major, string thesisTitle, string advisorName)
        : base(name, age, studentID, major)
    {
        ThesisTitle = thesisTitle;
        AdvisorName = advisorName;
    }

  
    public void DefendThesis()
    {
        Console.WriteLine($"Graduate student {Name} defends thesis '{ThesisTitle}', supervised by {AdvisorName}");
    }

    public override void ShowDetails()
    {
        base.ShowDetails();
        Console.WriteLine($"Thesis: {ThesisTitle}, Advisor: {AdvisorName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Task 1, 2, 3: Employee System");
        Employee[] empArr = new Employee[3];

        empArr[0] = new Employee(1, "Ahmed Ali", SecurityLevel.DBA, 8000, new HiringDate(15, 5, 2020), Gender.M);
        empArr[1] = new Employee(2, "Sara Mohamed", SecurityLevel.Guest, 3000, new HiringDate(10, 8, 2021), Gender.F);
        empArr[2] = new Employee(3, "Omar Hassan", SecurityLevel.DBA | SecurityLevel.Developer | SecurityLevel.Secretary, 12000, new HiringDate(1, 1, 2019), Gender.M);

        foreach (var emp in empArr)
        {
            Console.WriteLine(emp.ToString());
        }

        Console.WriteLine("\nTask 4: Household Appliances");
        
        WashingMachine washer = new WashingMachine("LG", "TurboWash", 2000, 8, 1400, true);
        washer.TurnOn();
        washer.ShowInfo();
        washer.StartWash();
        washer.Rinse();
        washer.Spin();
        washer.TurnOff();

        Console.WriteLine();

        Refrigerator fridge = new Refrigerator("Samsung", "CoolMax", 150, 300, true, 4);
        fridge.TurnOn();
        fridge.ShowInfo();
        fridge.Cool();
        fridge.SetTemperature(6);
        fridge.Defrost();
        fridge.TurnOff();

        Console.WriteLine();

        Microwave micro = new Microwave("Panasonic", "QuickHeat", 1200, 900, true, 5);
        micro.TurnOn();
        micro.ShowInfo();
        micro.Heat();
        micro.Grill();
        micro.Stop();
        micro.TurnOff();

        Console.WriteLine();

        AirConditioner ac = new AirConditioner("Carrier", "SmartCool", 1800, 12000, 3, "Cool");
        ac.TurnOn();
        ac.ShowInfo();
        ac.CoolRoom();
        ac.ChangeFanSpeed(5);
        ac.TurnOff();

        Console.WriteLine("\nTask 5: University System");
        
        GraduateStudent grad = new GraduateStudent("Fatima Ahmed", 24, "GS2023001", "Computer Science", "AI in Healthcare", "Dr. Khaled Ibrahim");
        grad.ShowDetails();
        grad.Study();
        grad.DefendThesis();

        Console.WriteLine("\nPress any key to exit");
        Console.ReadKey();
    }
}
