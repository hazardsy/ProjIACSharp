using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    public class Point :GenericNode

    { 
        public static Cell Arrivee { get; set; }
        
        public Cell[] Traverses { get; set; }

        public Cell[] Restants { get; set; }

        public Point(Cell[] traverses, Cell[] restants)
        {
            Traverses = traverses;
            Restants = restants;
        }

        public override bool IsEqual(GenericNode N2)
        {
            Point n2point = (Point)N2;

            if (Traverses.Length != n2point.Traverses.Length)
                return false;

            for (int i = 0; i < Traverses.Length; i++)
                if (!Traverses[i].IsEqual(n2point.Traverses[i]))
                    return false;

            return true;
        }
        public override double GetArcCost(GenericNode N2)
        {
            Point n2point = (Point)N2;

            Cell lastVisited = Traverses.Last();
            Cell nextVisited = n2point.Traverses.Last();


            int lastVisitedIndex = Array.FindIndex(Form4points.allPoints, n => n.IsEqual(lastVisited));
            int nextVisitedIndex = Array.FindIndex(Form4points.allPoints, n => n.IsEqual(nextVisited));

            return Form4points.distances[lastVisitedIndex, nextVisitedIndex];
        }

        public override bool EndState()
        {
            return Restants.Length == 0 && Traverses.Last().IsEqual(Point.Arrivee);
        }

        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> listeGenericNode = new List<GenericNode>();

            foreach(Cell c in Restants)
            {
                List<Cell> nextRestant = new List<Cell>(Restants);
                List<Cell> nextTraverses = new List<Cell>(Traverses);

                nextRestant.Remove(c);
                nextTraverses.Add(c);

                Point node = new Point(nextTraverses.ToArray(), nextRestant.ToArray());
                listeGenericNode.Add(node);

            }
            return listeGenericNode;
        }

        public override double CalculeHCost()
        {
            return 0;
            //Distance de manhattan
            //return Math.Abs(this.X - Form1.arrivee.X) + Math.Abs(this.Y - Form1.arrivee.Y);
            //Dist Eucl
            //return (Math.Sqrt(Math.Pow(Form1.arrivee.X - this.X, 2) + Math.Pow(Form1.arrivee.Y - this.Y, 2)));
        }
    }
}
