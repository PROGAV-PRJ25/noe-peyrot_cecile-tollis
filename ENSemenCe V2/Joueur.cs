public class Joueur
{
    public string Nom {get;set;}
    public int NbActionsPossibles {get;set;}
    public List<Plante> InventaireSemis {get;set;}
    public List<Plante> PlantesSurJardin {get;set;}
    public List<string> InventaireRecoltes {get;set;}

    public Joueur(string nom)
    {
        Nom = nom;
        NbActionsPossibles = 4;
        InventaireSemis = new List<Plante>();
        PlantesSurJardin = new List<Plante>();
        InventaireRecoltes = new List<string>();
    }

    public void Semer(Plateau plateau, Plante plante)
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

        Terrain? terrainCible = null;
        string typeTerrain = "";
        bool terrainTrouve = false;

        while (terrainTrouve==false)
        {
            Console.WriteLine($"Choisissez un terrain pour {plante.Nom}: Terre, Sable ou Argile.");
            typeTerrain = Convert.ToString(Console.ReadLine()!.ToLower());

            foreach (var terrain in plateau.Terrains)
            {
                if (terrain.TypeTerrain.ToLower()==typeTerrain)
                {
                    terrainCible = terrain;
                    terrainTrouve = true;
                }
            }

            if (terrainTrouve==false)
            {
                Console.WriteLine("Le terrain tapé est inconnu. Veuillez réessayer !");
            }
        }

        bool plantee = false;
        for (int i=0; i<terrainCible?.Cases.GetLength(0); i++)
        {
            for (int j=0; j<terrainCible.Cases.GetLength(1); j++)
            {
                if ((plantee==false) && (terrainCible.Cases[i,j]==null))
                {
                    terrainCible.Cases[i,j] = plante;
                    plantee = true;
                }
            }
        }

        if (plantee)
        {
            InventaireSemis.Remove(plante);
            PlantesSurJardin.Add(plante);
            NbActionsPossibles--;
            Console.Clear();
            Console.WriteLine($"{plante.Nom} a été planté dans le terrain {typeTerrain}.");
        }

        else
        {
            Console.WriteLine($"La zone {typeTerrain} est pleine. Impossible de planter {plante.Nom}.");
        }
    }

    public void Arroser(Plateau plateau, string typeTerrain)
    {
        // à compléter...
    }

    public void Recolter(Plateau plateau)
    {
        // à compléter...
    }
}
