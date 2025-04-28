Plateau plateau = new Plateau(9,6);

// Création d'une Tomate
Tomate tomate = new Tomate("T");

// Création d'un joueur 
Joueur joueur = new Joueur("Jean"); // A modifier en demandant le nom au début 

// Ajout de la Tomate dans l'inventaire de semis du joueur
joueur.InventaireSemis.Add(tomate);
plateau.AfficherPlateau();
