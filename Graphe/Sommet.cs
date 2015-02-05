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
        public bool Egal(Sommet b)
        {
            return Libelle == b.Libelle;
        }

        public Point? Position ;
        public string Libelle { get; private set; }
        public EnumMarque Marque { get; set; }
        public int Previsite { get; set; }
        public int Hauteur { get; set; }
        public Sommet(string Libelle,bool aleatoire=false)
        {

            this.Libelle = Libelle;
            Marque = EnumMarque.NonMarque;
            if (aleatoire)
                Position = new Point(Fonctions.NombreAleatoire(1000), Fonctions.NombreAleatoire(1000));
        }
    }
}
