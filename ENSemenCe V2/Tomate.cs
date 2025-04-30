public class Rose : Plante
{
    public string TerrainPrefere {get;set;}
    public int NbMaxParTerrain = 3; // On avait bien dit 3 ? 

    public Rose(string nom, string symbole) : base(nom, symbole)
    {
        TerrainPrefere = "Terre"; // La tomate préfère la terre
    }
}
