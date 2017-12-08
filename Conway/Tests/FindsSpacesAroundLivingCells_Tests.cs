using System.Linq;
using NUnit.Framework;
using Conway.Lib;
using Conway.Values;

namespace Conway.Tests
{
    [TestFixture]
    public class FindsSpacesAroundLivingCells_Tests
    {
        [Test]
        public void SingleCell()
        {
            var SUT = new FindsSpacesAroundLivingCells();
            var cells = new[] { new Location("B2") };

            var spaces = SUT.FindSpacesAround(cells);

            Assert.That(spaces.Select(NameOf), Is.EquivalentTo("A1 A2 A3 B1 B3 C1 C2 C3".Split()));
        }

        [Test]
        public void ProducesNoDublicates()
        {
            var SUT = new FindsSpacesAroundLivingCells();
            var cells = new[] { new Location("B2"), new Location("D2") };

            var spaces = SUT.FindSpacesAround(cells);

            Assert.That(spaces.Select(NameOf).OrderBy(x => x), Is.EquivalentTo("A1 A2 A3 B1 B3 C1 C2 C3 D1 D3 E1 E2 E3".Split()));
        }

        [Test]
        public void ExcludesLivingCells()
        {
            var SUT = new FindsSpacesAroundLivingCells();
            var cells = new[] { new Location("B2"), new Location("C3") };

            var spaces = SUT.FindSpacesAround(cells);

            Assert.That(spaces.Select(NameOf).OrderBy(x => x), Is.EquivalentTo("A1 B1 C1 A2 C2 D2 A3 B3 D3 B4 C4 D4".Split()));
        }

        string NameOf(Cell c)
        {
            return c.Location.Name();
        }
    }
}
