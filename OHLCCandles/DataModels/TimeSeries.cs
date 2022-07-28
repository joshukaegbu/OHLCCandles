using System.Collections.Generic;

namespace OHLCCandles.DataModels
{
    public class TimeSeries
    {
        public string SeriesName { get; set; }

        public List<CustomDataPoint> DataPointsCollection { get; set; }
        
    }
}