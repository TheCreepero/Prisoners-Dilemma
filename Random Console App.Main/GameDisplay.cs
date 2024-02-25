using Random_Console_App.Main.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Console_App.Main
{
    public static class GameDisplay
    {
        public static void DisplayMatchStart(Player player1, Player player2)
        {
            Console.WriteLine($"This game is played between: {player1.PlayerName} (Player 1) and {player2.PlayerName} (Player 2)");
        }

        public static void DisplayRoundStart(int roundNumber)
        {
            Console.WriteLine($"---ROUND {roundNumber + 1}---");
        }

        public static void DisplayChoices(Player player1, Player player2)
        {
            Console.WriteLine($"{player1.PlayerName} chooses: {player1.Choice}");
            Console.WriteLine($"{player2.PlayerName} chooses: {player2.Choice}");
        }

        public static void DisplayRoundEnd()
        {
            Console.WriteLine("---END OF ROUND---");
        }

        public static void DisplayMatchEnd()
        {
            Console.WriteLine("Game over!");
        }

        public static void DisplayWinner(Player winner, int score)
        {
            if (winner != null)
            {
                Console.WriteLine($"{winner.PlayerName} wins with a sentence of {score} years!");
            }
            else
            {
                Console.WriteLine($"A tie! Both score {score}");
            }
        }
    }
}