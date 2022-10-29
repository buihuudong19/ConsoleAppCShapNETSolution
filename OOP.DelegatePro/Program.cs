namespace Programmming;


public class Program
{
    public delegate int AddDele(int a, int b);//dinh nghia ra 1 kieu (manual)
    public delegate void Print(string s);   
    public static void Main()
    {
        //AddDele addDele = new AddDele(Add);
        AddDele addDele = Add;

        //Truyen ham thong quan lambda expression method

        AddDele addNewDele = (a, b) => a + b;
        Func<int,int, int> addDeleFunc = (a, b) => a + b;
        Action<string> printAction = s => Console.WriteLine(s);

        int result = addDele(2, 3);
        int r = addDele.Invoke(2, 3);
        Console.WriteLine(r);

        Console.WriteLine("=========================");
        Display(Add,10,20);
        Console.ReadLine(); 
    }

    public static void Display(AddDele dele, int a, int b)
    {
        Console.WriteLine($"Tong hai so a va b la: {dele(a, b)}");    
    }

    public static int Add(int a,int b)
    {
        return a + b;
    }


}
