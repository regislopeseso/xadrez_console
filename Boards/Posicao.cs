
namespace Boards
{
    public class Position
    {
        public int lines { get; set; }
        public int columns { get; set; }

        public Position(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;   
        }

        public override string ToString()
        {
            return $"Position (line;column) = ({this.lines};{this.columns})";
        }

    }
}
 