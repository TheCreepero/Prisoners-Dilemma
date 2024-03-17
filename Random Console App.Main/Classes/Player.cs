using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes
{
    public abstract class Player
    {
        protected Player()
        {
            RoundResult = new RoundResult();
        }

        public string PlayerName { get; set; }
        public Choice Choice { get; set; }

        public RoundResult RoundResult { get; set; }

        public abstract Choice MakeChoice();

        public abstract void ProcessResults(Result results, Player otherPlayer, Player thisPlayer);
    }
}