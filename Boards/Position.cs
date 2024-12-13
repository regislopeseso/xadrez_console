
namespace Boards
{
    public class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int lines, int columns)
        {
            this.line = lines;
            this.column = columns;   
        }

        public override string ToString()
        {
            return $"Position (line;column) = ({this.line};{this.column})";
        }

    }
}
 