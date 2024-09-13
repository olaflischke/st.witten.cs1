using System.Globalization;
using System.Xml.Linq;

namespace HistorischeWaehrungenDal
{
    public class Handelstag
    {
        public Handelstag(XElement handelstagNode)
        {
            this.Datum = DateOnly.Parse(handelstagNode.Attribute("time").Value);

            //CultureInfo ciEzb=new CultureInfo("pl-PL");
            //NumberFormatInfo nfiEzb = ciEzb.NumberFormat;

            NumberFormatInfo nfiEzb = new NumberFormatInfo() { CurrencyDecimalSeparator = "." };

            var qWaehrungen = handelstagNode.Elements()
                                            .Select(el => new Waehrung()
                                            {
                                                IsoZeichen = el.Attribute("currency").Value,
                                                EuroKurs = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb) //NumberFormatInfo.InvariantInfo)
                                            });

            this.Waehrungen = qWaehrungen.ToList();
        }

        public DateOnly Datum { get; set; }
        public List<Waehrung> Waehrungen { get; set; }
    }
}