using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public class Logic
    {

        public static void RUN(Form1 form1, object slotSender)
        {
            bool IsGameOver = false; //indicates whether game is done



            // PLACE THE TOKEN IN THE SLOT AND GET ITS SLOT BACK
            CircularButton slot = PlaceTokenAndGetSlot(form1, slotSender);



            // CHECK FOR WINNER
            if (slot == null)
            { 
                Console.WriteLine("COLUMN IS FULL"); 
            }
            else 
            {
                if (IsWinner(form1, slot))
                {
                    if (form1.currentPlayer == Form1.CurrentPlayer.P1)
                    {
                        Console.WriteLine("P1 WON");

                        // +1 win to P1
                        int currentWins = Convert.ToInt32(form1.labelWinsP1.Text);
                        form1.labelWinsP1.Text = (currentWins + 1).ToString();

                        form1.labelPlayerTurn.Text = form1.nameP1 + " WON THE GAME !!!";
                    }
                    else
                    {
                        Console.WriteLine("P2 one win");

                        // +1 win to P2
                        int currentWins = Convert.ToInt32(form1.labelWinsP2.Text);
                        form1.labelWinsP2.Text = (currentWins + 1).ToString();

                        form1.labelPlayerTurn.Text = form1.nameP2 + " WON THE GAME !!!";
                    }


                    // game stops
                    FreezeGrid(form1);
                    IsGameOver = true;
                }
                else
                {
                    Console.WriteLine("NO WINNER FOUND");
                }     
            }



            // UPDATES CURRENT PLAYER OTHERWISE GAME IS OVER
            if (!IsGameOver && !IsGridFilled(form1) && slot!=null)
            {
                if (form1.currentPlayer == Form1.CurrentPlayer.P1)
                {
                    form1.currentPlayer = Form1.CurrentPlayer.P2; 
                    form1.labelPlayerTurn.Text = form1.nameP2 + " is playing. . .";
                }
                else
                {
                    form1.currentPlayer = Form1.CurrentPlayer.P1;
                    form1.labelPlayerTurn.Text = form1.nameP1 + " is playing. . .";
                }
            }
            else if (IsGridFilled(form1))
            {
                Console.WriteLine("ALL SLOTS FULL");

                form1.labelPlayerTurn.Text = "DRAW  -  GAME IS OVER !!!";
                FreezeGrid(form1);
            }

        }







        // PLACE TOKEN IN THE SLOT

        private static CircularButton PlaceTokenAndGetSlot(Form1 form1, object slotSender)
        {
            // the slot was clicked
            CircularButton slotClicked = slotSender as CircularButton;


            // the column number that slot was clicked
            int colClicked = GetColumnNumber(slotClicked.Name);


            // get all slots in ascending order (*from bottom to top)
            List<CircularButton> slotsFromClickedColumn = GetAllSlots(form1, colClicked);
            List<CircularButton> sortedSlots = OrderBySlotsAsc(slotsFromClickedColumn);


            // this loop will start searching from bottom to top
            for (int i = 0; i < sortedSlots.Count; i++)
            {
                CircularButton slot = sortedSlots[i];

                // when the color is stil as its initial color, it means a token can be placed
                if (slot.BackColor == form1.slotColor)
                {
                    //make it blue if player 1
                    if (form1.currentPlayer == Form1.CurrentPlayer.P1)
                    {
                        slot.BackColor = Color.Blue; // the color for player 1

                        //form1.currentPlayer = Form1.CurrentPlayer.P2; // player's 2 turn
                        //form1.labelPlayerTurn.Text = form1.nameP2 + " is playing. . .";
                    }
                    // make it red if player 2
                    else
                    {
                        slot.BackColor = Color.Red; // the color for player 2

                        //form1.currentPlayer = Form1.CurrentPlayer.P1; // player's 1 turn
                        //form1.labelPlayerTurn.Text = form1.nameP1 + " is playing. . .";
                    }

                    // return the slot
                    return slot;
                }


                //if not match, go to next slot in second row....
            }


            // if nothin, column means is full - return null
            return null;
        }

        private static List<CircularButton> OrderBySlotsAsc(List<CircularButton> list)
        {
            return (from slot in list
                    orderby GetRowNumber(slot.Name)
                    select slot).ToList();
        }

        private static List<CircularButton> GetAllSlots(Form1 form1, int colClicked)
        {
            List<CircularButton> list = new List<CircularButton>();

            foreach (CircularButton slot in form1.grid.Controls.OfType<CircularButton>())
            {
                int col = GetColumnNumber(slot.Name);

                if (col == colClicked)
                {
                    list.Add(slot);
                }
            }

            return list;
        }

        private static int GetColumnNumber(string slotName)
        {
            // *** slot's name was set to string format as: "col,row" 

            int indexOfComma = slotName.IndexOf(",");

            string column = slotName.Substring(0, indexOfComma);

            return Convert.ToInt32(column);
        }

        private static int GetRowNumber(string slotName)
        {
            // *** slot's name was set to string format as: "col,row" 

            int indexOfComma = slotName.IndexOf(",");

            string row = slotName.Substring(indexOfComma + 1);

            return Convert.ToInt32(row);
        }







        // CHECK FOR WINNER

        private static bool IsWinner(Form1 form1, CircularButton slot)
        {
            int slotColumn = GetColumnNumber(slot.Name); // column where last token has been placed
            int slotRow = GetRowNumber(slot.Name); // row where last token has been placed
            Color slotColor = slot.BackColor; // slot's color where last token has been placed



            // check vertically, horizontically and diagonally for winner
            if (Algorithm.Vertical_Bottom_Top(form1, slotColumn, slotRow, slotColor))
                return true;

            if (Algorithm.Horizontal_Left_Right(form1, slotColumn, slotRow, slotColor))
                return true;

            if (Algorithm.Diagonal_BottomLeft_TopRight(form1, slotColumn, slotRow, slotColor))
                return true;

            if (Algorithm.Diagonal_TopLeft_BottomRight(form1, slotColumn, slotRow, slotColor))
                return true;



            // no winner
            return false;
        }


        // slot + next 3 horizontal right => slot's color same       
        private static bool HorizontalRight(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (horizontically right), if they have the same color
            for (int i = 1; i <=4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to next column on the right
                slotColumn++; 
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("HorizontalRight");
            return true;
        }

        // slot + next 3 horizontal left => slot's color same
        private static bool HorizontalLeft(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (horizontically left), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to next column on the left
                slotColumn--; 
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("HorizontalLeft");
            return true;
        }


        // slot + next 3 vertical top => slot's color same
        private static bool VerticalTop(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (vertically top), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to next row on top
                slotRow++; 
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("VerticalTop");
            return true;
        }

        // slot + next 3 vertical bottom => slot's color same
        private static bool VeeticalBottom(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (vertically bottom), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to next row on bottom
                slotRow--;
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("VeeticalBottom");
            return true;
        }


        // slot + next 3 diagonal right bottom => slot's color same
        private static bool DiagonalRightBottom(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (diagonally right bottom), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to  next column on the right - next row on the bottom
                slotColumn++;
                slotRow--;
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("DiagonalRightBottom");
            return true;
        }

        // slot + next 3 diagonal left bottom => slot's color same
        private static bool DiagonalLeftBottom(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (diagonally left bottom), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to  next column on the left - next row on the bottom
                slotColumn--;
                slotRow--;
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("DiagonalLeftBottom");
            return true;
        }

        // slot + next 3 diagonal right top => slot's color same
        private static bool DiagonalRightTop(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (diagonally right top), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to  next column on the right - next row on the top
                slotColumn++;
                slotRow++;
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("DiagonalRightTop");
            return true;
        }

        // slot + next 3 diagonal left top => slot's color same
        private static bool DiagonalLeftTop(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            // checks the 4 slots 'in a row' (diagonally left top), if they have the same color
            for (int i = 1; i <= 4; i++)
            {
                string slotNameToCheck = string.Format("{0},{1}", slotColumn, slotRow);

                // find the corresponding slot on grid
                Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                // if not exist or not the same color, automatically means there is no winner
                if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    return false;

                // goes to  next column on the left - next row on the top
                slotColumn--;
                slotRow++;
            }

            // the 4 slots had the same colors - we have a winner
            Console.WriteLine("DiagonalLeftTop");
            return true;
        }







        // all slots are filled
        private static bool IsGridFilled(Form1 form1)
        {
            foreach (CircularButton slot in form1.grid.Controls.OfType<CircularButton>())
            {
                if (slot.BackColor == form1.slotColor)
                    return false;
            }

            return true;
        }

        // stop the game when is a winner
        private static void FreezeGrid(Form1 form1)
        {
            foreach (CircularButton slot in form1.grid.Controls.OfType<CircularButton>())
                slot.Enabled = false;
        }






        private static bool Diagonal_BottomLeft_TopRight(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {

            int x = (form1.gridCols >= form1.gridRows) ? form1.gridCols : form1.gridRows;

            string bottomLeftSlot = string.Format("{0},{1}", slotColumn, slotRow);

            for (int i = 0; i < x; i++)
            {
                slotColumn--;
                slotRow--;

                string temp = string.Format("{0},{1}", slotColumn, slotRow);

                Control control = form1.grid.Controls[temp];

                if (control == null)
                    break;

                bottomLeftSlot = temp;
            }

           // Console.WriteLine("..SLOT: "+slotToStart );




            int countSameColors = 0;

            int col = GetColumnNumber(bottomLeftSlot);
            int row = GetRowNumber(bottomLeftSlot);
            for (int i = 1; col <= x+1; i++)
            {
                // checks the 4 slots 'in a row' (diagonally left top), if they have the same color
                for (int j = 1; j <= 4; j++)
                {
                    string slotNameToCheck = string.Format("{0},{1}", col, row);
                    Console.WriteLine(slotNameToCheck);

                    // find the corresponding slot on grid
                    Control slotToCheck = form1.grid.Controls[slotNameToCheck];

                    // if not exist or not the same color, automatically means there is no winner
                    if (slotToCheck == null || slotToCheck.BackColor != slotColor)
                    {
                        Console.WriteLine("break");
                        break;
                    }
                        

                    // goes to  next column on the left - next row on the top
                    col++;
                    row++;

                    //the 4 slots had the same colors - we have a winner
                    countSameColors++;
                    Console.WriteLine("colors: " +countSameColors);
                    if (countSameColors == 4)
                        return true;
                }


                //next banch of slots
                col = GetColumnNumber(bottomLeftSlot) + i;
                row = GetRowNumber(bottomLeftSlot) + i;
                countSameColors = 0;
            }


            return false ;

        }





       




    }
}
