namespace Random_Console_App.Main.Services
{
    public class DataService
    {
        public static string GetUserInput()
        {
            return Console.ReadLine() ?? "NULL";
        }

        public static void GetProceedState()
        {
            Console.WriteLine("Do you want to proceed? Y/N");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (input == 'N' || input == 'n')
                RuntimeService.ExitGracefully();
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