using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OHLCCandles.DataModels;
using OHLCCandles.Interfaces;

namespace OHLCCandles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Instantiate IoC Container
            var container = StartUp.ConfigureServices();

            var mainProcess = container.GetRequiredService<IMainProcess>();

            //create mock data
            var testTimeSeries = TestDataGenerator.GenerateTestDataForTimeSeries();


            //produce OHLC candles
            var candles = await mainProcess.ProduceCandlesFromTimeSeries(testTimeSeries);

            PrintCandles(candles);


        }

        public static void PrintCandles(List<Candle> candles)
        {
            foreach(var candle in candles)
            {
                Console.WriteLine($"OpenValue: {candle.Openvalue} HighValue: {candle.HighValue} LowValue: {candle.LowValue} CloseValue: {candle.CloseValue}");
            }
        }
    }
}
