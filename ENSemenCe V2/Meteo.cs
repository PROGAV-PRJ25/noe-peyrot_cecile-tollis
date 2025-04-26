public class Meteo
{
    public List<string> ListeMeteo {get;set;}
    public string MeteoActuelle {get;set;}
    public Random Changement {get;set;} // On crée une variable qui va permettre de changer la météo lors de la partie.

    public Meteo()
    {
        ListeMeteo = new List<string> {"petite pluie", "grosse pluie", "soleil", "sécheresse", "tornade"};
        MeteoActuelle = "soleil"; // On commence le jeu doucement.
        Changement = new Random();
    }

    public void ChangerMeteo()
    {
        int index = Changement.Next(0,ListeMeteo.Count); // Next(a,b) va de a à (b-1) donc pas de problème avec le .Count !
        MeteoActuelle = ListeMeteo[index];
    }

    // Il faudrait qu'on fasse une fonction qui détermine quelle météo est considérée comme dangereuse et donc activant le mode urgence.
}
