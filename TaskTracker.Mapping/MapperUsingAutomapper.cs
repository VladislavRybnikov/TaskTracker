using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Configuration.Base;

namespace TaskTracker.Mapping
{
    public class MapperUsingAutomapper
        : IGenericMapper
    { 
        public MapperUsingAutomapper(IMapperConfiguration config)
        {
            config.Configure();
        }

        public TFirst Map<TFirst, TSecond>(TSecond from)
        {
            throw new NotImplementedException();
        }

        public TSecond Map<TFirst, TSecond>(TFirst from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TFirst> Map<TFirst, TSecond>
            (IEnumerable<TSecond> from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TSecond> Map<TFirst, TSecond>
            (IEnumerable<TFirst> from)
        {
            throw new NotImplementedException();
        }
    }
}
