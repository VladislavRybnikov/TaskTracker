using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;

namespace TaskTracker.Mapping.Dto
{
    public class WorkTaskDtoMapper : IMapper<WorkTask, WorkTaskDto>
    {
        public WorkTask Map(WorkTaskDto from)
        {
            return new WorkTask
            {
                Name = from.Name,
                Description = from.Description,
                Category = new WorkTaskCategory { Name = from.CategoryName },
                DateInfo = new WorkTaskDateInfo
                {
                    CreationDate = from.CreationDate,
                    Deadline = from.Deadline
                },
                Progress = new WorkTaskProgress
                {
                    WorkTaskState = from.WorkTaskState,
                    ExecutedPercent = from.ExecutedPercent
                }

            };
        }

        public WorkTaskDto Map(WorkTask from)
        {
            var result = new WorkTaskDto
            {
                Name = from.Name,
                Description = from.Description
            };

            if (from.Category != null)
            {
                result.CategoryName = from.Category.Name;
            }

            if (from.DateInfo != null)
            {
                result.Deadline = from.DateInfo.Deadline;
                result.CreationDate = from.DateInfo.CreationDate;
            }

            if (from.Progress != null)
            {
                result.ExecutedPercent = from.Progress.ExecutedPercent;
                result.WorkTaskState = from.Progress.WorkTaskState;
            }

            return result;
        }

        public IEnumerable<WorkTask> Map(IEnumerable<WorkTaskDto> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }

        public IEnumerable<WorkTaskDto> Map(IEnumerable<WorkTask> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
