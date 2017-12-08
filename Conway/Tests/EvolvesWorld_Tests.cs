using System.Collections.Generic;
using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    class EvolvesWorld_Tests : SpecsFor<EvolvesWorld>
    {
        Point[] input_cells = new[] { new Point(1, 1), new Point(2, 2) };
        Point[] cells_to_remove = new[] { new Point(2, 2) };
        Point[] cells_to_create = new[] { new Point(3, 3) };
        IEnumerable<Point> result;

        protected override void Given()
        {
            GetMockFor<IAnalysesCells>().Setup(x => x.FindCellsToCreate(input_cells)).Returns(cells_to_create);
            GetMockFor<IAnalysesCells>().Setup(x => x.FindCellsToRemove(input_cells)).Returns(cells_to_remove);
        }

        protected override void When()
        {
            var world = new World(input_cells);
            var evolved_world = SUT.Evolve(world);
            result = evolved_world.Cells;
        }

        [Test]
        public void HappyPath()
        {
            Assert.That(result, Is.EqualTo(new[] { new Point(1, 1), new Point(3, 3) }));
        }
    }
}
