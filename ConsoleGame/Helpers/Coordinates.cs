namespace ConsoleGame.Helpers
{
    public class Coordinates(int x, int y)
    {
        //C# oferuje automatyczne właściwości (ang. auto-implemented properties), które upraszczają kod, gdy potrzebuję tylko prostego dostępu do pola bez dodatkowej logiki.
        public int X { get; set; } = x;

        public int Y { get; set; } = y;


        //copy constructor -Dwukropek (:) po nazwie konstruktora oznacza wywołanie innego konstruktora tej samej klasy przed wykonaniem ciała bieżącego konstruktora.
        public Coordinates(Coordinates coordinatesToCopy) : this(coordinatesToCopy.X, coordinatesToCopy.Y)
        {
        }
    }
}
