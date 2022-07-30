using System;
using System.Collections.Generic;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;
using System.Threading.Tasks;

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

        public async Task<List<Candle>> ProduceCandlesFromTimeSeries(TimeSeries timeSeries)
        {
            var dataChunks = new List<List<CustomDataPoint>>();
            var candles = new List<Candle>();

            await Task.Run(() =>
            {
                dataChunks = TimeSeriesProcessor.ProcessHourlyTimeSeries(timeSeries);

                candles = CandleGenerator.GenerateOHLCCandleList(dataChunks, "Hourly");
            });
           

            return candles;
        }
    }
}
