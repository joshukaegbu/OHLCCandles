using System;
using System.Collections.Generic;
using OHLCCandles.DataModels;

namespace OHLCCandles.Interfaces
{
    public interface IHourlyTimeSeriesProcessor
    {
        public List<List<CustomDataPoint>> ProcessHourlyTimeSeries(TimeSeries timeSeries);
    }
}
