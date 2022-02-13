using MongoDB.Bson;

namespace mongodb_tuts.Examples;

public class Example_CreateBsonDocument
{
    public static void Start()
    {
        // CreateEmptyDoc();
        // CreateSimpleDoc();
        // GetDocProperty();
        // UseBsonElement();
        // AddBsonElement();
        // CreateComplexDocument();
        CreateDocWithArray();
    }

    private static void CreateEmptyDoc()
    {
        BsonDocument doc = new BsonDocument();

        Console.WriteLine(doc);
    }

    private static void CreateSimpleDoc()
    {
        BsonDocument doc = new BsonDocument
        {
            {"name", "Bill"}
        };

        Console.WriteLine(doc);
    }

    private static void GetDocProperty()
    {
        BsonDocument doc = new BsonDocument
        {
            {"name", "Bill"}
        };

        Console.WriteLine(doc["name"]);

        doc["name"] = "Tom";

        Console.WriteLine(doc.GetValue("name"));
    }

    private static void UseBsonElement()
    {
        BsonElement element = new BsonElement("name", "Bill");
        BsonDocument document = new BsonDocument(element);

        Console.WriteLine(document);
    }

    private static void AddBsonElement()
    {
        BsonElement element = new BsonElement("name", "Bill");
        BsonDocument document = new BsonDocument();

        document.Add(element);

        Console.WriteLine(document);
    }

    private static void CreateComplexDocument()
    {
        BsonDocument doc = new BsonDocument
        {
            {"name", "Bill"},
            {"lastName", "Gates"},
            {"age", new BsonInt32(48)},
            {"company", new BsonDocument
            {
                {"name", "microsoft"},
                {"year", new BsonInt32(1974)},
                {"price", new BsonInt32(300_000)}
            }}
        };

        Console.WriteLine(doc);
    }

    private static void CreateDocWithArray()
    {
        BsonDocument chempDoc = new BsonDocument();

        chempDoc.Add("countries", 
            new BsonArray(new[]
                {
                    "Бразилия", 
                    "Аргентина",
                    "Германия",
                    "Нидерланды"
                })
            );
        chempDoc.Add("finished", new BsonBoolean(true));

        Console.WriteLine(chempDoc);
    }
}