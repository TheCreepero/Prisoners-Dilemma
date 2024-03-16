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
        public bool Won { get; set; }
        public bool Tied { get; set; }
        public int Score { get; set; }
        public Choice RoundChoice { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsLost { get; set; }

        public void GetResults(Player thisPlayer, Player otherPlayer) 
        {
            if ((thisPlayer.RoundScore < otherPlayer.RoundScore))
            {
                Won = true;
                RoundsWon++;
            }
            else if (thisPlayer.RoundScore == otherPlayer.RoundScore)
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
