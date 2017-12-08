//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Conway.Lib;
//using Conway.Values;
//using NUnit.Framework;

//namespace Conway.Tests
//{
//    [TestFixture]
//    public class IntegrationTests
//    {
//        [Test]
//        public void Glider()
//        {
//            var input = @"
//#
// ##
//##
//";
//            var expected = @"
//# 
//  #
//###
//";
//            List<World> protocol = new List<World>();
//            var SUT = new SimulatesConwayFactory().Create(protocol.Add);

//            SUT.Simulate(input, 1);

//            Assert.That(protocol.Single(), Is.EqualTo(expected));
//        }
//    }
//}
