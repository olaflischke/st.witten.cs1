using EierfarmBl;

namespace EierfarmBlTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void KannHuhnFressen()
        {
            // Huhn instanziieren
            Huhn huhn = new Huhn("Hilde"); // ggf. Projektverweis unter "Abhängigkeiten"
            // Gewicht vor dem Fressen
            double gewichtVorher = huhn.Gewicht;
            Console.WriteLine($"Gewicht vor dem Fressen: {gewichtVorher}g.");
            // Fressen
            huhn.Fressen();
            // Gewicht nach dem Fressen
            double gewichtNachher = huhn.Gewicht;
            Console.WriteLine($"Gewicht nach dem Fressen: {gewichtNachher}g.");
            // Testergebnis
            Assert.Greater(gewichtNachher, gewichtVorher);
        }

        [Test]
        public void KannHuhnEilegen()
        {
            // Huhn instanziieren
            Huhn huhn = new Huhn("Hilde");
            int anzahlVorher = huhn.Eier.Count;

            // Zum Eilegen Gewicht anpassen
            huhn.Gewicht = 1600;
            huhn.EiLegen();

            // Ergebnis
            int anzahlNachher = huhn.Eier.Count;
            Assert.That(anzahlNachher, Is.GreaterThan(anzahlVorher));
        }
    }
}