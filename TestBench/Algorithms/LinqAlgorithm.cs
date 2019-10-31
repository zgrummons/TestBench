using System.Linq;

namespace TestBench.Algorithms
{
    public class LinqAlgorithm : IAlgorithm
    {
        public int Solution(int[] inputs) => inputs.Min();
    }
}
