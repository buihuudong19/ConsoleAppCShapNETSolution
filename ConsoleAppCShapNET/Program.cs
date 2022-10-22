using ConsoleAppCShapNET.Entities;
namespace ConsoleAppCShapNET.App;
public class Program
{
    public static void Main()
    {
        //create a object Employee
        Employee e = new Employee();//e: object/instance
        e.Id = 1;
        e.Name = "Bui Huu Dong";
        e.Address = "Quan 10, TPHCM";
        e.Dob = new DateOnly(2022, 10, 20);
        e.WorkHourly = 150;
        e.WorkRate = 250_000;

        Employee e2 = new Employee(2, "Tri", new DateOnly(1983, 01, 15), "Quan 1", 230, 180_000);
        e2.Name = "Nguy Long";

        Employee e3 = new Employee(null);
        int? a = null;
       
        if(a == null)
        {
            a = 0;
        }
        a= a ?? default;
        Console.WriteLine(a);
        Console.WriteLine(e2);
        Console.ReadLine();
    }
}
