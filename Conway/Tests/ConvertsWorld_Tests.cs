using System;
using NUnit.Framework;
using SpecsFor;
using System.Linq;

namespace Conway.Tests
{
    class ConvertsWorld_Tests : SpecsFor<ConvertsWorld>
    {
        [Test]
        public void FromMatrix()
        {
            var input = new int[3, 2];
            input[0, 0] = 1;
            input[2, 1] = 1;

            var world = SUT.FromMatrix(input);

            Assert.That(PrintCells(world), Is.EqualTo("A1 C2"));
        }

        string PrintCells(World world)
        {
            return string.Join(" ", world.Cells.Select(PrintCell).OrderBy(x => x));
        }

        string PrintCell(Point point)
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return alphabet[point.X] + "" + (point.Y + 1);
        }


        [Test]
        public void ToMatrix()
        {
            var world = new World( new Point(1, 1), new Point(2, 4) );
            var expected_matrix = new int[2, 4];
            expected_matrix[0, 0] = 1;
            expected_matrix[1, 3] = 1;

            var actual_matrix = SUT.ToMatrix(world);

            Assert.That(actual_matrix, Is.EqualTo(expected_matrix));
            
        }
    }
}
