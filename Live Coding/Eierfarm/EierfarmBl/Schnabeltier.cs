using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEileger
    {
        public List<Ei> Eier { get; set; } = new List<Ei>();
        public double Gewicht { get; set; }

        public void EiLegen()
        {
            if (this.Gewicht > 2000)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public void Fressen()
        {
            if (this.Gewicht < 4500)
            {
                this.Gewicht += 250;
            }
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}