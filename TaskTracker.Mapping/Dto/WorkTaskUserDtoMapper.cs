using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;
using TaskTracker.ViewModels;

namespace TaskTracker.Mapping.Dto
{
    public class WorkTaskUserDtoMapper
        : IMapper<WorkTaskUser, WorkTaskUserDto>
    {
        public WorkTaskUser Map(WorkTaskUserDto from)
        {
            throw new NotImplementedException();
        }

        public WorkTaskUserDto Map(WorkTaskUser from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkTaskUser> Map(IEnumerable<WorkTaskUserDto> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }

        public IEnumerable<WorkTaskUserDto> Map(IEnumerable<WorkTaskUser> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
