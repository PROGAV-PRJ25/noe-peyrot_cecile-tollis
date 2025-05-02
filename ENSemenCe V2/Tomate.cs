public class Rose : Plante
{
    public string TerrainPrefere { get; set; }
    public int NbMaxParTerrain = 3; 
    public int StadeCroissance { get; private set; } = 0; // Commence au stade 0

    public Rose(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "Terre"; 
    }

    public override void Pousser()
    {
        if (StadeCroissance < 8) // Il y a 8 stades (de 1 à 8, avec le final)
        {
            StadeCroissance++;
            Console.WriteLine($"La rose a poussé ! Elle est maintenant au stade {StadeCroissance}.");
            Console.WriteLine("--- Aperçu --- ");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("La rose est déjà au stade final !");
        }

        AfficherPlante();
    }

    public void AfficherPlante()
    {
        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine(" |");
                break;
            case 2:
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                break;
            case 3:
                Console.WriteLine(" |/");
                Console.WriteLine(" |");
                break;
            case 4:
                Console.WriteLine(" _");
                Console.WriteLine(" |/");
                Console.WriteLine(" |");
                break;
            case 5:
                Console.WriteLine(" _ __");
                Console.WriteLine(" |/_/");
                Console.WriteLine(" |");
                break;
            case 6:
                Console.WriteLine(@" /_\__"); // Utilisation @ car C# ne comprend pas la séquence /_\__
                Console.WriteLine("  |/_/");
                Console.WriteLine("  |");
                break;
            case 7:
                Console.WriteLine(@" \_/__");
                Console.WriteLine("  |/_/");
                Console.WriteLine("  |");
                break;
            case 8: // Stade final
                Console.WriteLine(@" / \");
                Console.WriteLine(@" \_/__");
                Console.WriteLine("  |/_/");
                Console.WriteLine("  |");
                break;
            default:
                Console.WriteLine("Erreur : Stade inconnu");
                break;
        }
    }
}
