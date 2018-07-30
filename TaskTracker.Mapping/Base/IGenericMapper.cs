using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Mapping.Base
{
    public interface IGenericMapper
    {
        TFirst Map<TFirst, TSecond>(TSecond from);
        TSecond Map<TFirst, TSecond>(TFirst from);

        IEnumerable<TFirst> Map<TFirst, TSecond>
            (IEnumerable<TSecond> from);
        IEnumerable<TSecond> Map<TFirst, TSecond>
            (IEnumerable<TFirst> from);
    }
}
