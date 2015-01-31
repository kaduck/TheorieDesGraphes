using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheorieDesGraphes
{
    public partial class Main : Form
    {
        Graphe graphe;
        public Main()
        {
            InitializeComponent();
        }

        private void btGenerer_Click(object sender, EventArgs e)
        {
            int fact = Fonctions.CalculAretes((int)tbSommets.Value - 1);
            if (tbAretes.Value > Fonctions.CalculAretes((int)tbSommets.Value - 1))
                MessageBox.Show("Le nombre d'arêtes choisies est trop grand, veuillez modifier le nombre d'arêtes.\n");
            else
            {
                graphe = new Graphe((int)tbSommets.Value, (int)tbAretes.Value, cbConnexe.Checked);
                uC_Graphe.DessinerGraphe(graphe);
            }
        }

    }
}
