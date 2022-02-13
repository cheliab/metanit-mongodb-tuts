using MongoDB.Bson.Serialization.Attributes;

namespace N_004_IgnoreIfNullAttribute.Models;

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    [BsonIgnoreIfDefault]
    public int Age { get; set; }
    [BsonIgnoreIfNull]
    public Company Company { get; set; }
}