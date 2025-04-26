public class Joueur
{
    public int NbActionsPossibles {get;set;}
    public List<Plante> InventaireSemis {get;set;}
    public List<string> InventaireRecoltes {get;set;}

    public Joueur()
    {
        NbActionsPossibles = 3; // Nombre maximum d'actions par tour : On avait dit 3 ou 4 déjà ? 
        InventaireSemis = new List<Plante>();
        InventaireRecoltes = new List<string>();
    }

    public void Semer(Plateau plateau, string typeTerrain, Plante plante)
    {
        
    }

    public void Arroser(Plateau plateau, string typeTerrain)
    {
       
    }

    public void Recolter(Plateau plateau)
    {
    
    }
}
