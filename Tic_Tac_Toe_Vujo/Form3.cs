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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        public int turns = 0;
        public int draws = 0;
        public int cpuwins = 0;
        public int playerwins = 0;
        public bool onturn = true;
        public int ocount = 0;
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        void NewGame()
        {
            A11.BackColor = A12.BackColor = A13.BackColor = A21.BackColor = A22.BackColor = A23.BackColor = A31.BackColor = A32.BackColor = A33.BackColor = Color.Gainsboro;
            A11.Text = A12.Text = A13.Text = A21.Text = A22.Text = A23.Text = A31.Text = A32.Text = A33.Text = "";
            turns = 0;
            ocount = 0;
            onturn = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (onturn == true)
                {
                    button.ForeColor = Color.Black;
                    button.Text = "X";
                    turns++;
                    onturn = !onturn;
                    if (turns >= 5)
                    {
                        if (Winner() == true)
                        {
                            playerwins++;
                            Twinkle_Winner();
                            MessageBox.Show("Player wins!", "Winner!");
                            
                            NewGame();
                        }
                    }
                }
                else
                {
                    button.ForeColor = Color.Red;
                    button.Text = "O";
                    ocount++;
                    turns++;
                    onturn = !onturn;
                    if (turns >= 5)
                    {
                        if (Winner() == true)
                        {
                            cpuwins++;
                            Twinkle_Winner();
                            MessageBox.Show("Cpu wins!", "Winner!");
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
            if(onturn == false)
            {
                CPU().PerformClick();
            }
        }
       public Button CPU()
        {
            Button butt = null;
                butt = Trywinordeff("O");
                if (butt != null)
                    return butt;
                else
                {
                    butt = Trywinordeff("X");
                    if (butt != null)
                        return butt;
                    else
                        return MoveRandom();
                }
             
        }

        public Button Trywinordeff(string s)
        {

            //HORIZONTALNE
            if ((A11.Text) == (A12.Text) && A11.Text == s && A13.Text == "")
                return A13;
            else if ((A11.Text) == (A13.Text) && A11.Text == s && A12.Text == "")
                return A12;
            else if ((A12.Text) == (A13.Text) && A12.Text == s && A11.Text == "")
                return A11;

            else if ((A21.Text) == (A23.Text) && A21.Text == s && A22.Text == "")
                return A22;
            else if ((A21.Text) == (A22.Text) && A21.Text == s && A23.Text == "")
                return A23;
            else if ((A23.Text) == (A22.Text) && A22.Text == s && A21.Text == "")
                return A21;

            else if ((A31.Text) == (A33.Text) && A31.Text == s && A32.Text == "")
                return A32;
            else if ((A31.Text) == (A32.Text) && A31.Text == s && A33.Text == "")
                return A33;
            else if ((A32.Text) == (A33.Text) && A33.Text == s && A31.Text == "")
                return A31;
            // vertikalne

            else if ((A11.Text) == (A21.Text) && A11.Text == s && A31.Text == "")
                return A31;
            else if ((A11.Text) == (A31.Text) && A11.Text == s && A21.Text == "")
                return A21;
            else if ((A21.Text) == (A31.Text) && A21.Text == s && A11.Text == "")
                return A11;

            else if ((A12.Text) == (A22.Text) && A12.Text == s && A32.Text == "")
                return A32;
            else if ((A12.Text) == (A32.Text) && A32.Text == s && A22.Text == "")
                return A22;
            else if ((A22.Text) == (A32.Text) && A22.Text == s && A12.Text == "")
                return A12;

            else if ((A13.Text) == (A23.Text) && A13.Text == s && A33.Text == "")
                return A33;
            else if ((A13.Text) == (A33.Text) && A13.Text == s && A23.Text == "")
                return A23;
            else if ((A23.Text) == (A33.Text) && A33.Text == s && A13.Text == "")
                return A13;
            //dijagonalne

            else if ((A11.Text) == (A22.Text) && A11.Text == s && A33.Text == "")
                return A33;
            else if ((A11.Text) == (A33.Text) && A11.Text == s && A22.Text == "")
                return A22;
            else if ((A22.Text) == (A33.Text) && A22.Text == s && A11.Text == "")
                return A11;

            else if ((A31.Text) == (A22.Text) && A31.Text == s && A13.Text == "")
                return A13;
            else if ((A22.Text) == (A13.Text) && A22.Text == s && A31.Text == "")
                return A31;
            else if ((A31.Text) == (A13.Text) && A13.Text == s && A22.Text == "")
                return A22;
            else
                return null;
        }

        public Button MoveRandom()
        {
            Button b = null;
            if (radioButton1.Checked == true)
            {
                foreach (Control C in Controls)
                {
                    b = C as Button;
                    if (b != null)
                    {
                        if (b.Text == "")
                            return b;
                    }
                }
                return null;
            }
            else if (radioButton2.Checked == true)
            {
                if (ocount == 0 && A22.Text == "")
                {
                    b = A22;
                    return b;
                }
                else if (ocount == 0 && A22.Text != "" && A13.Text == "")
                {
                    b = A13;
                    return b;
                }
                else if(ocount ==1 && A22.Text == "X" && A31.Text=="X")
                {
                    b = A11;
                    return b;
                }
                else if(ocount==1 && A13.Text=="X" && A31.Text=="X")
                {
                    b = A12;
                    return b;
                }
                else if(ocount==1 && A21.Text=="X" && A12.Text=="X")
                {
                    b = A11;
                    return b;
                }
                else
                {
                    b = Trywinordeff("O");
                    if (b != null)
                        return b;
                    else
                    {
                        b = Trywinordeff("X");
                        if (b != null)
                            return b;
                        else
                        {
                            
                            return MoveSmart();
                        }
                    }
                }

            }
            else
                return null;
        }
        public Button MoveSmart()
        {
            Button b = null;
            
                    foreach (Control C in Controls)
                    {
                        b = C as Button;
                        if (b != null)
                        {
                            if (b.Text == "")
                                return b;
                        }
                    }
                    return null;
            
        }
        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Player wins: " + playerwins +"\nCPU wins: " + cpuwins +"\nDraws: " + draws, "Results");
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playerwins = 0;
            cpuwins = 0;
            draws = 0;
            NewGame();
        }

        private void radiobutton_Checked(object sender, EventArgs e)
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
