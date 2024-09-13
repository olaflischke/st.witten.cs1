
using System.Xml.Linq;

namespace HistorischeWaehrungenDal
{
    /// <summary>
    /// Stellt ein Archiv dar.
    /// </summary>
    /// <remarks>
    /// Ein Archiv stellt Daten der EZB zu historischen Währungskursen bereit.
    /// </remarks>
    /// <exception cref="HistorischeWaehrungenDalException">Tritt auf, wenn beim Datenlesen etwas fehlschlägt.</exception>
    public class Archiv
    {
        /// <summary>
        /// Erstellt eine neue Archiv-Instanz mit den GESMES-XML-Daten aus der URL
        /// </summary>
        /// <param name="url">URL einer GESME-XML-Datei.</param>
        public Archiv(string url)
        {
            this.Handelstage = GetData(url);
        }

        /// <summary>
        /// Liest die Daten der durch die URL gg. GESMES-Datei und gibt eine Liste von Handelstag-Objekten zurück.
        /// </summary>
        /// <param name="url">URL einer GESME-XML-Datei.</param>
        /// <returns>Liste von Handelstag-Objekten</returns>
        private List<Handelstag>? GetData(string url)
        {
            try
            {
                XDocument xmlDokument = XDocument.Load(url);

                var qCubes = xmlDokument.Root
                                        .Descendants()
                                        .Where(xe => xe.Name.LocalName == "Cube"
                                                        && xe.Attributes().Any(at => at.Name == "time"))
                                        // Projektion
                                        .Select(xe => new Handelstag(xe));// { Datum = DateOnly.Parse(xe.Attribute("time").Value) });

                return qCubes.ToList();

            }
            catch (HttpRequestException ex) // Spezieller Catch-Block 
            {
                return GetDataFromDb();
            }

            catch (Exception ex) // Allgemeiner Catch-Block
            {
                throw new HistorischeWaehrungenDalException("Fehler beim Datenlesen", ex);
            }
            finally
            {
                // Wird immer ausgeführt
                // Gut zum Aufräumen
            }


            //List<Handelstag> tage = new List<Handelstag>();
            //foreach (var xe in qCubes)
            //{
            //    Handelstag tag = new Handelstag();
            //    tage.Add(tag);
            //}

            //return tage;


        }

        private List<Handelstag>? GetDataFromDb()
        {
            return null;
        }

        public List<Handelstag> Handelstage { get; set; }
    }
}
