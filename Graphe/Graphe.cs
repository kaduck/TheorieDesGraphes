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
        public List<Sommet> listeSommet { get; private set; }
        public List<Arete> listeArete { get; private set; }
        public Graphe ()
        {
            listeSommet = new List<Sommet>();
            listeArete = new List<Arete>();
        }

        public Graphe(int nbSommet,int nbArete, bool connexe)
        {
            listeSommet = new List<Sommet>();
            listeArete = new List<Arete>();

            for (int i = 0; i < nbSommet; i++)
            {
                AjouterSommet(new Sommet(((char)(i + 65)).ToString()));
            }
            for (int i = 0; i < nbArete; i++)
            {
                if (connexe)
                {
                    #region Connexe
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
                        } while (sommetNonLies.Count==0);
                        LierSommet(sommetOrigine, sommetNonLies[rnd.Next(sommetNonLies.Count())]);
                    }
                    #endregion
                }
                else
                {
                    Sommet sommetOrigine;
                    List<Sommet> sommetNonLies = new List<Sommet>();
                    do
                    {
                        sommetOrigine = listeSommet[rnd.Next(listeSommet.Count())];
                        List<Sommet> sommetLies = RecupererSommetsLies(sommetOrigine);
                        sommetNonLies = listeSommet.Except(sommetLies).ToList();
                    } while (sommetNonLies.Count == 0);
                    LierSommet(sommetOrigine, sommetNonLies[rnd.Next(sommetNonLies.Count())]);
                }
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
