namespace ConsoleAppCShapNET.Entities;
public class Employee
{
    //1. fields (data)
    private int _id;
    private string _name;
    private DateOnly _dob;
    //2. properties
    public int Id { 
        get { return _id; } 
        set { _id = value; } 
    }
    private static int _lastID = 0; //Id cuoi cung cua employee
    public static int NextId = ++_lastID;
    public string Name { get => _name; set => _name = value; }
    public DateOnly Dob { get => _dob; set => _dob = value; }

    public string Address { get; set; }
    public int WorkHourly { get; set; }
    public float WorkRate { get; set; }

    public static Employee[] Employees { get; }


    
    
    
    //3. constructors
    //overloading...
    static Employee()
    {
        Employees = new Employee[2];

        Employee e = new Employee();
        e.Id = NextId;
        e.Name = "Nguyen van A";
        e.Address = "Quan 1, TPHCM";
        e.Dob = new DateOnly(1987,02,18);
        e.WorkHourly = 20;
        e.WorkRate = 300000;
        
        Employees[0] = e;
        Employees[1] = new Employee(NextId, "Long Nguy", new DateOnly(1987, 01, 05), "Quan 3, TPHCM", 25, 400000);

    }
    public Employee()
    {
    }
    public Employee(int? id = null)
    {
        Id = id ?? default;//supported by c#7.1 id = 0=> id = default(int)
    }
    public Employee(int id, string name, DateOnly dob, string address, int workHourly, float workRate)
    {
        Id = id;
        Name = name;
        Dob = dob;
        Address = address;
        WorkHourly = workHourly;
        WorkRate = workRate;
    }



    //4. methods vs functions vs behavior
    public string Show() => _display();
    private string _display() => $"Id: {Id}, Name: {_name}, Address: {Address}, WorkHourly: {WorkHourly}, WorkRate:{WorkRate}";
    public double GetSalary() => _calculatorSalary();
    private double _calculatorSalary() => WorkRate* WorkHourly;

    public override string? ToString() => this._display();
}
