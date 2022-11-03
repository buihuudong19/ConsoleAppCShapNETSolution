namespace SOLID.OOP.SRP;
public class EmployeeStore
{
    private static int _lastID = 0; //Id cuoi cung cua employee
    public static int NextId => ++_lastID;
    private static List<Employee> _employees { get; }

    static EmployeeStore()
    {
        _employees = new List<Employee>()
        {
            //object-initalizer
            new Employee
            {
                Id = NextId,
                Name = "Cong Phu",
                Dob = new DateOnly(1982,08,23),
                Address ="Quan 10, TPHCM",
                WorkHourly=230,
                WorkRate = 300_000
            },
            new Employee
            {
                Id = NextId,
                Name = "Gia Tri",
                Dob = new DateOnly(1990,07,23),
                Address ="Hoc Mon, TPHCM",
                WorkHourly=260,
                WorkRate = 400_000
            },
             new Employee
            {
                Id = NextId,
                Name = "Cong Cong",
                Dob = new DateOnly(1990,04,23),
                Address ="Binh Thanh, TPHCM",
                WorkHourly=260,
                WorkRate = 500_000
            }
             

             

        };
        
    }

    public EmployeeStore() { }
    public IEnumerable<Employee> Employees => _employees; //Properties

    //method manual
    public void Save(Employee e)
    {
        //1. Check e co ton tai chua?
        if (_employees.Any(n => n.Id == e.Id))
        {
            //lay chi so cua phan tu "e"
            int index = _employees.FindIndex(n => n.Id == e.Id);
            _employees[index] = e;
        }
        else
        {
            _employees.Add(e);
        }
    }

    public Employee? Load(int empId) => _employees.FirstOrDefault(b => b.Id == empId);

}
