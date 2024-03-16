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
        public bool Tied { get; set; }
        public Choice LastChoice { get; set; }

        public override Choice MakeChoice()
        {
            if (RoundsWon > RoundsLost)
            {
                //Scene: Lost last round but has still won more than lost
                if (!Won)
                {
                    if (LastChoice == Choice.Cooperate)
                    {
                        return Choice.Defect;
                    }
                    if (LastChoice == Choice.Defect)
                    {
                        return Choice.Cooperate;
                    }
                }

                //Scene: Tied last round and has won more than lost
                if (!Won && Tied)
                {
                    return LastChoice;
                }
                
                //Scene: Won last round and has won more than lost
                if (Won)
                {
                    return LastChoice;
                }
            }
            else if (RoundsWon < RoundsLost)
            {
                //Scene: Lost
                if (!Won)
                {
                    if (LastChoice == Choice.Cooperate)
                    {
                        return Choice.Defect;
                    }
                    if (LastChoice == Choice.Defect)
                    {
                        return Choice.Cooperate;
                    }
                }

                //Scene: Tied
                if (!Won && Tied)
                {
                    if (LastChoice == Choice.Cooperate)
                    {
                        return Choice.Defect;
                    }
                    if (LastChoice == Choice.Defect)
                    {
                        return Choice.Cooperate;
                    }
                }

                //Scene: Won
                return LastChoice;
            }
            else if (RoundsLost == RoundsWon)
            {
                //Scene: Lost
                if (!Won)
                {
                    if (LastChoice == Choice.Cooperate)
                    {
                        return Choice.Defect;
                    }
                    if (LastChoice == Choice.Defect)
                    {
                        return Choice.Cooperate;
                    }
                }

                //Scene: Tied
                if (!Won && Tied)
                {
                    if (LastChoice == Choice.Cooperate)
                    {
                        return Choice.Defect;
                    }
                    if (LastChoice == Choice.Defect)
                    {
                        return Choice.Cooperate;
                    }
                }

                if (Won)
                {
                    return LastChoice;
                }

                //Scene: Won
                return LastChoice;
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
            LastChoice = thisPlayer.Choice;
        }
    }
}