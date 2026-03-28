using ServiceReference1;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("My First SOAP Client!");

        MyFirstSOAPInterfaceClient client = new MyFirstSOAPInterfaceClient();

        string text = await client.getHelloWorldAsStringAsync("Karol");
        long days = await client.getDaysBetweenDatesAsync("01 01 2022", "04 01 2022");

        Console.WriteLine(text);
        Console.WriteLine(days);
    }
}