using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SortedSquares :IEnumerable<Square>
    {
        public void Add(Square square)
        {
            squares.Add(square);
            squares=squares.OrderBy(s => s.Row + s.Column).ToList();
        }
        public void Clear()
        {
            squares.Clear();
        }

        public IEnumerator<Square> GetEnumerator()
        {
           return squares.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return squares.GetEnumerator();
        }

        //public IEnumerable<Square> Squares { get { return squares; } }
      
        public int Length{ get { return squares.Count; } }

        private List<Square> squares = new List<Square>();
    }
}
