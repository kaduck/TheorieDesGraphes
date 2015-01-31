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
                Point pos = new Point(som.Position.X * (this.Width - 20) / 1000, som.Position.Y * (this.Height - 20) / 1000);
                Rectangle rect= new Rectangle(pos,new Size(5,5));
                graphics.FillEllipse(new SolidBrush(Color.Black), rect);
                graphics.DrawString(som.Libelle, new Font("Arial", 16), new SolidBrush(Color.Black), new PointF(pos.X + 10, pos.Y + 10));
            }
            foreach(Arete ar in graphe.listeArete)
            {
                Point posA = new Point(ar.Destination.Position.X * (this.Width - 20) / 1000, ar.Destination.Position.Y * (this.Height - 20) / 1000);
                Point posB = new Point(ar.Origine.Position.X * (this.Width - 20) / 1000, ar.Origine.Position.Y * (this.Height - 20) / 1000);
                graphics.DrawLine(Pens.Black, posA, posB);
            }
        }
    }
}
