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

        XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@nazwaPostaciFarmaceutycznej='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
        query.SetContext(manager);
        XPathNodeIterator iterator = navigator.Select(query);

        Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", iterator.Count);

        Dictionary<string, HashSet<string>> substanceFormsMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> creamCompaniesMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> tabCompaniesMap = new Dictionary<string, HashSet<string>>();

        XPathNodeIterator allProducts = navigator.Select("/x:produktyLecznicze/x:produktLeczniczy", manager);

        while (allProducts.MoveNext())
        {
            string drugForm = allProducts.Current.GetAttribute("nazwaPostaciFarmaceutycznej", "");
            string commonName = allProducts.Current.GetAttribute("nazwaPowszechnieStosowana", "");
            string company = allProducts.Current.GetAttribute("podmiotOdpowiedzialny", "");

            if (!substanceFormsMap.ContainsKey(commonName))
                substanceFormsMap[commonName] = new HashSet<string>();
            substanceFormsMap[commonName].Add(drugForm);

            if (drugForm == "Krem" && !string.IsNullOrEmpty(company))
            {
                if (!creamCompaniesMap.ContainsKey(company))
                    creamCompaniesMap[company] = new HashSet<string>();
                creamCompaniesMap[company].Add(commonName);
            }

            if (drugForm == "Tabletki" && !string.IsNullOrEmpty(company))
            {
                if (!tabCompaniesMap.ContainsKey(company))
                    tabCompaniesMap[company] = new HashSet<string>();
                tabCompaniesMap[company].Add(commonName);
            }
        }

        int multiFormCount = substanceFormsMap.Count(d => d.Value.Count > 1);
        Console.WriteLine("Liczba produktów leczniczych o takiej samej nazwie powszechnej i pod różnymi postaciami {0}", multiFormCount);

        var topCream = creamCompaniesMap.OrderByDescending(x => x.Value.Count).FirstOrDefault();
        if (topCream.Key != null)
            Console.WriteLine("Podmiot produkujący najwięcej kremów: {0} ({1} substancji)", topCream.Key, topCream.Value.Count);

        var topTablet = tabCompaniesMap.OrderByDescending(x => x.Value.Count).FirstOrDefault();
        if (topTablet.Key != null)
            Console.WriteLine("Podmiot produkujący najwięcej tabletek: {0} ({1} substancji)", topTablet.Key, topTablet.Value.Count);

        Console.WriteLine("\nTOP 3 podmioty produkujące najwięcej kremów (XPath):");
        var top3Creams = creamCompaniesMap.OrderByDescending(x => x.Value.Count).Take(3);
        foreach (var entry in top3Creams)
        {
            Console.WriteLine("- {0}: {1} produktów", entry.Key, entry.Value.Count);
        }
    }
}