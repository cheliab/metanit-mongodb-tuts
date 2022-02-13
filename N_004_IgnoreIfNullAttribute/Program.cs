using MongoDB.Bson;
using N_004_IgnoreIfNullAttribute.Models;

namespace N_004_IgnoreIfNullAttribute;

class Program
{
    public static void Main()
    {
        Person bill = new Person
        {
            Name = "Bill",
            Surname = "Gates",
            Age = 48
        };

        Person stive = new Person
        {
            Name = "Stive",
            Surname = "Jobs"
        };

        Console.WriteLine(bill.ToJson());
        Console.WriteLine(stive.ToJson());
    }
}