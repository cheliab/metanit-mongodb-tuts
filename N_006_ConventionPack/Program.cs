using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using N_006_ConventionPack.Models;

namespace N_006_ConventionPack;

class Program
{
    public static void Main()
    {
        ConventionPack conventionPack = new ConventionPack();
        conventionPack.Add(new CamelCaseElementNameConvention());
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        Person person = new Person
        {
            Name = "Pavel",
            Age = 31
        };

        BsonDocument doc = person.ToBsonDocument();

        Console.WriteLine(doc);

        Console.ReadKey();
    }
}

