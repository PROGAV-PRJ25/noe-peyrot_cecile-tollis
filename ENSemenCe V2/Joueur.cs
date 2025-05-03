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
            Console.WriteLine("Tu n'as plus d'actions pour ce tour !");
            return;
        }

        if (!InventaireSemis.Contains(plante))
        {
            Console.WriteLine("Cette plante n’est pas dans ton inventaire !");
            return;
        }

        Terrain? terrainCible = null;
        string typeTerrain = "";
        bool terrainTrouve = false;

        while (terrainTrouve==false)
        {
            Console.WriteLine($"Choisis un terrain pour {plante.Nom}: Terre, Sable ou Argile.");
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
                Console.WriteLine("Le terrain tapé est inconnu. Réessaie !");
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
            Console.WriteLine($"{plante.Nom} a été plantée dans le terrain {typeTerrain}.");
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
        Console.WriteLine("Voici les plantes que tu peux récolter :");
        List<Plante> plantesMures = new List<Plante>();

        int index = 1;
        foreach (var plante in PlantesSurJardin)
        {
            if (plante is Cerise c && c.StadeCroissance==5 || plante is Endive e && e.StadeCroissance==5 || plante is Rose r && r.StadeCroissance==5)
            {
                Console.WriteLine($"{index}. {plante.Nom}");
                plantesMures.Add(plante);
                index++;
            }
        }

        if (plantesMures.Count==0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucune plante n'est prête à être récoltée !");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine("Choisis la plante à récolter (numéro) :");
        int choix = Convert.ToInt32(Console.ReadLine()!);

        if (choix<1 || choix>plantesMures.Count)
        {
            Console.WriteLine("Numéro invalide !");
            return;
        }

        Plante planteARetirer = plantesMures[choix - 1];
        
        // Retirer la plante du plateau
        foreach (var terrain in plateau.Terrains)
        {
            for (int i=0; i<terrain.Cases.GetLength(0); i++)
            {
                for (int j=0; j<terrain.Cases.GetLength(1); j++)
                {
                    if (terrain.Cases[i,j]==planteARetirer)
                    {
                        terrain.Cases[i, j] = null;
                        Console.Clear();
                        Console.WriteLine($"{planteARetirer.Nom} a été récoltée !");
                        PlantesSurJardin.Remove(planteARetirer);
                        InventaireRecoltes.Add(planteARetirer.Nom);
                        NbActionsPossibles--;
                        return;
                    }
                }
            }
        }
    }

    public void AfficherInventaireRecoltes()
    {
        Console.WriteLine("Inventaire des récoltes :");

        if (InventaireRecoltes.Count==0)
        {
            Console.WriteLine("Tu n'as encore rien récolté !");
        }

        else
        {
            foreach (var nom in InventaireRecoltes)
            {
                Console.WriteLine($"- {nom}");
            }
        }
    }

}
