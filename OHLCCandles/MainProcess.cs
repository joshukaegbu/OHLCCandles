using System;
using System.Collections.Generic;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandles
{
    public class MainProcess : IMainProcess
    {
        public ICandleGenerator CandleGenerator { get; set; }

        public IHourlyTimeSeriesProcessor TimeSeriesProcessor { get; set; }


        public MainProcess(ICandleGenerator candleGenerator, IHourlyTimeSeriesProcessor timeSeriesProcessor)
        {
            this.CandleGenerator = candleGenerator;
            this.TimeSeriesProcessor = timeSeriesProcessor;
        }

        public List<Candle> ProduceCandlesFromTimeSeries(TimeSeries timeSeries)
        {
            var dataChunks = TimeSeriesProcessor.ProcessHourlyTimeSeries(timeSeries);

            var candles = CandleGenerator.GenerateOHLCCandleList(dataChunks, "Hourly");

            return candles;
        }
    }
}
