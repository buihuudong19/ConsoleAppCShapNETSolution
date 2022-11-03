
string[] lstNames = { "Dong", "Phu", "Linh", "Gia Tri", "Cong Cong" };
/*Query Expression*/
/*Sap xep tang dan theo ten va in ra*/
foreach (string e in lstNames.OrderBy(s => s)){
    Console.WriteLine(e);   
}
/*Sap xep giam dan theo length*/
foreach (string e in lstNames.OrderBy(a => a.Length))
{
    Console.WriteLine(e);
}
/*lay ra all names contains character 'n'*/

dynamic data = lstNames.Select(s => s.Contains('n'));
data = lstNames.Where(s => s.Contains('n'));
Console.WriteLine("==============================");
foreach (string e in data)
{
    Console.WriteLine(e);
}

/*Linq to objects*/

var names = from w in lstNames
            where (w.Contains('n') && w.Length>4)
            select w;
Console.WriteLine("==============================");
foreach (string e in names)
{
    Console.WriteLine(e);
}

