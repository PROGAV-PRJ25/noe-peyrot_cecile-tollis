public class Conditions
{
    public double Temperature { get; set; }
    public double Pluie { get; set; }
    public double Ensoleillement { get; set; }
    public bool Intemperie { get; set; }
    public bool IntrusPresent { get; set; }

    private Random rng = new Random();

    public void GenererAleatoires()
    {
        Temperature = rng.Next(-5, 35); // en °C
        Pluie = Math.Round(rng.NextDouble() * 2, 2); // de 0.0 à 2.0 mm
        Ensoleillement = Math.Round(rng.NextDouble() * 10, 1); // 0 à 10 (exposition)
        Intemperie = rng.NextDouble() < 0.1;
        IntrusPresent = rng.NextDouble() < 0.05;
    }

    public override string ToString()
    {
        return $" {Temperature}°C |  {Pluie}mm |  {Ensoleillement}/10 | Intempéries: {(Intemperie ? "Oui" : "Non")} | Intrus: {(IntrusPresent ? "Oui" : "Non")}";
    }
}
