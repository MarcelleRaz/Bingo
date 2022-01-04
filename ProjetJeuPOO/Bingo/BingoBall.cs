using System;
using System.Collections.Generic;
using System.Text;

//Classe représentant un objet boule 

namespace ProjetJeuPOO.Bingo
{
    public class BingoBall
    {
        private int number;
        private char letter;
        private Random rand;

        public BingoBall()
        {
            rand = new Random();
        }
        public int Number { get => number; set => number = value; }
        public char Letter { get => letter; set => letter = value; }
        public Random Rand { get => rand; set => rand = value; }
    }
}
