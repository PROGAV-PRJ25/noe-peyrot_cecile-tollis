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

    public void AppliquerMeteo()
    {
        
    }

    // Il faudrait qu'on fasse une fonction qui détermine quelle météo est considérée comme dangereuse et donc activant le mode urgence.
}



