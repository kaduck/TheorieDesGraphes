using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheorieDesGraphes
{
    public class Sommet
    {
        private Random rnd = new Random();
        /// <summary>
        /// Surcharge de l'opérateur d'équivalence on regarde le libelle
        /// </summary>
        public static bool operator ==(Sommet a, Sommet b)
        {
            return a.Libelle == b.Libelle;
        }
        public static bool operator !=(Sommet a, Sommet b)
        {
            return a.Libelle != b.Libelle;
        }
        public Point? Position ;
        public string Libelle { get; private set; }
        public bool Marque { get; set; }
        public Sommet(string Libelle,bool aleatoire=false)
        {

            this.Libelle = Libelle;
            Marque = false;
            if (aleatoire)
                Position = new Point(Fonctions.NombreAleatoire(1000), Fonctions.NombreAleatoire(1000));
        }
    }
}
