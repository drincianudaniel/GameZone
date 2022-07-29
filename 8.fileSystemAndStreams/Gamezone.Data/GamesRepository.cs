using GameZoneModels;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gamezone.Data
{
    public class GamesRepository
    {

        private static string rootPath = @"F:\amdaris\GameZone\8.fileSystemAndStreams\Gamezone.Data";
        private static string dirPath = Path.Combine(rootPath, "Data");
        private static string filePath = Path.Combine(dirPath, "games.txt");
        FileStream fs = File.Create(filePath);

        public async void AddGamesToFile(List<Game> gamesToAdd)
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach(Game game in gamesToAdd)
                {
                    await sw.WriteLineAsync($"ID: {game.id} name: {game.name}");
                }
            }
        }

        public string ReadGamesFromFile()
        {
            using(var sr  = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}