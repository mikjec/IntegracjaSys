using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

internal class XMLReadWithXLSTDOM
{
    internal static void Read(string filepath)
    {
        XPathDocument document = new XPathDocument(filepath);
        XPathNavigator navigator = document.CreateNavigator();
        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("x", "http://rejestry.ezdrowie.gov.pl/rpl/eksport-danych-v6.0.0");

        // UWAGA: Zmieniłem @postac na @nazwaPostaciFarmaceutycznej, bo tak miałeś w XML
        XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@nazwaPostaciFarmaceutycznej='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
        query.SetContext(manager);

        XPathNodeIterator iterator = navigator.Select(query);
        int count = iterator.Count;

        Console.WriteLine("Liczba produktów (XPath): {0}", count);

        // Sekcja TOP 3
        XPathNodeIterator allProducts = navigator.Select("/x:produktyLecznicze/x:produktLeczniczy", manager);
        Dictionary<string, HashSet<string>> creamCompaniesMap = new Dictionary<string, HashSet<string>>();

        while (allProducts.MoveNext())
        {
            // Tutaj też musisz użyć dokładnych nazw z pliku XML!
            string drugForm = allProducts.Current.GetAttribute("nazwaPostaciFarmaceutycznej", "");
            string commonName = allProducts.Current.GetAttribute("nazwaPowszechnieStosowana", "");
            string company = allProducts.Current.GetAttribute("podmiotOdpowiedzialny", "");

            if (drugForm == "Krem")
            {
                if (!string.IsNullOrEmpty(company))
                {
                    if (!creamCompaniesMap.ContainsKey(company))
                        creamCompaniesMap[company] = new HashSet<string>();
                    creamCompaniesMap[company].Add(commonName);
                }
            }
        }

        var top3Creams = creamCompaniesMap.OrderByDescending(x => x.Value.Count).Take(3);
        foreach (var entry in top3Creams)
        {
            Console.WriteLine("- {0}: {1}", entry.Key, entry.Value.Count);
        }
    }
}