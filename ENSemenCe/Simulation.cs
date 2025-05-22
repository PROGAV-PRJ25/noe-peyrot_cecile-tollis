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
    private Webcam webcam;
    private Meteo meteo;
    private bool modeUrgence = false; // Ce booléen détermine si le mode urgence se lance ou non (il est donc initialisé à false pour un début normal).

    public Simulation(int nbTours)
    {
        this.nbTours = nbTours;
        semaineActuelle = 1;
        plateau = new Plateau(9,6); // On initialise un plateau de 9 lignes et 6 colonnes.
        
        rose1 = new Rose("Rose", "R"); // On crée deux roses : rose1 et rose2.
        rose2 = new Rose("Rose", "R"); 
        cerise1 = new Cerise("Cerise", "C"); // On crée une cerise.
        endive1 = new Endive("Endive", "E"); // On crée une endive.
        ble1 = new Ble("Blé", "B"); // On crée une pousse de blé.
        lotus1 = new Lotus("Lotus", "L"); // On crée un lotus.
        tournesol1 = new Tournesol("Tournesol", "T"); // On crée un tournesol.

        webcam = new Webcam();
        meteo = new Meteo();
    }

    public void LancerSimulation()
    {
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
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        while(semaineActuelle <= nbTours)
        {   
            // Au début de chaque tour, on teste si le mode urgence doit se lancer ou si la partie continue normalement.
            Random r = new Random();
            TesterModeUrgence(r);

            if (TesterApparitionRat())
            {
                Rat rat = new Rat("Rat", "R");
                rat.Agir(plateau, joueur1!);
            }

            if (TesterModeUrgence(r) == true)
            {
                // ActiverModeUrgence();
            }

            else // Si le mode urgence n'est pas activé, la partie se déroule classiquement.
            {
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
                    Console.WriteLine($"\n Semaine {semaineActuelle}"); // On annonce le numéro de la semaine.
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"{joueur1!.Nom}, il te reste {joueur1.NbActionsPossibles} actions maximum !"); // On rappelle le nombre d'actions. 
                    Console.WriteLine("Choisis l'action que tu souhaites effectuer :");
                    Console.WriteLine("1. Semer ");
                    Console.WriteLine("2. Arroser");
                    Console.WriteLine("3. Récolter");
                    Console.WriteLine("4. Voir mes récoltes");
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
                    }
                }
                foreach (var plante in joueur1.PlantesSurJardin)
                {
                    plante.VerifierConditions(plante, joueur1);
                    plante.Pousser(plante);
                    plante.NiveauEau = plante.NiveauEau - 10;
                }
                Console.Clear();
                semaineActuelle++;
            }
        }   
                
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
    }

    public string typeIntrus = "";
    public bool TesterModeUrgence(Random r)
    {
        int probaUrgence = r.Next(0,101); // On détermine un nombre entre 0 et 100 pour savoir si on lance le mode urgence ou pas.

        if(probaUrgence<85) // Il y a 85% de chances de continuer le jeu normalement.
        {
            modeUrgence = false;
        }

        else if(probaUrgence>=85 && probaUrgence<95) // Il y a 10% de chances que le mode urgence se lance à cause d'un rat.
        {
            modeUrgence = true;
            Rat rat1 = new Rat("Rat","R");
            typeIntrus = "Rat";

        }

        else // Il y a 5% de chances que le mode urgence se lance à cause de l'arrivée d'un Indominus.
        {
            modeUrgence = true;
            Indominus indominus1 = new Indominus("Indominus","I");
            typeIntrus = "Indominus";
        }

        return modeUrgence;
    }
    
    public bool TesterApparitionRat()
    {
        Random r = new Random();
        int chance = r.Next(0, 100); // 0 à 99
        return chance < 99; // 20% de chance
    }


    public void ActiverModeUrgence(Plateau plateau)
    {
        ConsoleColor originalBackground = Console.BackgroundColor; // On sauvegarde le fond de base avant de le changer.
        Console.BackgroundColor = ConsoleColor.Red;

        Console.WriteLine($"Attention, un intrus vient de s'introduire dans ton jardin !");

        if (typeIntrus == "Rat")
        {
            Console.WriteLine("Oh non, il s'agit d'un méchant rat !");
        }

        else
        {
            Console.WriteLine("Au secours, un terrible Indominus est là !!");
        }

        /*
        Code à avancer : Il faut récupérer la case du coin supérieur droit pour y placer le rat ou l'Indominus, c'est de là que les intrus vont arriver pour le moment.
        foreach(var terrain in plateau.Terrains)
        {
            for (int i=0; i<terrain.Cases.GetLength(0); i++)
            {
                for (int j=0; j<terrain.Cases.GetLength(1); j++)
                {
                    if (terrain.Cases[i,j] == null)
                    {
                        Console.Write(" . "); // Case vide.
                    }
                        
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($" {terrain.Cases[i,j]!.Symbole} "); // Case occupée par une plante (symbole de la plante) - ! évite la valeur nulle
                        Console.ForegroundColor = ConsoleColor.White;
                    }       
                }

                Console.WriteLine();
            }
        }
        */

        plateau.AfficherPlateau();
        // Faire en sorte d'afficher l'intrus.

        Console.BackgroundColor = originalBackground; // On rétablit le fond une fois que l'urgence est terminée.

    }

}
