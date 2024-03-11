using Random_Console_App.Main.Classes;
using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Services
{
    public class NoiseService
    {
        private readonly double NoiseChance;

        public NoiseService(double noiseChance = 10)
        {
            NoiseChance = (100 - noiseChance) / 100;
        }

        public Choice AddNoise(Player player)
        {
            Random rand = new Random();

            if (player.Choice == Choice.Cooperate)
                return rand.NextDouble() < NoiseChance ? Choice.Cooperate : Choice.Defect;
            else return rand.NextDouble() < NoiseChance ? Choice.Defect : Choice.Cooperate;
        }
    }
}