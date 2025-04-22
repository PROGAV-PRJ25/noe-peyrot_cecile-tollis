// On définit ici le personnage incarné par le joueur au cours de la partie.

public class Joueur
{
    // On définit les différents attirbuts associés à la classe Joueur :
    public string Nom {get;set;} // Le nom permet d'offrir une expérience plus immersive dans le jeu.
    public List<Plante> InventaireSemis {get;set;} // Cette liste permet de faire un inventaire des différentes plantes que le joueur peut semer au cours de la partie.
    public int ActionsRestantes {get;set;} // Il y aura un nombre d'actions possibles par tour, et cette variable permettra d'indiquer à chaque instant le nombre d'actions restantes.

    // On définit le constructeur de la classe Joueur :
    public Joueur (string nom, List<Plante> inventaireSemis, int actionsRestantes)
    {
        Nom = nom;
        InventaireSemis = inventaireSemis;
        ActionsRestantes = actionsRestantes;
    }

    // On définit les différentes méthodes associées à la classe Joueur : 
    public void Semer(Plante p, Terrain t)
    {
        // On vérifie si le terrain est disponible.
        // On vérifie si la plante est compatible avec le terrain.
        // On ajoute la plante au terrain.
        // On ajoute la plante à la liste des plantes du joueur.
    }

    public void ArroserSousTerrain(Terrain sousTerrain, double quantiteEau)
    {
        // On arrose toutes les plantes situées sur un sous-terrain choisi.
    }


    public void Recolter(Terrain sousTerrain)
    {
        // On récolte les plantes mûres situées sur le sous-terrain choisi.
    }

    public void TraiterPlanteMalade(Plante plante, Maladie traitement)
    {
        // On traite une plante malade.
    }

    public void Desherber(Terrain sousTerrain)
    {
        // On désherbe un sous-terrain choisi.
    }

    public void InstallerProtection(Terrain sousTerrain, string type)
    {
        // On pose une protection (pare-soleil, serre, etc.) dans un sous-terrain choisi.
    }

    public void ActionUrgence(string action)
    {
        // On effectue une action d'urgence (effrayer un intrus, etc.).
    }

    public void AfficherEtatPotager()
    {
        // On affiche les plantes et leurs états, ainsi que leur position sur le terrain.
    }

}

