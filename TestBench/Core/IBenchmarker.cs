using System;

namespace TestBench.Core
{
    internal interface IBenchmarker
    {
        void Run();
        T Time<T>(Func<T> func, string name);
    }
}
