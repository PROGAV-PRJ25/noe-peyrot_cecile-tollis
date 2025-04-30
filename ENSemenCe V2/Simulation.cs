public class Simulation
{
    public int nbTours;

    public Simulation(int nbTours)
    {
        // On sait pas trop s'il faut mettre des trucs ici...
    }

    public void LancerSimulation()
    {
        Console.Clear();
        AfficherEffet();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Comment vous appelez vous jeune jardinier ?");
        string nom = Convert.ToString(Console.ReadLine()!)!;
        Joueur joueur1 = new Joueur(nom); // Création d'un joueur 
        Console.WriteLine($"Bonjour {joueur1.Nom} ! La simulation va commencer !");
        Console.WriteLine();
        Thread.Sleep(1000);

        Console.WriteLine($"Tu as {nbTours} semaines pour obtenir le plus beau des jardins");
        Thread.Sleep(1000);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("⚠️ Attention, tu ne peut effectuer que 3 actions chaques semaines ! ⚠️ BONNE CHANCE");
        Thread.Sleep(1000);
        
        Console.ForegroundColor = ConsoleColor.White;

        Plateau plateau = new Plateau(9,6); // Création nouveau plateau
        
        Rose rose = new Rose("Rose", "R"); // Création d'une Rose
        Rose rose2 = new Rose("Rose", "R");


        // Ajout de la Tomate dans l'inventaire de semis du joueur
        joueur1.InventaireSemis.Add(rose);
        joueur1.InventaireSemis.Add(rose2);
        joueur1.Semer(plateau, "Terre", rose);
        plateau.AfficherPlateau();
        Thread.Sleep(1500);
        Console.Clear();
        joueur1.Semer(plateau, "Sable", rose2);
        
        plateau.AfficherPlateau();
        
    }

    public void AfficherEffet()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("-");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("---");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue ");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ensemence ");
        Thread.Sleep(1500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ");
        Thread.Sleep(1500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe -");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe --");
        Thread.Sleep(750);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe ---");
        Thread.Sleep(1500);
    }
}
