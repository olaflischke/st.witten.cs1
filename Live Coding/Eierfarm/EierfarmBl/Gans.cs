using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Gans : Gefluegel
    {
        public Gans(string name) : base(name)
        {
            this.Gewicht = 2000;
        }

        public int Steuerkurs { get; set; }

        public override void Fressen()
        {
            if (this.Gewicht < 5000)
            {
                this.Gewicht += 250;
            }
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 2500)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }
    }
}