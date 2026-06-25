using System.Text.Json;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string jsonContent = File.ReadAllText(filePath);

        using JsonDocument doc = JsonDocument.Parse(jsonContent);

        int propertyCount = 0;

        if (doc.RootElement.ValueKind == JsonValueKind.Object)
        {
            propertyCount = doc.RootElement.EnumerateObject().Count();
        }
        else if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            propertyCount = doc.RootElement.GetArrayLength();
        }

        Console.WriteLine($" -> Parsed {propertyCount} root properties.");

        string displayContent = jsonContent.Length > 100
            ? jsonContent.Substring(0, 100) + "..."
            : jsonContent;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}