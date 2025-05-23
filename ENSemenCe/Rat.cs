public class Rat : Intrus
{

    public Rat(string nom, string symbole) : base(nom, symbole)
    {
    }
    
    public override void Agir(Plateau plateau, Joueur joueur) 
    {
        Console.WriteLine("Un rat est apparu ! Appuie sur [ESPACE] pour faire du bruit !!");
        Console.ResetColor();
        Thread.Sleep(1500);

        Random rand = new Random();

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
                        break;
                    }
                }
                if (terrain != null) break;
            }
            if (terrain != null) break;
        }

        if (terrain == null)
        {
            Console.WriteLine("\nLe rat n’a trouvé aucune plante sur aucun terrain !");
            Thread.Sleep(1500);
            return;
        }

        // 2. Trouver une ligne avec au moins une plante
        List<int> lignesAvecPlantes = new List<int>();
        for (int ligne = 0; ligne < terrain.Cases.GetLength(0); ligne++)
        {
            for (int col = 0; col < terrain.Cases.GetLength(1); col++)
            {
                if (terrain.Cases[ligne, col] is Plante)
                {
                    lignesAvecPlantes.Add(ligne);
                    break;
                }
            }
        }

        int ligneChoisie = lignesAvecPlantes[rand.Next(lignesAvecPlantes.Count)];

        // 3. Déplacer le rat de droite à gauche sur cette ligne
        for (int col = terrain.Cases.GetLength(1) - 1; col >= 0; col--)
        {
            Console.Clear();
            Console.BackgroundColor=ConsoleColor.Red;
            Console.WriteLine("Appuie sur [ESPACE] pour chasser le rat !");

            for (int i = 0; i < terrain.Cases.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                {
                    if (i == ligneChoisie && j == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" 🐭 ");
                        Console.ResetColor();
                    }
                    else if (terrain.Cases[i, j] != null)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($" {terrain.Cases[i, j]!.Symbole} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }

            // Attente + détection touche
            int delay = 300;
            int step = 30;

            for (int t = 0; t < delay; t += step)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTu as effrayé le rat ! Il s’enfuit !");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        return;
                    }
                }
                Thread.Sleep(step);
            }

            if (terrain.Cases[ligneChoisie, col] is Plante plante)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n🐭 Le rat a mangé un(e) {plante.Nom} !");
                Console.ResetColor();
                terrain.Cases[ligneChoisie, col] = null;
                joueur.PlantesSurJardin.Remove(plante);
                Thread.Sleep(2000);
                return;
            }
        }

        // Ce cas ne devrait plus arriver
        Console.WriteLine("\n🐭 Le rat est reparti sans rien trouver.");
        Thread.Sleep(1500);
    }




}
