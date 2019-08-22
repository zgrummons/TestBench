namespace TestBench.Algorithms
{
    internal class SimpleO1Algorithm : IAlgorithm
    {
        public int Solution(int[] inputs)
        {
            var result = int.MaxValue;
            foreach (var input in inputs)
            {
                if (input >= result) continue;

                if (input == 0)
                    return input;

                result = input;
            }

            return result;
        }
    }
}
