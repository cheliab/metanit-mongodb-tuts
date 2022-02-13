using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace N_004_IgnoreIfNullAttribute.Models;

public class Person_RepresentationAttr
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    [BsonRepresentation(BsonType.String)]
    public int Age { get; set; }
}