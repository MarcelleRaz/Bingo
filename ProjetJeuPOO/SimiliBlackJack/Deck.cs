using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    public class Deck:IBlackJack
    {        
        private List<string> jeuC; //jeu du croupier
        public Deck()
        {            
        }
        public List<string> JeuC { get => jeuC; set => jeuC = value; }

        public void DealCard()
        {
            throw new NotImplementedException();
        }

        public void Jouer()
        {
            jeuC = new List<string>();
        }

        public void VoirScore()
        {
            throw new NotImplementedException();
        }
    }
}
