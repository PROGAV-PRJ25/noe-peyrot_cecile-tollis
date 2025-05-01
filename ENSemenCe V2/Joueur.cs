public class Joueur
{
    public string Nom {get;set;}
    public int NbActionsPossibles {get;set;}
    public List<Plante> InventaireSemis {get;set;}
    public List<string> InventaireRecoltes {get;set;}

    public Joueur(string nom)
    {
        Nom = nom;
        NbActionsPossibles = 4;
        InventaireSemis = new List<Plante>();
        InventaireRecoltes = new List<string>();
    }

    public void Semer(Plateau plateau, string typeTerrain, Plante plante)
    {
        if (NbActionsPossibles==0)
        {
            Console.WriteLine("Vous n'avez plus d'actions pour ce tour !");
            return;
        }

        if (!InventaireSemis.Contains(plante))
        {
            Console.WriteLine("Cette plante n’est pas dans votre inventaire !");
            return;
        }

        // Rechercher le terrain correspondant dans le plateau.
        Terrain? terrainCible = null;
        foreach (var terrain in plateau.Terrains)
        {
            if (terrain.TypeTerrain == typeTerrain)
            {
                terrainCible = terrain;
                break;
            }
        }

        if (terrainCible==null) // Au cas où l'utilisateur tape un mauvais nom.
        {
            Console.WriteLine($"le terrain {typeTerrain} n'existe pas.");
            return;
        }

        // On cherche une case vide dans ce terrain.
        bool plantee = false;
        for (int i=0; i<terrainCible.Cases.GetLength(0); i++)
        {
            for (int j=0; j<terrainCible.Cases.GetLength(1); j++)
            {
                if (terrainCible.Cases[i,j]==null)
                {
                    terrainCible.Cases[i,j] = plante;
                    plantee = true;
                    break;
                }
            }

            if (plantee) // Dès qu'on a planté, pas besoin de continuer à chercher.
            {
                break;
            }
        }

        if (plantee==true)
        {
            InventaireSemis.Remove(plante);
            NbActionsPossibles--;
            Console.WriteLine($"{plante.Nom} a été plantée dans le terrain {typeTerrain}.");
        }
        else
        {
            Console.WriteLine($"La zone {typeTerrain} est pleine, il est donc impossible de planter {plante.Nom}.");
        }
    }



    public void Arroser(Plateau plateau, string typeTerrain)
    {
       
    }

    public void Recolter(Plateau plateau)
    {
    
    }
}
