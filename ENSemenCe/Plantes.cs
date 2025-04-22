public abstract class Plantes 
{
    public string Nom {get; set;}

    bool EstComestible {get; set;}

    bool EstAnnuel {get; set;}
    
    List <string> SaisonsDeSemis {get; set;}

    TypeTerrain TerrainPrefere {get; set;}

    double Espacement {get; set;}

    double EspaceNecessaire {get; set;}

    double VitesseCroissance {get; set;}

    ZoneHydratation HydratationPreferee {get; set;}
    double StockEau {get;set;}

    ZoneLuminosite LuminositePreferee {get; set;}
    double NiveauLuminosite {get;set;}

    ZoneTemperature TemperaturePreferee {get;set;}

    List<Maladies> MaladiesProbables {get; set;}

    int EsperanceDeVie {get; set;}

    int NombreDeProduits {get; set;}

    double EtatSante {get; set;}

    bool EstMorte {get; set;}


    public Plantes(string nom, bool estComestible, bool estAnnuel, List <string> saisonsDeSemis, TypeTerrain terrainPrefere, double espacement, double espaceNecessaire, ZoneHydratation hydratationPreferee ,double stockEau,ZoneLuminosite luminositePreferee ,double niveauLuminosite, ZoneTemperature temperaturePreferee, List<Maladies> maladiesProbables, int esperanceDeVie,  int nombreDeProduits, double etatSante, bool estMorte)
    {
        Nom = nom;
        EstComestible = estComestible;
        EstAnnuel = estAnnuel;
        SaisonsDeSemis = saisonsDeSemis;
        TerrainPrefere = terrainPrefere;
        Espacement = espacement;
        EspaceNecessaire = espaceNecessaire;
        HydratationPreferee = hydratationPreferee;
        StockEau = stockEau;
        NiveauLuminosite = niveauLuminosite;
        LuminositePreferee = luminositePreferee;
        TemperaturePreferee = temperaturePreferee;
        MaladiesProbables = maladiesProbables;
        EsperanceDeVie = esperanceDeVie;
        NombreDeProduits = nombreDeProduits;
        EtatSante = etatSante;
        EstMorte  = estMorte;
    }

    public abstract void Pousser(); //Conditions

    public void VerifierConditions() //Terrain terrain, Condition meteo
    {
        /*
            if(terrain.Type != TerrainPrefere)
            {
                EtatSante = EtatSante -5;
            }

            if(!(TemperaturePreferee.VerifieTemperature(meteo.Temperature))
            {
                EtatSante = EtatSante -5;
            }

            if(!(LuminositePreferee.VerifieLuminosite(meteo.Ensoleillement)))
            {
                EtatSante = EtatSante -5;
            }

            if(!(HydratationPreferee.VerifieHydatation(Plantes.StockEau)))
            {
                EtatSante = EtatSante -5;
            }

            if(EtatSante <50)
            {
                EstMort=true;
            }
        */
    }

    public abstract void AfficherPlante();
    public abstract void SupprimerPlante();

}