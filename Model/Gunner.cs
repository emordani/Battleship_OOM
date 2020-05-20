using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }
    public class Gunner
    {
        public Gunner(int rows,int columns,IEnumerable<int> shipLengths) {
            evidenceGrid = new Grid(rows,columns);
            shipsToShoot=new List<int> (shipLengths.OrderByDescending(l => l));
            ShootingTactics = ShootingTactics.Random;
            squareTerminator = new SquareTerminator(rows, columns);
            targetSelect = new RandomShooting(evidenceGrid);
        }
        public Square NextTarget()
        {

            lastTarget = targetSelect.NextTarget(shipsToShoot[0]);
            return lastTarget;
        }

        public void ProcessHitResult (HitResult hitResult)
        {
            evidenceGrid.MarkHitResult(lastTarget, hitResult);
            if (hitResult == HitResult.Missed)
                return;
            squaresHit.Add(lastTarget);
            if (hitResult == HitResult.Sunken)
            {
                var toEliminate = squareTerminator.ToEliminate(squaresHit);
                foreach (var sq in toEliminate)
                    evidenceGrid.MarkHitResult(sq, HitResult.Missed);
                foreach (var sq in squaresHit)
                    evidenceGrid.MarkHitResult(sq, HitResult.Sunken);
                int length = squaresHit.Length;
                shipsToShoot.Remove(length);
                squaresHit.Clear();
            }
            ChangeTactics(hitResult);         
        }

        private void ChangeTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                ShootingTactics = ShootingTactics.Random;
                targetSelect = new RandomShooting(evidenceGrid);
                return;
            }
            if(hitResult==HitResult.Hit)
            {
                switch (ShootingTactics)
                {
                    case ShootingTactics.Random:
                        ShootingTactics = ShootingTactics.Surrounding;
                        targetSelect = new SurroundShooting(evidenceGrid,squaresHit);
                        return;
                    case ShootingTactics.Surrounding:
                        ShootingTactics = ShootingTactics.Inline;
                        targetSelect = new InlineShooting(evidenceGrid, squaresHit);
                        return;
                    case ShootingTactics.Inline:
                        return;
                }
            }           
        }

        private Square lastTarget;
        private Grid evidenceGrid;
        private List<int> shipsToShoot;
        private SortedSquares squaresHit = new SortedSquares();

        private Random random = new Random();
        private ISquareTerminator squareTerminator;
        private ITargetSelect targetSelect;
        public ShootingTactics ShootingTactics { get; private set; }
    }
}
