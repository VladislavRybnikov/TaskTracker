using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;

namespace TaskTracker.Mapping.Dto
{
    public class WorkTaskPointDtoMapper : IMapper<WorkTaskPoint, WorkTaskPointDto>
    {
        public WorkTaskPoint Map(WorkTaskPointDto from)
        {
            throw new NotImplementedException();
        }

        public WorkTaskPointDto Map(WorkTaskPoint from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkTaskPoint> Map(IEnumerable<WorkTaskPointDto> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }

        public IEnumerable<WorkTaskPointDto> Map(IEnumerable<WorkTaskPoint> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
