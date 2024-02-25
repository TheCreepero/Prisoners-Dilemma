using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    public class RandomPlayer : Player
    {
        public RandomPlayer(string name, double chance)
        {
            PlayerName = name;
            ChanceToCooperate = (100 - chance) / 100;
        }

        public double ChanceToCooperate { get; set; }

        public override Choice MakeChoice()
        {
            Random rand = new Random();

            return rand.NextDouble() < ChanceToCooperate ? Choice.Cooperate : Choice.Defect;
        }

        public override void ProcessResults(Result results)
        {
            //Nothing
        }
    }
}