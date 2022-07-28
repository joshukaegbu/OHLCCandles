using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OHLCCandles;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandlesTest
{
    [TestFixture]
    public class OHLCCandleUnitTests
    {
        public ICandleGenerator SUT { get; set; }

        public List<CustomDataPoint> TestData { get; set; }

        public IHourlyTimeSeriesProcessor TimeSeriesProcessor { get; set; }

        public List<List<CustomDataPoint>> TestDataChunkList { get; set; }


        [SetUp]
        public void Setup()
        {
            this.SUT = new OHLCCandleGenerator();
            this.TestData = TestDataGenerator.GenerateTestDataForCandle();
            this.TimeSeriesProcessor = new TimeSeriesProcessor();
            this.TestDataChunkList = TimeSeriesProcessor.ProcessHourlyTimeSeries(TestDataGenerator.GenerateTestDataForTimeSeries());
        }

        //Are the correct number of candles created 
        [Test]
        public void GenerateCandleListProducesCorrectNoOfCandles()
        {
            var candleList = SUT.GenerateOHLCCandleList(TestDataChunkList, "Hourly");

            Assert.That(candleList.Count, Is.EqualTo(14));
        }

        //These Tests check to see if a candle with the correct values is created when random generated data is passed into the GenerateOHLCCandle Method

        [Test]
        public void OHLCCandleGeneratorProducesCorrectOpenValue()
        {
            var candle = SUT.GenerateOHLCCandle(TestData, "Hourly");

            Assert.That(candle, Is.Not.Null);
            Assert.That(candle.Openvalue, Is.EqualTo(TestData.ElementAt(0).YAxis));
           

        }

        [Test]
        public void OHLCCandleGeneratorProducesCorrectHighValue()
        {
            var candle = SUT.GenerateOHLCCandle(TestData, "Hourly");

            Assert.That(candle, Is.Not.Null);
            Assert.That(candle.HighValue, Is.EqualTo(TestData.Max(x => x.YAxis)));
        }

        [Test]
        public void OHLCCandleGeneratorProducesCorrectLowValue()
        {
            var candle = SUT.GenerateOHLCCandle(TestData, "Hourly");

            Assert.That(candle, Is.Not.Null);
            Assert.That(candle.LowValue, Is.EqualTo(TestData.Min(x => x.YAxis)));
        }

        [Test]
        public void OHLCCandleGeneratorProducesCorrectCloseValue()
        {
            var candle = SUT.GenerateOHLCCandle(TestData, "Hourly");

            Assert.That(candle, Is.Not.Null);
            Assert.That(candle.CloseValue, Is.EqualTo(TestData.LastOrDefault().YAxis));
        }


        [Test]
        public void TestRandomNumberGenerator()
        {
            var randomnumber = TestDataGenerator.GetRandomDoubleBetweenRange(100, 120);

            Assert.That(randomnumber, Is.GreaterThan(100));
            Assert.That(randomnumber, Is.LessThan(120));
        }

    }
}
