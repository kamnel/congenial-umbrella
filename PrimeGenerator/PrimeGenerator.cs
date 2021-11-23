using System;
using System.Collections;
using System.Linq;

namespace Vista.Sample.Utils.Library
{
    public class PrimeGenerator
    {
        public static IEnumerable GetPrimeNumbers(int num)
        {
            return Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(num))))
                .Aggregate(Enumerable.Range(1, num).ToList(),
                (result, index) =>
                    {
                        result.RemoveAll(i => i > result[index] && i%result[index] == 0);
                        return result;
                    }
                );
        }
    }

}
