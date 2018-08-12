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
            return new WorkTaskPoint
            {
                Id = from.Id,
                Name = from.Name,
                Description = from.Description,
                AttachmentPath = from.AttachmentPath,
                WorkTaskPointProgress = new WorkTaskPointProgress
                {
                    ExecutedPercent = from.ExecutedPercent,
                    PointSateDescripton = from.PointSateDescripton,
                    PointState = from.PointState
                }
            };
        }

        public WorkTaskPointDto Map(WorkTaskPoint from)
        {
            var result = new WorkTaskPointDto
            {
                Id = from.Id,
                Name = from.Name,
                Description = from.Description,
                AttachmentPath = from.AttachmentPath,
            };

            if (from.WorkTaskPointProgress != null)
            {
                result.ExecutedPercent = from.WorkTaskPointProgress
                    .ExecutedPercent;
                result.PointState = from.WorkTaskPointProgress.PointState;
                result.PointSateDescripton = from.WorkTaskPointProgress
                    .PointSateDescripton;
            }

            return result;
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
