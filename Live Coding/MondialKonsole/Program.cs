using MondialKonsole.ExtensionMethods;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

string pfad = "data/mondial.xml";

XDocument mondialDoc = XDocument.Load(pfad);

//Console.WriteLine("TOP 10 der Länder");
//Top10ByPopulation();

Console.WriteLine();
Console.WriteLine("Städte mit 'B'");

CapitalsStartingWithLetter("B");

void Top10ByPopulation()
{

    var qCountriesWithPopulation = mondialDoc.Root.Elements()
                                              .Where(el => el.Name.LocalName == "country") // CheckLocalName(el.Name.LocalName, "country")
                                              .Select(el => new
                                              {
                                                  Name = el.Element("name")?.Value,
                                                  Population = Convert.ToInt32(el.Elements().Where(pp => pp.Name.LocalName == "population").Last().Value)
                                              })
                                              .OrderByDescending(co => co.Population)
                                              .Take(10);

    foreach (var item in qCountriesWithPopulation)
    {
        Console.WriteLine($"{item.Name}: {item.Population:#,##0}");
    }
}

bool CheckLocalName(string localName, string v)
{
    {
        if (localName == v)
            return true;
        return false;
    }
}

void CapitalsStartingWithLetter(string letter)
{
    var qCapitalsStartingWithLetter = mondialDoc.Root.Elements()
                                                    .Where(el => el.Name.LocalName == "country" && el.Attributes().Any(at => at.Name == "capital"))
                                                    .Select(el => new
                                                    {
                                                        Country = el.Elements("name").First().Value,
                                                        Name = el.Descendants("city")
                                                                    .Where(ct => ct.Attribute("id").Value == el.Attribute("capital").Value)
                                                                    .Elements("name").First().Value
                                                    })
                                                    .Where(cp => cp.Name.StartsWith(letter))
                                                    .OrderBy(cp => cp.Country);

    foreach (var item in qCapitalsStartingWithLetter)
    {
        Console.WriteLine($"{item.Country}: {item.Name}");
    }
}
