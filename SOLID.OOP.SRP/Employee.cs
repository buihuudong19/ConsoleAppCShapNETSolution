namespace SOLID.OOP.SRP;
public class Employee
{
   
    //1. Properties
    public int Id { get;set; }
 
    public string? Name { get; set; }
    public DateOnly Dob { get; set; }

    public string? Address { get; set; }
    public int WorkHourly { get; set; }
    public float WorkRate { get; set; }

    public Employee()
    {
    }

    public Employee(int id, string? name, DateOnly dob, string? address, int workHourly, 
        float workRate)
    {
        Id = id;
        Name = name;
        Dob = dob;
        Address = address;
        WorkHourly = workHourly;
        WorkRate = workRate;
    }

    public override string? ToString() => $"Id: {Id}, Name: {Name}, Dob: {Dob}, " +
        $"Address: {Address}, WorkHourly: {WorkHourly}, WorkRate: {WorkRate}";
    
}
