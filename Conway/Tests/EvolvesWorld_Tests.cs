using System;
using Conway.Contracts;
using Conway.Lib;
using Conway.Values;
using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    public class EvolvesWorld_Tests : SpecsFor<EvolvesWorld>
    {
        World world = new World();
        Cell[] spaces = new Cell[0];
        Cell[] living_cells = new Cell[0];
        World evolved_world = new World();
        World result;

        protected override void Given()
        {
            GetMockFor<IFindsSpacesAroundLivingCells>().Setup(x => x.FindSpacesIn(world)).Returns(spaces);
            GetMockFor<IFindsLivingCells>().Setup(x => x.FindLivingCellsIn(world)).Returns(living_cells);
            GetMockFor<IEvolvesCells>().Setup(x => x.EvolveCells(world, spaces, living_cells)).Returns(evolved_world);
        }

        protected override void When()
        {
            result = SUT.Evolve(world);
        }

        [Test]
        public void HappyPath()
        {
            Assert.That(result, Is.EqualTo(evolved_world));
        }
    }
}
