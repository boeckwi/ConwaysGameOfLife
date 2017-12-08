using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    class AnalysesCells_Tests : SpecsFor<AnalysesCells>
    {
        [Test]
        public void CellWithMoreThan3Neighbours_ShouldBeRemoved()
        {
            var cells = new[]
            {
                                  new Point(2, 1), new Point(3, 1),
                new Point(1, 2),  new Point(2, 2), new Point(3, 2),
            };

            var actual = SUT.FindCellsToRemove(cells);

            var expected = new[]
            {
                new Point(2, 1),
                new Point(2, 2)
            };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CellWithLessThan2Neighbours_ShouldBeRemoved()
        {
            var cells = new[]
            {
                new Point(1, 1),        new Point(3, 1), new Point(4, 1),
                new Point(1, 2),        new Point(3, 2), new Point(4, 2),
            };

            var actual = SUT.FindCellsToRemove(cells);

            var expected = new[]
            {
                new Point(1, 1),
                new Point(1, 2)
            };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AtSpaceWith3Neighbours_ShouldCreateCell()
        {
            var cells = new[]
            {
                new Point(1, 1), 
                new Point(1, 2), new Point(2, 2)
            };

            var actual = SUT.FindCellsToCreate(cells);

            var expected = new[]
            {
                new Point(2, 1),
            };

            Assert.That(actual, Is.EqualTo(expected));
        }}
}
