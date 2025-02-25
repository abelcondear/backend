using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin
{
    internal class Message
    {
        public Message()
        {
            RowCompletedSuccess = "One row was completed successfully.";
            ColumnCompletedSuccess = "One column was completed successfully.";
            DiagonalCompletedSuccess = "One diagonal was completed successfully.";
        }

        public string RowCompletedSuccess { get; private set; }
        public string ColumnCompletedSuccess { get; private set; }
        public string DiagonalCompletedSuccess { get; private set; }
    }
}
