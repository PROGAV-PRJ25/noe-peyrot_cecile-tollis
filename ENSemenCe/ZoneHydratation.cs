public class ZoneHydratation
{
    public double HydratationMin {get; set;}
    public double HydratationMax {get; set;}

    public ZoneHydratation(double eauMin, double eauMax)
    {
        HydratationMin = eauMin;
        HydratationMax = eauMax;
    }

    public bool VerifieHydratation(double StockEau)
    {
        return (StockEau<=HydratationMax && StockEau >= HydratationMin);
    }
}