public class Maladie
{
    public Random ProbabiliteMaladie {get;set;}

    public Maladie()
    {
        ProbabiliteMaladie = new Random();
    }
    
    public void EstMalade(Plante plante)
    {
        if ((plante.EstVivante==true) && (plante.EstMalade==false))
        {
            int risqueMaladie = ProbabiliteMaladie.Next(0,101); // On tire une probabilité entre 0% et 100%.

            if (risqueMaladie<15) // C'est juste à titre indicatif, on peut changer cette valeur si tu veux !
            {
                plante.EstMalade = true;
                Console.WriteLine($"{plante.Nom} est tombée malade !"); // C'est mon Papa qui a proposé de prévenir le joueur, tu en penses quoi ?
            }
        }
    }

    public void AppliquerEffetMaladie(Plante plante) // Mon Papa a proposé ce nom, moi je suis pas fan, à toi de décider !
    {
        // Faire perte de la vie à la plante à chaque tour.
    }
}