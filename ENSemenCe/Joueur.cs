public class Endive : Plante
{
    public int NbMaxParTerrain = 3; 
    
    public Endive(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "Terre"; 
    }

    public override void Pousser()
    {
        if (StadeCroissance < 5) // Il y a 5 stades (de 1 à 5)
        {
            StadeCroissance++;
            Console.WriteLine($"L'endive a poussé ! Elle est maintenant au stade {StadeCroissance}.");
            Console.WriteLine("--- Aperçu --- ");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("L'endive est déjà au stade final !");
        }

        AfficherPlante();
    }

    public void AfficherPlante()
    {
        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine("   /\\   ");
                break;
            case 2:
                Console.WriteLine("   /\\   ");
                Console.WriteLine("  |   |  ");
                break;
            case 3:
                Console.WriteLine("   /\\   ");
                Console.WriteLine("  |   |  ");
                Console.WriteLine("  |   |  ");
                break;
            case 4:
                Console.WriteLine("   /\\   ");
                Console.WriteLine("  |   |  ");
                Console.WriteLine("  |   |  ");
                Console.WriteLine("  |___|  ");
                break;
            case 5:
                Console.WriteLine("   /\\   ");
                Console.WriteLine("  |   |  ");
                Console.WriteLine("  |   |  ");
                Console.WriteLine("  |___|  ");
                break;
            default:
                Console.WriteLine("Erreur : Stade inconnu");
                break;
        }
    }
}
