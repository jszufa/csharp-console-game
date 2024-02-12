using ConsoleGame;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Class1.Printer();

        //testing
        var console = new ConsoleHandlerImpl();
        console.DisplayOutputLn("Siemanko!");
        var input = console.ReadInput();
        console.DisplayOutputLn(input);
    }
}