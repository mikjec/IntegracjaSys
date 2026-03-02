using System.IO;

string xmlpath = Path.Combine("Assets", "data.xml");
Console.WriteLine("XML loaded by DOM Approach");
XMLReadWithDOMApproach.Read(xmlpath);


Console.WriteLine("XML loaded by SAX Approach");
XMLReadWithSAXApproach.Read(xmlpath);

Console.WriteLine("XML loaded with XPath");
XMLReadWithXLSTDOM.Read(xmlpath);

Console.WriteLine("XML Analysis");
AdvancedXMLAnalysis.Run(xmlpath);

Console.ReadLine();

