using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheorieDesGraphes
{
    public class Arete
    {
        public Arete(Sommet origine, Sommet destination)
        {
            Origine = origine;
            Destination = destination;
        }
        public Sommet Origine { get; private set; }
        public Sommet Destination { get; private set; }
        public bool Marque { get; set; }
    }
}
