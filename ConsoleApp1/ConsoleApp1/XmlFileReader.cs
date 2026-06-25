using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;


namespace ConsoleApp1;


public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        XDocument doc = XDocument.Load(filePath);

        string xmlContent = doc.ToString();
        int nodeCount = doc.Descendants().Count();

        Console.WriteLine($" -> Root element: <{doc.Root?.Name}> with {nodeCount} descendant nodes.");

        string displayContent = xmlContent.Length > 100
            ? xmlContent.Substring(0, 100) + "..."
            : xmlContent;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}