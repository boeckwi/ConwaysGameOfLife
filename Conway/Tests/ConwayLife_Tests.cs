using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    class ConwayLife_Tests : SpecsFor<ConwayLife>
    {
        int[,] input_matrix = new int[0, 0];
        World initial_world = new World();
        World evolved_world = new World();
        int[,] evolved_matrix = new int[10, 10];
        int[,] actual_output;

        protected override void Given()
        {
            GetMockFor<IConvertsWorld>().Setup(x => x.FromMatrix(input_matrix)).Returns(initial_world);
            GetMockFor<IEvolvesWorld>().Setup(x => x.Evolve(initial_world)).Returns(evolved_world);
            GetMockFor<IConvertsWorld>().Setup(x => x.ToMatrix(evolved_world)).Returns(evolved_matrix);
        }

        protected override void When()
        {
            actual_output = SUT.Evolve(input_matrix);
        }

        [Test]
        public void HappyPath()
        {
            Assert.That(actual_output, Is.EqualTo(evolved_matrix));
        }
    }
}
