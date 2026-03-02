using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class AdvancedXMLAnalysis
{
    public static void Run(string filepath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);

        Dictionary<string, int> substanceCountStats = new Dictionary<string, int>();
        Dictionary<string, int> formStats = new Dictionary<string, int>();

        var allProducts = doc.GetElementsByTagName("produktLeczniczy").Cast<XmlNode>().Take(20);

        foreach (XmlNode product in allProducts)
        {
            string form = product.Attributes["nazwaPostaciFarmaceutycznej"]?.Value ?? "Nieznana";


            int count = 0;
            foreach (XmlNode child in product.ChildNodes)
            {
                if (child.Name == "substancjeCzynne")
                {

                    count = child.ChildNodes.Count;
                    break; 
                }
            }

            string countKey;
            if (count == 1) countKey = "Jedna substancja czynna";
            else if (count > 1) countKey = $"Złożone: ";
            else countKey = "Brak substancji/Błąd danych";

            if (!substanceCountStats.ContainsKey(countKey))
                substanceCountStats[countKey] = 0;
            substanceCountStats[countKey]++;

            if (!formStats.ContainsKey(form))
                formStats[form] = 0;
            formStats[form]++;
        }

        Console.WriteLine("=== ZAAWANSOWANA ANALIZA SUBSTANCJI CZYNNYCH (TOP 20) ===");
        foreach (var stat in substanceCountStats.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{stat.Key}: {stat.Value} produktów");
        }

        Console.WriteLine("\n=== GRAFICZNA WIZUALIZACJA: POSTACI W PIERWSZYCH 20 PRODUKTACH ===");
        DrawConsoleBarChart(formStats, 8);
    }

    private static void DrawConsoleBarChart(Dictionary<string, int> data, int topCount)
    {
        var topData = data.OrderByDescending(x => x.Value).Take(topCount).ToList();

        if (!topData.Any()) return;

        int maxValue = topData.Max(x => x.Value);
        int maxBarLength = 40;

        Console.WriteLine($"{"KRYTERIUM (POSTAĆ)",-30} | WYKRES (Skala: max {maxValue})");
        Console.WriteLine(new string('-', 80));

        foreach (var item in topData)
        {
            int barLength = (int)Math.Round((double)item.Value / maxValue * maxBarLength);
            string bar = new string('█', barLength);
            string label = item.Key.Length > 28 ? item.Key.Substring(0, 25) + "..." : item.Key;

            Console.WriteLine($"{label,-30} | {bar} ({item.Value})");
        }
        Console.WriteLine(new string('-', 80));
    }
}