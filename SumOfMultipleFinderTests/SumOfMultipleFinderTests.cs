using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfMultiple;
using System;

namespace SumOfMultipleFinderTests
{
    [TestClass]
    public class SumOfMultipleFinderTests
    {
        private ISumOfMultipleFinder _sumOfMultipleFinder;

        [TestInitialize]
        public void Setup()
        {
            _sumOfMultipleFinder = new SumOfMultipleFinder();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SumOfNegativeValues_ThrowsException()
        {
            _sumOfMultipleFinder.SumOfMultipleThreeOrFive(int.MinValue);
        }

        [TestMethod]
        [DataRow(0,(ulong)0)]
        [DataRow(3, (ulong)0)]
        [DataRow(15, (ulong)45)]
        [DataRow(16, (ulong)60)]
        [DataRow(1000, (ulong)233168)]
        public void MultipleThreeOrFiveReturnsCorrectData(int input, ulong expected)
        {
            Assert.AreEqual(expected, _sumOfMultipleFinder.SumOfMultipleThreeOrFive(input));
        }     

        [TestMethod]
        public void MultipleThreeOrFive_IntMax_Returns()
        {
            Assert.IsTrue(_sumOfMultipleFinder.SumOfMultipleThreeOrFive(int.MaxValue) > 0);
        }
    }
}
