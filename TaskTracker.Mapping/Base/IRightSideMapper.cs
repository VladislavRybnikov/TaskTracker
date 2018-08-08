using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Mapping.Base
{
    public interface IRightSideMapper<TFrom, TTo>
    {
        TFrom Map(TTo from);
        IEnumerable<TFrom> Map(IEnumerable<TTo> from);
    }
}
