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
                Console.WriteLine("Une petite pluie vient arroser les plantes !");
                foreach (var plante in joueur.PlantesSurJardin)
                {
                    plante.NiveauEau += 1;
                }
                break;

            case "Soleil":
                Console.WriteLine("Un beau soleil est présent dans le ciel, les plantes poussent normalement.");
                // Pas d'effet particulier
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
                    plante.NiveauEau += 20;
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
                break;

            case "Petit vent":
                Console.WriteLine("Un petit vent a déplacé les plantes !");
                // Effet à coder.
                break;

            default:
                Console.WriteLine("Météo inconnue, aucun effet.");
                break;
        }
    }


    // Il faudrait qu'on fasse une fonction qui détermine quelle météo est considérée comme dangereuse et donc activant le mode urgence.
}


