using Random_Console_App.Main.Classes;
using Random_Console_App.Main.Services;
using Random_Console_App.Main.Visuals;

Console.WriteLine(ASCII.welcomeMessage);
Console.WriteLine("Prisoner's Dilemma starting...");

Player player1 = InitializationService.CreatePlayer(1);
Player player2 = InitializationService.CreatePlayer(2);

int rounds = DataService.GetIntegerInput("Please input the number of rounds you want to play: ");
int delay = DataService.GetIntegerInput("Please input the delay you wish to have between each round (in milliseconds): ");

Console.WriteLine("Prisoner's Dilemma started. Everything is up and running!");

DataService.GetProceedState();

GameService gameService = new GameService(rounds, delay);
await gameService.PlayMatch(player1, player2);

Console.ReadLine();