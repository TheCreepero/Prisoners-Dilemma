using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes
{
    public class RoundResult
    {
        public RoundResult()
        {
            Won = false;
            Tied = false;
            Score = 0;
            RoundChoice = Choice.Cooperate;
            RoundsWon = 0;
            RoundsLost = 0;
        }

        public bool Won { get; set; }
        public bool Tied { get; set; }
        public int Score { get; set; }
        public Choice RoundChoice { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsLost { get; set; }

        public void GetResults(Player thisPlayer, Player otherPlayer)
        {
            if ((thisPlayer.RoundResult.Score < otherPlayer.RoundResult.Score))
            {
                Won = true;
                RoundsWon++;
            }
            else if (thisPlayer.RoundResult.Score == otherPlayer.RoundResult.Score)
            {
                Won = false;
                Tied = true;
            }
            else
            {
                Won = false;
                RoundsLost--;
            }
            RoundChoice = thisPlayer.Choice;
        }
    }
}