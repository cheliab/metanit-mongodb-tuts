using MongoDB.Bson.Serialization.Attributes;

namespace N_003_ModelAttributes.Models;

public class Person_SimpleExample
{
    [BsonId]
    public int PersonId { get; set; }
    public string Name { get; set; }
}