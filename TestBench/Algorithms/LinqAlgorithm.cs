﻿using System.Linq;

namespace TestBench.Algorithms
{
    internal class LinqAlgorithm : IAlgorithm
    {
        public int Solution(int[] inputs)
        {
            return inputs.Min();
        }
    }
}
