using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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
            if ((thisPlayer.RoundScore < otherPlayer.RoundScore) || (thisPlayer.RoundScore == 2 && otherPlayer.RoundScore == 2))
            {
                Won = true;
            }
            else if (thisPlayer.RoundScore == 3 && otherPlayer.RoundScore == 3)
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