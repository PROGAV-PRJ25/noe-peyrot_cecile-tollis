public class Pissenlit : Plante
{
    public int NbMaxParTerrain = 4;

    public Pissenlit(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "sable";
    }

    public override void Pousser(Plante plante)
    {
        if (plante.EstVivante)
        {
            ProgressionCroissance += VitesseDeCroissance;

            while (ProgressionCroissance >= 1 && StadeCroissance < 7)
            {
                StadeCroissance++;
                ProgressionCroissance -= 1;
            }

            if (StadeCroissance >= 7)
            {
                EstMure = true;
            }
        }
    }

    public override void AfficherPlante()
    {
        if (StadeCroissance >= 7)
        {
            Console.WriteLine("Le pissenlit est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"Le pissenlit est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu ---");
            Console.WriteLine();
        }

        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine("  .--.");
                break;
            case 2:
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");

                break;
            case 3:
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");
                Console.WriteLine("'. /\\ .'");
                break;
            case 4:
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");
                Console.WriteLine("'. /\\ .'");
                Console.WriteLine("  \"||\"");
                break;
            case 5:
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");
                Console.WriteLine("'. /\\ .'");
                Console.WriteLine("  \"||\"");
                Console.WriteLine("   || /\\");
                break;
            case 6:
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");
                Console.WriteLine("'. /\\ .'");
                Console.WriteLine("  \"||\"");
                Console.WriteLine("   || /\\");
                Console.WriteLine(" /\\ ||//\\)");
                break;
            case 7: // Stade final
                Console.WriteLine("  .--.");
                Console.WriteLine(".'_\\/_'.");
                Console.WriteLine("'. /\\ .'");
                Console.WriteLine("  \"||\"");
                Console.WriteLine("   || /\\");
                Console.WriteLine(" /\\ ||//\\)");
                Console.WriteLine("(/\\\\||/");
                Console.WriteLine("    \\||/");
                Console.WriteLine("Pissenlit mature !");
                break;
            default:
                break;
        }
    }
}
