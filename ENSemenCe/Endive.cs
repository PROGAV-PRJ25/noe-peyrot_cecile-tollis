public class Endive : Plante
{
    public int NbMaxParTerrain = 3; 
    
    public Endive(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "terre"; 
    }

    public override void Pousser(Plante plante)
    {
        if (plante.EstVivante)
        {
            ProgressionCroissance += VitesseDeCroissance;

            while (ProgressionCroissance >= 1 && StadeCroissance < 5)
            {
                StadeCroissance++;
                ProgressionCroissance -= 1;
            }

            if (StadeCroissance >= 5)
            {
                EstMure = true;
            }
        }
    }

    public override void AfficherPlante()
    {
        if (StadeCroissance >= 5)
        {
            Console.WriteLine("L'endive est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"L'endive est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu --- ");
            Console.WriteLine();
        }
        
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
                break;
        }
    }
}
