using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiktactoeGame
{
    public partial class Form1 : Form
    {
        bool turn = true; //When true=X turn, false=Y turn
        int turn_count = 0;                         
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Bhuwan", "Tik Tac About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false; //it will disable the button after it is used
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            //horizontal check
            if((A1.Text==A2.Text) && (A2.Text==A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;

            else if((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //vertical check
            else if((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;

            else if((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;

            else if((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //DIAGONAL CHECKS

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            if (there_is_a_winner)
            {
                disableButtons();
                String winner = "";
                if (turn)
                {
                    OWinCount.Text = (Int32.Parse(OWinCount.Text) + 1).ToString();
                    winner = "O";
                   
                        
                }
                else
                {
                    XWinCount.Text = (Int32.Parse(XWinCount.Text) + 1).ToString();
                    winner = "X";
                }
                MessageBox.Show(winner + "Wins!", "YaY!");
            }//endif
            else
            {
                DrawCount.Text = (Int32.Parse(DrawCount.Text) + 1).ToString();
                if (turn_count == 9)
                    MessageBox.Show("Draw", "Bummer");

            }
            
        }//end checkForWinner
        private void disableButtons()
        {
           
                foreach (Control c in Controls)  //All the controls in form (button) are got from Controls object
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//endtryblock
                catch { }
            }
           
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            
                foreach (Control c in Controls)  //All the controls in form (button) are got from Controls object
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch { }
            }//endforeach
            }
           
        

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            { 
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void resetCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XWinCount.Text = "0";
            OWinCount.Text = "0";
            DrawCount.Text = "0";
        }
    }
}
