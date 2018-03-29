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
    public partial class Form1 : Form
    {
        private const int tailleCase = 25;
        PictureBox[,] tableauImage = new PictureBox[20, 20];
        public static List<Cell>  listeNoeuds = new List<Cell>();
        public static Cell depart;
        public static Cell arrivee;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.PapayaWhip;
            PictureBox fond = new PictureBox();
            fond.Size = new Size(20 * (tailleCase + 1) - 1, 20 * (tailleCase + 1) - 1);
            fond.Top = 40;
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
                    tableauImage[k, i].BackColor = Obstacles.chercheObstacle(k,i)?Color.Black:Color.White;
                    if(!Obstacles.chercheObstacle(k,i))
                    {
                        listeNoeuds.Add(new Cell(k, i));
                    }
                    tableauImage[k, i].Top = k*(tailleCase+1)+40;
                    tableauImage[k, i].Left = i*(tailleCase+1);
                    tableauImage[k, i].Show();

                }
            }

            fond.SendToBack();
            this.ClientSize = new Size(20 * (tailleCase + 1)-1, 20 * (tailleCase + 1)-1+40);

            comboBoxArriveeX.SelectedIndex = 15;
            comboBoxArriveeY.SelectedIndex = 16;
            comboBoxDepartX.SelectedIndex = 2;
            comboBoxDepartY.SelectedIndex = 1;
            arrivee = new Cell(17, 18);
            depart = new Cell(4, 3);
        }
        private void reInitTableau()
        {
            for (int k = 0; k < 20; k++)
            {
                for (int i = 0; i < 20; i++)
                {
                    tableauImage[k, i].BackColor = Obstacles.chercheObstacle(k, i) ? Color.Black : Color.White;
                    tableauImage[k, i].Image=null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reInitTableau();
            Cell caseDepart = new Cell(comboBoxDepartX.SelectedIndex + 1, comboBoxDepartY.SelectedIndex + 1);
            if (!Obstacles.chercheObstacle(caseDepart))
            {

                arrivee = new Cell(comboBoxArriveeX.SelectedIndex + 1, comboBoxArriveeY.SelectedIndex + 1);
                depart = new Cell(comboBoxDepartX.SelectedIndex + 1, comboBoxDepartY.SelectedIndex + 1);

                Cell.Arrivee = arrivee;

                Graph G = new Graph();

                List<GenericNode> solution = G.RechercheSolutionAEtoile(depart);
                List<GenericNode> fermes = G.L_Fermes;
                foreach(GenericNode c in fermes)
                {
                    Cell cBis = (Cell)c;
                    tableauImage[cBis.X, cBis.Y].BackColor = Color.LightSteelBlue;
                }
                foreach (GenericNode c in solution)
                {
                    Cell cBis = (Cell)c;
                    tableauImage[cBis.X, cBis.Y].BackColor = Color.Blue;
                }
            }
            tableauImage[arrivee.X, arrivee.Y].BackColor = Color.Red;
            tableauImage[arrivee.X, arrivee.Y].ImageLocation = @"../../Zelda.png";
            tableauImage[depart.X, depart.Y].BackColor = Color.Green;
            tableauImage[depart.X, depart.Y].ImageLocation = @"../../Link.png";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4points nouvForm = new Form4points();
            this.Hide();
            nouvForm.ShowDialog();
            this.Close();
        }
    }
}
