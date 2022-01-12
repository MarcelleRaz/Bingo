using System;
using ProjetJeuPOO.Bingo;
using ProjetJeuPOO.SimiliBlackJack;
using ProjetJeuPOO.SimiliPendu;

namespace ProjetJeuPOO
{
    class Controller
    {
        Utilisateur user = new Utilisateur();
        ProgramBingo bingo = new ProgramBingo();
        Pendu jeupendu = new Pendu();
        static void Main(string[] args)
        {
            Controller program = new Controller();
            program.saisieinfoUser();
            program.startMachine();
        }
        public void startMachine()
        {
            bool start = true;
            while (start == true)
            {
                menu3jeux();
            }
        }
        public void saisieinfoUser()
        {  
            Console.WriteLine("Veuillez saisir votre nom:");
            user.Nom = Console.ReadLine();
            user.InfoUser[0, 0] = "Bingo";
            user.InfoUser[1, 0] = "Black Jack";
            user.InfoUser[2, 0] = "Pendu";
            user.InfoUser[0, 1] = Convert.ToString(bingo.BingoPartie);
            user.InfoUser[0, 2] = Convert.ToString(bingo.NbBingo);
            user.InfoUser[2, 1] = Convert.ToString(jeupendu.NPartie);
            user.InfoUser[2, 2] = Convert.ToString(jeupendu.NVictoire);
        }
        public void afficheinfoUser()
        {
            user.InfoUser[0, 1] = Convert.ToString(bingo.BingoPartie);
            user.InfoUser[0, 2] = Convert.ToString(bingo.NbBingo);
            user.InfoUser[2, 1] = Convert.ToString(jeupendu.NPartie);
            user.InfoUser[2, 2] = Convert.ToString(jeupendu.NVictoire);
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Nom: " + user.Nom);
            Console.WriteLine("*****************************************************");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t" + "\t" + "Parties jouées"+"\t"+"\t"+"Nb de victoires");
                Console.WriteLine(user.InfoUser[i, 0] + "\t" + "\t" + user.InfoUser[i, 1] + "\t" + "\t" + "\t" + user.InfoUser[i, 2]);
            }
            Console.WriteLine("*****************************************************");
        }
        public void menu3jeux()
        {
            afficheinfoUser();
            Console.WriteLine("Veuillez faire le choix parmi les 3 jeux suivants:");
            Console.WriteLine("1- Bingo");
            Console.WriteLine("2- Simili Black Jack");
            Console.WriteLine("3- Le pendu");
            Console.WriteLine("4- Quitter");
            choixmenuUser();
        }
        public void choixmenuUser()
        {
            string choice = Console.ReadLine();
            bool erreur = false;
            switch (choice)
            {
                case "1":
                    bingo.menuBingo();
                    return;
                case "2":
                    //blackjack
                    break;
                case "3":
                    jeupendu.menuPendu();
                    break;
                case "4":
                    System.Environment.Exit(0);
                    break;
                default:
                    erreur = true;
                    erreurmenuUser(choice,erreur);
                    break;
            }
        }
        public void erreurmenuUser(string choice, bool erreur)
        {
            while (erreur == true)
            {
                erreur = false;
                Console.WriteLine("Veuillez choisir parmi les numéros ci-dessus.");
            }
            choixmenuUser();
        }
        public static void retourmenuppl()
        {
            
        }
    }
}
