using SOLID.OOP.SRP;
namespace SOLID.OOP.OCP;



public class ManagerEmployeeSalaryCalculator : BaseSalaryCalculator
{
    public ManagerEmployeeSalaryCalculator(Employee emp) : base(emp)
    {

    }
    public override double CalculateSalary() => Employee.WorkHourly * Employee.WorkRate * 1.2;
}
