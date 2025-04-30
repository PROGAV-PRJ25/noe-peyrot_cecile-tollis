public abstract class Terrain
{
    public string TypeTerrain {get;set;}
    public Plante?[,] Cases {get;set;}

    public Terrain(string typeTerrain, int nbLignes, int nbColonnes)
    {
        TypeTerrain = typeTerrain;
        Cases = new Plante?[nbLignes, nbColonnes];
    }

    public void AfficherTerrain()
    {
        for (int i=0; i<Cases.GetLength(0); i++)
        {
            for (int j=0; j<Cases.GetLength(1); j++)
            {
                if (Cases[i,j] == null)
                {
                    Console.Write(" . "); // Case vide.
                }
                    
                else
                {
                    Console.Write($" {Cases[i,j]!.Symbole} "); // Case occupée par une plante (symbole de la plante) - ! évite la valeur nulle
                }       
            }

            Console.WriteLine();
        }
    }
}
