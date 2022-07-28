using System;
using NUnit.Framework;
using OHLCCandles.Interfaces;
using OHLCCandles;
using OHLCCandles.DataModels;

namespace OHLCCandlesTest
{
    [TestFixture]
    public class TimeSeriesProcessorTests
    {
        public IHourlyTimeSeriesProcessor TimeSeriesProcessor { get; set; }

        public TimeSeries SUT { get; set; }


        [SetUp]
        public void SetUp()
        {
            this.TimeSeriesProcessor = new TimeSeriesProcessor();
            this.SUT = TestDataGenerator.GenerateTestDataForTimeSeries();
        }

        [Test]
        public void CheckNoOfCandlesCreated()
        {
            var hourDataChunks = TimeSeriesProcessor.ProcessHourlyTimeSeries(SUT);

            Assert.That(hourDataChunks, Is.Not.Null);
            Assert.That(hourDataChunks.Count, Is.EqualTo(14));
        }

        [Test]
        public void CheckNumberOfDataPointsPerHourChunk() //Test makes sure that all data points are processed, should be 60 per chunk/one for each minute.
        {
            var hourDataChunks = TimeSeriesProcessor.ProcessHourlyTimeSeries(SUT);

            foreach(var chunk in hourDataChunks)
            {
                Assert.That(chunk.Count, Is.EqualTo(60));
            }
        }
    }
}
