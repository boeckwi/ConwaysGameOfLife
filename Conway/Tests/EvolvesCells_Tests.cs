using System;
using Conway.Lib;
using Conway.Values;
using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    public class EvolvesCells_Tests : SpecsFor<EvolvesCells>
    {
        [Test]
        public void RemovesCellsWithFeverThanTwoLiveNeighbours()
        {
            var world = new World();

            world.LivingCells = new[] {"A", "B"};

            var living_cells = new []
            {
                new Cell("A", 2), 
                new Cell("B", 1), 
            };

            var result = SUT.EvolveCells(world, new Cell[0], living_cells);
            Assert.That(result.LivingCells, Is.EqualTo(new[] {"A"}));
        }

        [Test]
        public void RemovesCellsWithMoreThanThreeNeighbours()
        {
            var world = new World();
            world.LivingCells = new[] {"A", "B"};
            var living_cells = new []
            {
                new Cell("A", 3), 
                new Cell("B", 4), 
            };

            var result = SUT.EvolveCells(world, new Cell[0], living_cells);
            Assert.That(result.LivingCells, Is.EqualTo(new[] {"A"}));
        }


        [Test]
        public void CreatsCellAtSpacesWithThreeNeighbours()
        {
            var world = new World();
            world.LivingCells = new string[0];
            var spaces = new []
            {
                new Cell("A", 2), 
                new Cell("B", 3), 
                new Cell("C", 4)
            };

            var result = SUT.EvolveCells(world, spaces, new Cell[0]);
            Assert.That(result.LivingCells, Is.EqualTo(new[] {"B"}));
        }
    }
}
