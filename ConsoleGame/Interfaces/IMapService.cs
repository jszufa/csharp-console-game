using ConsoleGame.GameLoop;

namespace ConsoleGame.Interfaces
{
    public interface IMapService
    {
        public void HandleCommand(string input, Level level, Game game);
        public void PrintControlsMessage();
        public bool ValidateCommand(char commandInput);
    }
}
