using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public class Algorithm
    {

        // Vertical from Bottom to Top
        public static bool Vertical_Bottom_Top(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            Console.WriteLine("\n\n--------------------------------------------------");
            Console.WriteLine("----- Vertical from Bottom to Top -----");

            /*  
             *  Vertical from Bottom to Top
             *  --------------------------------------
             * 
             *  1.  -bottom slot -  
             *  
             *      Firstly, the following code is looking for the bottom slot,
             *      starting from the slot where the token has been placed,
             *      and going down verticaly following the corresponding vertical line.
             *      
             *      
             *  2.  - find 4 in a row -
             *  
             *      Secondly, the code is looking for '4 in a row' slots with same color (blue or red, not the default),
             *      starting from the bottom slot and going up vertically.
             * 
             * **/



            // slot where the token has been placed,
            string slotTaken = string.Format("{0},{1}", slotColumn, slotRow);

            // loop to find the bottom slot
            string bottomSlot = null;

            for (int i = 0; i < form1.gridRows; i++)
            {
                // going down vertically
                slotRow--;

                // temp slot
                string bottomSlotTemp = string.Format("{0},{1}", slotColumn, slotRow);
                Control slot = form1.grid.Controls[bottomSlotTemp];

                // if temp slot doesn't exist, it means we check out of the grid so exit loop
                if (slot == null)
                    break;

                // if temp slot exists, then set it as our bottom slot
                bottomSlot = bottomSlotTemp;
            }

            // if null,it means the slot taken was already the bottom one
            if (bottomSlot == null)
                bottomSlot = slotTaken;





            // outer loop for the starting slot
            for (int i = 0; i < form1.gridRows; i++)
            {
                // starting slot
                int col = slotColumn;
                int row = GetRowNumber(bottomSlot) + i;

                string startSlot = string.Format("{0},{1}", col, row);
                Console.WriteLine("\nstart slot: " + startSlot);

                if (row >= form1.gridRows - 2)
                {
                    Console.WriteLine("*** outer break (less than 4 remaining)\n");
                    break;
                }



                // inner loop checks for same color in the '4 in a row' slots
                int sameColorCounter = 0;
                Control slot = null;
                for (int j = 1; j <= 4; j++)
                {
                    // the slot to check
                    string slotNameToCheck = string.Format("{0},{1}", col, row);
                    slot = form1.grid.Controls[slotNameToCheck];
                    Console.WriteLine("*** check slot: " + slotNameToCheck);

                    // if slot doesn't exist or color not the same, exit loop
                    if (slot == null || slot.BackColor != slotColor)
                    {
                        Console.WriteLine("*** inner break (color not " + slotColor + ")");
                        break;
                    }

                    // when color is same...
                    if (slot.BackColor == slotColor)
                    {
                        sameColorCounter++;
                        Console.WriteLine("*** same color slots: " + sameColorCounter);

                        //...if counts 4 in a row, that's it we have a winner !!!
                        if (sameColorCounter == 4)
                            return true;
                    }

                    // next slot in the '4 in a row' slots
                    row++;
                }


                // if the color is the default no need for further checks,it means there no more tokens on the top
                if (slot.BackColor == form1.slotColor)
                {
                    Console.WriteLine("*** outer break (no more tokens to check)");
                    break;
                }
            }



            return false;
        }





        // Horizontal from Left to Right
        public static bool Horizontal_Left_Right(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            Console.WriteLine("\n\n--------------------------------------------------");
            Console.WriteLine("----- Horizontal from Left to Right -----");

            /*  
             *  Horizontal from Left to Right
             *  --------------------------------------
             * 
             *  1.  -very left slot -  
             *  
             *      Firstly, the following code is looking for the very left slot,
             *      starting from the slot where the token has been placed,
             *      and going left horizontically following the corresponding horizontal line.
             *      
             *      
             *  2.  - find 4 in a row -
             *  
             *      Secondly, the code is looking for '4 in a row' slots with same color (blue or red, not the default),
             *      starting from the very left slot and going right horizontically.
             * 
             * **/



            // slot where the token has been placed,
            string slotTaken = string.Format("{0},{1}", slotColumn, slotRow);

            // loop to find the very left slot
            string leftSlot = null;

            for (int i = 0; i < form1.gridCols; i++)
            {
                // going left horizontically
                slotColumn--;

                // temp slot
                string bottomSlotTemp = string.Format("{0},{1}", slotColumn, slotRow);
                Control slot = form1.grid.Controls[bottomSlotTemp];

                // if temp slot doesn't exist, it means we check out of the grid so exit loop
                if (slot == null)
                    break;

                // if temp slot exists, then set it as our left slot
                leftSlot = bottomSlotTemp;
            }

            // if null,it means the slot taken was already the left one
            if (leftSlot == null)
                leftSlot = slotTaken;

            Console.WriteLine("\nleft slot: " + leftSlot);





            // outer loop for the starting slot
            for (int i = 0; i < form1.gridRows; i++)
            {
                // starting slot
                int col = GetColumnNumber(leftSlot) + i;
                int row = slotRow;

                string startSlot = string.Format("{0},{1}", col, row);
                Console.WriteLine("\nstart slot: " + startSlot);

                if (col >= form1.gridCols - 2)
                {
                    Console.WriteLine("*** outer break (less than 4 remaining)\n");
                    break;
                }



                // inner loop checks for same color in the '4 in a row' slots
                int sameColorCounter = 0;
                for (int j = 1; j <= 4; j++)
                {
                    // the slot to check
                    string slotNameToCheck = string.Format("{0},{1}", col, row);
                    Control slot = form1.grid.Controls[slotNameToCheck];
                    Console.WriteLine("*** check slot: " + slotNameToCheck);

                    // if slot doesn't exist or color not the same, exit loop
                    if (slot == null || slot.BackColor != slotColor)
                    {
                        Console.WriteLine("*** inner break (color not " + slotColor + ")");
                        break;
                    }

                    // when color is same...
                    if (slot.BackColor == slotColor)
                    {
                        sameColorCounter++;
                        Console.WriteLine("*** same color slots: " + sameColorCounter);

                        //...if counts 4 in a row, that's it we have a winner !!!
                        if (sameColorCounter == 4)
                            return true;
                    }

                    // next slot in the '4 in a row' slots
                    col++;
                }
            }



            return false;
        }





        // Diagonal from Bottom-Left to Top-Right
        public static bool Diagonal_BottomLeft_TopRight(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            Console.WriteLine("\n\n--------------------------------------------------");
            Console.WriteLine("----- Diagonal from Bottom-Left to Top-Right -----");

            /*  
             *  Diagonal from Bottom-Left to Top-Right
             *  --------------------------------------
             * 
             *  1.  - very bottom left slot -  
             *  
             *      Firstly, the following code is looking for the very bottom left slot,
             *      starting from the slot where the token has been placed,
             *      and going down diagonally following the corresponding diagonal line.
             *      
             *      
             *  2.  - find 4 in a row -
             *  
             *      Secondly, the code is looking for '4 in a row' slots with same color (blue or red, not the default),
             *      starting from the very bottom left slot and going up right diagonally.
             * 
             * **/



            // slot where the token has been placed,
            string slotTaken = string.Format("{0},{1}", slotColumn, slotRow);

            // loop to find the very bottom left slot
            string bottomLeftSlot = null;

            for (int i = 0; i < form1.gridCols; i++)
            {
                // going down diagonally
                slotColumn--;
                slotRow--;

                // temp slot
                string bottomLeftSlotTemp = string.Format("{0},{1}", slotColumn, slotRow);
                Control slot = form1.grid.Controls[bottomLeftSlotTemp];

                // if temp slot doesn't exist, it means we check out of the grid so exit loop
                if (slot == null)
                    break;

                // if temp slot exists, then set it as our bottom left slot
                bottomLeftSlot = bottomLeftSlotTemp;
            }

            // if null,it means the slot taken was already the very bottom left
            if (bottomLeftSlot == null)
                bottomLeftSlot = slotTaken;





            // outer loop for the starting slot
            for (int i = 0; i < form1.gridCols; i++)
            {
                // starting slot
                int col = GetColumnNumber(bottomLeftSlot) + i;
                int row = GetRowNumber(bottomLeftSlot) + i;

                string startSlot = string.Format("{0},{1}", col, row);
                Console.WriteLine("\nstart slot: " + startSlot);

                if (col >= form1.gridCols - 2)
                {
                    Console.WriteLine("*** outer break (less than 4 remaining)\n");
                    break;
                }



                // inner loop checks for same color in the '4 in a row' slots
                int sameColorCounter = 0;
                for (int j = 1; j <= 4; j++)
                {
                    // the slot to check
                    string slotNameToCheck = string.Format("{0},{1}", col, row);
                    Control slot = form1.grid.Controls[slotNameToCheck];
                    Console.WriteLine("*** check slot: " + slotNameToCheck);

                    // if slot doesn't exist or color not the same, exit loop
                    if (slot == null || slot.BackColor != slotColor)
                    {
                        Console.WriteLine("*** inner break (color not " + slotColor + ")");
                        break;
                    }

                    // when color is same...
                    if (slot.BackColor == slotColor)
                    {
                        sameColorCounter++;
                        Console.WriteLine("*** same color slots: " + sameColorCounter);

                        //...if counts 4 in a row, that's it we have a winner !!!
                        if (sameColorCounter == 4)
                            return true;
                    }

                    // next slot in the '4 in a row' slots
                    col++;
                    row++;
                }
            }



            return false;
        }





        // Diagonal from Top-Left to Bottom-Right
        public static bool Diagonal_TopLeft_BottomRight(Form1 form1, int slotColumn, int slotRow, Color slotColor)
        {
            Console.WriteLine("\n\n--------------------------------------------------");
            Console.WriteLine("----- Diagonal from Top-Left to Bottom-Right -----");

            /*  
             *  Diagonal from Top-Left to Bottom-Right
             *  --------------------------------------
             * 
             *  1.  - top left slot -  
             *  
             *      Firstly, the following code is looking for the top left slot,
             *      starting from the slot where the token has been placed,
             *      and going up diagonally following the corresponding diagonal line.
             *      
             *      
             *  2.  - find 4 in a row -
             *  
             *      Secondly, the code is looking for '4 in a row' slots with same color (blue or red, not the default),
             *      starting from the top left slot and going down right diagonally.
             * 
             * **/



            // slot where the token has been placed,
            string slotTaken = string.Format("{0},{1}", slotColumn, slotRow);

            // loop to find the top left slot
            string topLeftSlot = null;

            for (int i = 0; i < form1.gridCols; i++)
            {
                // going up diagonally (towards left top slot)
                slotColumn--;
                slotRow++;

                // temp slot
                string topLeftSlotTemp = string.Format("{0},{1}", slotColumn, slotRow);
                Control slot = form1.grid.Controls[topLeftSlotTemp];

                // if temp slot doesn't exist, it means we check out of the grid so exit loop
                if (slot == null)
                    break;

                // if temp slot exists, then set it as our top left slot
                topLeftSlot = topLeftSlotTemp;
            }

            // if null,it means the slot taken was already the top left
            if (topLeftSlot == null)
                topLeftSlot = slotTaken;

          



            // outer loop for the starting slot
            for (int i = 0; i < form1.gridCols; i++)
            {
                // starting slot
                int col = GetColumnNumber(topLeftSlot) + i;
                int row = GetRowNumber(topLeftSlot) - i;

                string startSlot = string.Format("{0},{1}", col, row);
                Console.WriteLine("\nstart slot: " + startSlot);

                if ( (col >= form1.gridCols - 2) || (row<4) )
                {
                    Console.WriteLine("*** outer break (less than 4 remaining)\n");
                    break;
                }



                // inner loop checks for same color in the '4 in a row' slots
                int sameColorCounter = 0;
                for (int j = 1; j <= 4; j++)
                {
                    // the slot to check
                    string slotNameToCheck = string.Format("{0},{1}", col, row);
                    Control slot = form1.grid.Controls[slotNameToCheck];
                    Console.WriteLine("*** check slot: " + slotNameToCheck);

                    // if slot doesn't exist or color not the same, exit loop
                    if (slot == null || slot.BackColor != slotColor)
                    {
                        Console.WriteLine("*** inner break (color not " + slotColor + ")");
                        break;
                    }

                    // when color is same...
                    if (slot.BackColor == slotColor)
                    {
                        sameColorCounter++;
                        Console.WriteLine("*** same color slots: " + sameColorCounter);

                        //...if counts 4 in a row, that's it we have a winner !!!
                        if (sameColorCounter == 4)
                            return true;
                    }

                    // next slot in the '4 in a row' slots
                    col++;
                    row--;
                }
            }



            return false;
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

    }
}
