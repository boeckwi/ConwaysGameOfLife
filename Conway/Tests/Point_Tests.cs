using NUnit.Framework;
using System.Linq;

namespace Conway.Tests
{
    [TestFixture]
    public class Point_Tests
    {
        [Test]
        public void Adjacents()
        {
            var point = new Point(2, 3);
            var expected = new[]
            {
                new Point(1, 2),
                new Point(2, 2),
                new Point(3, 2),

                new Point(1, 3),
                new Point(3, 3),

                new Point(1, 4),
                new Point(2, 4),
                new Point(3, 4),
            };

            Assert.That(point.Adjacents(), Is.EquivalentTo(expected));
        }
    }
}
