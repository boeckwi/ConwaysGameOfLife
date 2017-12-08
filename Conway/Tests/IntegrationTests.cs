using System.Collections.Generic;
using System.Linq;
using Conway.Lib;
using Conway.Values;
using NUnit.Framework;

namespace Conway.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Triangle()
        {
            var input = @"
#
##";
            var expected = new CreatesWorldFromString().CreateWorldFrom(@"
##
##
");

            List<World> protocol = new List<World>();
            var SUT = new SimulatesConwayFactory().Create(protocol.Add);

            SUT.Simulate(input, 1);

            Assert.That(protocol.Last().LivingCells, Is.EquivalentTo(expected.LivingCells));
        }

        [Test]
        public void Glider()
        {
            var input = @"
#
 ##
##
";

            var expected = new CreatesWorldFromString().CreateWorldFrom(@"
 # 
  #
###
");
            List<World> protocol = new List<World>();
            var SUT = new SimulatesConwayFactory().Create(protocol.Add);

            SUT.Simulate(input, 1);

            Assert.That(protocol.Last().LivingCells, Is.EquivalentTo(expected.LivingCells));
        }

    }
}
