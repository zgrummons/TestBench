namespace TestBench.Algorithms
{
    internal class SimpleAlgorithm : IAlgorithm
    {
        public int Solution(int[] inputs)
        {
            var result = int.MaxValue;
            foreach (var input in inputs)
            {
                if (input < result)
                    result = input;
            }

            return result;
        }
    }
}
