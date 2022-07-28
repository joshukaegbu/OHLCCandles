using System.Collections.Generic;
using OHLCCandles.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OHLCCandles.DataModels;

namespace OHLCCandles
{
    public class OHLCCandleGenerator : ICandleGenerator
    {

        public List<Candle> GenerateOHLCCandleList(List<List<CustomDataPoint>> dataChunks, string timePeriod)
        {
            var candleListOutput = new List<Candle>();

            foreach(var chunk in dataChunks)
            {
                var candle = GenerateOHLCCandle(chunk, timePeriod);
                candleListOutput.Add(candle);
            }

            return candleListOutput;
        }

        public Candle GenerateOHLCCandle(List<CustomDataPoint> data, string timePeriod)
        {
            var open = data.FirstOrDefault().YAxis;

            var close = data.LastOrDefault().YAxis;

            var high = data.Max(x => x.YAxis);

            var low = data.Min(x => x.YAxis);

            return new Candle() { Openvalue = open, CloseValue = close, HighValue = high, LowValue = low, TimePeriod = timePeriod };
        }
    }






}
