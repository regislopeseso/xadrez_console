using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boards;

namespace Chess
{
    class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position ConvertPosition()
        {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString()
        {
            return $"{this.column}{this.line}";
        }




    }
}
