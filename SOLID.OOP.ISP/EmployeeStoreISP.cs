using SOLID.OOP.SRP;
using System.Collections.ObjectModel;
namespace SOLID.OOP.ISP;

public interface IEmployeeReader
{
    IEnumerable<Employee> GetAll();
    Employee? Get(int? id);
}
public interface IEmployeeWriter
{
    void Create(Employee e);
    void Replace(Employee e);
    void Remove(Employee e);
}

public class EmployeeStoreISP: IEmployeeReader, IEmployeeWriter
{
    private static int _lastID = 0; //Id cuoi cung cua employee
    private static int NextId => ++_lastID;
    private static List<Employee> _employees { get; }


    static EmployeeStoreISP()
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
                WorkRate = 300_000,
                Type = "Fresher"

            },
            new Employee
            {
                Id = NextId,
                Name = "Gia Tri",
                Dob = new DateOnly(1990,07,23),
                Address ="Hoc Mon, TPHCM",
                WorkHourly=260,
                WorkRate = 400_000,
                 Type = "Senior"
            },
             new Employee
            {
                Id = NextId,
                Name = "Cong Cong",
                Dob = new DateOnly(1990,04,23),
                Address ="Binh Thanh, TPHCM",
                WorkHourly=260,
                WorkRate = 500_000,
                 Type = "Junior"
            }
        };

    }
    //property return _employees ra ngoai
    public IEnumerable<Employee> Employees = new ReadOnlyCollection<Employee>(_employees);

    public void Create(Employee e)
    {
        if (e.Id == default)
        {
            throw new Exception("A new employee cannot be created with an id.");
        }
        else
        {
            e.Id = NextId;
            _employees.Add(e);
        }
    }

    public Employee? Get(int? id)
    {
        //return Employees.FirstOrDefault(e => e.Id == id);
        //return _employees.Find(x => x.Id == id);
        return _employees.Where(x => x.Id == id).FirstOrDefault();
    }

    public IEnumerable<Employee> GetAll() => _employees;


    public void Remove(Employee e)
    {
        if (!_employees.Any(b => b.Id == e.Id))
        {
            throw new Exception($"The Employee {e.Id} does not exits");
        }
        var index = _employees.FindIndex(b => b.Id == e.Id);
        _employees.RemoveAt(index);

    }

    public void Replace(Employee e)
    {
        if (!_employees.Any(b => b.Id == e.Id))
        {
            throw new Exception($"The Employee {e.Id} does not exits");
        }
        var index = _employees.FindIndex(b => b.Id == e.Id);
        _employees[index] = e;
    }
}

