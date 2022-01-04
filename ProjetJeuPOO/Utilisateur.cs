using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjetJeuPOO
{
    public class Utilisateur
    {
        private string nom;
        private string [,] infoUser;
        private static int nbcard;

        public Utilisateur()
        {
            infoUser = new string [3,3];
            
        }

        public string Nom { get => nom; set => nom = value; }
        public static int Nbcard { get => nbcard; set => nbcard = value; }
        public string[,] InfoUser { get => infoUser; set => infoUser = value; }
    }
}
