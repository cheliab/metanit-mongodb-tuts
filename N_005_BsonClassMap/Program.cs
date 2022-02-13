using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using N_005_BsonClassMap.Models;

namespace N_005_BsonClassMap;

class Program
{
    public static void Main()
    {
        BsonClassMap.RegisterClassMap<Person>(classMap =>
        {
            classMap.AutoMap();
            classMap.MapMember(person => person.Name).SetElementName("firstName");
        });

        Person person = new Person
        {
            Name = "Bill",
            Age = 48
        };

        BsonDocument doc = person.ToBsonDocument();

        Console.WriteLine(doc);

        Console.ReadKey();
    }
}