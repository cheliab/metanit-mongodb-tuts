using MongoDB.Bson;

namespace N_002_WorkWithModels.Models;

public class Person
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public Company Company { get; set; }
    public List<int> Languages { get; set; }
}