public abstract class Intrus
{
    public string Nom { get; set; }
    public string Symbole { get; set; }

    public Intrus(string nom, string symbole)
    {
        Nom = nom;
        Symbole = symbole;
    }
    
    public abstract void Agir(Plateau plateau, Joueur joueur);

}
