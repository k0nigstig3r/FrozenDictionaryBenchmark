using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class Benchmark
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDictionaries>();
            Console.ReadLine();
        }
    }

    public class BenchmarkDictionaries
    {
        private static readonly VanillaUserCache VanillaUserCache = new();
        private static readonly PerformantUserCache PerformantUserCache = new();


        [Benchmark]
        public void BenchmarkVanilla()
        {
            var _ = VanillaUserCache.GetItem(1);
        }

        [Benchmark]
        public void BenchmarkPerformant()
        {
            var _ = PerformantUserCache.GetItem(1);
        }
    }
}