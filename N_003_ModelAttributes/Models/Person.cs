using MongoDB.Bson.Serialization.Attributes;

namespace N_003_ModelAttributes.Models;

public class Person
{
    [BsonElement("First Name")]
    public string Name { get; set; }
    [BsonIgnore]
    public string Surname { get; set; }
    public int Age { get; set; }
    public Company Company { get; set; }
}

