using MongoDB.Bson;
using MongoDB.Driver;

namespace N_011_FilterData;

class Program
{
    public static void Main()
    {
        // FindPeople();
        // FindPeople_GTFilter();
        // FindPeople_Or_Filter();
        FindPeople_And_Filter();
    }

    private static void FindPeople()
    {
        string connectionString = "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");
        
        // поиск документов, в которых Name = "Bill"
        var filter = new BsonDocument("Name", "Bill");
        var people = collection.Find(filter).ToList();
        foreach (var person in  people)
        {
            Console.WriteLine(person);
        }
    }

    private static void FindPeople_GTFilter()
    {
        string connectionString = "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");
        
        // поиск документов - использование оператора $gt
        var filter = new BsonDocument("Age", new BsonDocument("$gt", 31));
        var people = collection.Find(filter).ToList();
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }

    /// <summary>
    /// Получить коллекцию "people"
    /// </summary>
    /// <returns></returns>
    private static IMongoCollection<BsonDocument> GetCollectionPeople()
    {
        string connectionString = "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("people");

        return collection;
    }

    private static void FindPeople_Or_Filter()
    {
        var collection = GetCollectionPeople();

        var filter = new BsonDocument("$or", new BsonArray
        {
            new BsonDocument("Age", new BsonDocument("$gte", 33)),
            new BsonDocument("Name", "Pavel")
        });

        var people = collection.Find(filter).ToList();
        foreach (var person in  people)
        {
            Console.WriteLine(person);
        }
    }

    private static void FindPeople_And_Filter()
    {
        var collection = GetCollectionPeople();

        var filter = new BsonDocument("$and", new BsonArray
        {
            new BsonDocument("Age", new BsonDocument("$gt", 31)),
            new BsonDocument("Name", "Bill")
        });

        var people = collection.Find(filter).ToList();
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}