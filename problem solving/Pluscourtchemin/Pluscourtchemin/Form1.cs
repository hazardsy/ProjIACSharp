using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pluscourtchemin
{
    public partial class Form1 : Form
    {
        static public double[,] matrice;
        static public int nbnodes = 10;
        static public int numinitial;
        static public int numfinal;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            matrice = new double[nbnodes, nbnodes];
            for (int i = 0; i < nbnodes; i++)
                for (int j = 0; j < nbnodes; j++)
                    matrice[i, j] = -1;

            matrice[0, 1] = 3;   matrice[1, 0] = 3;
            matrice[0, 2] = 5;      matrice[2, 0] = 5;
            matrice[0, 3] = 7;      matrice[3, 0] = 7;
            matrice[1, 4] = 8;      matrice[4, 1] = 8;
            matrice[2, 4] = 3;      matrice[4, 2] = 3;
            matrice[4, 5] = 7;      matrice[5, 4] = 7;
            matrice[5, 6] = 4;      matrice[6, 5] = 4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numinitial = Convert.ToInt32(textBox1.Text);
            numfinal = Convert.ToInt32(textBox2.Text);
            Graph g = new Graph();
            Node2 N0 = new Node2();
            N0.numero = numinitial;
            List<GenericNode> solution = g.RechercheSolutionAEtoile(N0);

            Node2 N1 = N0;
            for (int i=1; i < solution.Count; i++)
            {
                Node2 N2 = (Node2)solution[i];
                listBox1.Items.Add(Convert.ToString(N1.numero) 
                     + "--->"  + Convert.ToString(N2.numero)
                     + "   : " +Convert.ToString(matrice[N1.numero,N2.numero]));
                N1 = N2;
            }

            g.GetSearchTree(treeView1);
        }
    }
}
