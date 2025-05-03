public class Simulation
{
    public int nbTours;
    public int semaineActuelle;
    private Joueur? joueur1;
    private Plateau plateau;
    private Rose rose1;
    private Rose rose2;
    private Cerise cerise1;
    private Endive endive1;
    private Webcam webcam;

    public Simulation(int nbTours)
    {
        this.nbTours = nbTours;
        semaineActuelle = 1;
        plateau = new Plateau(9,6); // Initialisation du plateau
        
        rose1 = new Rose("Rose", "R"); // Création de deux roses : rose1 et rose2
        rose2 = new Rose("Rose", "R"); 
        cerise1 = new Cerise("Cerise", "C"); // Création d'une cerise
        endive1 = new Endive("Endive", "E"); // Création d'une cerise

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
        Console.WriteLine($"Tu as {nbTours} semaines pour obtenir le plus beau des jardins !");
        
        Console.ForegroundColor = ConsoleColor.Red;
        Thread.Sleep(2000);
        Console.WriteLine("⚠️ Attention, tu ne peux effectuer que 3 actions chaque semaine ! ⚠️  Bonne chance !");
        Thread.Sleep(4000);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        while(semaineActuelle <= nbTours)
        {   
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Semaine {semaineActuelle}"); // Annonce le numéro de la semaine 
            Console.ForegroundColor = ConsoleColor.White;
            joueur1!.NbActionsPossibles = 4; // Initialisation du nombre d'actions
            
            webcam.AfficherPlateau(plateau);
            
            foreach(var plante in joueur1.PlantesSurJardin) // On affiche toutes les plantes déjà plantées pour suivre leur évolution 
            {
                plante.AfficherDonnees(plante);
                Console.WriteLine();
                Console.WriteLine("Appuie sur une touche pour continuer");
                Console.ReadKey();
                Console.WriteLine();
            }

            int choix = 10; // Au hasard et différent de 0
            while(choix != 0 && joueur1.NbActionsPossibles!=0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Semaine {semaineActuelle}"); // Annonce le numéro de la semaine 
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"{joueur1!.Nom}, il te reste {joueur1.NbActionsPossibles} actions maximum !"); // Rappel du nombre d'actions 
                Console.WriteLine("Choisis l'action que tu souhaites effectuer :");
                Console.WriteLine("1. Semer ");
                Console.WriteLine("2. Passer à la semaine suivante");  
                choix = Convert.ToInt32(Console.ReadLine()!);

                Console.Clear();
                if(choix !=0)
                {
                    if(choix==1)
                    {
                        if(joueur1.InventaireSemis.Count!=0)
                        {
                            bool bonnePlante = false;
                            int numPlante = 0; // On déclare numPlante à l'extérieur de la boucle pour pouvoir l'utiliser en dehors
                            while(!bonnePlante)
                            {
                                Console.WriteLine("Quelle plante veux-tu semer ?"); // A COMPLETER QUAND ON AURA TOUTES LES PLANTES 
                                int index = 1;
                                foreach(var plante in joueur1.InventaireSemis) // On affiche toutes les plantes dans l'inventaire 
                                {
                                    Console.WriteLine($"{index}. {plante.Nom}");
                                    index++;
                                }
                                Console.WriteLine("Entre le numéro de la plante :");
                                numPlante = Convert.ToInt32(Console.ReadLine()!);

                                if(numPlante <=0 || numPlante > joueur1.InventaireSemis.Count) 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("La plante choisie n'est pas dans la liste ! Tape le bon numéro !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    bonnePlante = true;
                                }
                            }
                            
                            var planteChoisie = joueur1.InventaireSemis[numPlante - 1];
                            joueur1!.Semer(plateau, planteChoisie);
                            plateau.AfficherPlateau();
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tu ne peux plus semer de plantes, ton inventaire est vide !");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    }
                }
            }
            Console.Clear();
            semaineActuelle++;

        }   
                
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
        Console.WriteLine("--- Bienvenue");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans en semence");
        Thread.Sleep(1500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
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
        Console.WriteLine("Comment t'appelles-tu jeune jardinier ?");
        string nom = Convert.ToString(Console.ReadLine()!)!;
        joueur1 = new Joueur(nom); 

        // Ajout des deux roses dans l'inventaire de semis du joueur
        joueur1.InventaireSemis.Add(rose1);
        joueur1.InventaireSemis.Add(rose2);
        joueur1.InventaireSemis.Add(cerise1);
        joueur1.InventaireSemis.Add(endive1);
    }

}
