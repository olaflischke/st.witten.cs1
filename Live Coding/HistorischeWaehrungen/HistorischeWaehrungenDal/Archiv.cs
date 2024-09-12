
using System.Xml.Linq;

namespace HistorischeWaehrungenDal
{
    public class Archiv
    {
        public Archiv(string url)
        {
            this.Handelstage = GetData(url);
        }

        private List<Handelstag>? GetData(string url)
        {
            XDocument xmlDokument = XDocument.Load(url);

            var qCubes = xmlDokument.Root
                                    .Descendants()
                                    .Where(xe => xe.Name.LocalName == "Cube"
                                                    && xe.Attributes().Any(at => at.Name == "time"))
                                    // Projektion
                                    .Select(xe => new Handelstag() { Datum = DateOnly.Parse(xe.Attribute("time").Value) });

            return qCubes.ToList();

            //List<Handelstag> tage = new List<Handelstag>();
            //foreach (var xe in qCubes)
            //{
            //    Handelstag tag = new Handelstag();
            //    tage.Add(tag);
            //}

            //return tage;


        }

        public List<Handelstag> Handelstage { get; set; }
    }
}
