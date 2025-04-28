public class TerrainSable : Terrain
{
    public TerrainSable(string typeTerrain, int nbLignes, int nbColonnes) : base(typeTerrain,nbLignes,nbColonnes)
    {
        TypeTerrain = typeTerrain;
        Cases = new Plante?[nbLignes, nbColonnes];
    }

    public void AfficherTerrainSable()
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
                    Console.Write(" P "); // Case occupée par une plante (P).
                }       
            }

            Console.WriteLine();
        }
    }
}
public class TerrainSable : Terrain
{
    public TerrainSable(string typeTerrain, int nbLignes, int nbColonnes) : base(typeTerrain,nbLignes,nbColonnes)
    {
        TypeTerrain = typeTerrain;
        Cases = new Plante?[nbLignes, nbColonnes];
    }

    public void AfficherTerrainSable()
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
                    Console.Write(" P "); // Case occupée par une plante (P).
                }       
            }

            Console.WriteLine();
        }
    }
}
