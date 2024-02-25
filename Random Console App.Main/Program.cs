using Random_Console_App.Main.Classes;
using Random_Console_App.Main.Services;
using Random_Console_App.Main.Visuals;

while (true)
{
    Console.WriteLine(ASCII.welcomeMessage);
    Console.WriteLine("Prisoner's Dilemma starting...");

    Player player1 = InitializationService.CreatePlayer(1);
    Player player2 = InitializationService.CreatePlayer(2);

    int rounds = DataService.GetIntegerInput("Please input the number of rounds you want to play: ");
    int delay = DataService.GetIntegerInput("Please input the delay you wish to have between each round (in milliseconds): ");
    int noise = DataService.GetIntegerInput("Please input the chance for noise you wish to have in each round (in percentages): ");

    Console.WriteLine("Prisoner's Dilemma started and configured. Ready to play!");

    DataService.StartSimulation();

    NoiseService noiseService = new NoiseService(Convert.ToDouble(noise));
    GameService gameService = new GameService(rounds, delay, noiseService);
    await gameService.PlayMatch(player1, player2);

    var restart = DataService.RestartSimulation();

    if (!restart)
        break;
}

Console.ReadLine();