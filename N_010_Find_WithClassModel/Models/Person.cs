using MongoDB.Bson;

namespace N_010_Find_WithClassModel.Models;

public class Person
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Company Company { get; set; }
    public List<string> Languages { get; set; }
}