using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using Placment = IEnumerable<Square>;
   public class Grid
    {
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            squares = new Square[Rows,Columns];
            for(int r = 0; r< Rows; ++r)
            {
                for (int c=0; c<Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }
     public IEnumerable<Placment> GetAvailablePlacments(int length)
        {
            return GetAvailableHorizontalPlacment(length).Concat(GetAvailableVerticalPlacment(length));
        }

        public void EliminateSquares(Placment ToEliminate)
        {
            foreach (var square in ToEliminate)
                squares[square.Row, square.Column] = null;
            
        }

        private IEnumerable<Placment> GetAvailableHorizontalPlacment(int length)
        {
            var result = new List<List<Square>>();
            for(int r=0;r<Rows; ++r)
            {
                int counter = 0;
                for(int c=0; c < Columns; ++c)
                {
                    if (squares[r, c] != null)
                        ++counter;
                    else
                        counter = 0;
                    if (counter >= length) { 
                        List<Square> seq = new List<Square>();
                        for (int first = c - length + 1; first <= c; ++first)
                            seq.Add(squares[r, first]);
                        result.Add(seq);
                    }
                }
            }
            return result;
            
        }
        private IEnumerable<Placment> GetAvailableVerticalPlacment(int length)
        {
            throw new NotImplementedException();
        }

        public readonly int Rows;
        public readonly int Columns;
        private Square[,] squares;
    }
}
