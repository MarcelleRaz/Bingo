using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProjetJeuPOO.Bingo;

namespace ProjetJeuPOO
{
    public class ProgramBingo
    {
        protected BingoBall ball;
        private ArrayList bingoannonceur;
        private BingoCard bingoCarduser;
        private int numcard;
        private string[] entete;
        private List<int> valB_a;
        private List<int> valI_a;
        private List<int> valN_a;
        private List<int> valG_a;
        private List<int> valO_a;
        private int bingoPartie;
        private int nbBingo;
        private List<int> listball;
        private Random rand;
        private bool menuppl;

        public ProgramBingo()
        {
            ball = new BingoBall();
            rand = new Random();
            bingoannonceur = new ArrayList();
            entete = new string[5] { "B", "I", "N", "G", "O" };
            bingoCarduser = new BingoCard(numcard);
            numcard = bingoCarduser.NumCard;
            valB_a = new List<int>();
            valI_a = new List<int>();
            valN_a = new List<int>();
            valG_a = new List<int>();
            valO_a = new List<int>();
            menuppl = false;
            for (int i = 0; i <15; i++)
            {
                valB_a.Add(0);
                valI_a.Add(0);
                valN_a.Add(0);
                valG_a.Add(0);
                valO_a.Add(0);
            }
            bingoannonceur.Add(valB_a);
            bingoannonceur.Add(valI_a);
            bingoannonceur.Add(valN_a);
            bingoannonceur.Add(valG_a);
            bingoannonceur.Add(valO_a);
            nbBingo = 0;
            bingoPartie = 0;
        }
        public ArrayList Bingoannonceur { get => bingoannonceur; set => bingoannonceur = value; }
        public BingoCard BingoCarduser { get => bingoCarduser; set => bingoCarduser = value; }
        public int NbBingo { get => nbBingo; set => nbBingo = value; }
        public int BingoPartie { get => bingoPartie; set => bingoPartie = value; }
        public bool Menuppl { get => menuppl; set => menuppl = value; }

