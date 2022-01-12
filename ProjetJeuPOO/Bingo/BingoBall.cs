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

        public BingoBall()
        {
        }
        public int Number { get => number; set => number = value; }
        public char Letter { get => letter; set => letter = value; }
    }
}
