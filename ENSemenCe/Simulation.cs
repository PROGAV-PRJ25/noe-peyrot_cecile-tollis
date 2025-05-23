public class Simulation
{
    public int nbTours;
    public int semaineActuelle;
    private Joueur? joueur1;
    private Plateau plateau;
    private Rose rose1;
    private Rose rose2;
    private Cerise cerise1;
    private Endive endive1;
    private Ble ble1;
    private Lotus lotus1;
    private Tournesol tournesol1;
    private Champignon champignon1;
    private Pissenlit pissenlit1;
    private Tulipe tulipe1;
    private Tulipe tulipe2;
    private Sapin sapin1;
    private Webcam webcam;
    private Meteo meteo;
    private bool modeUrgence = false; // Ce booléen détermine si le mode urgence se lance ou non (il est donc initialisé à false pour un début normal).
    private string typeIntrus = ""; // Pour savoir quel intrus est apparu : "Rat" ou "Indominus"
    private Intrus? intrusActuel = null; // L'intrus actif sur le plateau (Rat ou Indominus)
    private Rat rat;
    private Indominus indominus;

    public Simulation(int nbTours)
    {
        this.nbTours = nbTours;
        semaineActuelle = 1;
        plateau = new Plateau(9, 6); // On initialise un plateau de 9 lignes et 6 colonnes.

        rose1 = new Rose("Rose", "R"); // On crée deux roses : rose1 et rose2.
        rose2 = new Rose("Rose", "R");
        cerise1 = new Cerise("Cerise", "C"); // On crée une cerise.
        endive1 = new Endive("Endive", "E"); // On crée une endive.
        ble1 = new Ble("Blé", "B"); // On crée une pousse de blé.
        lotus1 = new Lotus("Lotus", "L"); // On crée un lotus.
        tournesol1 = new Tournesol("Tournesol", "T"); // On crée un tournesol.
        champignon1 = new Champignon("Champignon", "Ch"); // On crée un champignon.
        pissenlit1 = new Pissenlit("Pissenlit", "P"); // On crée un pissenlit.
        tulipe1 = new Tulipe("Tulipe", "Tu"); // On crée une tulipe.
        tulipe2 = new Tulipe("Tulipe", "Tu"); // On crée une tulipe.
        sapin1 = new Sapin("Sapin", "S"); // On crée un sapin.
        rat = new Rat("Rat", "R");
        indominus = new Indominus("Indominus", "I");

        webcam = new Webcam();
        meteo = new Meteo();
    }

    public void LancerSimulation()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        AfficherEffet();

        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(1000);
        InitialiserPartie();
        Console.WriteLine($"Bonjour {joueur1!.Nom} ! Et bienvenue dans ENSemenCe !!");
        Console.WriteLine($"Tu as {nbTours} semaines pour obtenir le plus beau des jardins !");

        Console.ForegroundColor = ConsoleColor.Red;
        Thread.Sleep(2000);
        Console.WriteLine("⚠️  Attention, tu ne peux effectuer que 3 actions chaque semaine ! ⚠️  Bonne chance !");
        Thread.Sleep(4000);
        Console.WriteLine("⚠️  La partie s'arrêtera lorsque tu attendras le nombre maximal de tour ou lorsque tu n'auras plus de plantes dans ton jardin et dans ton inventaire !");
        Thread.Sleep(5000);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        while (semaineActuelle <= nbTours && (joueur1.InventaireSemis.Count != 0 || joueur1.PlantesSurJardin.Count != 0))
        {
            // Au début de chaque tour, on teste si le mode urgence doit se lancer ou si la partie continue normalement.
            Random r = new Random();
            TesterModeUrgence(r);

            if (joueur1.PlantesSurJardin.Count != 0)
            {
                if (TesterModeUrgence(r) == true)
                {
                    ActiverModeUrgence();
                    Console.WriteLine("Seulement une heure vient de s'écouler depuis l'incident !");
                }
            }



            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Semaine {semaineActuelle}"); // On annonce le numéro de la semaine.
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var plante in joueur1.PlantesSurJardin) // On affiche toutes les plantes déjà plantées pour suivre leur évolution.
            {
                plante.AfficherDonnees(plante, joueur1);
                Console.WriteLine();
                plante.AfficherPlante();
                Console.WriteLine("Appuie sur une touche pour continuer");
                Console.ReadKey();
                Console.WriteLine();
            }

            Console.Write("La météo de la semaine est : ");
            Console.WriteLine(meteo.ChangerMeteo()); // On annonce la météo de la semaine.
            meteo.AppliquerMeteo(joueur1, plateau); // On applique les effets de la météo.
            joueur1!.NbActionsPossibles = 3; // On initialise le nombre d'actions possibles par tour pour le joueur, ici 3.

            webcam.AfficherPlateau(plateau);


            int choix = 10; // On l'a défini au hasard et différent de 0.
            while (choix != 0 && joueur1.NbActionsPossibles != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\nSemaine {semaineActuelle}"); // On annonce le numéro de la semaine.
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"{joueur1!.Nom}, il te reste {joueur1.NbActionsPossibles} actions maximum !"); // On rappelle le nombre d'actions. 
                Console.WriteLine("Choisis l'action que tu souhaites effectuer :");
                Console.WriteLine("1. Semer ");
                Console.WriteLine("2. Arroser");
                Console.WriteLine("3. Récolter");
                Console.WriteLine("4. Voir mes récoltes");
                Console.WriteLine("5. Désherber un terrain");
                Console.WriteLine("0. Passer à la semaine suivante");
                choix = Convert.ToInt32(Console.ReadLine()!);

                Console.Clear();
                if (choix != 0)
                {
                    if (choix == 1)
                    {
                        if (joueur1.InventaireSemis.Count != 0)
                        {
                            bool bonnePlante = false;
                            int numPlante = 0; // On déclare numPlante à l'extérieur de la boucle pour pouvoir l'utiliser en-dehors.
                            while (!bonnePlante)
                            {
                                Console.WriteLine("Quelle plante veux-tu semer ?");
                                int index = 1;
                                foreach (var plante in joueur1.InventaireSemis) // On affiche toutes les plantes dans l'inventaire.
                                {
                                    Console.WriteLine($"{index}. {plante.Nom}");
                                    index++;
                                }
                                Console.WriteLine("Entre le numéro de la plante : ");
                                numPlante = Convert.ToInt32(Console.ReadLine()!);

                                if (numPlante <= 0 || numPlante > joueur1.InventaireSemis.Count)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("La plante choisie n'est pas dans la liste ! Tape le bon numéro !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    bonnePlante = true;
                                }
                            }

                            var planteChoisie = joueur1.InventaireSemis[numPlante - 1];
                            joueur1!.Semer(plateau, planteChoisie);
                            plateau.AfficherPlateau();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tu ne peux plus semer de plantes, ton inventaire est vide !");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }

                    else if (choix == 2)
                    {
                        Console.WriteLine("Sur quel type de terrain veux-tu arroser ? (Terre, Sable, Argile)");
                        string typeTerrain = Convert.ToString(Console.ReadLine()!.ToLower());
                        joueur1!.Arroser(plateau, typeTerrain);
                    }

                    else if (choix == 3)
                    {
                        joueur1!.Recolter(plateau);
                        plateau.AfficherPlateau();
                    }

                    else if (choix == 4)
                    {
                        joueur1!.AfficherInventaireRecoltes();
                    }
                    else if (choix == 5)
                    {
                        joueur1.Desherber(plateau);
                        plateau.AfficherPlateau();
                    }

                }
            }
            foreach (var plante in joueur1.PlantesSurJardin.ToList()) // Mise à jour en fin de semaine des conditions de chaques plantes 
            {
                plante.NiveauEau = plante.NiveauEau - 10;
                plante.VerifierConditions(plante, joueur1);
                plante.Pousser(plante);

            }
            Console.Clear();
            semaineActuelle++;
            plateau.FairePousserMauvaisesHerbes();
            /*
            if (semaineActuelle % 2 == 0) // Les mauvaises herbes poussent une semaine sur 2
            {
                plateau.FairePousserMauvaisesHerbes();
            }
            */
            


        }
        Console.Clear();
        Console.WriteLine("C'est la fin de la partie !");
        Thread.Sleep(500);
        Console.WriteLine("Voici l'inventaire de tes récoltes");
        joueur1!.AfficherInventaireRecoltes();
        Thread.Sleep(1000);
        AfficherFin();

    }

    public void AfficherEffet()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("-");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("---");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans en semence");
        Thread.Sleep(1500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans");
        Thread.Sleep(1000);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe -");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe --");
        Thread.Sleep(500);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--- Bienvenue dans ENSemenCe ---");
        Thread.Sleep(1500);
    }

    public void AfficherFin()
    {
        Console.WriteLine(@" __  __               _ ");
        Console.WriteLine(@"|  \/  | ___ _ __ ___(_)");
        Console.WriteLine(@"| |\/| |/ _ \ '__/ __| |");
        Console.WriteLine(@"| |  | |  __/ | | (__| |");
        Console.WriteLine(@"|_|  |_|\___|_|  \___|_|");
        Thread.Sleep(4000);
    }

    public void InitialiserPartie()
    {
        // On crée un joueur. 
        Console.WriteLine("Comment t'appelles-tu jeune jardinier ?");
        string nom = Convert.ToString(Console.ReadLine()!)!;
        joueur1 = new Joueur(nom);

        // On remplit son inventaire avec les différentes plantes :
        joueur1.InventaireSemis.Add(rose1);
        joueur1.InventaireSemis.Add(rose2);
        joueur1.InventaireSemis.Add(cerise1);
        joueur1.InventaireSemis.Add(endive1);
        joueur1.InventaireSemis.Add(ble1);
        joueur1.InventaireSemis.Add(lotus1);
        joueur1.InventaireSemis.Add(tournesol1);
        joueur1.InventaireSemis.Add(champignon1);
        joueur1.InventaireSemis.Add(pissenlit1);
        joueur1.InventaireSemis.Add(tulipe1);
        joueur1.InventaireSemis.Add(tulipe2);
        joueur1.InventaireSemis.Add(sapin1);
    }

    public void ActiverModeUrgence()
    {
        Console.Clear();
        ConsoleColor originalBackground = Console.BackgroundColor;
        Console.BackgroundColor = ConsoleColor.Red;

        Console.WriteLine($"🚨  MODE URGEEEENNCCEEEE  🚨");
        Console.WriteLine($"🚨  Attention, un intrus vient de s'introduire dans ton jardin !");

        if (typeIntrus == "Rat")
        {
            Console.WriteLine("🐭  Oh non, il s'agit d'un méchant rat !");
            Thread.Sleep(1000);
            rat.Agir(plateau, joueur1!);
            intrusActuel = rat;
        }
        else
        {
            Console.WriteLine("🦖  Au secours, un terrible Indominus est là !!");
            indominus.Agir(plateau, joueur1!);
            intrusActuel = indominus;
        }

        Thread.Sleep(1000);
        Console.BackgroundColor = originalBackground;
        Console.Clear();
    }


    public bool TesterModeUrgence(Random r) // Pourcentage de chance qu'un rat ou qu'un indominus arrive
    {
        int probaUrgence = r.Next(0, 101);
        if (probaUrgence < 87)
        {
            modeUrgence = false;
            typeIntrus = "";
        }
        else if (probaUrgence < 94)
        {
            modeUrgence = true;
            typeIntrus = "Rat";
        }
        else
        {
            modeUrgence = true;
            typeIntrus = "Indominus";
        }
        return modeUrgence;
    }
    



}
