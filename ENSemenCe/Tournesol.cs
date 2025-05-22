public class Tournesol : Plante
{
    public int NbMaxParTerrain = 4;

    public Tournesol(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "sable";
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
            Console.WriteLine("Le tournesol est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"Le tournesol est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu ---");
            Console.WriteLine();
        }

        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine("  |  ");
                break;
            case 2:
                Console.WriteLine("  |  ");
                Console.WriteLine("  |  ");
                break;
            case 3:
                Console.WriteLine("  |  ");
                Console.WriteLine(" \\|/ ");
                break;
            case 4:
                Console.WriteLine("  |  ");
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                break;
            case 5:
                Console.WriteLine("  |  ");
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                Console.WriteLine(" / \\ ");
                break;
            case 6:
                Console.WriteLine("  |  ");
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                Console.WriteLine(" / \\ ");
                Console.WriteLine("  |  ");
                break;
            case 7:
                Console.WriteLine("  |  ");
                Console.WriteLine(" \\|/ ");
                Console.WriteLine("  |  ");
                Console.WriteLine(" / \\ ");
                Console.WriteLine("  |  ");
                Console.WriteLine("  |  ");
                break;
            case 8: // Stade final
                Console.WriteLine(" \\|/ ");
                Console.WriteLine(" -O- ");
                Console.WriteLine("  |  ");
                Console.WriteLine(" / \\ ");
                Console.WriteLine("  |  ");
                Console.WriteLine("  |  ");
                break;
            default:
                break;
        }
    }
}
