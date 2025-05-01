public class Webcam
{
    public void AfficherPlateau(Plateau plateau)
    {
        bool afficher = false;
        Console.WriteLine("Voulez vous afficher la webcam ? (Tappez le chiffre correspondant)");
        Console.WriteLine("1.Oui");
        Console.WriteLine("2.Non");
        int reponse = Convert.ToInt32(Console.ReadLine()!);
        if(reponse == 1)
        {
            afficher = true;
        }
        else
        {
            afficher = false;
        }
       
        if(afficher)
        {
            Console.WriteLine("Vous avez activé la webcam !");
            plateau.AfficherPlateau();
        }
    }
}
