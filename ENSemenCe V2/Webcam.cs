public class Webcam
{
    public void AfficherPlateau(Plateau plateau)
    {
        // Est-ce qu'on fait le test pour afficher la webcam ici ou dans Simulation ? 
        Console.WriteLine("Vous avez activé la webcam !");
        plateau.AfficherPlateau();
    }
}
