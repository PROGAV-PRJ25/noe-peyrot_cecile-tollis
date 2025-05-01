public class Simulation
{
    public int nbTours;
    public int semaineActuelle;

    private Joueur? joueur1;
    private Plateau plateau;
    private Rose rose1;
    private Rose rose2;
    private Webcam webcam;

    public Simulation(int nbTours)
    {
        this.nbTours = nbTours;
        semaineActuelle = 1;
        plateau = new Plateau(9,6); // Initialisation plateau
        
        rose1 = new Rose("Rose", "R"); // Création de deux roses : rose1 et rose2
        rose2 = new Rose("Rose", "R"); 

        webcam = new Webcam();

    }

    public void LancerSimulation()
    {
        Console.Clear();
        AfficherEffet();

        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(1000);
        InitialiserPartie();
        Console.WriteLine($"Bonjour {joueur1!.Nom} ! Et bienvenue dans ENSemenCe !!");
        Console.WriteLine($"Tu as {nbTours} semaines pour obtenir le plus beau des jardins");
        
        Console.ForegroundColor = ConsoleColor.Red;
        Thread.Sleep(1000);
        Console.WriteLine("⚠️ Attention, tu ne peut effectuer que 3 actions chaques semaines ! ⚠️ BONNE CHANCE");
        Thread.Sleep(2000);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        while(semaineActuelle <= nbTours)
        {   
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Semaine {semaineActuelle}"); //Annonce numéro de semaine 
            Console.ForegroundColor = ConsoleColor.White;
            joueur1!.NbActionsPossibles = 4; // Initialisation nombre actions
            
            webcam.AfficherPlateau(plateau);
            int choix = 10;
            while(choix != 0 && joueur1.NbActionsPossibles!=0)
            {
                Console.WriteLine($"{joueur1!.Nom}, il te reste {joueur1.NbActionsPossibles} actions maximum !"); // Rappel nombre actions 
                Console.WriteLine("Choisis l'action que tu souhaites effectuer");
                Console.WriteLine("1. Semer ");
                Console.WriteLine("0. Passer à la semaine suivante");
                choix = Convert.ToInt32(Console.ReadLine()!);

                if(choix !=0)
                {
                    if(choix ==1)
                    {
                        Console.WriteLine("Quelle plante voulez-vous semer ? (Ecrivez le nom)"); // A COMPLETER QUAND ON AURA TOUTES LES PLANTES 
                        int index = 1;
                        foreach(var plante in joueur1.InventaireSemis)
                        {
                            Console.WriteLine($"{index}. {plante.Nom}");
                            index++;
                        }
                        Console.WriteLine("Entrez le numéro de la plante :");
                        int numPlante = Convert.ToInt32(Console.ReadLine()!);

                        var planteChoisie = joueur1.InventaireSemis[numPlante - 1];
                        
                        joueur1!.Semer(plateau, planteChoisie);
                        plateau.AfficherPlateau();
                    }
                }
            }

        }   
        joueur1!.Semer(plateau, rose1); // Avec ! : joueur1 est garanti d'être initialisé
        plateau.AfficherPlateau();
        Thread.Sleep(1500);
        Console.Clear();
        joueur1.Semer(plateau, rose2);
        
        plateau.AfficherPlateau();
        
    }

    public void AfficherEffet()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("-");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("---");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue ");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe ");
        Thread.Sleep(1500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ");
        Thread.Sleep(1000);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe -");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe --");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe ---");
        Thread.Sleep(1500);
    }

    public void InitialiserPartie()
    {
        // Création d'un joueur 
        Console.WriteLine("Comment vous appelez vous jeune jardinier ?");
        string nom = Convert.ToString(Console.ReadLine()!)!;
        joueur1 = new Joueur(nom); 

        // Ajout des deux roses dans l'inventaire de semis du joueur
        joueur1.InventaireSemis.Add(rose1);
        joueur1.InventaireSemis.Add(rose2);
        
    }
}
