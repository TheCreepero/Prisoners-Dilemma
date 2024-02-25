using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    public class Collaborator : Player
    {
        public Collaborator(string name)
        {
            PlayerName = name;
        }

        public override Choice MakeChoice()
        {
            return Choice.Cooperate;
        }

        public override void ProcessResults(Result results, Player otherPlayer)
        {
            //Nothing
        }
    }
}