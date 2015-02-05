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

        public static int CalculNbGrapheMax(int nbSommets, int nbAretes)
        {
            int nbGraphe = 0;
            int i = 0;
            while(nbGraphe == 0)
            {
                i++;
                if (nbAretes <= CalculAretes(nbSommets - i) && nbAretes > CalculAretes(nbSommets - i - 1))
                {
                    nbGraphe = i;
                }
            }
            return nbGraphe;
        }

        private static bool VerifierMarquage(List<Sommet> listeSommet)
        {
            foreach (var item in listeSommet)
	        {
                if (item.Marque == EnumMarque.NonMarque)
                    return false;
	        }
            return true;
        }

        private static void ParcoursLargeur(Graphe graphe)
        {
            List<Sommet> sommetsOuverts = new List<Sommet>() { graphe.listeSommet[0] };
            List<Sommet> sommetsAdjacents = new List<Sommet>();
            List<Sommet> sommetsAdjacentAjouter = new List<Sommet>();
            graphe.listeSommet[0].Marque = EnumMarque.Ouvert;
            while (sommetsOuverts.Count>0)
            {
                sommetsAdjacents = graphe.ObtenirSommetsAdjacents(sommetsOuverts[0]);
                foreach (var sommetAdjacent in sommetsAdjacents)
                {
                    graphe.listeSommet.Where(t => t == sommetAdjacent).First().Marque = EnumMarque.Ouvert;
                    sommetsOuverts.Add(sommetAdjacent);
                }
                graphe.listeSommet.Where(t => t == sommetsOuverts[0]).First().Marque = EnumMarque.Ferme;
                sommetsOuverts.Remove(sommetsOuverts[0]);
            }
        }

        public static Boolean TestConnexite(Graphe graphe)
        {
            ParcoursLargeur(graphe);
            if(VerifierMarquage(graphe.listeSommet))
            {
                return true;
            }else{
                return false;
            }
        }

        public static List<Sommet> SommetArticulation(Graphe graphe)
        {
            int previsite;
            List<Sommet> pileSommets = new List<Sommet>();
            List<Sommet> listeSommetArticulation = new List<Sommet>();
            List<Arete> ensembleArcs = new List<Arete>();
            List<Arete> listeAretes = graphe.listeArete;
            List<Sommet> listeSommets = graphe.listeSommet.Where(t => t.Marque == EnumMarque.NonMarque).ToList();

            while(!VerifierMarquage(listeSommets))
            {
                previsite = 1;
                listeSommets = listeSommets.Where(t => t.Marque == EnumMarque.NonMarque).ToList();
                listeSommets[0].Marque = EnumMarque.Ouvert;
                pileSommets.Add(graphe.listeSommet[0]);
                listeSommets[0].Previsite = previsite;
                listeSommets[0].Hauteur = previsite;
                previsite++;
                while (pileSommets.Count > 0)
                {
                    if (ExisteSommetAdjacent(pileSommets.Last(),listeSommets,listeAretes))
                    {
                        Sommet y = ObtenirSommetsAdjacents(pileSommets.Last(), listeSommets, listeAretes).First();
                        listeSommets.First(t => t == y).Marque = EnumMarque.Ouvert;
                        ensembleArcs.Add(new Arete(pileSommets.Last(), y));
                        pileSommets.Add(listeSommets.First(t => t == y));
                        //ensembleArcs.Add(listeAretes.First(t => t.Destination == y && t.Origine == pileSommets.Last()
                        //   || t.Destination == pileSommets.Last() && t.Origine == y));
                        listeSommets.First(t => t == y).Previsite = previsite;
                        previsite++;
                        listeSommets.First(t => t == y).Hauteur = listeSommets.First(t => t == y).Previsite;
                    }
                    else
                    {
                        listeSommets.First(t => t == pileSommets.Last()).Marque = EnumMarque.Ferme;

                        List<Sommet> listeSommetSuccesseur = ObtenirSommetsAdjacents(pileSommets.Last(),listeSommets,listeAretes,false);
                        List<Sommet> SommetsASupprimer = new List<Sommet>();
                        foreach (Sommet item in listeSommetSuccesseur)
                        {
                            if (RechercherArc(item, pileSommets.Last(), ensembleArcs))
                                SommetsASupprimer.Add(item);
                        }

                        foreach (Sommet item in SommetsASupprimer)
                        {
                            listeSommetSuccesseur.Remove(item);
                        }

                        foreach (Sommet successeur in listeSommetSuccesseur)
                        {
                            listeSommets.First(t => t == pileSommets.Last()).Hauteur = (listeSommets.First(t => t == pileSommets.Last()).Hauteur < successeur.Hauteur) ? listeSommets.First(t => t == pileSommets.Last()).Hauteur : successeur.Hauteur;
                        }
                        pileSommets.Remove(pileSommets.Last());
                    }
                }
                if (ObtenirSommetsAdjacents(listeSommets[0], listeSommets, ensembleArcs, false).Count >= 2)
                {
                    listeSommetArticulation.Add(listeSommets[0]);
                }
                foreach(Sommet x in listeSommets)
                {
                    if (listeSommets.Count>0 && Different(x,listeSommets[0]))
                    {
                        List<Arete> listeArcSuccesseur = RechercherArcsOrigine(x, ensembleArcs);
                        foreach (Arete y in listeArcSuccesseur)
	                    {
                            if (y.Destination.Hauteur >= x.Previsite)
                                listeSommetArticulation.Add(x);
	                    }
                    }
                }
            }

            return listeSommetArticulation;
        }

        private static bool ExisteSommetAdjacent(Sommet sommet, List<Sommet> listeSommets, List<Arete> listeAretes)
        {
            return listeAretes.Exists(t => (t.Destination == sommet && t.Origine.Marque == EnumMarque.NonMarque) || (t.Origine == sommet && t.Destination.Marque == EnumMarque.NonMarque));
        }

        private static List<Arete> RechercherArcsOrigine(Sommet origine, List<Arete> ensembleArcs)
        {
            return ensembleArcs.Where(t => t.Origine == origine).ToList();
        }

        private static bool RechercherArc(Sommet origine, Sommet destination, List<Arete> ensembleArcs)
        {
            return ensembleArcs.Exists(t => (t.Destination.Egal(destination) && t.Origine.Egal(origine)));
        }

        public static List<Sommet> ObtenirSommetsAdjacents(Sommet sommet,List<Sommet> listeSommets,List<Arete> listeAretes, bool nonMarques = true)
        {
            if (nonMarques)
            {
                List<Arete> listeAdjacents = listeAretes.Where(t => t.Origine == sommet || t.Destination == sommet).ToList();
                List<Sommet> sommetAdjacents = listeAretes.Where(t => t.Origine == sommet).Select(t => t.Destination).Where(t => t.Marque == EnumMarque.NonMarque).ToList();
                sommetAdjacents.AddRange(listeAretes.Where(t => t.Destination == sommet).Select(t => t.Origine).Where(t => t.Marque == EnumMarque.NonMarque).ToList());
                sommetAdjacents = sommetAdjacents.Distinct().ToList();
                return sommetAdjacents;
            }
            else
            {
                List<Arete> listeAdjacents = listeAretes.Where(t => t.Origine == sommet || t.Destination == sommet).ToList();
                List<Sommet> sommetAdjacents = listeAretes.Where(t => t.Origine == sommet).Select(t => t.Destination).ToList();
                sommetAdjacents.AddRange(listeAretes.Where(t => t.Destination == sommet).Select(t => t.Origine).ToList());
                sommetAdjacents = sommetAdjacents.Distinct().ToList();
                return sommetAdjacents;
            }

        }

        public static bool Different(Sommet a, Sommet b)
        {
            if (b != null)
                return a.Libelle != b.Libelle;
            else
                return a != null;
        }

    }

    public enum EnumMarque
    {
        NonMarque,
        Ouvert,
        Ferme
    }
}
