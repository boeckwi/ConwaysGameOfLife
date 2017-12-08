using System;
using Conway.Lib;
using NUnit.Framework;
using SpecsFor;
using System.Linq;
using Conway.Values;

namespace Conway.Tests
{
    public class CreatesWorldFromString_Tests : SpecsFor<CreatesWorldFromString>
    {
        [Test]
        public void SingleCell()
        {
            var world = SUT.CreateWorldFrom(@"#");

            Assert.That(world.LivingCells.Select(NameOf), Is.EquivalentTo("A1".Split()));
        }

        [Test]
        public void Multiple()
        {
            var world = SUT.CreateWorldFrom(@"
# 
 #
 #
");
            Assert.That(world.LivingCells.Select(NameOf), Is.EquivalentTo("A1 B2 B3".Split()));
        }

        [Test]
        public void TrimsTopAndLeft()
        {
            var world = SUT.CreateWorldFrom(@"


    # 
     #
     #
");
            Assert.That(world.LivingCells.Select(NameOf), Is.EquivalentTo("A1 B2 B3".Split()));
        }
        string NameOf(Location c)
        {
            return c.Name();
        }

    }
}
