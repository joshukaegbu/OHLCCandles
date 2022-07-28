using System;
namespace OHLCCandles.DataModels
{
    public class Candle
    {
        public string TimePeriod { get; set; }

        public double Openvalue { get; set; }

        public double HighValue { get; set; }

        public double LowValue { get; set; }

        public double CloseValue { get; set; }
    }
}
