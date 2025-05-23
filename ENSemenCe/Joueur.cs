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
        NbActionsPossibles = 3;
        InventaireSemis = new List<Plante>();
        PlantesSurJardin = new List<Plante>();
        InventaireRecoltes = new List<string>();
    }

    public void Semer(Plateau plateau, Plante plante)
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine($" --- Pour information, le terrain préféré de {plante.Nom} est {plante.TerrainPrefere} ---");
        Console.BackgroundColor = ConsoleColor.Black;
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
            Console.WriteLine($"Choisis un terrain pour {plante.Nom} : Terre, Sable ou Argile.");
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
        for (int i = 0; i < terrainCible?.Cases.GetLength(0); i++)
        {
            for (int j = 0; j < terrainCible.Cases.GetLength(1); j++)
            {
                if (!plantee && terrainCible.Cases[i, j] == null && !terrainCible.MauvaisesHerbes[i, j])
                {
                    terrainCible.Cases[i, j] = plante;
                    plantee = true;
                }
            }
        }

        if (plantee)
        {
            InventaireSemis.Remove(plante);
            PlantesSurJardin.Add(plante);
            plante.TerrainActuel = terrainCible;
            NbActionsPossibles--;
            Console.Clear();
            Console.WriteLine($"{plante.Nom} a été planté(e) dans le terrain {typeTerrain}.");
        }

        else
        {
            Console.Clear();
            Console.WriteLine($"La zone {typeTerrain} est pleine. Impossible de planter {plante.Nom}.");
        }
    }

    public void Arroser(Plateau plateau, string typeTerrain)
    {
        foreach (var terrain in plateau.Terrains)
        {
            if (terrain.TypeTerrain == typeTerrain)
            {
                for (int i = 0; i < terrain.Cases.GetLength(0); i++)
                {
                    for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                    {
                        // Si la case contient une plante, on lui ajoute de l'eau
                        var plante = terrain.Cases[i, j];
                        if (plante != null)
                        {
                            plante.NiveauEau = Math.Min(plante.NiveauEau + 20, 100); // Limite l'eau à 100
                            Console.WriteLine($"La plante {plante.Nom} a été arrosée. Niveau d'eau : {plante.NiveauEau}/100");

                        }
                    }
                }
            }
        }
        NbActionsPossibles--;
    }


    public void Recolter(Plateau plateau)
    {
        Console.WriteLine("Voici les plantes que tu peux récolter :");
        List<Plante> plantesMures = new List<Plante>();

        int index = 1;
        foreach (var plante in PlantesSurJardin)
        {
            if (plante.EstMure)
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
    
    public void Desherber(Plateau plateau)
    {
        if (NbActionsPossibles == 0)
        {
            Console.WriteLine("Tu n'as plus d'actions pour ce tour !");
            return;
        }

        Terrain? terrainCible = null;
        bool terrainTrouve = false;

        while (!terrainTrouve)
        {
            Console.WriteLine("Choisis un terrain à désherber : Terre, Sable ou Argile.");
            string typeTerrain = Convert.ToString(Console.ReadLine()!.ToLower());

            foreach (var terrain in plateau.Terrains)
            {
                if (terrain.TypeTerrain.ToLower() == typeTerrain)
                {
                    terrainCible = terrain;
                    terrainTrouve = true;
                    break;
                }
            }

            if (!terrainTrouve)
            {
                Console.WriteLine("Le terrain tapé est inconnu. Réessaie !");
            }
        }

        if (terrainCible != null)
        {
            int mauvaisesHerbesEnlevees = 0;
            for (int i = 0; i < terrainCible.MauvaisesHerbes.GetLength(0); i++)
            {
                for (int j = 0; j < terrainCible.MauvaisesHerbes.GetLength(1); j++)
                {
                    if (terrainCible.MauvaisesHerbes[i, j])
                    {
                        terrainCible.MauvaisesHerbes[i, j] = false;
                        mauvaisesHerbesEnlevees++;
                    }
                }
            }

            NbActionsPossibles--;
            Console.WriteLine($"Toutes les mauvaises herbes ont été enlevées du terrain {terrainCible.TypeTerrain}.");
        }
    }


    public void AfficherInventaireRecoltes()
    {
        Console.WriteLine("Afficher l'inventaire ne diminue pas le nombre d'actions");
        Console.WriteLine("\n Inventaire des récoltes :");

        if (InventaireRecoltes.Count == 0)
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
