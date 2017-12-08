using Conway.Lib;
using Conway.Values;
using NUnit.Framework;
using System.Linq;
using System;

namespace Conway.Tests
{
    [TestFixture]
    public class FindsLivingCells_Tests
    {
        [Test]
        public void SingleCellWithoutNeighbours()
        {
            var SUT = new FindsLivingCells();
            var cells = new[] { new Location("B2") };

            var spaces = SUT.FindLivingCellsIn(cells);

            Assert.That(spaces.Select(Print), Is.EquivalentTo("B2:0".Split()));
        }

        string Print(Cell c)
        {
            return c.Location.Name() + ":" + c.LivingNeighbours;
        }
    }
}
