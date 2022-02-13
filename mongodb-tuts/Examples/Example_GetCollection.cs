using MongoDB.Bson;
using MongoDB.Driver;

namespace mongodb_tuts.Examples;

public class Example_GetCollection
{
    public static void Start()
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("test");

        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("users");

        Console.WriteLine(collection.CollectionNamespace.CollectionName);
    }
}