using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandles
{
    public class TimeSeriesProcessor : IHourlyTimeSeriesProcessor  //Can be extended to implement IMinuteTimeSeriesProcessor in the future
    {

        public List<List<CustomDataPoint>> ProcessHourlyTimeSeries(TimeSeries timeSeries)
        {
            
            var sortedDataPoints = timeSeries.DataPointsCollection.OrderBy(x => x.XAxis).ToList();       //Sort DataPoints by TimeStamp


            var startDataPoint = sortedDataPoints.FirstOrDefault();       //Determine first and last datapoint on X-axis/time axis

            var lastDataPoint = sortedDataPoints.LastOrDefault();


            //We need to split the time series into smaller hour based chunks, one chunk per hour.
            //First do some DateTime arithmetic to determine how many chunks there will be.

            var totalHours = (lastDataPoint.XAxis - startDataPoint.XAxis).TotalHours;

            
            var totalNoOfCandles = Math.Ceiling(totalHours);   //round up to get the total number of hourly candles

            var currentDataPoint = startDataPoint;

            var hourDataChunkListOutput = new List<List<CustomDataPoint>>();

            int j = 0; // this counter will be used to kep track of our location within the whole data set

            for (int i = 0; i < totalNoOfCandles ; i++)
            {
                
                List<CustomDataPoint> hourDataChunk = new List<CustomDataPoint>();      //This list will store all the data points for each hour


                while (currentDataPoint.XAxis < (startDataPoint.XAxis.AddHours(1)))  //While loop will keep looping while current time is less than 1 hr away from the start time
                {
                    if(j < (sortedDataPoints.Count - 1))   //This if statement breaks out of the loop for the last iteration, to prevent argument out of range exception.
                    {
                        hourDataChunk.Add(sortedDataPoints.ElementAt(j));
                        j++;

                        currentDataPoint = sortedDataPoints.ElementAt(j);
                    }
                    else
                    {
                        hourDataChunk.Add(sortedDataPoints.LastOrDefault());
                        break;
                    }
                            
                }

                hourDataChunkListOutput.Add(hourDataChunk);
                //while loop stops excuting because we have completed 1 hr interval, to start generating the next chunk we make the starting dataPoint equal to current dataPoint, and begin executing from this new point.
                startDataPoint = sortedDataPoints.ElementAt(j);       

            }

            return hourDataChunkListOutput;




        }
    }
}
