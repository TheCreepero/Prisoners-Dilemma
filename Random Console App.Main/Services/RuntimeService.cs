namespace Random_Console_App.Main.Services
{
    public class RuntimeService
    {
        public static void ExitGracefully()
        {
            Console.WriteLine("Application closed!");
            Environment.Exit(0);
        }
    }
}