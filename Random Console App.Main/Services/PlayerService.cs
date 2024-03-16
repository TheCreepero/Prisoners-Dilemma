using Random_Console_App.Main.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Services
{
    public class PlayerService
    {
        public void BasicRoundEvaluation(Result results, Player otherPlayer, Player thisPlayer)
        {
        }

        public static Choice Opposite(Choice choice)
        {
            if (choice == Choice.Cooperate)
            {
                return Choice.Defect;
            }
            else if (choice == Choice.Defect)
            {
                return Choice.Cooperate;
            }
            return choice;
        }
    }
}