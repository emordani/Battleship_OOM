using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void GetAvilablePlacmentsForShipsReturns2PlacmentsForShipsofLength3InHorizontalGrid1x4()
        {
            Grid g = new Grid(1,4);
            var result = g.GetAvailablePlacments(3);
            Assert.AreEqual(2,result.Count());
            Assert.AreEqual(3,result.First().Count());
            Assert.AreEqual(3, result.Last().Count());
        }
        [TestMethod]
        public void GetAvilablePlacmentsForShipsReturns2PlacmentsForShipsofLength3InHorizontalGrid5x1()
        {
            Grid g = new Grid(5, 1);
            var result = g.GetAvailablePlacments(3);
            Assert.AreEqual(2, result.Count());

            foreach(var sequance in result)
                Assert.AreEqual(3, sequance.Count());
           
        }
    }
}
