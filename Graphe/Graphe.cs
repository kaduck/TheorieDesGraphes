using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheorieDesGraphes
{
    public class Graphe
    {
        private Random rnd = new Random();
        public List<Sommet> listeSommet { get; set; }
        public List<Arete> listeArete { get; set; }
        public Graphe ()
        {
            listeSommet = new List<Sommet>();
            listeArete = new List<Arete>();
        }

        public Graphe(int nbSommet, int nbArete, bool connexe)
        {
            listeSommet = new List<Sommet>();
            listeArete = new List<Arete>();
            for (int i = 0; i < nbSommet; i++)
            {
                AjouterSommet(new Sommet(((char)(i + 65)).ToString()));
            }
            if (connexe)
            {
                #region Connexe
                for (int i = 0; i < nbArete; i++)
                {
                    List<Sommet> sommetsNonMarques = listeSommet.Where(t => !t.Marque).ToList();
                    List<Sommet> sommetsMarques = listeSommet.Where(t => t.Marque).ToList();
                    int tailleNonLies = sommetsNonMarques.Count;
                    int tailleLies = sommetsMarques.Count;
                    Sommet sommetOrigine;

                    if (tailleNonLies != 0)
                    {
                        if (i == 0)
                        {
                            sommetOrigine = sommetsNonMarques[rnd.Next(tailleNonLies)];
                            sommetsNonMarques.Remove(sommetOrigine);
                            tailleNonLies -= 1;
                        }
                        else
                        {
                            sommetOrigine = sommetsMarques[rnd.Next(tailleLies)];
                        }
                        LierSommet(sommetOrigine, sommetsNonMarques[rnd.Next(tailleNonLies)]);
                    }
                    else
                    {
                        List<Sommet> sommetNonLies = new List<Sommet>();
                        do
                        {
                            sommetOrigine = listeSommet[rnd.Next(tailleLies)];
                            List<Sommet> sommetLies = RecupererSommetsLies(sommetOrigine);
                            sommetNonLies = listeSommet.Except(sommetLies).ToList();
                        } while (sommetNonLies.Count == 0);
                        LierSommet(sommetOrigine, sommetNonLies[rnd.Next(sommetNonLies.Count())]);
                    }
                }
                #endregion
            }
            else
            {
                #region Non connexe
                int nbGrapheMax = Fonctions.CalculNbGrapheMax(nbSommet, nbArete);
                int nbGrapheMin = (nbSommet - nbArete < 2) ? 2 : nbSommet - nbArete;
                int nbGraphe = rnd.Next(nbGrapheMin, nbGrapheMax);
                int nbSommetRestant = nbSommet;
                int nbSommetMarque = 0;
                int nbSommetGraphe = nbSommetRestant - nbGraphe + 1;
                int?[,] listeGraphes = new int?[nbGraphe, nbSommetGraphe];

                for (int j = 0; j < nbGraphe; j++)
                {
                    if (j < nbGraphe - 1)
                        nbSommetGraphe = rnd.Next(1, nbSommetRestant - nbGraphe + 1);
                    else
                        nbSommetGraphe = nbSommet - nbSommetMarque;
                    for (int k = 0; k < nbSommetGraphe; k++)
                    {
                        listeGraphes[j, k] = nbSommetMarque;
                        nbSommetMarque++;
                    }
                }

                for (int j = 0; j < nbGraphe; j++)
                {
                    int nbAretesMarque = 0;
                    for (int k = 0; k < listeGraphes.GetLength(1) ; k++)
                    {
                        int test = listeGraphes.GetLength(1);
                        if (listeGraphes[j, k].HasValue && k+1<listeGraphes.GetLength(1) && listeGraphes[j, k + 1].HasValue)
                        {
                            LierSommet(listeSommet[listeGraphes[j, k].Value], listeSommet[listeGraphes[j, k + 1].Value]);
                            nbAretesMarque++;
                        }
                    }
                }
                #endregion
            }
        }

        private List<Sommet> RecupererSommetsLies(Sommet sommet)
        {
            List<Arete> aretesLies = listeArete.Where(t => t.Origine == sommet || t.Destination == sommet).ToList();
            List<Sommet> sommetLies = new List<Sommet>();
            foreach (Arete aretes in aretesLies)
            {
                if (!sommetLies.Contains(aretes.Destination))
                    sommetLies.Add(aretes.Destination);
                if (!sommetLies.Contains(aretes.Origine))
                    sommetLies.Add(aretes.Origine);
            }
            return sommetLies;
        }

        public void AjouterSommet(Sommet sommet)
        {
            if (!listeSommet.Exists(t => t == sommet))
                listeSommet.Add(sommet);
        }
        public void LierSommet(Sommet origine, Sommet destination)
        {
            if (!listeArete.Exists(t => (t.Origine == origine && t.Destination == destination) || (t.Origine == destination && t.Destination == origine)))
            {
                listeArete.Add(new Arete(origine, destination));
                origine.Marque = true;
                destination.Marque = true;
            }
        }
    }
}
