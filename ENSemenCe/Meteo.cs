
public class Meteo
{
    public List<string> ListeMeteo {get;set;}
    public List<string> ListeMeteoDangereuse {get;set;}
    public string MeteoExceptionnelle {get;set;}
    public string MeteoActuelle {get;set;}
    public Random Changement {get;set;} // On crée une variable qui va permettre de changer la météo lors de la partie.

    public Meteo()
    {
        ListeMeteo = new List<string> {"Petite pluie", "Soleil", "Nuageux"};
        ListeMeteoDangereuse = new List<string> {"Grosse pluie", "Sécheresse", "Tornade"};
        MeteoExceptionnelle = "Petit vent";
        MeteoActuelle = "Soleil"; // On commence le jeu doucement.
        Changement = new Random();
    }

    public string ChangerMeteo()
    {
        int nombre = Changement.Next(0,101); // On choisit un nombre entre 0 et 100 pour déterminer la météo.
        if (nombre<80) // Il y a 80% de chances que la météo soit classique.
        {
            int index = Changement.Next(0,ListeMeteo.Count); // On choisit aléatoirement dans la liste des météos classiques.
            MeteoActuelle = ListeMeteo[index]; 
        }
        else if (80<=nombre && nombre<95) // Il y a 15% de chances que la météo soit dangereuse.
        {
            int index = Changement.Next(0,ListeMeteoDangereuse.Count); // On choisit aléatoirement dans la liste des météos dangereuses.
            MeteoActuelle = ListeMeteoDangereuse[index]; 
        }
        else // Il y a 5% de chances que la météo soit exceptionnelle.
        {
            MeteoActuelle = MeteoExceptionnelle; 
        }
        
        return MeteoActuelle;
    }

    public void AppliquerMeteo(Joueur joueur, Plateau plateau)
    {
        switch (MeteoActuelle)
        {
            case "Petite pluie":
                Console.WriteLine("Une petite pluie vient arroser le jardin !");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    plante.NiveauEau = Math.Min(plante.EtatSante+5,100);
                }
                break;

            case "Soleil":
                Console.WriteLine("Un beau soleil est présent dans le ciel.");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    plante.EtatSante = Math.Min(plante.EtatSante+3,10); // Etat de santé ne doit pas dépasser 10
                    plante.NiveauEau = plante.NiveauEau -10;
                }
                break;

            case "Nuageux":
                Console.WriteLine("Le ciel est couvert, les plantes ne poussent pas aussi vite que prévu...");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    if(plante.StadeCroissance>0)
                    {
                        plante.StadeCroissance--;
                    }
                }
                break;

            case "Grosse pluie":
                Console.WriteLine("Attention à la grosse pluie ! Certaines plantes risquent la noyade...");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    plante.NiveauEau = Math.Min(plante.EtatSante+20,100);
                }
                break;

            case "Sécheresse":
                Console.WriteLine("Une sécheresse affaiblit les plantes !");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    plante.NiveauEau -= 20;
                    if (plante.NiveauEau < 0) 
                    {
                        plante.NiveauEau = 0; // On évite un niveau d'eau négatif comme cela.
                    }
                }
                break;

            case "Tornade":
                Console.WriteLine("Une tornade a arraché des plantes !");
                joueur.PlantesSurJardin.Clear(); // Effet extrême, à peaufiner.
                foreach(var terrain in plateau.Terrains)
                {
                    foreach(var plante in joueur.PlantesSurJardin)
                    {
                        plante.SupprimerPlante(plante,terrain);
                    }
                }
                break;

            case "Petit vent":
                if (joueur.PlantesSurJardin.Count>=2)
                {
                    Random rnd = new Random();
                    int i1 = rnd.Next(joueur.PlantesSurJardin.Count);
                    int i2 = rnd.Next(joueur.PlantesSurJardin.Count);

                    // Utilisation d'un while pour ne pas échanger une plante avec elle-même :
                    while (i2==i1)
                    {
                        i2 = rnd.Next(joueur.PlantesSurJardin.Count);
                    }

                    Plante plante1 = joueur.PlantesSurJardin[i1];
                    Plante plante2 = joueur.PlantesSurJardin[i2];

                    // Identifier sur quel terrain ces plantes se trouvent, et les échanger dans les cases
                    Terrain? terrainCible1 = plante1.TerrainActuel;
                    Terrain? terrainCible2 = plante2.TerrainActuel;

                    if (terrainCible1!=null && terrainCible2!=null)
                    {
                        // Ce sont les coordonnées des plantes, on les fixe à une valeur initiale qui permettra de savoir si on a bien trouvé les plantes.
                        int x1 = -1;
                        int y1 = -1;
                        int x2 = -1;
                        int y2 = -1;

                        // Chercher la plante 1
                        for (int i=0; i<terrainCible1.Cases.GetLength(0); i++)
                        {
                            for (int j=0; j<terrainCible1.Cases.GetLength(1); j++)
                            {
                                if (terrainCible1.Cases[i,j]==plante1)
                                {
                                    x1 = i;
                                    y1 = j;
                                    break;
                                }
                            }
                        }

                        // Chercher la plante 2
                        for (int i=0; i<terrainCible2.Cases.GetLength(0); i++)
                        {
                            for (int j=0; j<terrainCible2.Cases.GetLength(1); j++)
                            {
                                if (terrainCible2.Cases[i,j]==plante2)
                                {
                                    x2 = i;
                                    y2 = j;
                                    break;
                                }
                            }
                        }

                        // Échanger les plantes dans les cases du terrain
                        if (x1!=-1 && y1!=-1 && x2!=-1 && y2!=-1)
                        {
                            terrainCible1.Cases[x1,y1] = plante2;
                            terrainCible2.Cases[x2,y2] = plante1;

                            Console.WriteLine("Un petit vent a soufflé ! Deux plantes ont changé de place dans ton jardin.");
                        }

                        else
                        {
                            Console.WriteLine("Impossible de trouver les plantes à échanger sur les terrains.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Une des plantes n'est pas dans un terrain valide.");
                    }
                }

                else
                {
                    Console.WriteLine("Petit vent, mais pas assez de plantes pour échanger.");
                }

                break;


            default:
                Console.WriteLine("Météo inconnue, aucun effet.");
                break;
        }
    }


    // Il faudrait qu'on fasse une fonction qui détermine quelle météo est considérée comme dangereuse et donc activant le mode urgence.
}


