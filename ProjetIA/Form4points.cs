using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA
{
    public partial class Form4points : Form
    {
        private const int tailleCase = 25;
        PictureBox[,] tableauImage = new PictureBox[20, 20];
        public static List<Cell> listeNoeuds = new List<Cell>();
        public static Cell depart;
        public static double[,] distances;
        public static Cell[] allPoints;

        public Form4points()
        {
            InitializeComponent();
            this.BackColor = Color.PapayaWhip;
            PictureBox fond = new PictureBox();
            fond.Size = new Size(20 * (tailleCase + 1) - 1, 20 * (tailleCase + 1) - 1);
            fond.Top = 60;
            fond.BackColor = Color.Black;
            this.Controls.Add(fond);
            for (int k = 0; k < 20; k++)
            {
                for (int i = 0; i < 20; i++)
                {

                    tableauImage[k, i] = new PictureBox();
                    this.Controls.Add(tableauImage[k, i]);
                    tableauImage[k, i].Height = tailleCase;
                    tableauImage[k, i].Width = tailleCase;
                    bool temp = Obstacles.chercheObstacle(k, i);
                    tableauImage[k, i].BackColor = Obstacles.chercheObstacle(k, i) ? Color.Black : Color.White;
                    if (!Obstacles.chercheObstacle(k, i))
                    {
                        listeNoeuds.Add(new Cell(k, i));
                    }
                    tableauImage[k, i].Top = k * (tailleCase + 1) + 60;
                    tableauImage[k, i].Left = i * (tailleCase + 1);
                    tableauImage[k, i].Show();

                }
            }

            fond.SendToBack();
            this.ClientSize = new Size(20 * (tailleCase + 1) - 1, 20 * (tailleCase + 1) - 1 + 60);

            comboBoxPoint1Y.SelectedIndex = 0;
            comboBoxPoint1X.SelectedIndex = 6;

            comboBoxPoint2Y.SelectedIndex = 0;
            comboBoxPoint2X.SelectedIndex = 7;

            comboBoxPoint3Y.SelectedIndex = 1;
            comboBoxPoint3X.SelectedIndex = 7;

            comboBoxPoint4Y.SelectedIndex = 2;
            comboBoxPoint4X.SelectedIndex = 7;

            comboBoxDepartX.SelectedIndex = 2;
            comboBoxDepartY.SelectedIndex = 1;

            depart = new Cell(4, 3);
        }

        //Remet l'affichage à zéro
        private void reInitTableau()
        {
            for (int k = 0; k < 20; k++)
            {
                for (int i = 0; i < 20; i++)
                {
                    tableauImage[k, i].BackColor = Obstacles.chercheObstacle(k, i) ? Color.Black : Color.White;
                    tableauImage[k, i].Image = null;
                }
            }
        }

        //Retourne le chemin le plus court entre depart et arrivée, avec le cout de ce chemin en valeur de sortie supplémentaire
        private List<GenericNode> getBestPath(Cell depart, Cell arrivee, out double cost)
        {
            Graph G = new Graph();

            Cell.Arrivee = arrivee;

            List<GenericNode> solution = G.RechercheSolutionAEtoile(depart);

            cost = 0;
            for (int i = 1; i < solution.Count; i++)
            {
                cost += solution.ElementAt(i - 1).GetArcCost(solution.ElementAt(i));
            }

            return solution;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reInitTableau();
            Cell caseDepart = new Cell(comboBoxDepartX.SelectedIndex + 1, comboBoxDepartY.SelectedIndex + 1);
            List<Cell> points = new List<Cell>();

            if (!Obstacles.chercheObstacle(caseDepart))
            {
                points.Add(new Cell(comboBoxPoint1X.SelectedIndex + 1, comboBoxPoint1Y.SelectedIndex + 1));
                points.Add(new Cell(comboBoxPoint2X.SelectedIndex + 1, comboBoxPoint2Y.SelectedIndex + 1));
                points.Add(new Cell(comboBoxPoint3X.SelectedIndex + 1, comboBoxPoint3Y.SelectedIndex + 1));
                points.Add(new Cell(comboBoxPoint4X.SelectedIndex + 1, comboBoxPoint4Y.SelectedIndex + 1));

                depart = new Cell(comboBoxDepartX.SelectedIndex + 1, comboBoxDepartY.SelectedIndex + 1);

                //Tous les points dans un tableau (dont le départ)
                allPoints = new Cell[points.Count + 1];
                allPoints[0] = depart;
                for (int i = 0; i < points.Count; i++)
                {
                    allPoints[i + 1] = points[i];
                }

                //distances[i,j] = longueur la plus courte entre allPoints[i] et allPoints[j]
                distances = new double[allPoints.Length, allPoints.Length];

                //paths[i,j] = chemin le plus court entre allPoints[i] et allPoints[j]
                List<GenericNode>[,] paths = new List<GenericNode>[allPoints.Length, allPoints.Length];

                for (int i = 0; i < allPoints.Length; i++)
                {
                    for (int j = i; j < allPoints.Length; j++)
                    {
                        double cost = 0;
                        List<GenericNode> bestPath = getBestPath(allPoints[i], allPoints[j], out cost);

                        distances[i, j] = cost;
                        distances[j, i] = cost;
                        paths[i, j] = new List<GenericNode>(bestPath);
                        bestPath.Reverse();
                        paths[j, i] = bestPath;

                    }
                }

                Point.Arrivee = depart;

                Cell[] startingPath = new Cell[] { depart };
                Point startingPoint = new Point(startingPath, allPoints);

                Graph G = new Graph();

                List<GenericNode> solution = G.RechercheSolutionAEtoile(startingPoint);

                //Récupération de la solution en termes de cellules pour l'affichage
                List<GenericNode> usableSolution = new List<GenericNode>();

                Point lastNode = (Point)solution.Last();
                for (int i = 1; i < lastNode.Traverses.Length; i++)
                {
                    int previousIndex = Array.FindIndex(allPoints, n => n.IsEqual(lastNode.Traverses[i - 1]));
                    int nextIndex = Array.FindIndex(allPoints, n => n.IsEqual(lastNode.Traverses[i]));
                    usableSolution = usableSolution.Concat(paths[previousIndex, nextIndex]).ToList();
                }

                //Affichage
                foreach (GenericNode c in usableSolution)
                {
                    Cell c2 = (Cell)c;
                    tableauImage[c2.X, c2.Y].BackColor = Color.Blue;
                }

                for (int i = 0; i < points.Count; i++)
                {
                    Cell c = points.ElementAt(i);
                    tableauImage[c.X, c.Y].BackColor = Color.BlueViolet;
                    tableauImage[c.X, c.Y].ImageLocation = @"../../Element" + (i + 1).ToString() + ".png";
                }

                tableauImage[depart.X, depart.Y].BackColor = Color.Green;
                tableauImage[depart.X, depart.Y].ImageLocation = @"../../Link.png";
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nouvForm2 = new Form1();
            this.Hide();
            nouvForm2.ShowDialog();
            this.Close();
        }
    }
}
