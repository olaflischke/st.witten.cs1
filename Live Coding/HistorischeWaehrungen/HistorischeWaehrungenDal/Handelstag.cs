namespace HistorischeWaehrungenDal
{
    public class Handelstag
    {
        public DateOnly Datum { get; set; }
        public List<Waehrung> Waehrungen { get; set; }
    }
}