using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RangeProject;

namespace RangeTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetRange_RightBoundaryIsGreaterThanTheLeftOne_ArgumentOutRangeException()
        {
  

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new RangeClass(5, 1));
        }

        [TestMethod]
        public void CompareRange_FirstRangeHas5and10AndRightHas1and3_FirstIsBroader()
        {
            var range1 = new RangeClass(5, 10);
            var range2 = new RangeClass(1, 3);
            
            string result = range1.CompareRange(range2);

            Assert.AreEqual("This range is bigger than the other range", result, "First range is broader than the second range");

        }

        [TestMethod]
        public void CompareRange_ValidComparisonWithBigNumbers_ValidComparison()
        {
            var range1 = new RangeClass(5000000000, 600000000000);
            var range2 = new RangeClass(5000000000, 700000000000);

            string result = range1.CompareRange(range2);

            Assert.AreEqual("This range is shorter than the other range", result, "First range is shorter than the second range");

        }

        [TestMethod]
        public void CompareRange_ValidComparisonWithFloatingNumbers_ValidComparison()
        {
            var range1 = new RangeClass(5.978, 6.93);
            var range2 = new RangeClass(1.01, 1.982);

            string result = range1.CompareRange(range2);

            Assert.AreEqual("This range is shorter than the other range", result, "First range is shorter than the second range");

        }

        [TestMethod]
        public void FindLength_ValidRange_ReturnsCorrectLength()
        {
            var range = new RangeClass(2, 5);

            double length = range.FindLength();

            Assert.AreEqual(3, length, "Length should be equal to the difference between right and left boundaries.");
        }

        [TestMethod]
        public void FindLength_ValidRangeWithBigNumbers_ReturnsCorrectLength()
        {
            var range = new RangeClass(0, 10000000000);

            double length = range.FindLength();

            Assert.AreEqual(10000000000, length, "Length sould be one billion");
        }

        [TestMethod]
        public void FindLength_ValidRangeWithFloatingNumbers_ReturnsCorrectLength()
        {
            var range = new RangeClass(3.6367, 6.1295);

            double length = range.FindLength();

            Assert.IsTrue(Math.Abs(length - 2.4928) < 0.0001);
        }

        [TestMethod]
        public void IsNumberInRange_NumberIsInRange_True()
        {
            var range = new RangeClass(0, 10);

            bool result = range.IsNumberInRange(5);

            Assert.AreEqual(true, result, "The number is in the rage");
        }

        [TestMethod]
        public void IsNumberInRange_NumberIsNotInRange_False()
        {
            var range = new RangeClass(0, 10);

            bool result = range.IsNumberInRange(15);

            Assert.AreEqual(false, result, "The number is not in the rage");
        }

        [TestMethod]
        public void IsNumberInRange_FloatingNumberIsInRange_True()
        {
            var range = new RangeClass(0.01, 0.9);

            bool result = range.IsNumberInRange(0.5);

            Assert.AreEqual(true, result, "The number is in the rage");
        }

        [TestMethod]
        public void IsNumberInRange_BigNumberIsInRange_True()
        {
            var range = new RangeClass(0, 10000000000);

            bool result = range.IsNumberInRange(500);

            Assert.AreEqual(true, result, "The number is in the rage");
        }

        [TestMethod]
        public void AreRangesIntersecting_RangesDoIntersect_True()
        {
            var range1 = new RangeClass(0, 10);
            var range2 = new RangeClass(4, 20);

            bool result = range1.AreRangesIntersecting(range2);

            Assert.AreEqual(true, result, "Ranges intersect");
        }

        [TestMethod]
        public void AreRangesIntersecting_RangesDoNotIntersect_False()
        {
            var range1 = new RangeClass(0, 10);
            var range2 = new RangeClass(11, 20);

            bool result = range1.AreRangesIntersecting(range2);

            Assert.AreEqual(false, result, "Ranges do not intersect");
        }
    }
}
