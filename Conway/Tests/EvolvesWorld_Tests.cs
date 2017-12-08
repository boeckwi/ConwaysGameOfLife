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
        Location[] existing_cells = new Location[0];
        Cell[] spaces = new Cell[0];
        World world;
        Cell[] living_cells = new Cell[0];
        World evolved_world = new World();
        World result;

        protected override void Given()
        {
            world = new World { LivingCells = existing_cells };
            GetMockFor<IFindsSpacesAroundLivingCells>().Setup(x => x.FindSpacesAround(existing_cells)).Returns(spaces);
            GetMockFor<IFindsLivingCells>().Setup(x => x.FindLivingCellsIn(world.LivingCells)).Returns(living_cells);
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
