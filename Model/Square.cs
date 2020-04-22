using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Square : IEquatable<Square>
    {
        public Square(int row,int column) {
            Row = row;
            Column = column;
        }

        public readonly int Row;
        public readonly int Column;

        public bool Equals(Square other)
        {
            return Row == other.Row && Column == other.Column;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Square)obj);
        }
        public override int GetHashCode()
        {
            return Row ^ Column;
        }
    }
}
