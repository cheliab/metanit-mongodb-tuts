using MongoDB.Bson;
using MongoDB.Driver;

namespace mongodb_tuts.Examples;

public class Example_GetAllCollectionsOfAllDatabases
{
    public static void Start()
    {
        string connectionString = "mongodb://localhost";

        MongoClient client = new MongoClient(connectionString);
        GetCollectionsNames(client).GetAwaiter();
    }

    private static async Task GetCollectionsNames(MongoClient client)
    {
        using (var dbsCursor = client.ListDatabases())
        {
            var dbList = await dbsCursor.ToListAsync();
            foreach (var db in dbList)
            {
                Console.WriteLine($"В базе данных \"{db["name"]}\" имеются следующие коллекции:");

                IMongoDatabase database = client.GetDatabase(db["name"].ToString());

                using (var collCursor = database.ListCollectionsAsync())
                {
                    var collections = collCursor.Result.ToListAsync().Result;
                    foreach (var collection in collections)
                    {
                        Console.WriteLine(" - " + collection["name"].ToString());
                    }
                }
            }
        }
    }
}