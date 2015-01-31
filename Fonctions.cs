using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Graphviz;

namespace TheorieDesGraphes
{ 
    static class Fonctions
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int NombreAleatoire(int max)
        {
            lock (syncLock)
            {
                return random.Next(max);
            }
        }
        public static int CalculAretes(int n)
        {
            return n > 1 ? n + CalculAretes(n - 1) : 1;
        }  
    }
}
