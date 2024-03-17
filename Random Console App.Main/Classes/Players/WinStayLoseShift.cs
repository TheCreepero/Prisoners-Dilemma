using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    public class WinStayLoseShift : Player
    {
        public WinStayLoseShift(string name)
        {
            PlayerName = name;
            Won = true;
            LastChoice = Choice.Cooperate;
        }

        public bool Won { get; set; }
        public Choice LastChoice { get; set; }

        public override Constants.Choice MakeChoice()
        {
            if (!Won && LastChoice == Choice.Cooperate)
                return Choice.Defect;
            else if (!Won && LastChoice == Choice.Defect)
                return Choice.Cooperate;

            return LastChoice;
        }

        public override void ProcessResults(Result results, Player otherPlayer, Player thisPlayer)
        {
            RoundResult.GetResults(thisPlayer, otherPlayer);
            if ((thisPlayer.RoundResult.Score < otherPlayer.RoundResult.Score) || (thisPlayer.RoundResult.Score == 2 && otherPlayer.RoundResult.Score == 2))
            {
                Won = true;
            }
            else if (thisPlayer.RoundResult.Score == 3 && otherPlayer.RoundResult.Score == 3)
            {
                Won = false;
            }
            else
            {
                Won = false;
            }
            LastChoice = thisPlayer.Choice;
        }
    }
}