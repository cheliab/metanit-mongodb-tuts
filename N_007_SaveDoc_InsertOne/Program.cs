using MongoDB.Bson;
using MongoDB.Driver;

namespace N_007_SaveDoc_InsertOne;

class Program
{
    public static async Task Main()
    {
        // await SaveDoc_InsertOne();
        await SaveDoc_InsertMany();
    }

    private static async Task SaveDoc_InsertOne()
    {
        string connection = "mongodb://localhost";
        var client = new MongoClient(connection);

        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");

        BsonDocument personDoc = new BsonDocument
        {
            {"Name", "Pavel"},
            {"Age", 32},
            {"Languages", new BsonArray{"english", "german"}}
        };

        await collection.InsertOneAsync(personDoc);
    }

    private static async Task SaveDoc_InsertMany()
    {
        string connection = "mongodb://localhost";
        var client = new MongoClient(connection);
        
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");

        BsonDocument billDoc = new BsonDocument
        {
            {"Name", "Bill"},
            {"Age", 32},
            {"Languages", new BsonArray{"english", "german"}}
        };

        BsonDocument steveDoc = new BsonDocument
        {
            {"Name", "Steve"},
            {"Age", 31},
            {"Languages", new BsonArray {"english", "french"}}
        };

        await collection.InsertManyAsync(new[] {billDoc, steveDoc});
    }
}