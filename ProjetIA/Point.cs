using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    public class Point : GenericNode

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
            //IsEqual seulement si les points ont été traversés dans le même ordre
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

            //Distance entre le dernier point visité et le point donné
            return Form4points.distances[lastVisitedIndex, nextVisitedIndex];
        }

        public override bool EndState()
        {
            //Aucun point restant à visiter et le dernier point visité est l'arrivée
            return Restants.Length == 0 && Traverses.Last().IsEqual(Point.Arrivee);
        }

        public override List<GenericNode> GetListSucc()
        {
            
            List<GenericNode> listeGenericNode = new List<GenericNode>();

            foreach (Cell c in Restants)
            {
                List<Cell> nextRestant = new List<Cell>(Restants);
                List<Cell> nextTraverses = new List<Cell>(Traverses);

                nextRestant.Remove(c);
                nextTraverses.Add(c);

                Point node = new Point(nextTraverses.ToArray(), nextRestant.ToArray());
                listeGenericNode.Add(node);

            }

            //Toutes les combinaisons de concaténation entre Traverses et un élément de Restants
            return listeGenericNode;
        }

        public override double CalculeHCost()
        {
            
            Cell lastVisited = Traverses.Last();
            Cell farthestCell = null;
            double farthestDistance = 0;
            foreach (Cell c in Restants)
            {
                double distance = Math.Sqrt(Math.Pow(lastVisited.X - c.X, 2) + Math.Pow(lastVisited.Y - c.Y, 2));
                if (distance > farthestDistance)
                {
                    farthestCell = c;
                    farthestDistance = distance;
                }
            }

            Cell target = Traverses[0];
            double distanceToTarget = farthestCell != null ? Math.Sqrt(Math.Pow(farthestCell.X - target.X, 2) + Math.Pow(farthestCell.Y - target.Y, 2)) : 0;

            //Distance entre le dernier point visité et le point le plus loin de celui-ci + le retour du point le plus loin à l'arrivée
            return farthestDistance + distanceToTarget;
        }
    }
}
