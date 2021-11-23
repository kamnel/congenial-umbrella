using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Sample.Utils.Library
{
    public class CpuUtils
    {
        public static IEnumerable<int> GetRandomNumbers(int num)
        {
            // Source must be array or IList.
            var source = Enumerable.Range(0, num).ToArray();

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length);
            var rand = new Random();

            int[] results = new int[source.Length];

            // Loop over the partitions in parallel.
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = rand.Next();
                }
            });
            return results;

        }
    }
}
