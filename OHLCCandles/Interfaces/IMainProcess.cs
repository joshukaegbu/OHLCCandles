using System.Collections.Generic;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandles.Interfaces
{
    public interface IMainProcess
    {
        ICandleGenerator CandleGenerator { get; set; }
        IHourlyTimeSeriesProcessor TimeSeriesProcessor { get; set; }

        List<Candle> ProduceCandlesFromTimeSeries(TimeSeries timeSeries);
    }
}