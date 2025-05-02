public abstract class Plante
{
    public string Symbole {get; set;}
    public string Nom {get;set;}
    public int NiveauCroissance {get;set;}
    public int NiveauEau {get;set;}
    public int EtatSante {get;set;}
    public bool EstVivante {get;set;}
    public bool EstMure {get;set;}
    public bool EstMalade {get;set;}

    public Plante(string nom, string symbole)
    {
        Symbole = symbole;
        Nom = nom;
        NiveauCroissance = 0;
        NiveauEau = 100; // La plante n'a pas besoin d'eau au tout début.
        EtatSante = 4; // la plante est en parfaite santé au tout début.
        EstVivante = true;
        EstMure = false;
        EstMalade = false;
    }

    public void AfficherDonnees(Plante plante)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"--- {plante.Nom} --- ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"    - Niveau d'eau : {plante.NiveauEau}/100"); 
        if(plante.NiveauEau < 50)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("--> La plante a besoin d'eau ! "); 
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine($"    - Etat de santé : {plante.EtatSante}/10"); 
        if(plante.EtatSante <5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("         --> La plante n'est pas en bonne santé ! "); 
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
        plante.Pousser();
    }

    public abstract void Pousser();
}


/*
Pour le dessin des plantes dans la console, on a commencé à regarder, et mon Papa a eu une idée drôle : 
Si une plante meurt, on l'affiche d'une certaine façon pendant une ou deux secondes, puis on l'enlève du plateau : 
En gros, faudrait faire un : 

if(plante.EstVivante==false) 
{
    Console.WriteLine("x_x");
    Console.WriteLine(" |");
    Console.WriteLine("/ \");
}

Tu en penses quoi ?

On a commencé à réfléchir pour faire une tomate, c'est archi galère, donc est-ce qu'on part sur un fruit ou un légume plus simple ? 
*/
