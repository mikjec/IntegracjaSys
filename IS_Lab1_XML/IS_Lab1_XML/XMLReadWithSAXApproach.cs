using System.Xml;

internal class XMLReadWithSAXApproach
{
    internal static void Read(string filepath)
    {
        // konfiguracja początkowa dla XmlReadera
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        settings.IgnoreProcessingInstructions = true;
        settings.IgnoreWhitespace = true;
        // odczyt zawartości dokumentu
        XmlReader reader = XmlReader.Create(filepath, settings);
        // zmienne pomocnicze
        int count = 0;
        string postac = "";
        string sc = "";
        string comp;
        Dictionary<string, HashSet<string>> substanceFormsMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> tabCompaniesMap = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> creamCompaniesMap = new Dictionary<string, HashSet<string>>();

        reader.MoveToContent();
        // analiza każdego z węzłów dokumentu

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
            {
                postac = reader.GetAttribute("nazwaPostaciFarmaceutycznej");
                sc = reader.GetAttribute("nazwaPowszechnieStosowana");
                comp = reader.GetAttribute("podmiotOdpowiedzialny");
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
        
        }
        

        Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0} ", count);

        count = 0;

        foreach (var d in substanceFormsMap)
        {
            if (d.Value.Count > 1)
            {
                count++;
            }
        }

        Console.WriteLine("Liczba produktów leczniczych w o takiej samej nazwie powszechnej i pod różnymi postaciami {0} ", count);

        foreach(var c in tabCompaniesMap)
        {

        }
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


        string topTabletCompany = "";
        int maxTablets = 0;
        foreach (var entry in tabCompaniesMap)
        {
            if (entry.Value.Count > maxTablets)
            {
                maxTablets = entry.Value.Count;
                topTabletCompany = entry.Key;
            }
        }

        Console.WriteLine("Podmiot produkujący najwięcej kremów: {0} ({1} substancji)", topCreamCompany, maxCreams);
        Console.WriteLine("Podmiot produkujący najwięcej tabletek: {0} ({1} substancji)", topTabletCompany, maxTablets);

        Console.WriteLine("\nTOP 3 podmioty produkujące najwięcej kremów (SAX):");
        var top3CreamsSAX = creamCompaniesMap
            .OrderByDescending(x => x.Value.Count)
            .Take(3);

        foreach (var entry in top3CreamsSAX)
        {
            Console.WriteLine("- {0}: {1} produktów", entry.Key, entry.Value.Count);
        }
    }
}