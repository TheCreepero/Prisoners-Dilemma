using Random_Console_App.Main.Classes;
using Random_Console_App.Main.Visuals;
using System.Text.Json;

namespace Random_Console_App.Main.Services
{
    public class GameService
    {
        private readonly int DelayBetweenRounds;
        private readonly int NumberOfRounds;

        public GameService(int rounds = 10, int delay = 500)
        {
            NumberOfRounds = rounds;
            DelayBetweenRounds = delay;
        }

        public static (int player1FinalScore, int player2FinalScore) GetWinner(List<Result> results, Player player1, Player player2)
        {
            int player1FinalScore = 0;
            int player2FinalScore = 0;

            foreach (var round in results)
            {
                player1FinalScore += round.Player1Score;
                player2FinalScore += round.Player2Score;
            }

            //Final Results
            Console.WriteLine(ASCII.finalResults);
            Console.WriteLine();

            Console.WriteLine($"{player1.PlayerName}: {player1FinalScore} years");
            Console.WriteLine($"{player2.PlayerName}: {player2FinalScore} years");

            if (player1FinalScore < player2FinalScore)
            {
                Console.WriteLine($"{player1.PlayerName} (Player 1) wins with a sentence of {player1FinalScore} years!");
            }
            else if (player1FinalScore > player2FinalScore)
            {
                Console.WriteLine($"{player2.PlayerName} (Player 2) wins with a sentence of {player2FinalScore} years!");
            }
            else if (player1FinalScore == player2FinalScore)
            {
                Console.WriteLine($"A tie! Both score {player1FinalScore}");
            }

            return (player1FinalScore, player2FinalScore);
        }

        public static async Task SaveResults(GameResult gameResult)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(gameResult, options);
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Create a directory for your results if it doesn't exist
            string dirPath = Path.Combine(baseDir, "Results");
            Directory.CreateDirectory(dirPath);

            // Generate a unique ID for the game
            string gameId = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Define the file path
            string filePath = Path.Combine(dirPath, $"results_{gameId}.json");

            // Write the JSON string to the file
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task PlayMatch(Player player1, Player player2)
        {
            GameDisplay.DisplayMatchStart(player1, player2);

            List<Result> results = await PlayRounds(player1, player2);

            GameResult gameResult = new GameResult
            {
                Info = new GameInfo
                {
                    Player1Name = player1.PlayerName,
                    Player2Name = player2.PlayerName,
                    Player1Type = player1.GetType().Name,
                    Player2Type = player2.GetType().Name,
                }
            };

            var (player1FinalScore, player2FinalScore) = GetWinner(results, player1, player2);
            GameDisplay.DisplayMatchEnd();

            gameResult.Results = results;
            gameResult.Player1FinalScore = player1FinalScore;
            gameResult.Player2FinalScore = player2FinalScore;

            await SaveResults(gameResult);
        }

        private Result PlayRound(Player player1, Player player2, int roundNumber)
        {
            player1.Choice = player1.MakeChoice();
            player2.Choice = player2.MakeChoice();

            GameDisplay.DisplayChoices(player1, player2);

            Result roundResult = new Result(roundNumber, player1.Choice, player2.Choice);
            roundResult.CalculateScore();

            return roundResult;
        }

        private async Task<List<Result>> PlayRounds(Player player1, Player player2)
        {
            List<Result> results = new List<Result>();

            for (int i = 0; i < NumberOfRounds; i++)
            {
                GameDisplay.DisplayRoundStart(i);

                Result roundResult = PlayRound(player1, player2, i);
                results.Add(roundResult);

                ProcessResultsDirector(player1, player2, roundResult);
                GameDisplay.DisplayRoundEnd();

                await Task.Delay(DelayBetweenRounds);
            }

            return results;
        }

        private void ProcessResultsDirector(Player player1, Player player2, Result results)
        {
            player1.ProcessResults(results, player2);
            player2.ProcessResults(results, player1);
        }
    }
}