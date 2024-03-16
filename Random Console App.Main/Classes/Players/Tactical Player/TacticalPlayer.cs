using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players.Tactical_Player
{
    public class TacticalPlayer : Player
    {
        public TacticalPlayer(string name)
        {
            PlayerName = name;
        }

        public int RoundsLost { get; set; }
        public int RoundsWon { get; set; }
        public bool Won { get; set; }
        public Choice LastChoice { get; set; }

        public override Choice MakeChoice()
        {
            if (RoundsWon > RoundsLost)
            {
                //Scene: Lost last round but has still won more than lost

                //Scene: Tied last round and has won more than lost

                //Scene: Won last round and has won more than lost
                return LastChoice;
            }
            else if (RoundsWon < RoundsLost)
            {
                //Scene: Lost

                //Scene: Tied

                //Scene: Won
            }
            else if (RoundsLost == RoundsWon)
            {
                //Scene: Lost

                //Scene: Tied

                //Scene: Won
            }
            return LastChoice;
        }

        public override void ProcessResults(Result results, Player otherPlayer, Player thisPlayer)
        {
            if ((thisPlayer.RoundScore < otherPlayer.RoundScore))
            {
                Won = true;
                RoundsWon++;
            }
            else
            {
                Won = false;
                RoundsLost--;
            }
            LastChoice = thisPlayer.Choice;
        }
    }
}