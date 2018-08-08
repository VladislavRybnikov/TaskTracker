using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Mapping.Base
{
    public interface IMapper<TFirst, TSecond> : ILeftSideMapper<TFirst, TSecond>,
        IRightSideMapper<TFirst, TSecond>
    {
       
    }
}
