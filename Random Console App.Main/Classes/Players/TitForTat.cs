using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    //TitForTat-player takes revenge one time if the other player defects,
    //but will go back to cooperating if the other player does so
    public class TitForTat : Player
    {
        public TitForTat(string name)
        {
            PlayerName = name;
        }

        public bool OneTimeRevenge { get; set; }

        public override Choice MakeChoice()
        {
            if (OneTimeRevenge)
                return Choice.Defect;
            return Choice.Cooperate;
        }

        public override void ProcessResults(Result results, Player otherPlayer)
        {
            if (otherPlayer.Choice == Choice.Defect)
                OneTimeRevenge = true;
            else if (otherPlayer.Choice == Choice.Cooperate)
                OneTimeRevenge = false;
        }
    }
}