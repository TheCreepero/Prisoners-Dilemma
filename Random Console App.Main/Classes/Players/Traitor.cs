using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    public class Traitor : Player
    {
        public Traitor(string name)
        {
            PlayerName = name;
        }

        public override Choice MakeChoice()
        {
            return Choice.Defect;
        }

        public override void ProcessResults(Result results, Player otherPlayer, Player thisPlayer)
        {
            //Nothing here
        }
    }
}