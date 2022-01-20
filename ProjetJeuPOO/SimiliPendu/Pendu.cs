using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ProjetJeuPOO.SimiliPendu
{
    public class Pendu : IPendu
    {
        private int [,] infopenduUser;
        private int nTournoie; //nb tournoies gagnées=3 victoires
        private int nPartie; //nb parties jouées
        private int nPoint;// nb points gagnées
        private int nVictoire; // nb victoire=3points
        private ListeDeMots mot;
        private Random rand;
        private char[] motenchar;
        private char[] motsslettre;
        private int essai;
        private string motatrouver;
        
        public int NTournoie { get => nTournoie; set => nTournoie = value; }
        public int NPartie { get => nPartie; set => nPartie = value; }
        public int NPoint { get => nPoint; set => nPoint = value; }
        public int[,] InfopenduUser { get => infopenduUser; set => infopenduUser = value; }
        public ListeDeMots Mot { get => mot; set => mot = value; }
        public Random Rand { get => rand; set => rand = value; }
        public char[] Motenchar { get => motenchar; set => motenchar = value; }
        public int Essai { get => essai; set => essai = value; }
        public int NVictoire { get => nVictoire; set => nVictoire = value; }

        public Pendu()
        {
            infopenduUser = new int [1, 4];
            nTournoie = 0;
            nPartie = 0;
            nPoint = 0;
            nVictoire = 0;
            rand = new Random();
            essai = 1;
            mot = new ListeDeMots();
        }
        public void calculPoints()
        {    
            nVictoire = nPoint / 3;
            nTournoie = nVictoire/ 3;
        }
         public void AfficherGagnant()
        {
            calculPoints();
            infopenduUser[0, 0] = nTournoie;
            infopenduUser[0, 1] = nPartie;
            infopenduUser[0, 2] = nPoint;
            infopenduUser[0, 3] = nVictoire;
            Console.WriteLine("Partie"+"\t"+"Points"+"\t"+"Victoires"+"\t"+"Tournoies gagnées");
            Console.WriteLine(infopenduUser[0, 1]+"\t"+ infopenduUser[0, 2]+"\t"+infopenduUser[0,3]+"\t"+ "\t" + infopenduUser[0, 0]);
        }
       
        public void menuPendu()
        {
            AfficherGagnant();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Bienvenue sur le jeu PENDU");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Veuillez faire le choix parmi les 2 options suivantes:");
            Console.WriteLine("1- Initialiser une nouvelle partie");
            Console.WriteLine("2- Fin de partie");
            choixmenuPendu();
        }
        public void choixmenuPendu()
        {
            string choice = Console.ReadLine();
            bool erreur = false;
            switch (choice)
            {
                case "1":
                    initPendu();
                    break;
                case "2":
                    findepartie();
                    break;
                default:
                    erreur = true;
                    erreurmenuPendu(erreur);
                    break;
            }
        }
        public void erreurmenuPendu(bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Veuillez choisir parmi les numéros ci-dessus.");
            }
            choixmenuPendu();
        }
        public string initPendu()
        {
            motatrouver = "";
            essai = 0;
            nPartie++;
            motsslettre = null;
            motenchar = null;
            int x = rand.Next(0,9);
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Je suis un mot à {0} caractères", mot.Lismots[x].Length);
            Console.WriteLine("*******************************************************************");
            mot.choixdeMot(Convert.ToString(x));
            motatrouver =mot.Lismots[x];
            motsslettre = new char[mot.Lismots[x].Length];
            motenchar = new char[mot.Lismots[x].Length];
            Console.WriteLine("Le mot à trouver est: ");
            for (int i = 0; i < mot.Lismots[x].Length; i++)
            {
                motsslettre[i] = '_';
                Console.Write(motsslettre[i]+" ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Qui suis-je?");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine( "Vous avez droit à 5 essais pour gagner la partie.");
            motenchar = motLettres(mot.Lismots[x]);
            choisirlettre();
            return motatrouver;
        }
        public void menujeuencours()
        {
            if (essai < 5)
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("Veuillez choisir parmis les suivants:");
                Console.WriteLine("1-choisir la prochaine lettre");
                Console.WriteLine("2-trouver le mot");
                Console.WriteLine("3-retourner au menu du jeu");
                Console.WriteLine("*******************************************************************");
                choixjeuencours();
            }
        }
        public void choixjeuencours()
        {
            bool erreur = false;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    essai++;
                    choisirlettre();
                    break;
                case "2":
                    essai++;
                    devinerMot();
                    break;
                case "3":
                    menuPendu();
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
            menujeuencours();
        }
        public bool veriflettre(string choixlettre)
        {
            bool erreur;
            if (choixlettre.All(char.IsDigit) || choixlettre.Length > 1 || choixlettre == null)
            {
                erreur = true;
                erreurchoixlettre(erreur);
            }
            else
            {
                erreur = false;
            }
            
            return erreur;
        }
        public char choisirlettre()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("vous avez {0} essai pour deviner votre mot à {1} caractères", 5-essai, motatrouver.Length);
            Console.WriteLine("Veuillez saisir votre lettre:");
            string choixlettre = Console.ReadLine();
            bool erreur=veriflettre(choixlettre);
            char lettre=' ';
            while(erreur==true)
            {
                choixlettre = Console.ReadLine();
                erreur = veriflettre(choixlettre);
            }
            if (erreur == false)
            {
                lettre = Convert.ToChar(choixlettre);
                convertenlettre(lettre);
            }
            return lettre;
        }
        public void erreurchoixlettre(bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Erreur de saisie. Veuillez saisir seulement une lettre:");
            }
        }
        public void devinerMot()
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("vous avez {0} essai pour deviner votre mot à {1} caractères", 5 - essai, motatrouver.Length);
            Console.WriteLine("Le mot à trouver est: ");
            Console.WriteLine();
            for (int i = 0; i < motsslettre.Count(); i++)
            {
                Console.Write(motsslettre[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Veuillez saisir votre réponse:");
            string reponse = Console.ReadLine();
            verifmot(reponse);
        }
        public void verifmot(string reponse)
        {
            if (reponse != motatrouver && essai == 4)
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine($"Le mot était: " + motatrouver);
                Console.WriteLine("Vous êtes pendu!");
                Console.WriteLine();
                Console.WriteLine("*******************************************************************");
                menuPendu();
            }
            if (reponse.Equals(motatrouver))
            {
                nPoint++;
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("Bravo! Vous avez trouvé le mot!");
                Console.WriteLine("*******************************************************************");
                if (nPoint % 3 == 0)
                {
                    nVictoire = nPartie / 3;
                    Console.WriteLine("Vous avez obtenue {0} victoire(s).",nVictoire);
                }
                menuPendu();
            }
            if (reponse != motatrouver && essai < 5)
            {
                menujeuencours();
            }
        }
        public char[] motLettres(string mot)
        {
            char[] motenLettres = mot.ToCharArray();
            return motenLettres;
        }
        public char [] convertenlettre(char lettre)
        {
            Console.WriteLine("Le mot à trouver est: ");
            for (int i = 0; i < motenchar.Length; i++)
            {
                if (motenchar[i] == lettre)
                {
                    motsslettre[i] = lettre;
                }
                Console.Write(motsslettre[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine("\n");
            string reponse = string.Join("",motsslettre);
            verifmot(reponse);
            return motsslettre;
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
                    initPendu();
                    break;
                default:
                    erreurmenuPendu(true);
                    break;
            }
        }
        public void Jouer()
        {
            throw new NotImplementedException();
        }
    }
}
