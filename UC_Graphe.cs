using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheorieDesGraphes
{
    public partial class UC_Graphe : UserControl
    {
        System.Drawing.Graphics graphics;
        public UC_Graphe()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }
        public void DessinerGraphe(Graphe graphe)
        {
            graphics.Clear(Color.White);
            foreach(Sommet som in graphe.listeSommet)
            {
                if (som.Position.HasValue)
                {
                    Color couleur;
                    if (!som.Marque)
                        couleur = Color.Black;
                    else
                        couleur = Color.Red;

                    Point pos = new Point(som.Position.Value.X * (this.Width - 20) / 1000, som.Position.Value.Y * (this.Height - 20) / 1000);
                    Rectangle rect = new Rectangle(pos, new Size(5, 5));
                    graphics.FillEllipse(new SolidBrush(couleur), rect);
                    graphics.DrawString(som.Libelle, new Font("Arial", 16), new SolidBrush(couleur), new PointF(pos.X + 10, pos.Y + 10));
                }
            }
            foreach(Arete ar in graphe.listeArete)
            {
                Pen couleur;
                if (!ar.Marque)
                    couleur = new Pen(Color.Black);
                else
                    couleur = new Pen(Color.Black);

                Point posA = new Point(ar.Destination.Position.Value.X * (this.Width - 20) / 1000, ar.Destination.Position.Value.Y * (this.Height - 20) / 1000);
                Point posB = new Point(ar.Origine.Position.Value.X * (this.Width - 20) / 1000, ar.Origine.Position.Value.Y * (this.Height - 20) / 1000);
                graphics.DrawLine(couleur, posA, posB);
            }
        }

        public void Effacer()
        {
            graphics.Clear(Color.White);
        }
    }
}
