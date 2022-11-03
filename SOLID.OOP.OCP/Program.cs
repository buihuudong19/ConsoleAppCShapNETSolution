/*
    Yêu cầu: Thêm mới một chức năng tính lương cho tổng tất cả n nhân viên
    Với điều kiện, mỗi nhân viên có một mức lương khác nhau
 */

using SOLID.OOP.OCP;
using SOLID.OOP.SRP;

namespace ConsoleAppCShapNET.App;
public class Program
{
    private static readonly EmployeePresenter _employeePresenter = new();
    private static readonly EmployeeStore _employeeStore = new();
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
            Console.WriteLine($"4. Show Total Salary of All Employee:");
            Console.WriteLine($"5. Exit");
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
                        ShowSalaryAll();
                        break;
                    case "5":
                        run = false;
                        break;
                    default:
                        Console.WriteLine($"Invalid optin when you chooose...");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"==============================");
            Console.WriteLine($"Press the enter to go back to the main menu");
            Console.ReadLine();
        } while (run);






        Console.ReadLine();
    }

    private static void ShowSalaryAll()
    {
        //Thuc thi in la tong luong cua tat cả các nhân viên

        var empCalculations = new List<BaseSalaryCalculator>
        {
            new FresherEmployeeSalaryCalculator(
                new Employee
                {
                     Id = EmployeeStore.NextId,
                     Name = "Dong",
                     Address="Quan 10",
                     Type="Fresher",
                     WorkHourly = 300,
                     WorkRate = 250_000
                }
            ),
             new JuniorEmployeeSalaryCalculator(
                new Employee
                {
                     Id = EmployeeStore.NextId,
                     Name = "Dong",
                     Address="Quan 10",
                     Type="Junior",
                     WorkHourly = 400,
                     WorkRate = 350_000
                }
            ),

              new SeniorEmployeeSalaryCalculator(
                new Employee
                {
                     Id = EmployeeStore.NextId,
                     Name = "Dong",
                     Address="Quan 10",
                     Type="Senior",
                     WorkHourly = 350,
                     WorkRate = 550_000
                }
            ),
              new ManagerEmployeeSalaryCalculator(
                new Employee
                {
                     Id = EmployeeStore.NextId,
                     Name = "Tri",
                     Address="Quan 10",
                     Type="Manager",
                     WorkHourly = 350,
                     WorkRate = 750_000
                }
            )

        };

        var calculatornNew = new SalaryCalculatorOCP(empCalculations);
        Console.WriteLine($"Sum of all the employees salaries is {calculatornNew.CalculateTotalSalaries()} dollars");



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
            Id = EmployeeStore.NextId,
            Name = name,
            Address = address,
            Dob = new DateOnly(2022, 10, 10),
            WorkHourly = int.Parse(workHourly),//"1" =>1
            WorkRate = float.Parse(workRate)
        };
        _employeeStore.Save(employee);
    }


    private static void ListAllEmployee()
    {
        /**/
        var employees = _employeeStore.Employees; //return all employees
        foreach (Employee e in employees)
        {
            _employeePresenter.Display(e);
        }
    }
}