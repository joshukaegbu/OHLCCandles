using System.Collections.Generic;
using System.Threading.Tasks;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandles.Interfaces
{
    public interface IMainProcess
    {
        ICandleGenerator CandleGenerator { get; set; }
        IHourlyTimeSeriesProcessor TimeSeriesProcessor { get; set; }

        public Task<List<Candle>> ProduceCandlesFromTimeSeries(TimeSeries timeSeries);
    }
}