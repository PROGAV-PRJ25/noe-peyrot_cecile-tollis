public abstract class Terrains
{
    public int Id {get; private set;}
    TypeTerrain Type {get; set;}
    public double Qualite {get;set;}
    public double Luminosite {get; set;}
    List <Plantes> Plante {get; set;}
    

    public Terrains(int id, TypeTerrain type, double qualite, double luminosite, List <Plantes> plante)
    {
        Id = id;
        Type = type;
        Qualite = qualite;
        Luminosite = luminosite;
        Plante = plante;
    }
}
