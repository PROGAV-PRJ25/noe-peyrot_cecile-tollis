public class ZoneTemperature
{
    public double TemperatureMin {get; set;}
    public double TemperatureMax {get; set;}

    public ZoneTemperature(double min, double max)
    {
        TemperatureMin = min;
        TemperatureMax = max;
    }

    public bool VerifieTemperature(double temperatureActuelle)
    {
        return (temperatureActuelle<=TemperatureMax && temperatureActuelle >= TemperatureMin);
    }
}