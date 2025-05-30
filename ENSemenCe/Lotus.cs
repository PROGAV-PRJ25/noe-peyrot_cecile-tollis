public class Lotus : Plante
{
    public int NbMaxParTerrain = 3;

    public Lotus(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "argile";
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
            Console.WriteLine("Le lotus est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"Le lotus est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu --- ");
            Console.WriteLine();
        }

        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine("  .  ");
                break;
            case 2:
                Console.WriteLine("  |  ");
                break;
            case 3:
                Console.WriteLine("  |  ");
                Console.WriteLine("  |  ");
                break;
            case 4:
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                break;
            case 5:
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                Console.WriteLine("  |  ");
                break;
            case 6:
                Console.WriteLine(@"  \|/  ");
                Console.WriteLine(" --O-- ");
                Console.WriteLine("  / \\  ");
                break;
            case 7:
                Console.WriteLine(@"  \|/  ");
                Console.WriteLine(" --O-- ");
                Console.WriteLine(@"  / \  ");
                Console.WriteLine("  | |  ");
                break;
            case 8: // Stade final
                Console.WriteLine(@"  \|/  ");
                Console.WriteLine(" --O-- ");
                Console.WriteLine(@"  / \  ");
                Console.WriteLine("  | |  ");
                break;
            default:
                break;
        }
    }
}
