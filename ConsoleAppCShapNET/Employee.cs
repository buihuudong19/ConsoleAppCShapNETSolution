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

    public static Employee[] Employees { get; private set; }
    private int _size = default(int);//0


    
    
    
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
        //Object inialize
        Employees[1] = new Employee{ 
            Id = ++NextId,
            Name="Long Nguy", 
            Dob=new DateOnly(1987, 01, 05), 
            Address="Quan 3, TPHCM",
            WorkHourly=25,
            WorkRate = 400000
        };

    }
    public Employee()
    {
        this._size = Employees.Length;

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

    public void Save()
    {
        //1. Check emp ton tai chua
        var index = CheckEmployee();
        if (index != -1)
        {
            Employees[index] = this;
        }
        else
        {
            //2. noi mang 1 chieu Employees ra
            if(this._size >= Employees.Length)
            {
                Employee[] temp = new Employee[_size*2];
                //di chuyen du lieu mang cu => temp
                Array.Copy(Employees, 0, temp, 0, _size);
                Employees = temp;
            }
            Employees[_size++] = this;
            

        }
        
    }
    private int CheckEmployee()
    {
        if(Employees.Length != 0)
        {
            for(int i=0; i < Employees.Length; i++)
            {
                if(Employees[i] != null && Employees[i].Id == Id)
                {
                   return i;
                }
               
            } 
        }
        return -1;
    }

    public override string? ToString() => this._display();
}
