public class Maladies 
{
    public string Nom {get; set;}
    public double ProbaInfection {get; set;}
    public int Dommage {get; set;}

    public Maladies(string nom, double probaInfection, int dommage)
    {
        Nom = nom;
        ProbaInfection = probaInfection;
        Dommage = dommage;
    }

    public bool EstInfecte()
    {
        bool planteInfectee = false; // booléen : true si la plante a une maladie, false sinon
        Random x = new Random();
        int rand = x.Next(1,101);
        if(rand > ProbaInfection)
        {
            return(planteInfectee);
        }
        else 
        {
            return(!planteInfectee);
        }
    }
}