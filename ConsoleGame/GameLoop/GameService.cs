using System.Xml;
using ConsoleGame.Interfaces;
using ConsoleGame.States;

namespace ConsoleGame.GameLoop;

using System;
using System.IO;
using Newtonsoft.Json;

public class GameService : IGameService
{
    private const string FilePath = "save.json";

    public void Save(GameState gameState)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        string saveJson = JsonConvert.SerializeObject(gameState, settings);

        try
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.Write(saveJson);
            }
        }
        catch (IOException e)
        {
            throw new InvalidOperationException("Failed to save game state", e);
        }
    }

    public GameState Load()
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        try
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameState>(json, settings);
            }
        }
        catch (IOException e)
        {
            throw new InvalidOperationException("Error loading game state: " + e.Message, e);
        }
    }
}
