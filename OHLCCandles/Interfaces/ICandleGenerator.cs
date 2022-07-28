using System;
using System.Collections.Generic;
using OHLCCandles.DataModels;

namespace OHLCCandles.Interfaces
{
    public interface ICandleGenerator
    {
        public Candle GenerateOHLCCandle(List<CustomDataPoint> data, string timePeriod);

        public List<Candle> GenerateOHLCCandleList(List<List<CustomDataPoint>> dataChunks, string timePeriod);
    }
}
