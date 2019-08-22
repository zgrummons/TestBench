using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TestBench.Algorithms;

namespace TestBench.Core
{
    internal class Benchmarker : IBenchmarker
    {
        private readonly IEnumerable<IAlgorithm> _algorithms;

        public Benchmarker(IEnumerable<IAlgorithm> algorithms)
        {
            _algorithms = algorithms;
        }

        public void Run()
        {
            var numbers = Time(LoadIntegers, "LoadIntegers");

            foreach (var algorithm in _algorithms)
                Time(() => algorithm.Solution(numbers), algorithm.ToString());
        }

        public T Time<T>(Func<T> func, string name)
        {
            var sw = Stopwatch.StartNew();
            var result = func.Invoke();
            sw.Stop();
            Console.WriteLine($"Method {name} ran in {sw.Elapsed.TotalSeconds} seconds{(result is int ? $", returning a result of {result}" : string.Empty)}.");
            return result;
        }

        private static int[] LoadIntegers()
        {
            var rng = new Random();
            var count = rng.Next(100, int.MaxValue);
            Console.WriteLine($"Generating {count:N0} integers");
            var numbers = new int[count];
            var percentIncrement = count / 100;

            for (var i = 0; i < count; i++)
            {
                if (i % percentIncrement == 0)
                    Console.Write($"\r{i / percentIncrement}% done");
                numbers[i] = rng.Next();
            }

            Console.WriteLine($"\nInteger generation finished");
            return numbers;
        }
    }
}
