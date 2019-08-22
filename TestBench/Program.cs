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
            //PostAttachment()

            var container = new Container(_ =>
            {
                _.For<IBenchmarker>().Use<Benchmarker>().Singleton();

                _.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                });
                //_.For<IAlgorithm>().Add<LinqAlgorithm>();
                //_.For<IAlgorithm>().Add<SimpleAlgorithm>();
                //_.For<IAlgorithm>().Add<SimpleO1Algorithm>();
            });

            container.GetInstance<IBenchmarker>().Run();
        }

    }
}
