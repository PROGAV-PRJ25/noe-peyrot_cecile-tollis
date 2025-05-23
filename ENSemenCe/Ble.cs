public class Ble : Plante
{
    public int NbMaxParTerrain = 5;

    public Ble(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "terre";
    }

    public override void Pousser(Plante plante)
    {
        if (plante.EstVivante)
        {
            ProgressionCroissance += VitesseDeCroissance;

            while (ProgressionCroissance >= 1 && StadeCroissance < 20)
            {
                StadeCroissance++;
                ProgressionCroissance -= 1;
            }

            if (StadeCroissance >= 20)
            {
                EstMure = true;
            }
        }
    }

    public override void AfficherPlante()
    {
        if (StadeCroissance >= 20)
        {
            Console.WriteLine("Le blé est arrivé à maturité !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"Le blé est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu --- ");
        }

        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine(" .    .");
                break;
            case 2:
                Console.WriteLine(" ,    ,");
                break;
            case 3:
                Console.WriteLine(" |    |");
                break;
            case 4:
                Console.WriteLine(" |    |");
                break;
            case 5:
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    |");
                break;
            case 6:
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    |");
                break;
            case 7:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 8:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 9:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 10:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 11:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 12:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 13:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 14:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 15:
                Console.WriteLine("  |     | ");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 16:
                Console.WriteLine(" |    | ");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 17:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 18:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 19:
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            case 20:
                Console.WriteLine("  _     _");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("\\|/  \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     |");
                break;
            default:
                break;
        }
    }
}
