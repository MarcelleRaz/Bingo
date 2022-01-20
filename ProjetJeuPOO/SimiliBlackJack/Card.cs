using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    public class Card
    {
        private List<string> lisCard;
        public Card()
        {
            
        }
        
        public List<string> LisCard { get => lisCard; set => lisCard = value; }
        public void initCard()
        {
            lisCard = new List<string>{"ACo","2Co","3Co","4Co","5Co","6Co","7Co","8Co","9Co","10Co","RCo","DCo","VCo",
            "ACa", "2Ca", "3Ca", "4Ca", "5Ca", "6Ca", "7Ca", "8Ca", "9Ca", "10Ca", "RCa", "DCa", "VCa",
            "AP", "2P", "3P", "4P", "5P", "6P", "7P", "8P", "9P", "10P", "RP", "DP", "VP",
            "AT", "2T", "3T", "4T", "5T", "6T", "7T", "8T", "9T", "10T", "RT", "DT", "VT" };
        }
    }
}
