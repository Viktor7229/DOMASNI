using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.CSharp.Adv.Class01.ConsoleApp2.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public float TotalGamesPlayed { get; set; }

        public float GamesWon { get; set; }
        public float GamesTied { get; set; }
        public UserChoice PlayerChoice { get; set; }

        public void GamesPlayed()
        {
            TotalGamesPlayed++;
        }
    }
}

