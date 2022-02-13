using MongoDB.Driver;
using mongodb_tuts.Mongo;

namespace mongodb_tuts.Examples;

public class Example_AllDbCollectonNames
{
    public static void Start()
    {
        var client = MongoClientStatic.Get();
        IMongoDatabase database = client.GetDatabase("test");

        var collectionNames = database.ListCollectionNames();

        collectionNames.ForEachAsync((name) => Console.WriteLine(name));
    }
}