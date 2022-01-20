using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    public class Hand:IBlackJack
    {
        private List<string> jeu; //jeu du joueur
        private int nbCard;
        public Hand()
        {
            
        }
        public List<string> Jeu { get => jeu; set => jeu = value; }
        public int NbCard { get => nbCard; set => nbCard = value; }
        
        public void DealCard()
        {
            throw new NotImplementedException();
        }

        public void Jouer()
        {
            jeu = new List<string>();
            nbCard = 0;
        }

        public void VoirScore()
        {
            throw new NotImplementedException();
        }
    }
}
