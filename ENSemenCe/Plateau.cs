public class Plateau
{
    public Terrain[] Terrains { get; set; }

    public Plateau(int nbLignes, int nbColonnes)
    {
        Terrains = new Terrain[3];
        int lignesParZone = nbLignes / 3;

        Terrains[0] = new TerrainTerre("terre", lignesParZone, nbColonnes);
        Terrains[1] = new TerrainSable("sable", lignesParZone, nbColonnes);
        Terrains[2] = new TerrainArgile("argile", lignesParZone, nbColonnes);
    }

    public void AfficherPlateau()
    {
        foreach (var terrain in Terrains)
        {
            Console.WriteLine($"Terrain {terrain.TypeTerrain}");
            terrain.AfficherTerrain();
            Console.WriteLine();
        }
    }
    
    public void FairePousserMauvaisesHerbes()
    {
        foreach (var terrain in Terrains)
        {
            terrain.FairePousserMauvaiseHerbe();
        }
    }
}
