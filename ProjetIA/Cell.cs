using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    public class Cell :GenericNode

    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool IsEqual(GenericNode N2)
        {
            Cell n2Cell = (Cell)N2;
            return X == n2Cell.X && Y == n2Cell.Y;
        }
        public override double GetArcCost(GenericNode N2)
        {
            Cell N2Cell = (Cell)N2;
            return (Math.Sqrt(Math.Pow(N2Cell.X - this.X, 2) + Math.Pow(N2Cell.Y - this.Y, 2)));
        }
        public override bool EndState()
        {
            return this.IsEqual(Form1.arrivee);
        }
        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> listeGenericNode = new List<GenericNode>();
            List<Cell> listSucc = Form1.listeNoeuds.FindAll(node => Math.Abs(node.X - this.X) <= 1 && Math.Abs(node.Y - this.Y) <= 1 && !this.IsEqual(node));
            foreach (Cell c in listSucc )
            {
                listeGenericNode.Add(c);
            }
            return listeGenericNode;
        }
        public override double CalculeHCost()
        {
           // return 0;
            //Distance de manhattan
            return Math.Abs(this.X - Form1.arrivee.X) + Math.Abs(this.Y - Form1.arrivee.Y);
            //Dist Eucl
            //return (Math.Sqrt(Math.Pow(Form1.arrivee.X - this.X, 2) + Math.Pow(Form1.arrivee.Y - this.Y, 2)));


        }
    }
}
