using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public partial class Form1 : Form
    {
        // our grid
        public Panel grid;
        public int gridCols;
        public int gridRows;
        public Color gridColor;
        public Color slotColor;



        // current player's trun
        public enum CurrentPlayer
        {
            P1, // the blue player
            P2  // the red player
        }

        public CurrentPlayer currentPlayer = CurrentPlayer.P1;



        // player names
        public string nameP1 = "Player 1";
        public string nameP2 = "Player 2";





        // ON LOAD
        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.GhostWhite; //form's back color
            AutoScroll = true; //scrolling
            WindowState = FormWindowState.Maximized; //maximize window


            //initialize grid arguments
            grid = new Panel();
            gridCols = 7;
            gridRows = 6;
            gridColor = Color.ForestGreen;
            slotColor = this.BackColor;


            labelPlayerTurn.Visible = false;
        }





        // START GAME
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // set the grid on the window

            Controls.Remove(grid); // remove the existing one **if exists

            int gridX = 15; // location X of the grid
            int gridY = labelPlayerTurn.Location.Y + labelPlayerTurn.Height + 15; // location Y of the grid

            grid = Grid.GetGrid(this, gridCols, gridRows, gridX, gridY, gridColor, slotColor, false); // get the grid

            Controls.Add(grid); // add it to window

            foreach (CircularButton slot in grid.Controls.OfType<CircularButton>())
            {
                slot.Click += Slot_Click; // add a click event
            }



            // set players

            if (!string.IsNullOrWhiteSpace(textBoxP1.Text))
                nameP1 = textBoxP1.Text;

            if (!string.IsNullOrWhiteSpace(textBoxP2.Text))
                nameP2 = textBoxP2.Text;

            labelPlayerTurn.Visible = true;

            labelPlayerTurn.Text = nameP1 + " is playing. . .";

            currentPlayer = CurrentPlayer.P1;
        }



        // slot click
        private void Slot_Click(object sender, EventArgs e)
        {
            // executes the logic every time a token is placed
            Logic.RUN(this, sender);
        }





        // EXIT GAME
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       



    }
}
