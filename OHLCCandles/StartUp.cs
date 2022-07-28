using System;
using Microsoft.Extensions.DependencyInjection;
using OHLCCandles.Interfaces;

namespace OHLCCandles
{
    //This class will set up the Dependency Injection

    public class StartUp
    {
        public static IServiceProvider ConfigureServices()
        {
            var provider = new ServiceCollection()
                .AddSingleton<ICandleGenerator, OHLCCandleGenerator>()
                .AddSingleton<IHourlyTimeSeriesProcessor, TimeSeriesProcessor>()
                .AddSingleton<IMainProcess, MainProcess>()
                .BuildServiceProvider();            

            return provider;
                
        }
    }
}
