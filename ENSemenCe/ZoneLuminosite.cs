public class ZoneLuminosite
{
    public double LumMax {get; set;}
    public double LumMin {get; set;}

    public ZoneLuminosite(double lumMin, double lumMax)
    {
        LumMin = lumMin;
        LumMax = lumMax;
    }

    public bool VerifieLuminosite(double NiveauLuminosite)
    {
        return (NiveauLuminosite<=LumMax && NiveauLuminosite >= LumMin);
    }
}