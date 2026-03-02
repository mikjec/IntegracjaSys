using System;
using System.Collections.Generic;
using System.Xml;

internal class XMLReadWithDOMApproach
{
    internal static void Read(string filepath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);

        string postac;
        string sc;
        string comp;
        int count = 0;

        var drugs = doc.GetElementsByTagName("produktLeczniczy");

        Dictionary<string, HashSet<string>> substanceFormsMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> creamCompaniesMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> tabCompaniesMap = new Dictionary<string, HashSet<string>>();

        foreach (XmlNode d in drugs)
        {

            postac = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
            sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
            comp = d.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;

         
            if (postac == "Krem" && sc == "Mometasoni furoas")
                count++;

            if (!substanceFormsMap.ContainsKey(sc))
            {
                substanceFormsMap[sc] = new HashSet<string>();
            }
            substanceFormsMap[sc].Add(postac);

            if (postac == "Krem")
            {
                if (!creamCompaniesMap.ContainsKey(comp))
                {
                    creamCompaniesMap[comp] = new HashSet<string>();
                }
                creamCompaniesMap[comp].Add(sc);
            }

            if (postac == "Tabletki")
            {
                if (!tabCompaniesMap.ContainsKey(comp))
                {
                    tabCompaniesMap[comp] = new HashSet<string>();
                }
                tabCompaniesMap[comp].Add(sc);
            }
        }

        Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count);

        count = 0;
        foreach (var d in substanceFormsMap)
        {
            if (d.Value.Count > 1) count++;
        }
        Console.WriteLine("Liczba produktów leczniczych o takiej samej nazwie powszechnej i pod różnymi postaciami {0}", count);


        string topCreamCompany = "";
        int maxCreams = 0;
        foreach (var entry in creamCompaniesMap)
        {
            if (entry.Value.Count > maxCreams)
            {
                maxCreams = entry.Value.Count;
                topCreamCompany = entry.Key;
            }
        }

        string topTabCompany = "";
        int maxTabs = 0;
        foreach (var entry in tabCompaniesMap)
        {
            if (entry.Value.Count > maxTabs)
            {
                maxTabs = entry.Value.Count;
                topTabCompany = entry.Key;
            }
        }

        Console.WriteLine("Podmiot produkujący najwięcej kremów: {0} ({1} substancji)", topCreamCompany, maxCreams);
        Console.WriteLine("Podmiot produkujący najwięcej tabletek: {0} ({1} substancji)", topTabCompany, maxTabs);

        Console.WriteLine("\nTOP 3 podmioty produkujące najwięcej kremów (DOM):");
        var top3CreamsDOM = creamCompaniesMap
            .OrderByDescending(x => x.Value.Count)
            .Take(3);

        foreach (var entry in top3CreamsDOM)
        {
            Console.WriteLine("- {0}: {1} produktów", entry.Key, entry.Value.Count);
        }
    }
}