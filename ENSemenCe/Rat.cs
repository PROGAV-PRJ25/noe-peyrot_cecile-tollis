public class Rat : Intrus
{

    public Rat(string nom, string symbole) : base(nom, symbole)
    {
    }
    
    public override void Agir(Plateau plateau, Joueur joueur)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("🐭 Un rat est apparu ! Appuyez sur ESPACE pour faire du bruit !!");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(1500);

        Random rand = new Random();

        // 1. Choisir un terrain au hasard
        Terrain terrain = plateau.Terrains[rand.Next(plateau.Terrains.Length)];

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

        if (lignesAvecPlantes.Count == 0)
        {
            Console.WriteLine("\n🐭 Le rat est reparti sans rien trouver.");
            Thread.Sleep(1500);
            return;
        }

        // Choisir une ligne au hasard parmi celles qui ont une plante
        int ligneChoisie = lignesAvecPlantes[rand.Next(lignesAvecPlantes.Count)];

        // 3. Déplacer le rat de droite à gauche sur cette ligne
        for (int col = terrain.Cases.GetLength(1) - 1; col >= 0; col--)
        {
            Console.Clear();
            Console.WriteLine("Appuyez sur [ESPACE] pour chasser le rat !");

            for (int i = 0; i < terrain.Cases.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.Cases.GetLength(1); j++)
                {
                    if (i == ligneChoisie && j == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" 🐭 ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (terrain.Cases[i, j] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {terrain.Cases[i, j]!.Symbole} ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }

            // Attente + détection touche
            int delay = 300; // ms
            int step = 30;   // vérifie toutes les 30 ms
            bool ratEffraye = false;

            for (int t = 0; t < delay; t += step)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n🐭 Le joueur a effrayé le rat ! Il s’enfuit !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1500);
                        ratEffraye = true;
                        break;
                    }
                }
                Thread.Sleep(step);
            }

            if (ratEffraye)
                return;

            // Le rat arrive sur une plante ?
            if (terrain.Cases[ligneChoisie, col] is Plante plante)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n🐭 Le rat a mangé une {plante.Nom} !");
                Console.ForegroundColor = ConsoleColor.White;
                terrain.Cases[ligneChoisie, col] = null;
                joueur.PlantesSurJardin.Remove(plante);
                Thread.Sleep(2000);
                return;
            }
        }

        Console.WriteLine("\n🐭 Le rat est reparti sans rien trouver.");
        Thread.Sleep(1500);
    }



}
