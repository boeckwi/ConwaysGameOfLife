using System;
using System.Collections.Generic;
using Conway.Contracts;
using Conway.Lib;
using Conway.Values;
using Moq;
using NUnit.Framework;
using SpecsFor;


namespace Conway.Tests
{
    class SimulatesConway_Tests : SpecsFor<SimulatesConway>
    {
        World world0 = new World();
        World world1 = new World();
        World world2 = new World();
        List<World> output = new List<World>();

        protected override void Given()
        {
            GetMockFor<ICreatesWorldFromString>().Setup(x => x.CreateWorldFrom("input")).Returns(world0);
            GetMockFor<IEvolvesWorld>().Setup(x => x.Evolve(world0)).Returns(world1);
            GetMockFor<IEvolvesWorld>().Setup(x => x.Evolve(world1)).Returns(world2);
            GetMockFor<IOutputsWorld>().Setup(x => x.Output(It.IsAny<World>())).Callback<World>(output.Add);
        }

        protected override void When()
        {
            SUT.Simulate("input", 2);
        }

        [Test]
        public void HappyPath()
        {
            Assert.That(output, Is.EqualTo(new[]{ world0, world1, world2 }));
        }
    }
}
