using MongoDB.Driver;

namespace mongodb_tuts.Examples;

public class Example_GetAllDbNames
{
    public static void Start()
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017");
        GetDatabaseNamesAsync(client).GetAwaiter();

        Console.ReadKey();
    }
    
    private static async Task GetDatabaseNamesAsync(MongoClient client)
    {
        using (var cursor = await client.ListDatabaseNamesAsync())
        {
            var databaseDocuments = await cursor.ToListAsync();
            foreach (var databaseDocument in databaseDocuments)
            {
                Console.WriteLine(databaseDocument);
            }
        }
    }
}