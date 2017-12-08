using System;
using Conway.Lib;
using Conway.Values;
using NUnit.Framework;
using SpecsFor;
using System.Linq;

namespace Conway.Tests
{
    public class EvolvesCells_Tests : SpecsFor<EvolvesCells>
    {
        [Test]
        public void RemovesCellsWithFeverThanTwoLiveNeighbours()
        {
            var world = new World();

            world.LivingCells = new[] {new Location("A1"),new Location("B1")};

            var living_cells = new []
            {
                Cell("A1", 2), 
                Cell("B1", 1), 
            };

            var result = SUT.EvolveCells(world, living_cells, new Cell[0]);
            Assert.That(result.LivingCells.Select(NameOf), Is.EqualTo(new[] {"A1"}));
        }

        Cell Cell(string location, int neighbours)
        {
            return new Cell(new Location(location), neighbours);
        }

        [Test]
        public void RemovesCellsWithMoreThanThreeNeighbours()
        {
            var world = new World();
            world.LivingCells = new[] { new Location("A1"), new Location("B1")};
            var living_cells = new []
            {
                Cell("A1", 3), 
                Cell("B1", 4), 
            };

            var result = SUT.EvolveCells(world, new Cell[0], living_cells);
            Assert.That(result.LivingCells.Select(NameOf), Is.EqualTo(new[] {"A1"}));
        }

        string NameOf(Location location)
        {
            return location.Name();
        }

        [Test]
        public void CreatsCellAtSpacesWithThreeNeighbours()
        {
            var world = new World();
            world.LivingCells = new Location[0];
            var spaces = new []
            {
                Cell("A1", 2), 
                Cell("B1", 3), 
                Cell("C1", 4)
            };

            var result = SUT.EvolveCells(world, new Cell[0], spaces);
            Assert.That(result.LivingCells.Select(NameOf), Is.EqualTo(new[] {"B1"}));
        }
    }
}
