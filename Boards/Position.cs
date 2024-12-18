﻿
namespace Boards
{
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column;   
        }

        public void DefineValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"Position (line;column) = ({this.Line};{this.Column})";
        }
    }
}
 