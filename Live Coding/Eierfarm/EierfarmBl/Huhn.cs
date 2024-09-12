using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl;

public class Huhn : Gefluegel
{
    public Huhn(string name) : base(name) // Aufruf des Konstruktors der Basisklasse
    {
        this.Gewicht = 1000;
    }

    public override void Fressen()
    {
        if (this.Gewicht < 3000)
        {
            //this.Gewicht = this.Gewicht + 100;
            this.Gewicht += 100;
        }
    }

    public override void EiLegen()
    {
        if (this.Gewicht > 1500)
        {
            Ei ei = new Ei(this);
            this.Gewicht -= ei.Gewicht;
            this.Eier.Add(ei);
        }
    }
}
