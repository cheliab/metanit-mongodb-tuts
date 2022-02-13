using MongoDB.Bson;
using N_003_ModelAttributes.Models;

namespace N_003_ModelAttributes;

class Program
{
    public static void Main()
    {
        Person p = new Person
        {
            Name = "Bill",
            Surname = "Gates",
            Age = 48
        };
        p.Company = new Company { Name = "Microsoft"};

        Console.WriteLine(p.ToJson());
    }
}

