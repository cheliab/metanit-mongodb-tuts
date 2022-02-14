using MongoDB.Driver;
using N_008_SaveClass.Models;

namespace N_008_SaveClass;

class Program
{
    public static async Task Main()
    {
        string connectionString = "mongodb://localhost";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");

        var collection = database.GetCollection<Person>("people");

        Person larryPerson = new Person
        {
            Name = "Larry",
            
            Age = 35,
            Company = new Company
            {
                Name = "Google"
            },
            Languages = new List<string>
            {
                "english",
                "german"
            }
        };

        await collection.InsertOneAsync(larryPerson);
    }
}