using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJackController
    {
        private Random rand;
        private int[,] infoUser;
        private Card listecarte;
        private Deck deck;
        private Hand hand;
        private int score;
        private int scoreC;
        private int tempscoreJoueur;
        private int tempscoreCroup;
        private int nbPartie;
        private int nbTournoie; //nb de tournoies gagnées
        private List<string> coeur;
        private List<string> carreau;
        private List<string> pique;
        private List<string> trefle;
        private List<string> templist;
        public BlackJackController()
        {
            rand = new Random();
            listecarte = new Card();
            deck = new Deck();
            hand = new Hand();
            score = 0;
            tempscoreJoueur = 0;
            tempscoreCroup = 0;
            nbPartie = 0;
            nbTournoie = 0;
            infoUser = new int[2, 3];
            scoreC = 0;
        }
        public Deck Deck { get => deck; set => deck = value; }
        
        public int NbPartie { get => nbPartie; set => nbPartie = value; }
        public int NbTournoie { get => nbTournoie; set => nbTournoie = value; }
        public int Score { get => score; set => score = value; }

        public void menuBJ()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Bienvenue sur le jeu BLACK JACK");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Veuillez faire le choix parmi les 2 options suivantes:");
            Console.WriteLine("1- Initialiser une nouvelle partie");
            Console.WriteLine("2- Fin de partie");            
            choixmenuBJ();
        }
        public void menuencours()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Veuillez faire le choix parmi les 3 options suivantes:");
            Console.WriteLine("1- une nouvelle carte?");
            Console.WriteLine("2- conserver sa mise.");
            Console.WriteLine("3- afficher mes cartes");
            choixmenuencours();
        }
        public void choixmenuBJ()
        {
            string choice = Console.ReadLine();
            bool erreur = false;
            switch (choice)
            {
                case "1":
                    nbPartie++;
                    initBJ();
                    break;
                case "2":
                    findepartie();
                    break;
                default:
                    erreur = true;
                    erreurmenuBJ(erreur);
                    break;
            }
        }
        public void erreurmenuBJ(bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Veuillez choisir parmi les numéros ci-dessus.");
            }
            choixmenuBJ();
        }
        public void choixmenuencours()
        {
            string choice = Console.ReadLine();
            bool erreur = false;
            switch (choice)
            {
                case "1":
                    hand.NbCard++;
                    tirercarte();
                    break;
                case "2":
                    conservermise();
                    break;
                case "3":
                    affichercartes();
                    break;
                default:
                    erreur = true;
                    erreurmenuencours(erreur);
                    break;
            }
        }
        public void erreurmenuencours(bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Veuillez choisir parmi les numéros ci-dessus.");
            }
            choixmenuencours();
        }
        public void initBJ()
        {
            listecarte.initCard();
            hand.Jouer();
            deck.Jouer();
            templist = new List<string>();
            int jeu1 = rand.Next(listecarte.LisCard.Count());
            hand.Jeu.Add(listecarte.LisCard[jeu1]);
            listecarte.LisCard.RemoveAt(jeu1);
            int jeu2 = rand.Next(listecarte.LisCard.Count());
            hand.Jeu.Add(listecarte.LisCard[jeu2]);
            listecarte.LisCard.RemoveAt(jeu2);
            hand.NbCard = hand.Jeu.Count;
            for(int i=0; i < hand.Jeu.Count; i++)
            {
                Console.WriteLine(hand.Jeu[i]);
            }
            menuencours();
        }
        
        public void affichercartes()
        {
            coeur = new List<string>();
            carreau = new List<string>();
            pique = new List<string>();
            trefle = new List<string>();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Coeur" + "\t" + "Carreau" + "\t" + "Pique" + "\t" + "Trèfle");
            for (int i = 0; i < hand.NbCard; i++)
            {
                if (hand.Jeu[i].Contains("Co"))
                {
                    string Co=hand.Jeu[i].Replace("Co", "");
                    coeur.Add(Co);
                }
                else if (hand.Jeu[i].Contains("Ca"))
                {
                    string Ca = hand.Jeu[i].Replace("Ca", "");
                    carreau.Add(Ca);
                }
                else if (hand.Jeu[i].Contains("P"))
                {
                    string P = hand.Jeu[i].Replace("P", "");
                    pique.Add(P);
                }
                else if (hand.Jeu[i].Contains("T"))
                {
                    string T = hand.Jeu[i].Replace("T", "");
                    trefle.Add(T);
                } 
            }
            remplirvide();
            templist.AddRange(coeur);
            templist.AddRange(carreau);
            templist.AddRange(pique);
            templist.AddRange(trefle);

            for (int i = 0; i < hand.NbCard; i++)
            {
                
                Console.WriteLine(coeur[i]+"\t"+carreau[i]+"\t"+pique[i]+"\t"+trefle[i]);
            }
            menuencours();
        }
        public void remplirvide()
        {
            while(coeur.Count()< hand.NbCard)
            {
                coeur.Add("0");
            }
            while (carreau.Count() < hand.NbCard)
            {
                carreau.Add("0");
            }
            while (pique.Count() < hand.NbCard)
            {
                pique.Add("0");
            }
            while (trefle.Count() < hand.NbCard)
            {
                trefle.Add("0");
            }
            coeur.Sort();
            coeur.Reverse();
            carreau.Sort();
            carreau.Reverse();
            pique.Sort();
            pique.Reverse();
            trefle.Sort();
            trefle.Reverse();
        }
        public void tirercarte()
        {
            int jeu = rand.Next(listecarte.LisCard.Count());
            hand.Jeu.Add(listecarte.LisCard[jeu]);
            listecarte.LisCard.RemoveAt(jeu);
            for (int i = 0; i < hand.Jeu.Count; i++)
            {
                Console.WriteLine(hand.Jeu[i]);
            }
            menuencours();
        }
        public void conservermise()
        {
            calculscorejoueur();
            tirageCroupier();
            afficherGagnant();
            menuBJ();
        }
        public void tirageCroupier()
        {
            if (tempscoreJoueur >= 21)
            {
                return;
            }
            while (tempscoreCroup < tempscoreJoueur && tempscoreCroup<21)
            {
                int jCroup = rand.Next(listecarte.LisCard.Count());
                deck.JeuC.Add(listecarte.LisCard[jCroup]);
                listecarte.LisCard.RemoveAt(jCroup);
                calculscoreCroup();
            }
        }
        public int calculscoreCroup()
        {
            List<string> tempLcroup = new List<string>();
            string val = "";
            for(int i=0;i<deck.JeuC.Count();i++)
            {
                if (deck.JeuC[i].Contains("Co"))
                {
                    val=deck.JeuC[i].Replace("Co", "");
                }
                if (deck.JeuC[i].Contains("Ca"))
                {
                    val=deck.JeuC[i].Replace("Ca", "");
                }
                if (deck.JeuC[i].Contains("P"))
                {
                    val = deck.JeuC[i].Replace("P", "");
                }
                if (deck.JeuC[i].Contains("T"))
                {
                    val=deck.JeuC[i].Replace("T", "");
                }
                tempLcroup.Add(val);
            }
            foreach(string x in tempLcroup)
            {
                if (x.Equals("R") || x.Equals("D") || x.Equals("V"))
                {
                    tempscoreCroup = tempscoreCroup + 10;
                }
                if (x.All(char.IsDigit))
                {
                    int z = Convert.ToInt32(x);
                    tempscoreCroup = tempscoreCroup + z;
                }
                if (x.Equals("A"))
                {
                    int z = 0;
                    if (tempscoreCroup < 11)
                    {
                        z = 11;
                    }
                    else
                    {
                        z = 1;
                    }
                    tempscoreCroup = tempscoreCroup + z;
                }
            }
            return tempscoreCroup;
        }
        public int calculscorejoueur()
        {
            foreach(var x in templist)
            {
                if (x.Equals("R")|| x.Equals("D")|| x.Equals("V"))
                {
                    tempscoreJoueur = tempscoreJoueur + 10;
                }
                if (x.All(char.IsDigit))
                {
                    int z = Convert.ToInt32(x);
                    tempscoreJoueur = tempscoreJoueur + z;
                }
                if (x.Equals("A"))
                {
                    int z = demanderAJoueur();
                    tempscoreJoueur = tempscoreJoueur + z;
                }
            }
            return tempscoreJoueur;
        }
        public int demanderAJoueur()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Voulez-vous attribuer 1 ou 11 pour votre As?");
            Console.WriteLine("Veuillez taper votre réponse:");
            string rep = Console.ReadLine();
            verifsaisie(rep);
            int reponse = Convert.ToInt32(rep);
            return reponse;
        }
        public void verifsaisie(string reponse)
        {
            while ((!reponse.All(Char.IsDigit)) || reponse!="1" && reponse!="11")
            {
                Console.WriteLine("Veuillez saisir 1 ou 11:");
                reponse = Console.ReadLine();
            }
        }
        public void afficherGagnant()
        {
            
            if ((tempscoreCroup<tempscoreJoueur && tempscoreJoueur < 21) || (tempscoreJoueur<21 && tempscoreCroup>21)|| tempscoreJoueur==21)
            {
                score++;
                nbTournoie = score / 4;
                Console.WriteLine("Vous avez gagnez la partie.");
            } 
            else if ((tempscoreCroup>tempscoreJoueur && tempscoreCroup <21)|| tempscoreJoueur>21)
            {
                scoreC++;
                Console.WriteLine("Vous avez perdu la partie.");
            }else if (tempscoreCroup == tempscoreJoueur)
            {
                Console.WriteLine("Vous avez un match nul.");
            }
            infoUser[0, 0] = nbPartie;
            infoUser[0, 1] = score;
            infoUser[0, 2] = nbTournoie;
            infoUser[1, 0] = nbPartie;
            infoUser[1, 1] = scoreC;
            infoUser[1, 2] = scoreC/4;
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("              "+"\t"+"Partie" + "\t" + "Points" + "\t" + "Victoires");
            Console.WriteLine("Croupier"+"\t"+ infoUser[1, 0] + "\t" + infoUser[1, 1] + "\t" + infoUser[1, 2]);
            Console.WriteLine("Vous"+"\t"+ "\t" + infoUser[0, 0] + "\t" + infoUser[0, 1] + "\t" + infoUser[0, 2]);
        }
        public void findepartie()
        {
            Console.WriteLine("Que voulez-vous faire:");
            Console.WriteLine("1-retourner au menu principal");
            Console.WriteLine("2-redemarrer une nouvelle partie");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    initBJ();
                    break;
                default:
                    erreurmenuBJ(true);
                    break;
            }
        }
    }
}
