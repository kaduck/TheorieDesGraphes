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

        #region Variables globales
        Graphe graphe;
        List<Sommet> ListeAttenteSommet;
        List<Arete> listeAretes = null;
        bool lectureSeule=false;
        #endregion

        public Main()
        {
            InitializeComponent();
        }
        
        private void ArreterEcriture(bool p)
        {
            if (p)
            {
                lectureSeule = true;
                btGenerer.Enabled = false;
                dgvMatrice.Enabled = false;
                tbSommets.Enabled = false;
            }
            else
            {
                lectureSeule = false;
                btGenerer.Enabled = true;
                dgvMatrice.Enabled = true;
                tbSommets.Enabled = true;
            }
        }

        private void AjouterPoint(Point Position)
        {
            Sommet sommet = ListeAttenteSommet.First();

            graphe.listeSommet.First(t => t == sommet).Position = Position;
            ListeAttenteSommet.Remove(sommet);
            sommet = graphe.listeSommet.First(t => t == sommet);

            List<Sommet> sommetPositionees = graphe.listeSommet.Where(t => t.Position != null).ToList();
            int indexSource = ExtraireIndexMatrice(sommet);
            foreach (Sommet item in sommetPositionees)
            {
                int indexDest = ExtraireIndexMatrice(item);
                if ((string)dgvMatrice.Rows[indexDest].Cells[indexSource].Value == "1")
                {
                    if (!listeAretes.Exists(t=>(t.Destination==sommet && t.Origine == item) || (t.Origine==sommet && t.Destination ==item)))
                    graphe.listeArete.Add(new Arete(sommet, item));
                }
            }
            uC_Graphe.DessinerGraphe(graphe);
            if (ListeAttenteSommet.Count>0)
                EcrireInstruction(ListeAttenteSommet.First());
            else
            {
                ArreterEcriture(false);
                lbInstruction.Text = "";
            }
        }

        private void EcrireInstruction(Sommet sommet)
        {
            lbInstruction.Text = "Choisissez une position pour " + sommet.Libelle + " : ";
        }

        private int ExtraireIndexMatrice(Sommet sommet)
        {
            int index = 0;

            foreach (DataGridViewColumn column in dgvMatrice.Columns)
            {
                if (column.Name == sommet.Libelle)
                    index = column.Index;
            }
            return index;
        }

        #region Evenements
        private void tbSommets_ValueChanged(object sender, EventArgs e)
        {
            dgvMatrice.Columns.Clear();
            dgvMatrice.Rows.Clear();
            for (int i = 0; i < tbSommets.Value; i++)
            {
                string nomColonne = ((char)(i + 65)).ToString();
                int indexLigne;
                int indexColonne;
                indexColonne = dgvMatrice.Columns.Add(nomColonne, nomColonne);
                indexLigne = dgvMatrice.Rows.Add();
                dgvMatrice.Columns[indexColonne].Width = 25;
                dgvMatrice.Rows[indexLigne].Tag = nomColonne;
                dgvMatrice.Rows[indexLigne].Cells[indexColonne].Style.BackColor = Color.Gray;
            }
        }

        private void dgvMatrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && (e.ColumnIndex != e.RowIndex) && !lectureSeule)
            {
                object valeur = dgvMatrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dgvMatrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((string)valeur == "1") ? "0" : "1";
                dgvMatrice.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = dgvMatrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
        }

        private void uC_Graphe_Click(object sender, EventArgs e)
        {
            Point Position = ((UserControl)sender).PointToClient(Control.MousePosition);
            Position.X = Position.X * 1000 / ((UserControl)sender).Width;
            Position.Y = Position.Y * 1000 / ((UserControl)sender).Height;
            if (ListeAttenteSommet.Count > 0)
            {
                AjouterPoint(Position);
            }
        }

        private void btGenerer_Click(object sender, EventArgs e)
        {
            graphe = new Graphe();
            uC_Graphe.Effacer();
            if (tbSommets.Value > 0)
            {
                ListeAttenteSommet = new List<Sommet>();
                listeAretes = new List<Arete>();

                for (int i = 0; i < dgvMatrice.ColumnCount; i++)
                {
                    string nomSommet = dgvMatrice.Columns[i].Name;
                    ListeAttenteSommet.Add(new Sommet(nomSommet));
                    graphe.listeSommet.Add(new Sommet(nomSommet));
                }

                EcrireInstruction(ListeAttenteSommet.First());
                ArreterEcriture(true);
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nombre de sommets supérieur à 0");
            }

            #region AncienFonctionnement
            //int fact = Fonctions.CalculAretes((int)tbSommets.Value - 1);
            //if (cbConnexe.Checked && tbAretes.Value > Fonctions.CalculAretes((int)tbSommets.Value - 1))
            //    MessageBox.Show("Le nombre d'arêtes choisies est trop grand, veuillez modifier le nombre d'arêtes.");
            //else if (cbConnexe.Checked && tbAretes.Value < tbSommets.Value - 1)
            //    MessageBox.Show("Le nombre d'arêtes choisies est trop petit, veuillez modifier le nombre d'arêtes.");
            //else if (!cbConnexe.Checked && tbAretes.Value > Fonctions.CalculAretes((int)tbSommets.Value - 2))
            //    MessageBox.Show("Le nombre d'arêtes choisies est trop grand, veuillez modifier le nombre d'arêtes.");
            //else
            //{
            //    graphe = new Graphe((int)tbSommets.Value, (int)tbAretes.Value, cbConnexe.Checked);
            //    uC_Graphe.DessinerGraphe(graphe);
            //}
            #endregion
        }
        #endregion
    }
}
