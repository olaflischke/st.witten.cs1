using HistorischeWaehrungenDal;

namespace HistorischeWaehrungenDalUnitTests
{
    public class Tests
    {
        string url;

        [SetUp]
        public void Setup()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [Test]
        public void KannArchivInitialisieren()
        {
            Archiv archiv = new Archiv(url);

            Handelstag? erster=archiv.Handelstage.FirstOrDefault();
            if (erster != null)
            {
                Waehrung? usd = erster.Waehrungen.FirstOrDefault();
                if (usd != null)
                {
                    Console.WriteLine($"{erster.Datum}: {usd.EuroKurs} {usd.IsoZeichen}");
                }
            }

            Assert.AreEqual(GetAttributeCount("time"), archiv.Handelstage.Count);
        }

        private double GetAttributeCount(string attributeName)
        {
            // TODO: Implementieren
            return 64;
        }
    }
}