// On définit ici le personnage incarné par le joueur au cours de la partie.

public class Joueur
{
    string Nom {get;set;} // Le nom permet d'offrir une expérience plus immersive dans le jeu.
    List<Plante> InventaireSemis {get;set;} // Cette liste permet de faire un inventaire des différentes plantes que le joueur peut semer au cours de la partie.
    List<Terrain> Terrains {get;set;} // Cette liste permet de répertorier les différents terrains possédés par le joueur au cours de la partie.
    int ActionsRestantes {get;set;} // Il y aura un nombre d'actions possibles par tour, et cette variable permettra d'indiquer à chaque instant le nombre d'actions restantes.
}