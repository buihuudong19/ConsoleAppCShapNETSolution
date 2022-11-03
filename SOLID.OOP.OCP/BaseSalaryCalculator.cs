
using SOLID.OOP.SRP;

namespace SOLID.OOP.OCP;
public abstract class BaseSalaryCalculator
{
    protected Employee Employee { get; private set; }
    public BaseSalaryCalculator(Employee employee)
    {
        Employee = employee;
    }

    //method abstract
    public abstract double CalculateSalary();

}
public class FresherEmployeeSalaryCalculator : BaseSalaryCalculator
{
    public FresherEmployeeSalaryCalculator(Employee emp) : base(emp)
    {

    }
    public override double CalculateSalary() => Employee.WorkHourly * Employee.WorkRate * 1.05;
}
public class SeniorEmployeeSalaryCalculator : BaseSalaryCalculator
{
    public SeniorEmployeeSalaryCalculator(Employee emp) : base(emp)
    {

    }
    public override double CalculateSalary() => Employee.WorkHourly * Employee.WorkRate * 1.1;
}

public class JuniorEmployeeSalaryCalculator : BaseSalaryCalculator
{
    public JuniorEmployeeSalaryCalculator(Employee emp) : base(emp)
    {

    }
    public override double CalculateSalary() => Employee.WorkHourly * Employee.WorkRate * 1.08;
}

//Dung the nao sau khi tach
public class SalaryCalculatorOCP
{
    private readonly IEnumerable<BaseSalaryCalculator> _employeeCalculation; //DI - Denpendency Injection (DI)

    public SalaryCalculatorOCP(IEnumerable<BaseSalaryCalculator> employeeCalculation)
    {
        _employeeCalculation = employeeCalculation;
    }
    public double CalculateTotalSalaries()
    {
        double total = 0D;
        foreach (var empCalc in _employeeCalculation)
        {
            total += empCalc.CalculateSalary();
        }

        return total;
    }
}


