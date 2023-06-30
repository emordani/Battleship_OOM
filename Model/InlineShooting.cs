using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class InlineShooting : ITargetSelect
    {
        public InlineShooting(Grid evidenceGrid,SortedSquares squaresHit)
        {
            this.squaresHit = squaresHit;
            this.evidenceGrid = evidenceGrid;
        }
        public Square NextTarget(int shipLength)
        {
            var l = evidenceGrid.GetSquaresInline(squaresHit);
            if (l.Count() == 1)
                return l.ElementAt(0).First();

            int index = random.Next(0, l.Count());
            return l.ElementAt(index).First();
        }
        private Random random = new Random();
        private readonly Grid evidenceGrid;
        private readonly SortedSquares squaresHit;
    }
}
