namespace TestBench.Algorithms
{
    public class IntuitiveAlgorithm : IAlgorithm
    {
        public int Solution(int[] inputs)
        {
            var result = int.MaxValue;
            foreach (var t in inputs)
                result = t < result ? t : result;
            return result;
        }
        private static int SolutionN2(int[] a)
        {
            int lowest = int.MaxValue;

            for (int i = 0; i < a.Length / 2; i++)
                lowest = a[i] < a[a.Length - i - 1] ? a[i] < lowest ? a[i] : lowest : a[a.Length - i - 1] < lowest ? a[a.Length - i - 1] : lowest;
            if (a.Length % 2 == 1)
                lowest = a[a.Length / 2] < lowest ? a[a.Length / 2] : lowest;
            return lowest;
        }

        private static int SolutionN2seq(int[] a)
        {
            int lowest = int.MaxValue;

            for (int i = 0; i < a.Length / 2; i += 2)
                lowest = a[i] < a[i + 1] ? a[i] < lowest ? a[i] : lowest : a[i + 1] < lowest ? a[i + 1] : lowest;
            if (a.Length % 2 == 1)
                lowest = a[a.Length / 2] < lowest ? a[a.Length / 2] : lowest;
            return lowest;
        }
    }
}