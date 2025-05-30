public abstract class Plante
{
    public string Symbole {get; set;}
    public string Nom {get;set;}
    public int NiveauEau {get;set;}
    public int EtatSante {get;set;}
    public bool EstVivante {get;set;}
    public bool EstMure {get;set;}
    public int StadeCroissance { get; set; } = 0; // Commence au stade 0
    public double VitesseDeCroissance { get; set; } = 1.0;
    public double ProgressionCroissance { get; set; } = 0.0;
    public string TerrainPrefere { get; set; } = "Inconnu "; // required : oblige les classes dérivées à l’initialiser
    public Terrain? TerrainActuel {get;set;} = null;

    public Plante(string nom, string symbole)
    {
        Symbole = symbole;
        Nom = nom;
        NiveauEau = 100; // La plante n'a pas besoin d'eau au tout début.
        EtatSante = 10; // la plante est en parfaite santé au tout début.
        EstVivante = true;
        EstMure = false;
    }

    public void AfficherDonnees(Plante plante, Joueur joueur)
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
        Console.WriteLine($"    - État de santé : {plante.EtatSante}/10"); 
        if(plante.EtatSante <5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("         --> La plante n'est pas en bonne santé !\n "); 
            Console.ForegroundColor = ConsoleColor.White;
        }
        if (plante.TerrainPrefere != plante.TerrainActuel!.TypeTerrain)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh non {plante.Nom} n'est pas sur son terrain préféré qui est {plante.TerrainPrefere} !");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine();
    }

    public abstract void Pousser(Plante plante);
    public abstract void AfficherPlante();

    public void VerifierConditions(Plante plante, Joueur joueur)
    {
        int nbConditionsRespectees = 3;
        if (plante.NiveauEau < 50)
        {
            nbConditionsRespectees--;
            plante.EtatSante -= 2;
        }
        else if (plante.NiveauEau >= 50 && plante.NiveauEau <= 70)
        {
            plante.EtatSante -= 1;
        }

        if (plante.TerrainPrefere != plante.TerrainActuel!.TypeTerrain)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oh non {plante.Nom} n'est pas sur son terrain préféré qui est {plante.TerrainPrefere} !");
            Console.ForegroundColor = ConsoleColor.White;
            nbConditionsRespectees--;
            plante.EtatSante -= 1;
        }

        if (NiveauEau <= 0)
        {
            plante.EtatSante = 0;
        }

        if (nbConditionsRespectees <= 1) // Si moins de 50% des conditions de la plante sont respectées elle meurt
            {
                plante.EtatSante = 0;
            }

        if (plante.EtatSante <= 0)
        {
            plante.EstVivante = false; 
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Malheureusement la plante {plante.Nom} n'était pas en bonne santé, elle n'a pas survécu.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            SupprimerPlante(plante, plante.TerrainActuel!, joueur);
        }

        if (plante.EtatSante <= 5)
        {
            plante.ProgressionCroissance = 0.2;
        }
    }

    public void SupprimerPlante(Plante plante, Terrain terrain, Joueur joueur)
    {
        for (int i=0; i<terrain.Cases.GetLength(0); i++)
        {
            for (int j=0; j<terrain.Cases.GetLength(1); j++)
            {
                if (terrain.Cases[i, j] == plante)
                {
                    terrain.Cases[i, j] = null;
                    joueur.PlantesSurJardin.Remove(plante);
                    Console.WriteLine($"\n {plante.Nom} ne se trouve plus sur le jardin");
                }   
            }
        }
    }
}
