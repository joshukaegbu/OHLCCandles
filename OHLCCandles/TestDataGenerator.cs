using System;
using System.Collections.Generic;
using System.Linq;
using OHLCCandles.DataModels;

namespace OHLCCandles
{
    public static class TestDataGenerator
    {

        //This method creates test data for a 14hr period, creating a new Data point per minute
        public static TimeSeries GenerateTestDataForTimeSeries()
        {
            var customDataPoints = new List<CustomDataPoint>();

            for(int i = 10; i <= 23; i++)
            {
                for (int j = 0; j <= 59; j++)
                {
                    var dataPoint = new CustomDataPoint() { XAxis = new DateTime(2022, 7, 27, i, j, 0), YAxis = GetRandomDoubleBetweenRange(100, 150) };

                    customDataPoints.Add(dataPoint);
                }
            }

            return new TimeSeries() { DataPointsCollection = customDataPoints, SeriesName = "Test Hourly Series" };
        }



        //This method created data for a 1hr period, creating a new Data point per minute
        public static List<CustomDataPoint> GenerateTestDataForCandle()
        {
            var customDataPoints = new List<CustomDataPoint>();

            for (int i = 0; i < 60; i++)
            {
                var dataPoint = new CustomDataPoint() { XAxis = new DateTime(2022, 7, 27, 18, i, 0), YAxis = GetRandomDoubleBetweenRange(100, 120) };

                customDataPoints.Add(dataPoint);
            }

            return customDataPoints.OrderBy(x => x.XAxis).ToList();
        }


        //This method generates random numbers between the two limits
        public static double GetRandomDoubleBetweenRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var randomDouble = random.NextDouble();

            var doubleWithinrange = (randomDouble * (upperBound - lowerBound)) + lowerBound;

            return doubleWithinrange;

        }

    }
}
