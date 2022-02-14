using MongoDB.Bson;
using MongoDB.Driver;

namespace N_009_FindAsync;

class Program
{
    public static async Task Main()
    {
        // await FindAsyncDocs();
        await FindDocs();
    }

    private static async Task FindAsyncDocs()
    {
        string connectionString = "mongodb://localhost";
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");

        var filter = new BsonDocument();
        using (var cursor = await collection.FindAsync(filter))
        {
            while (await cursor.MoveNextAsync())
            {
                var people = cursor.Current;
                foreach (var doc in people)
                {
                    Console.WriteLine(doc);
                } 
            }
        }
    }

    private static async Task FindDocs()
    {
        string connectionString = "mongodb://localhost";
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");

        var filter = new BsonDocument();
        var people = await collection.Find(filter).ToListAsync();
        foreach (var doc in people)
        {
            Console.WriteLine(doc);
        }
    }
}