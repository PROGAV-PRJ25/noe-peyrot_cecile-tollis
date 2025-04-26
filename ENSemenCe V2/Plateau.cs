public class Plateau
{
    public Terrain[] Terrains {get;set;}

    public Plateau(int nbLignes, int nbColonnes)
    {
        Terrains = new Terrain[3];
        int lignesParZone = nbLignes / 3;

        Terrains[0] = new Terrain("Terre", lignesParZone, nbColonnes);
        Terrains[1] = new Terrain("Sable", lignesParZone, nbColonnes);
        Terrains[2] = new Terrain("Argile", lignesParZone, nbColonnes);
    }

    public void AfficherPlateau()
    {
        foreach(var terrain in Terrains) // La variable terrain existe uniquement ici, on peut changer son nom si c'est trompeur.
        {
            Console.WriteLine($"Terrain {terrain.TypeTerrain}");
            terrain.AfficherTerrain();
            Console.WriteLine();
        }
    }
}
