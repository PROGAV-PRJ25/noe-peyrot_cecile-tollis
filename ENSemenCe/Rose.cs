public class Rose : Plante
{
    public int NbMaxParTerrain = 3; 
    
    public Rose(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "terre"; 
    }

    public override void Pousser(Plante plante)
    {
        if (plante.EstVivante)
        {
            ProgressionCroissance += VitesseDeCroissance;

            while (ProgressionCroissance >= 1 && StadeCroissance < 8)
            {
                StadeCroissance++;
                ProgressionCroissance -= 1;
            }

            if (StadeCroissance >= 8)
            {
                EstMure = true;
            }
        }
    }


    public override void AfficherPlante()
    {
        if (StadeCroissance >= 8)
        {
            Console.WriteLine("La rose est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"La rose est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu --- ");
            Console.WriteLine();
        }
        
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
                break;
        }
    }
}
