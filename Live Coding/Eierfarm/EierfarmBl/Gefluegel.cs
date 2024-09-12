using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEileger, IGefluegel
    {
        protected Gefluegel(string name)
        {
            this.Name = name;
        }

        public List<Ei> Eier { get; set; } = new List<Ei>();

        public double Gewicht { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public DateTime Schluepfdatum { get; set; } = DateTime.Now;

        public abstract void Fressen();
        public abstract void EiLegen();
    }
}