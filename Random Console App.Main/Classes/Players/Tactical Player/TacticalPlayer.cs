using static Random_Console_App.Main.Constants;
using Random_Console_App.Main.Services;

namespace Random_Console_App.Main.Classes.Players.Tactical_Player
{
    public class TacticalPlayer : Player
    {
        public TacticalPlayer(string name)
        {
            PlayerName = name;
            FirstRound = true;
        }

        public int RoundsLost { get; set; }
        public int RoundsWon { get; set; }
        public bool Won { get; set; }
        public bool Tied { get; set; }
        public bool FirstRound { get; set; }
        public Choice LastChoice { get; set; }

        public override Choice MakeChoice()
        {
            if (RoundResult != null)
            {
                if (RoundResult.RoundsWon > RoundResult.RoundsLost)
                {
                    //Scene: Lost last round but has still won more than lost
                    if (!Won)
                    {
                        return PlayerService.Opposite(RoundResult.RoundChoice);
                    }

                    //Scene: Tied last round and has won more than lost
                    if (!Won && Tied)
                    {
                        return RoundResult.RoundChoice;
                    }

                    //Scene: Won last round and has won more than lost
                    if (Won)
                    {
                        return RoundResult.RoundChoice;
                    }
                }
                else if (RoundResult.RoundsWon < RoundResult.RoundsLost)
                {
                    //Scene: Lost
                    if (!Won)
                    {
                        return PlayerService.Opposite(RoundResult.RoundChoice);
                    }

                    //Scene: Tied
                    if (!Won && Tied)
                    {
                        return PlayerService.Opposite(RoundResult.RoundChoice);
                    }

                    //Scene: Won
                    return RoundResult.RoundChoice;
                }
                else if (RoundResult.RoundsLost == RoundResult.RoundsWon && !FirstRound)
                {
                    //Scene: Lost
                    if (!Won)
                    {
                        return PlayerService.Opposite(RoundResult.RoundChoice);
                    }

                    //Scene: Tied
                    if (!Won && Tied)
                    {
                        return PlayerService.Opposite(RoundResult.RoundChoice);
                    }

                    if (Won)
                    {
                        return RoundResult.RoundChoice;
                    }

                    //Scene: Won
                    return RoundResult.RoundChoice;
                }
            }

            return Choice.Cooperate;
        }

        public override void ProcessResults(Result results, Player otherPlayer, Player thisPlayer)
        {
            FirstRound = false;
            RoundResult.GetResults(thisPlayer, otherPlayer);
        }
    }
}