namespace Random_Console_App.Main.Services
{
    public class DataService
    {
        public static string GetUserInput()
        {
            return Console.ReadLine() ?? "NULL";
        }

        public static void StartSimulation()
        {
            Console.WriteLine("Press N to exit. Press any other key to start the simulation.");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (input == 'N' || input == 'n')
                RuntimeService.ExitGracefully();
        }

        public static bool RestartSimulation()
        {
            Console.WriteLine("Press N to exit. Press any other key to restart.");
            char input = Console.ReadKey().KeyChar;

            if (input == 'N' || input == 'n')
            {
                return false;
            }
            return true;
        }

        public static int GetIntegerInput(string prompt)
        {
            int number;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return number;
        }

        public static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}