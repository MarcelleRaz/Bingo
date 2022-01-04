using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

// Classe représentant un objet carte pour le joueur.
// Un joueur a au minimum une carte.

namespace ProjetJeuPOO.Bingo
{
    public class BingoCard : IBingoBoulier
    {
        private int[,] card1;
        private int[,] card2;
        private int[,] card3;
        private int[,] card4;
        private string [] entete;
        //private List<int> valB;
        //private List<int> valI;
        //private List<int> valN;
        //private List<int> valG;
        //private List<int> valO;
        private int numCard;

        public BingoCard()
        {
            
        }
        public BingoCard(int numero)
        {
            this.numCard = numero;
            card1 = new int[5,5];
            card2 = new int[5, 5];
            card3 = new int[5, 5];
            card4 = new int[5, 5];

            //this.bingoannonceur = new ArrayList();
            entete = new string[5] { "B", "I", "N", "G", "O" };

            //valB = new List<int>();
            //valI = new List<int>();
            //valN = new List<int>();
            //valG = new List<int>();
            //valO = new List<int>();
        }
        
        public string[] Entete { get => entete; set => entete = value; }
        //public List<int> ValB { get => valB; set => valB = value; }
        //public List<int> ValI { get => valI; set => valI = value; }
        //public List<int> ValN { get => valN; set => valN = value; }
        //public List<int> ValG { get => valG; set => valG = value; }
        //public List<int> ValO { get => valO; set => valO = value; }
        public int NumCard { get => numCard; set => numCard = value; }
        public int[,] Card1 { get => card1; set => card1 = value; }
        public int[,] Card2 { get => card2; set => card2 = value; }
        public int[,] Card3 { get => card3; set => card3 = value; }
        public int[,] Card4 { get => card4; set => card4 = value; }


        //public ArrayList Bingoannonceur { get => bingoannonceur; set => bingoannonceur = value; }



        public ArrayList creerbingoAnnonceur()
        {
            return null;
        }

        void IBingoBoulier.add(BingoBall element)
        {
            //bingoannonceur.Add(entete);
            //bingoannonceur.Add(element);
        }

        BingoBall IBingoBoulier.getRanbomBall()
        {
            return null;
        }

        int IBingoBoulier.getSize()
        {
            throw new NotImplementedException();
        }

        bool IBingoBoulier.isEmpty()
        {
            throw new NotImplementedException();
        }

        void IBingoBoulier.restartBoulier()
        {
            throw new NotImplementedException();
        }

        
    }
}
