public class Indominus : Intrus
{
    public Indominus(string nom, string symbole) : base(nom, symbole)
    { 
    }

    public override void Agir(Plateau plateau, Joueur joueur)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Appuyez sur [G] pour lancer une grenade !");
        Thread.Sleep(1000);
        Random rand = new Random();
        Plante planteTrouvee;

        // 1. Trouver un terrain avec au moins une plante
        Terrain? terrain = null;
        foreach (var t in plateau.Terrains)
        {
            for (int i = 0; i < t.Cases.GetLength(0); i++)
            {
                for (int j = 0; j < t.Cases.GetLength(1); j++)
                {
                    if (t.Cases[i, j] is Plante)
                    {
                        terrain = t;
                        planteTrouvee = t.Cases[i, j]!;
                        break;
                    }
                }
                if (terrain != null) break;
            }
            if (terrain != null) break;
        }

        if (terrain == null)
        {
            Console.WriteLine("\nL'indominus n’a trouvé aucune plante sur tous les terrains !");
            Thread.Sleep(1500);
            return;
        }

        int lignes = terrain.Cases.GetLength(0);
        int colonnes = terrain.Cases.GetLength(1);
        
        // Parcours ligne par ligne en partant du bas 
        for (int ligne = lignes - 1; ligne >= 0; ligne--)
        {
            for (int col = colonnes - 1; col >= 0; col--)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Appuyez sur [G] pour lancer une grenade !");
                Console.ResetColor();

                // Affichage du terrain
                for (int i = 0; i < terrain.Cases.GetLength(0); i++)
                {
                    for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                    {
                        if (i == ligne && j == col)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(" 🦖 ");
                        }
                        else if (terrain.Cases[i, j] != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" {terrain.Cases[i, j]!.Symbole} ");
                        }
                        else
                        {
                            Console.Write(" . ");
                        }
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }

                // Tentative de lancer de grenade
                int delay = 250;
                int step = 30;

                for (int t = 0; t < delay; t += step)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.G)
                        {

                            if (rand.Next(3) == 0) // 1 chance sur 3
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("<<< BBBBOOOOOOOOOOOOMMMMMMMMM >>>");
                                Thread.Sleep(1500);
                                Console.WriteLine("\nGrenade réussie ! L'Indominus a eu peur ! Pas d'inquiétude, les plantes vont bien !");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                return;
                            }
                            else if (rand.Next(4) == 0)
                            {
                                // Explosion aléatoire d'une plante
                                var plantesDisponibles = new List<Plante>();
                                for (int i = 0; i < terrain.Cases.GetLength(0); i++)
                                {
                                    for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                                    {
                                        if (terrain.Cases[i, j] is Plante p)
                                            plantesDisponibles.Add(p); // on fait une liste de plante disponible sur le terrain 
                                    }
                                }

                                if (plantesDisponibles.Count > 0)
                                {
                                    var planteExplosee = plantesDisponibles[rand.Next(plantesDisponibles.Count)]; // On choisit une plante aléatoire dans la liste de plantes
                                    // Supprimer du terrain
                                    for (int i = 0; i < terrain.Cases.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                                        {
                                            if (terrain.Cases[i, j] == planteExplosee)
                                                terrain.Cases[i, j] = null;
                                        }
                                    }

                                    joueur.PlantesSurJardin.Remove(planteExplosee);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nMALHEUR !!! VOUS AVEZ EXPLOSÉ UNE PLANTE !");
                                    plateau.AfficherPlateau();
                                    Console.ResetColor();
                                    Thread.Sleep(2500);
                                }

                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n La grenade a raté !");
                                Thread.Sleep(800);
                            }
                        }
                    }
                    Thread.Sleep(step);
                }

                // Si une plante est mangée
                if (terrain.Cases[ligne, col] is Plante plante)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n🦖 L'Indominus a dévoré une {plante.Nom} !");
                    Console.ResetColor();
                    terrain.Cases[ligne, col] = null;
                    joueur.PlantesSurJardin.Remove(plante);
                    Thread.Sleep(2000);
                    return;
                }

            }
        }

        Console.WriteLine("\n🦖 L'Indominus s'est éloigné sans rien manger...");
        Thread.Sleep(1500);
    }
}
