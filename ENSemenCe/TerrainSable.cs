public class TerrainSable : Terrain
{
    public TerrainSable(string typeTerrain, int nbLignes, int nbColonnes) : base(typeTerrain,nbLignes,nbColonnes)
    {
        TypeTerrain = typeTerrain;
        Cases = new Plante?[nbLignes, nbColonnes];
    }
}
