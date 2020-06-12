using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Vujo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int player = 2;
        public int turns = 0;
        public int draws = 0;
        public int xwins = 0;
        public int owins = 0;
        public int games = 2;
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.ForeColor = Color.Black;
                    button.Text = "X";
                    turns++;
                    player++;
                    if (turns >= 5)
                    {
                        if (Winner() == true)
                        {
                            xwins++;
                            // button.ForeColor = Color.Red;
                            Twinkle_Winner();
                            MessageBox.Show("X wins!", "Winner!");
                            NewGame();
                        }
                    }
                }
                else
                {
                    button.ForeColor = Color.Red;

                    button.Text = "O";
                    turns++;
                    player++;
                    if (turns >= 5)
                    {
                        if (Winner() == true)
                        {
                            owins++;
                            //button.ForeColor = Color.Red;
                            Twinkle_Winner();
                            MessageBox.Show("O wins!", "Winner!");
                            NewGame();
                        }
                    }
                }
            }
            if (CheckDraws() == true)
            {
                MessageBox.Show("Tie Game!", "Draw");
                draws++;
                NewGame();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("X wins: " + xwins + "\nO wins: " + owins + "\nDraws: " + draws, "Results");
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draws = 0;
            xwins = 0;
            owins = 0;
            NewGame();
        }
        void NewGame()
        {
            A11.BackColor= A12.BackColor = A13.BackColor = A21.BackColor = A22.BackColor = A23.BackColor = A31.BackColor = A32.BackColor = A33.BackColor = Color.Gainsboro;
            A11.Text = A12.Text = A13.Text = A21.Text = A22.Text = A23.Text = A31.Text = A32.Text = A33.Text = "";
            turns = 0;
            games++;
            if (games % 2 == 0)
            {
                player = 2;
            }
            else
            {
                player = 3;
            }

        }
        bool CheckDraws()
        {
            if ((turns == 9) && (Winner() == false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool Winner()
        {
            // horizontalna provjeravanja
            if ((A11.Text == A12.Text) && (A12.Text == A13.Text) && (A11.Text != ""))
            {
                return true;
            }
            else if ((A21.Text == A22.Text) && (A21.Text == A23.Text) && (A21.Text != ""))
            {
                return true;
            }
            else if ((A31.Text == A32.Text) && (A31.Text == A33.Text) && (A31.Text != ""))
            {
                return true;
            }
            //vertikalna provjeravanja
            else if ((A11.Text == A21.Text) && (A11.Text == A31.Text) && (A11.Text != ""))
            {
                return true;
            }
            else if ((A12.Text == A22.Text) && (A12.Text == A32.Text) && (A12.Text != ""))
            {
                return true;
            }
            else if ((A13.Text == A23.Text) && (A13.Text == A33.Text) && (A13.Text != ""))
            {
                return true;
            }
            // dijagonalna provjeravanja
            else if ((A11.Text == A22.Text) && (A11.Text == A33.Text) && (A11.Text != ""))
            {
                return true;
            }
            else if ((A13.Text == A22.Text) && (A13.Text == A31.Text) && (A13.Text != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        void Twinkle_Winner()
        {
            // horizontalna provjeravanja
            if ((A11.Text == A12.Text) && (A12.Text == A13.Text) && (A11.Text != ""))
            {
                A11.BackColor = Color.Yellow;
                A12.BackColor = Color.Yellow;
                A13.BackColor = Color.Yellow;
            }
            else if ((A21.Text == A22.Text) && (A21.Text == A23.Text) && (A21.Text != ""))
            {
                A21.BackColor = Color.Yellow;
                A22.BackColor = Color.Yellow;
                A23.BackColor = Color.Yellow;
            }
            else if ((A31.Text == A32.Text) && (A31.Text == A33.Text) && (A31.Text != ""))
            {
                A31.BackColor = Color.Yellow;
                A32.BackColor = Color.Yellow;
                A33.BackColor = Color.Yellow;
            }
            //vertikalna provjeravanja
            else if ((A11.Text == A21.Text) && (A11.Text == A31.Text) && (A11.Text != ""))
            {
                A11.BackColor = Color.Yellow;
                A21.BackColor = Color.Yellow;
                A31.BackColor = Color.Yellow;
            }
            else if ((A12.Text == A22.Text) && (A12.Text == A32.Text) && (A12.Text != ""))
            {
                A12.BackColor = Color.Yellow;
                A22.BackColor = Color.Yellow;
                A32.BackColor = Color.Yellow;
            }
            else if ((A13.Text == A23.Text) && (A13.Text == A33.Text) && (A13.Text != ""))
            {
                A13.BackColor = Color.Yellow;
                A23.BackColor = Color.Yellow;
                A33.BackColor = Color.Yellow;
            }
            // dijagonalna provjeravanja
            else if ((A11.Text == A22.Text) && (A11.Text == A33.Text) && (A11.Text != ""))
            {
                A11.BackColor = Color.Yellow;
                A22.BackColor = Color.Yellow;
                A33.BackColor = Color.Yellow;
            }
            else if ((A13.Text == A22.Text) && (A13.Text == A31.Text) && (A13.Text != ""))
            {
                A13.BackColor = Color.Yellow;
                A22.BackColor = Color.Yellow;
                A31.BackColor = Color.Yellow;
            }
        }
    }
}
