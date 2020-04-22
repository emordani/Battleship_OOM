using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void AddShipCreatesNewShipInTheFleet()
        {
            Fleet fleet = new Fleet();
            fleet.AddShip(new List<Square> { new Square(1, 4), new Square(1, 5), new Square(1, 6) });
            Assert.AreEqual(1, fleet.Ships.Count());

            fleet.AddShip(new List<Square> { new Square(4, 5), new Square(5, 5), new Square(6, 5) });
            Assert.AreEqual(2, fleet.Ships.Count());

            Assert.IsTrue(fleet.Ships.First().Squares.Contains(new Square(1, 6)));
            Assert.IsTrue(fleet.Ships.First().Squares.Contains(new Square(1, 4)));
            Assert.IsTrue(fleet.Ships.First().Squares.Contains(new Square(1, 5)));
        }
    }
}
