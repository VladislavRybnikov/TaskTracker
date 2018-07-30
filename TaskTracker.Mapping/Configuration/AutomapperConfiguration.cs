using AutoMapper;
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
                Mapper.Initialize(cfg => 
                {
                    //TODO: Create maps;
                });
            }

            IsConfigurated = true;
        }

        public void Reset()
        {
            Mapper.Reset();
        }
    }
}
