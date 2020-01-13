using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ConnectFour
{
    public class Grid
    {

        public static Panel GetGrid(Form1 form1, int gridCols, int gridRows, int gridX, int gridY, Color gridColor, Color slotColor, bool showColRowOnSlot)
        {
            Panel grid = new Panel
            {
                Location    = new Point(gridX, gridY), // the location for the grid
                BackColor   = gridColor // the background color for grid
            };

            int gridPadding         = 10; // a padding to the grid
            int slotWidth           = 55; // the width for the slot
            int slotHeight          = 55; // the height for the slot
            int slotDistanceScale   = 20; // a scale for the distance between the slots
           


            // CREATE THE SLOTS AND ADD THEM TO GRID

            int currentGridWidth    = 0; // the width of the grid
            int currentGridHeight   = 0; // the height o fthe gird
            int currentSlotY        = gridPadding; // the location Y for slot

            for (int row = gridRows; row > 0; row--)
            {
                int currentSlotX = gridPadding; // the location Y for slot

                for (int col = 1; col <= gridCols; col++)
                {
                    //create slot
                    CircularButton slot = new CircularButton
                    {
                        Size        = new Size(slotWidth, slotHeight),
                        Location    = new Point(currentSlotX, currentSlotY),
                        Name        = string.Format("{0},{1}", col, row),
                        BackColor   = slotColor,
                        FlatStyle   = FlatStyle.Flat
                    };
                    slot.FlatAppearance.BorderSize = 0;
                    if (showColRowOnSlot)
                        slot.Text = string.Format("{0},{1}", col, row);

                    //add slot to grid
                    grid.Controls.Add(slot);

                    //update next slot location X
                    currentSlotX += slotWidth + slotDistanceScale;

                    //update grid width
                    currentGridWidth = currentSlotX;
                }

                //update next slot location Y
                currentSlotY += slotHeight + slotDistanceScale;

                //update grid height
                currentGridHeight = currentSlotY;
            }



            // set the final size for grid
            int finalGridWidth = currentGridWidth - slotDistanceScale + gridPadding;
            int finalGridHeight = currentGridHeight - slotDistanceScale + gridPadding;
            grid.Size = new Size(finalGridWidth, finalGridHeight);



            // return the grid
            return grid;
        }


    }
}
