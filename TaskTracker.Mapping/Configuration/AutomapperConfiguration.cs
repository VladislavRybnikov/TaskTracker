using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Mapping.Configuration.Base;

namespace TaskTracker.Mapping.Configuration
{
    public class AutomapperConfiguration : IMapperConfiguration
    {
        public static bool IsConfigurated { get; set; }

        static AutomapperConfiguration()
        {
            IsConfigurated = false;
        }

        public void Configure()
        {
            if (!IsConfigurated)
            {

            }

            IsConfigurated = true;
        }
    }
}
