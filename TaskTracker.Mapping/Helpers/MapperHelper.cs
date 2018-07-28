using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskTracker.Mapping.Helpers
{
    internal class MapperHelper
    {
        internal static IEnumerable<TFirst> TransformRange<TFirst, TSecond>
           (IEnumerable<TSecond> from,
           Func<TSecond, TFirst> transformation) 
            => from.ToList().Select(x => transformation(x));
    }
}
