using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes
{
    public abstract class Player
    {
        public string PlayerName { get; set; }
        public Choice Choice { get; set; }

        public abstract Choice MakeChoice();

        public abstract void ProcessResults(Result results);
    }
}