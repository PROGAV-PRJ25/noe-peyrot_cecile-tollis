public abstract class Terrain
{
    public string TypeTerrain { get; set; }
    public Plante?[,] Cases { get; set; }
    public bool[,] MauvaisesHerbes { get; set; }



    public Terrain(string typeTerrain, int nbLignes, int nbColonnes)
    {
        TypeTerrain = typeTerrain;
        Cases = new Plante?[nbLignes, nbColonnes];
        MauvaisesHerbes = new bool[nbLignes, nbColonnes];

    }

    public void AfficherTerrain()
    {
        for (int i = 0; i < Cases.GetLength(0); i++)
        {
            for (int j = 0; j < Cases.GetLength(1); j++)
            {
                if (Cases[i, j] != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($" {Cases[i, j]!.Symbole} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (MauvaisesHerbes[i, j])
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" , ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine();
        }
    }
    
    public void FairePousserMauvaiseHerbe()
    {
        Random rand = new Random();
        List<(int, int)> casesVides = new();

        for (int i = 0; i < Cases.GetLength(0); i++)
        {
            for (int j = 0; j < Cases.GetLength(1); j++)
            {
                if (Cases[i, j] == null && !MauvaisesHerbes[i, j])
                {
                    casesVides.Add((i, j));
                }
            }
        }

        if (casesVides.Count > 0)
        {
            var (x, y) = casesVides[rand.Next(casesVides.Count)];
            MauvaisesHerbes[x, y] = true;
        }
    }
}
