using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGunner
    {
        [TestMethod]
        public void InitiallyShootingTacticsIsRandomAslongAsFirstSquareIsHit()
        {
            int[] shipLengths = new int[] {1,2,3 };
            Gunner g = new Gunner(6,6,shipLengths);
            Assert.AreEqual(ShootingTactics.Random,g.ShootingTactics);
            g.NextTarget();
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromRandomToSurroundingAfterFirstSquareIsHit()
        {
            int[] shipLengths = new int[] { 1, 2, 3 };
            Gunner g = new Gunner(6, 6, shipLengths);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            int[] shipLengths = new int[] { 1, 2, 3 };
            Gunner g = new Gunner(6, 6, shipLengths);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);
        }

        [TestMethod]
        public void ShootingTacticsChangesFromInlineToRandomAfterShipIsSunken()
        {
            int[] shipLengths = new int[] { 1, 2, 3 };
            Gunner g = new Gunner(6, 6, shipLengths);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.ShootingTactics);

            g.NextTarget();
            g.ProcessHitResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, g.ShootingTactics);
            
        }
    }
}
