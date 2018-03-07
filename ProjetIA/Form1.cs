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
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.PapayaWhip;
            PictureBox fond = new PictureBox();
            fond.Size = new Size(20 * (tailleCase + 1) - 1, 20 * (tailleCase + 1) - 1);
            fond.BackColor = Color.Black;
            this.Controls.Add(fond);
            PictureBox[,] tableauImage = new PictureBox[20,20];
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
                    tableauImage[k, i].Top = k*(tailleCase+1);
                    tableauImage[k, i].Left = i*(tailleCase+1);
                    tableauImage[k, i].Show();

                }
            }

            fond.SendToBack();
            this.ClientSize = new Size(20 * (tailleCase + 1)-1, 20 * (tailleCase + 1)-1+40);

            /*foreach(DataGridCell in )
                DataGridCell.X,Cell,Y
            tableauImage[15, 12].BackColor = Color.Black;*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
