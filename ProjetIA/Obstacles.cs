using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA
{
    static class Obstacles
    {
        private static List<Cell> listeObstacles = new List<Cell>();

        public static List<Cell> GetObstacles()
        {
            if(listeObstacles.Count==0)
            {
                listeObstacles.Add(new Cell(11,8));
                for(int i=3;i<9;i++)
                    for(int k=4; k<6; k++)
                        listeObstacles.Add(new Cell(i, k));
                for (int i = 1; i < 12; i++)
                    listeObstacles.Add(new Cell(i, 9));
                for (int i = 1; i < 5; i++)
                    listeObstacles.Add(new Cell(i, 15));
                for (int i = 16; i < 20; i++)
                    listeObstacles.Add(new Cell(4,i));
                for (int i = 1; i < 7; i++)
                    listeObstacles.Add(new Cell(11, i));
                for (int i = 12; i < 16; i++)
                    for(int k =5; k<7;k++)
                        listeObstacles.Add(new Cell(i, k));
                for (int i = 14; i < 19; i++)
                    for (int k = 10; k < 12; k++)
                        listeObstacles.Add(new Cell(i, k));
                for (int i = 12; i < 17; i++)
                    for (int k = 15; k < 17; k++)
                        listeObstacles.Add(new Cell(i, k));
                for (int i = 0; i < 20; i++)
                    listeObstacles.Add(new Cell(i, 0));
                for (int i = 0; i < 20; i++)
                    listeObstacles.Add(new Cell(i, 19));
                for (int i = 1; i < 19; i++)
                    listeObstacles.Add(new Cell(0, i));
                for (int i = 1; i < 19; i++)
                    listeObstacles.Add(new Cell(19, i));
            }
            return listeObstacles;
        }

        public static bool chercheObstacle(int x, int y)
        {
            List<Cell> temp = GetObstacles();
            return GetObstacles().Exists(cell => (cell.X == x && cell.Y == y));
        }
    }
}
