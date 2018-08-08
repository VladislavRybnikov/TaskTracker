using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Mapping.Base
{
    public interface ILeftSideMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);       
        IEnumerable<TTo> Map(IEnumerable<TFrom> from);
    }
}
