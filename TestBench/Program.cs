using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lamar;
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
            });

            container.GetInstance<IBenchmarker>().Run();
        }

    }
}
