namespace Statistics.Tests
{
    [TestClass]
    public class StatisticsTests
    {
        private int[] testData = new int[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };

        [TestMethod]
        public void MaximumTest()
        {
            int expected = 9;
            int result = Statistics.Maximum(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MinimumTest()
        {
            int expected = 1;
            int result = Statistics.Minimum(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MeanTest()
        {
            double expected = 5.0;
            double result = Statistics.Mean(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MedianTest()
        {
            double expected = 5.5;
            double result = Statistics.Median(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModeTest()
        {
            int[] expected = new int[] { 5 };
            int[] result = Statistics.Mode(testData);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RangeTest()
        {
            int expected = 8;
            int result = Statistics.Range(testData);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardDeviationTest()
        {
            double expected = 2.87;
            double result = Statistics.StandardDeviation(testData);
            Assert.AreEqual(expected, result, 0.01);
        }
    }
}