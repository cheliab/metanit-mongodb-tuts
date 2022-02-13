using MongoDB.Driver;

namespace mongodb_tuts.Mongo;

public static class MongoClientStatic
{
    public static MongoClient Get()
    {
        string connectionString = "mongodb://localhost:27017";
        return new MongoClient(connectionString);
    }
}