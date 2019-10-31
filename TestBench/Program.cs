using Lamar;
using Serilog;
using Serilog.Core;
using TestBench.Algorithms;
using TestBench.Core;

namespace TestBench
{
    internal class Program
    {
        private static void Main()
        {
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.AddAllTypesOf<IAlgorithm>();
                });

                _.For<IBenchmarker>().Use<Benchmarker>().Singleton();
                _.For<ILogger>().Use(new LoggerConfiguration().WriteTo.Console().CreateLogger()).Singleton();
            });
             
            container.GetInstance<IBenchmarker>().Run();
        }

    }
}
