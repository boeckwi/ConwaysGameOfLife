using System;
using Conway.Lib;
using NUnit.Framework;
using SpecsFor;

namespace Conway.Tests
{
    public class CreatesWorldFromString_Tests : SpecsFor<CreatesWorldFromString>
    {
        [Test]
        public void SingleCell()
        {
            var world = SUT.CreateWorldFrom(@"#");

            Assert.That(world.LivingCells, Is.EquivalentTo("A:1".Split()));
        }

        [Test]
        public void Multiple()
        {
            var world = SUT.CreateWorldFrom(@"
# 
 #
 #
");
            Assert.That(world.LivingCells, Is.EquivalentTo("A:1 B:2 B:3".Split()));
        }

        [Test]
        public void TrimsTopAndLeft()
        {
            var world = SUT.CreateWorldFrom(@"


    # 
     #
     #
");
            Assert.That(world.LivingCells, Is.EquivalentTo("A:1 B:2 B:3".Split()));
        }
    }
}
