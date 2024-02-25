﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Random_Console_App.Main.Constants;

namespace Random_Console_App.Main.Classes.Players
{
    public class Vengeful : Player
    {
        public Vengeful(string name)
        {
            PlayerName = name;
            Revenge = false;
        }

        public bool Revenge { get; set; }

        public override Choice MakeChoice()
        {
            if (Revenge)
                return Choice.Defect;
            return Choice.Cooperate;
        }

        public override void ProcessResults(Result results)
        {
            if (results.Player2Choice == Choice.Defect)
                Revenge = true;
        }
    }
}