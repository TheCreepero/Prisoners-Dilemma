using Random_Console_App.Main.Classes;
using Random_Console_App.Main.Classes.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Console_App.Main.Services
{
    public class InitializationService
    {
        public static Player CreatePlayer(int playerNumber)
        {
            // Get all subclasses of Player
            var playerTypes = typeof(Player).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Player)) && !t.IsAbstract)
                .ToList();

            int playerTypeIndex;
            do
            {
                Console.WriteLine($"Please choose the type for Player {playerNumber}:");
                for (int i = 0; i < playerTypes.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {playerTypes[i].Name}");
                }

                playerTypeIndex = DataService.GetIntegerInput("Your choice: ") - 1;

                if (playerTypeIndex < 0 || playerTypeIndex >= playerTypes.Count())
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (playerTypeIndex < 0 || playerTypeIndex >= playerTypes.Count());

            // Create the player
            Type playerType = playerTypes[playerTypeIndex];
            string playerName = DataService.GetStringInput($"Please enter a name for Player {playerNumber}: ");
            if (playerType == typeof(RandomPlayer))
            {
                int defectionChance = DataService.GetIntegerInput("Please enter the defection chance for RandomPlayer: ");
                return (Player)Activator.CreateInstance(playerType, playerName, defectionChance);
            }
            else
            {
                return (Player)Activator.CreateInstance(playerType, playerName);
            }
        }
    }
}