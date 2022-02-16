using MongoDB.Bson;
using MongoDB.Driver;
using N_010_Find_WithClassModel.Models;

namespace N_010_Find_WithClassModel;

class Propgram
{
    public static async Task Main()
    {
        // await GetDocs_WithClassAsync();
        GetDocs_WithClass();
    }

    /// <summary>
    /// Получение данных с использванием классов
    /// </summary>
    private static async Task GetDocs_WithClassAsync()
    {
        string connectionString = "mongodb://localhost";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");

        var collection = database.GetCollection<Person>("people");

        var filter = new BsonDocument();

        using (var cursor = await collection.FindAsync(filter))
        {
            while (await cursor.MoveNextAsync())
            {
                var people = cursor.Current;
                foreach (Person person in people)
                {
                    Console.WriteLine($"{person.Id} - {person.Name} ({person.Age})");
                }    
            }
        }
    }

    private static void GetDocs_WithClass()
    {
        string connectionString = "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<Person>("people");

        var filter = new BsonDocument();
        var people = collection.Find(filter).ToList();
        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Id} - {person.Name} ({person.Age})");
        }
    }
}