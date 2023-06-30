using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetMethodCretesShips()
        {
            Shipwright sw = new Shipwright(10, 10);
            var fleet = sw.CreateFleet(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            Assert.AreEqual(10, fleet.Ships.Count());
        }
        [TestMethod]
        public void CreateFleetMethodCretesShipsForAGivenTerminator()
        {
            var terminator = SquareTerminatorFactory.Create(Model.ShipAdjoining.None, 10, 10);
            Shipwright sw = new Shipwright(10, 10);
            var fleet = sw.CreateFleet(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            Assert.AreEqual(10, fleet.Ships.Count());
        }
    }
}
