namespace ConsoleGame.Interfaces
{
    public interface IConsoleHandler
    {
        string ReadInput();

        void DisplayOutput(string output);

        void DisplayOutputLn(string output);

        void DisplayOutputEmptyLn();
    }
}
