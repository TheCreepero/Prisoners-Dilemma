using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes
{
    public class Result
    {
        public Result(int roundNumber, Choice player1Choice, Choice player2Choice)
        {
            RoundNumber = roundNumber;
            Player1Choice = player1Choice;
            Player2Choice = player2Choice;
        }

        public int RoundNumber { get; set; }
        public Choice Player1Choice { get; set; }
        public Choice Player2Choice { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        //Payoff T > R > P > S
        public void CalculateScore()
        {
            if (Player1Choice == Choice.Cooperate && Player2Choice == Choice.Cooperate)
            {
                //Payoff R
                Console.WriteLine("Both players cooperate! Each player gets 2 years in prison.");
                Player1Score = 2;
                Player2Score = 2;
            }
            else if (Player1Choice == Choice.Defect && Player2Choice == Choice.Defect)
            {
                //Lower payoff P
                Console.WriteLine("Both players defect! Each player gets 3 years in prison.");
                Player1Score = 3;
                Player2Score = 3;
            }
            else if (Player1Choice == Choice.Cooperate && Player2Choice == Choice.Defect)
            {
                //P1 gets lowest payoff S, P2 gets highest payoff T
                Console.WriteLine("Player 1 cooperates and Player 2 defects! Player 1 gets 5 years in prison and Player 2 goes free.");
                Player1Score = 5;
                Player2Score = 0;
            }
            else if (Player1Choice == Choice.Defect && Player2Choice == Choice.Cooperate)
            {
                //P2 gets lowest payoff S, P1 gets highest payoff T
                Console.WriteLine("Player 1 defects and Player 2 cooperates! Player 1 goes free and Player 2 gets 5 years in prison.");
                Player1Score = 0;
                Player2Score = 5;
            }
        }
    }

    public class GameResult
    {
        public GameInfo Info { get; set; }
        public List<Result> Results { get; set; }
        public int Player1FinalScore { get; set; }
        public int Player2FinalScore { get; set; }
    }

    public class GameInfo
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public string Player1Type { get; set; }
        public string Player2Type { get; set; }
    }
}