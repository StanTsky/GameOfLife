using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        const int MAX_GENERATIONS = 100;
        const int MARK = 0;     // The game will either be in a marking state or an updating state
        const int UPDATE = 1;   // These constants define those two states
        //bool createUserPattern = false;
        /*  Which state the game is currently in. This variable is used by the timer to decide
            whether call the current generation’s Mark() or Update() functions. */
        int state = MARK;
        //  A list of the generations the board has gone through. Allocate this using the new operator.
        List<Generation> generations = new List<Generation>();

        Generation gn = new Generation();
        int startX = Generation.BOARD_WIDTH / 2;
        int startY = Generation.BOARD_HEIGHT / 2;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Width = Generation.CELL_SIZE * Generation.BOARD_WIDTH + 10;
            pictureBox1.Height = Generation.CELL_SIZE * Generation.BOARD_HEIGHT + 10;

            // call a function to set up one of your test cases

            //gn.AddOrganism(0, 1);
            //gn.AddOrganism(1, 1);
            //gn.AddOrganism(2, 1);

            //gn.AddOrganism(2, 1);
            //gn.AddOrganism(3, 1);
            //gn.AddOrganism(1, 2);
            //gn.AddOrganism(2, 2);
            //gn.AddOrganism(2, 3);
            //generations.Add(gn); // put new generation in the list of generations
            //pictureBox1.Invalidate();
            ShowCounts();
        }
        bool GameOver()
        {  /*   Return true if the current generation is extinct (remember the Generation has an Extinct function).
                Return true if the max number of turns has been reached.
                Return true if the current Generation is equal to any of the previous Generations.
                (Remember the Generation class has an Equals() function).
             */
            if (gn.IsExtinct()) return true;

            if (generations.Count == MAX_GENERATIONS) return true;

            //if (generations.Count>2)
            //{
            //    if (gn.Equals(generations[generations.Count - 1]))
            //    {
            //        return true;
            //    }
            //}

            return false;   // If none of the previous cases were hit, return false
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            gn.Draw(e.Graphics, (state == UPDATE));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameOver())
            {
                //MessageBox.Show("Game over!");
                timer1.Enabled = false;
            }
            else
            {
                CheckState();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //generations.Clear();
            //gn = null;
            timer1.Enabled = true;
            //ShowCounts();
            //CheckState();
        }

        private void CheckState()
        {
            if (state == MARK)
            {
                gn.Mark();
                ShowCounts();
                state = UPDATE;
                pictureBox1.Invalidate();
            }
            else
            {
                gn = gn.Update();
                generations.Add(gn); // put new generation in the list of generations
                ShowCounts();
                state = MARK;
                pictureBox1.Invalidate();
                if (gn.IsExtinct()) timer1.Enabled = false;
            }
        }

        private void ShowCounts()
        {
            textCounts.Text = "";
            int bw = Generation.BOARD_WIDTH;
            int bh = Generation.BOARD_HEIGHT;

            for (int i = 0; i < bh; i++)
            {
                for (int j = 0; j < bw; j++)  // Loop over all the rows and columns in the board
                {
                    textCounts.AppendText(gn.CountOrganism(j, i).ToString());
                }
                textCounts.AppendText("\r\n");
            }
            textCounts.AppendText($"Generations: {generations.Count.ToString()}");
        }

        private void rPertominoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();

            startX -= 3;
            startY -= 3;

            gn.AddOrganism(startX + 2, startY+ 1);
            gn.AddOrganism(startX + 3, startY + 1);
            gn.AddOrganism(startX + 1, startY + 2);
            gn.AddOrganism(startX + 2, startY + 2);
            gn.AddOrganism(startX + 2, startY + 3);

            BeginGame();
        }

        private void verticalOscillationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();

            startX -= 2;
            startY -= 1;

            gn.AddOrganism(startX, startY + 1);
            gn.AddOrganism(startX + 1, startY + 1);
            gn.AddOrganism(startX + 2, startY + 1);

            BeginGame();

        }

        private void ResetGame()
        {
            gn = new Generation();
            generations.Clear();
            state = MARK;
            startX = Generation.BOARD_WIDTH / 2;
            startY = Generation.BOARD_HEIGHT / 2;

            //generations = new List<Generation>();
        }

        private void BeginGame()
        {
            generations.Add(gn); // put new generation in the list of generations
            pictureBox1.Invalidate();
            timer1.Enabled = true;
        }

        private void steadyStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
            startX -= 2;
            startY -= 2;

            gn.AddOrganism(startX + 1, startY + 1);
            gn.AddOrganism(startX + 2, startY + 1);
            gn.AddOrganism(startX + 1, startY + 2);
            gn.AddOrganism(startX + 2, startY + 2);

            BeginGame();

        }
    }
}
