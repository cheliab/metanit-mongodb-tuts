using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using N_002_WorkWithModels.Models;

namespace N_002_WorkWithModels;

class Program
{
    public static void Main()
    {
        // Example_ClassToJson();
        // Example_BsonDocToClass();
        Example_ClassToBsonDocument();
        
        Console.ReadKey();
    }

    private static void Example_ClassToJson()
    {
        Company c = new Company
        {
            Name = "Microsoft"
        };
        
        Person p = new Person
        {
            Name = "Bill",
            Surname = "Gates",
            Age = 48
        };
        p.Company = c;

        Console.WriteLine(p.ToJson());
    }

    private static void Example_BsonDocToClass()
    {
        BsonDocument personDoc = new BsonDocument
        {
            {"Name", "Bill"},
            {"Surname", "Gates"},
            {"Age", new BsonInt32(48)},
            {"Company", new BsonDocument
            {
                {"Name", "Microsoft"}
            }}
        };

        Person person = BsonSerializer.Deserialize<Person>(personDoc);

        Console.WriteLine(person.ToJson());

        Console.ReadKey();
    }

    private static void Example_ClassToBsonDocument()
    {
        Person personObj = new Person
        {
            Name = "Bill",
            Surname = "Gates",
            Age = 48
        };
        personObj.Company = new Company
        {
            Name = "Microsoft"
        };

        BsonDocument personDoc = personObj.ToBsonDocument();

        Console.WriteLine(personDoc);
    }
}