using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics.Metrics;

namespace bin
{
    internal class PlayControl
    {
        enum Direction
        {
            FromRightToLeft=0,
            FromLeftToRight=1
        }

        public Boolean[,] matrix = new Boolean[3, 3]
                            {
                                {   true, true, true    },
                                {   true, true, true    },
                                {   true, true, true    }
                            };
        public Message m;
        public PlayControl() //constructor
        {
            m = new Message();
            reset();
        }

        private Boolean IsRowMatching(int rowIndex, Boolean[,] array)
        {
            int counter = 0;
            string r = "";

            for (int column = 0; column <= array.GetUpperBound(1); column++)
            {
                if (array[rowIndex, column] == true)
                {
                    counter++;
                    r += $"{rowIndex} {column}|";
                }
            }
            
            return (counter == (array.GetUpperBound(1) + 1));
        }

        private Boolean IsColumnMatching(int columnIndex, Boolean[,] array)
        {
            int counter = 0;
            string r = "";
            for (int row = 0; row <= array.GetUpperBound(0); row++)
            {
                if (array[row, columnIndex] == true)
                {
                    counter++;
                    r += $"{row} {columnIndex}|";
                }
            }

            return (counter == (array.GetUpperBound(0) + 1));
        }

        private Boolean IsDiagonalMatching(Direction orientation, Boolean[,] array)
        {
            int column = (orientation == Direction.FromLeftToRight) ? 0 : array.GetUpperBound(1); //upper bound for column
            int counter = column;
            bool increment = (column == 0);
            if (!increment) { counter ++;  } //

            string r = "";
            for (int row = 0; row <= array.GetUpperBound(0); row++)
            {
                if (array[row, column] == true)
                {
                    if (increment) { column++;  counter++; }
                    else { column--;  counter--; } //move previous position however we do not know if it is going to be true, next iteration
                    r += $"{row} {column}|";
                }
            }

            bool retval = false;

            if (orientation == Direction.FromLeftToRight && counter == (array.GetUpperBound(1) + 1)) { retval = true;  }
            else if (orientation == Direction.FromRightToLeft && counter == 0) { retval = true;  }

            return retval;
        }
        
        public void reset()
        {
            matrix[0, 0] = false;
            matrix[0, 1] = false;
            matrix[0, 2] = false;

            matrix[1, 0] = false;
            matrix[1, 1] = false;
            matrix[1, 2] = false;

            matrix[2, 0] = false;
            matrix[2, 1] = false;
            matrix[2, 2] = false;
        }

        public bool Play(int rowIndex, int colIndex, Boolean value)
        {
            bool retval;

            matrix[rowIndex, colIndex] = value;

            if ((retval = IsRowMatching(0, matrix))) { reset(); MessageBox.Show(m.RowCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information ); }
            else if ((retval = IsRowMatching(1, matrix))) { reset(); MessageBox.Show(m.RowCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
            else if ((retval = IsRowMatching(2, matrix))) { reset(); MessageBox.Show(m.RowCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }

            else if ((retval = IsColumnMatching(0, matrix))) { reset(); MessageBox.Show(m.ColumnCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
            else if ((retval = IsColumnMatching(1, matrix))) { reset(); MessageBox.Show(m.ColumnCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
            else if ((retval = IsColumnMatching(2, matrix))) { reset(); MessageBox.Show(m.ColumnCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }

            else if ((retval = IsDiagonalMatching(Direction.FromLeftToRight, matrix))) { reset(); MessageBox.Show(m.DiagonalCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
            else if ((retval = IsDiagonalMatching(Direction.FromRightToLeft, matrix))) { reset(); MessageBox.Show(m.DiagonalCompletedSuccess, "Information", MessageBoxButton.OK, MessageBoxImage.Information); }

            return retval;
        }
    }
}
