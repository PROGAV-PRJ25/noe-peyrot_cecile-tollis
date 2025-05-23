public class Tulipe : Plante
{
    public int NbMaxParTerrain = 5;

    public Tulipe(string nom, string symbole) : base(nom, symbole)
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
            Console.WriteLine("La tulipe est déjà au stade final !");
            EstMure = true;
        }
        else
        {
            Console.WriteLine($"La tulipe est au stade {StadeCroissance} de croissance.");
            Console.WriteLine("--- Aperçu ---");
            Console.WriteLine();
        }

        switch (StadeCroissance)
        {
            case 1:
                Console.WriteLine(@",");
                break;
            case 2:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                break;
            case 3:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                break;
            case 4:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                break;
            case 5:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                break;
            case 6:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                break;
            case 7:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                break;
            case 8:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                break;
            case 9:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                break;
            case 10:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                break;
            case 11:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                Console.WriteLine(@"   |\    |  |   |\");
                break;
            case 12:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                Console.WriteLine(@"   |\    |  |   |\");
                Console.WriteLine(@"   |  |  |  |   |  |");
                break;
            case 13:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                Console.WriteLine(@"   |\    |  |   |\");
                Console.WriteLine(@"   |  |  |  |   |  |");
                Console.WriteLine(@"   | |   |  |  / /");
                break;
            case 14:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/      |");
                Console.WriteLine(@"   |     |        |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                Console.WriteLine(@"   |\    |  |   |\");
                Console.WriteLine(@"   |  |  |  |   |  |");
                Console.WriteLine(@"   | |   |  |  / /");
                Console.WriteLine(@"    \ \ |  |/ /");
                break;
            case 15:
                Console.WriteLine(@",");
                Console.WriteLine(@"    /  \^/   `\");
                Console.WriteLine(@"   |     \/     |");
                Console.WriteLine(@"   |     |       |");
                Console.WriteLine(@"   \     \      /");
                Console.WriteLine(@"     '\\    //'");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |");
                Console.WriteLine(@"         |  |  ,");
                Console.WriteLine(@"    |\   |  |   |\");
                Console.WriteLine(@"    |  | |  |   | |");
                Console.WriteLine(@"    | |  |  |  / /");
                Console.WriteLine(@"     \ \ |  |/ /");
                Console.WriteLine(@"      `\ \//`");
                Console.WriteLine(@"     ^^^^^^^^");
                break;
        }

    }
}