        public void menuBingo()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Bienvenue sur le jeu BINGO");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Veuillez faire le choix parmi les 5 options suivantes:");
            Console.WriteLine("1- Initialiser une nouvelle partie");
            Console.WriteLine("2- Visualiser une des cartes du joueur");
            Console.WriteLine("3- Visualiser la carte de l'annonceur");
            Console.WriteLine("4- Tirer une boule");
            Console.WriteLine("5- Fin de partie");
            string choice = Console.ReadLine();
            choixmenuBingo(choice);
        }
        public void choixmenuBingo(string choice)
        {
            bool erreur = false;

            switch (choice)
            {
                case "1":
                    initBingo();
                    break;
                case "2":
                    choixCard();
                    break;
                case "3":
                    visualisannonceurCard();
                    break;
                case "4":
                    tirerboule();
                    break;
                case "5":
                    findepartie();
                    break;
                default:
                    erreur = true;
                    erreurmenubingo(choice, erreur);
                    break;
            }
        }
        public void erreurmenubingo(string choice, bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Veuillez choisir parmi les numéros ci-dessus.");
            }
            choixmenuBingo(choice);
        }
        public void initBingo()
        {
            bingoPartie++;
            bingoCarduser.Card1 = null;
            bingoCarduser.Card2 = null;
            bingoCarduser.Card3 = null;
            bingoCarduser.Card4 = null;
            listball = new List<int>();
            Console.WriteLine("Vous avez droit à un maximum de 4 cartes. Combien de carte désirez-vous avoir?");
            Utilisateur.Nbcard = verifchoixnbCard();
            Console.WriteLine($"Vous avez {Utilisateur.Nbcard} cartes.");
            multiplecard();
            remplirboulier();
            menuBingo();
        }
        public void remplirboulier()
        {
            for (int i = 0; i < 75; i++)
            {
                listball.Add(i + 1);
            }
        }
        public int verifchoixnbCard()
        {
            string _nbcard = Console.ReadLine();
            while ((!_nbcard.All(char.IsDigit)) || Convert.ToDouble(_nbcard) <= 0 || Convert.ToDouble(_nbcard) > 4)
            {
                Console.WriteLine("Il y a erreur dans le nombre de carte. Veuillez saisir un autre chiffre.");
                _nbcard = Console.ReadLine();
            }
            int nbcard = Convert.ToInt32(_nbcard);

            return nbcard;
        }
        public void visualisUserCard(int[,] tempocard)
        {
            foreach (string c in entete)
            {
                Console.Write(c + "\t");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(tempocard[i, 0] + "\t" + tempocard[i, 1] + "\t" + tempocard[i, 2] + "\t" + tempocard[i, 3] + "\t" + tempocard[i, 4]);
            }
            menuBingo();
        }
        public void choixCard()
        {
            Console.WriteLine("Quel numéro de carte voulez-vous voir?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    visualisUserCard(bingoCarduser.Card1);
                    break;
                case "2":
                    visualisUserCard(bingoCarduser.Card2);
                    break;
                case "3":
                    visualisUserCard(bingoCarduser.Card3);
                    break;
                case "4":
                    visualisUserCard(bingoCarduser.Card4);
                    break;
                default:
                    break;
            }
        }
        public void visualisannonceurCard()
        {
            foreach (string c in entete)
            {
                Console.Write(c + "\t");
            }
            Console.WriteLine("\n");
            trierNumAnnonceur();
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(valB_a[i] + "\t" + valI_a[i] + "\t" + valN_a[i] + "\t" + valG_a[i] + "\t" + valO_a[i]);
            }
            menuBingo();
        }
        public void tirerboule()
        {
            int index = rand.Next(listball.Count);
            Console.WriteLine($"Vous avez tiré la boule {listball[index]}");
            changerNumannonceur(listball[index]);
            verifcarduser(listball[index]);
            listball.Remove(listball[index]);
            menuBingo();
        }
        public void changerNumannonceur(int num)
        {
            ball.Number = num;
            classerball();
            trierNumAnnonceur();
        }
        public void changeNumUser(int[,] tempocard, int x)
        {
            for (int i = 0; i < 5; i++)
            { for (int j = 0; j < 5; j++)
                {
                    if (tempocard[i, j] == x)
                    {
                        tempocard[i, j] = 0;
                    }
                }
            }
        }
        public void verifcarduser(int x)
        {
            int z = Utilisateur.Nbcard;
            switch (z)
            {
                case 1:
                    changeNumUser(bingoCarduser.Card1,x);
                    matchcardUser(bingoCarduser.Card1);
                    break;
                case 2:
                    changeNumUser(bingoCarduser.Card1, x);
                    matchcardUser(bingoCarduser.Card1);
                    changeNumUser(bingoCarduser.Card2, x);
                    matchcardUser(bingoCarduser.Card2);
                    break;
                case 3:
                    changeNumUser(bingoCarduser.Card1, x);
                    matchcardUser(bingoCarduser.Card1);
                    changeNumUser(bingoCarduser.Card2, x);
                    matchcardUser(bingoCarduser.Card2);
                    changeNumUser(bingoCarduser.Card3, x);
                    matchcardUser(bingoCarduser.Card3);
                    break;
                case 4:
                    changeNumUser(bingoCarduser.Card1, x);
                    matchcardUser(bingoCarduser.Card1);
                    changeNumUser(bingoCarduser.Card2, x);
                    matchcardUser(bingoCarduser.Card2);
                    changeNumUser(bingoCarduser.Card3, x);
                    matchcardUser(bingoCarduser.Card3);
                    changeNumUser(bingoCarduser.Card4, x);
                    matchcardUser(bingoCarduser.Card4);
                    break;
            }
        }
        public void matchcardUser(int [,]tempocard)
        {
            for(int i = 0; i < 5; i++)
            {
                if(tempocard[i, 0].Equals(0) && tempocard[i, 1].Equals(0) && tempocard[i, 2].Equals(0) && tempocard[i, 3].Equals(0)&& tempocard[i, 4].Equals(0))
                {
                    nbBingo++;
                    Console.WriteLine("Vous avez "+ nbBingo +" BINGO!");
                }
            }
            if (tempocard[0, 0].Equals(0) && tempocard[3, 3].Equals(0)&& tempocard[1, 1].Equals(0)&& tempocard[4, 4].Equals(0))
            {
                nbBingo++;
                Console.WriteLine("Vous avez " + nbBingo + " BINGO!");
            }
            if (tempocard[4, 0].Equals(0) && tempocard[3, 1].Equals(0) && tempocard[1,3].Equals(0) && tempocard[0, 4].Equals(0))
            {
                nbBingo++;
                Console.WriteLine("Vous avez " + nbBingo + " BINGO!");
            }
        }
        public BingoBall classerball()
        {
            if (ball.Number<=15 && ball.Number >= 1)
            {
                for(int i = 0; i < valB_a.Count; i++)
                {
                    if (valB_a[i] == 0)
                    {
                        valB_a[i]=(ball.Number);
                        break;
                    }
                }
            }
            if (ball.Number <= 30 && ball.Number >= 16)
            {
                for (int i = 0; i < valI_a.Count; i++)
                {
                    if (valI_a[i] == 0)
                    {
                        valI_a[i] = (ball.Number);
                        break;
                    }
                }
            }
            if (ball.Number <= 45 && ball.Number >= 31)
            {
                for (int i = 0; i < valN_a.Count; i++)
                {
                    if (valN_a[i] == 0)
                    {
                        valN_a[i] = (ball.Number);
                        break;
                    }
                }
            }
            if (ball.Number <= 60 && ball.Number >= 45)
            {
                for (int i = 0; i < valG_a.Count; i++)
                {
                    if (valG_a[i] == 0)
                    {
                        valG_a[i] = (ball.Number);
                        break;
                    }
                }
            }
            if (ball.Number <= 75 && ball.Number >= 61)
            {
                for (int i = 0; i < valO_a.Count; i++)
                {
                    if (valO_a[i] == 0)
                    {
                        valO_a[i] = (ball.Number);
                        break;
                    }
                }
            }
            return ball;
        }
        public void trierNumAnnonceur() 
        {
            valB_a.Sort();
            valI_a.Sort();
            valN_a.Sort();
            valG_a.Sort();
            valO_a.Sort();
        }
        public int [,] creerbingocard()
        {
            List<int> valB= new List<int>();
            List<int> valI = new List<int>();
            List<int> valN = new List<int>();
            List<int> valG = new List<int>();
            List<int> valO = new List<int>();
            int[,] card = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                valB.Add(rand.Next(1, 15));
                valI.Add(rand.Next(16, 30));
                valN.Add(rand.Next(31, 45));
                valG.Add(rand.Next(46, 60));
                valO.Add(rand.Next(61, 75));
            }
            for (int i = 0; i < 5; i++)
            {
                card[i, 0] = valB[i];
                card[i, 1] = valI[i];
                card[i, 2] = valN[i];
                card[i, 3] = valG[i];
                card[i, 4] = valO[i];
            }
            card[2, 2] = 0;
            return card;
        }
        public void multiplecard()
        {
            int z = Utilisateur.Nbcard;
            switch (z)
            {
                case 1:
                    bingoCarduser.Card1 = creerbingocard();
                    break;
                case 2:
                    bingoCarduser.Card1 = creerbingocard();
                    bingoCarduser.Card2 = creerbingocard();
                    break;
                case 3:
                    bingoCarduser.Card1 = creerbingocard();
                    bingoCarduser.Card2 = creerbingocard();
                    bingoCarduser.Card3 = creerbingocard();
                    break;
                case 4:
                    bingoCarduser.Card1 = creerbingocard();
                    bingoCarduser.Card2 = creerbingocard();
                    bingoCarduser.Card3 = creerbingocard();
                    bingoCarduser.Card4 = creerbingocard();
                    break;
            }
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
                    initBingo();
                    break;
                default:
                    erreurmenubingo(choice, true);
                    break;
            }
            
        }
    }
}
