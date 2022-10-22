using ConsoleAppCShapNET.Entities;
namespace ConsoleAppCShapNET.App;
public class Program
{
    public static void Main()
    {
        //Khoi tao menu
        var run = true;
        do
        {
            Console.Clear();
            //string interpolation 
            Console.WriteLine($"Choises:");
            Console.WriteLine($"1. Fetch and display the employee with id = 1");
            Console.WriteLine($"2. Add new employee");
            Console.WriteLine($"3. Show all employees");
            Console.WriteLine($"4. Exit");
            var input = Console.ReadLine();
            Console.Clear();
            try
            {
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        CreateEmployee();
                        break;
                    case "3":
                        ListAllEmployee();
                        break;
                    case "4":
                        run = false;
                        break;
                    default:
                        Console.WriteLine($"Invalid optin when you chooose...");
                        break;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"==============================");
            Console.WriteLine($"Press the enter to go back to the main menu");
            Console.ReadLine();
        }while (run);

        
        

   
        
        Console.ReadLine();
    }

    private static void CreateEmployee()
    {
        Console.Clear();
        Console.Write($"Please enter the Name:");
        var name = Console.ReadLine();
        Console.WriteLine();
        Console.Write($"Please enter the Address:");
        var address = Console.ReadLine();
        Console.WriteLine();
        
        Console.Write($"Please enter the Work Hourly:");
        var workHourly = Console.ReadLine();
        Console.WriteLine();
        Console.Write($"Please enter the Work Rate:");
        var workRate = Console.ReadLine();
        Console.WriteLine();
        var employee = new Employee
        {
            Id = ++Employee.NextId,
            Name = name,
            Address = address,
            Dob = new DateOnly(2022, 10, 10),
            WorkHourly = int.Parse(workHourly),//"1" =>1
            WorkRate = float.Parse(workRate)
        };
        employee.Save();
    }

    private static void ListAllEmployee()
    {
        foreach(Employee e in Employee.Employees)
        {
            Console.WriteLine(e);
        }
    }
}
