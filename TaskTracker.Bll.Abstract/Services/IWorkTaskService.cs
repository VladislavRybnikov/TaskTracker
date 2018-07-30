using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Abstract.Services
{
    public interface IWorkTaskService
    {
        void UpdateWorkTaskProgressAsync();
        void CreateWorkTaskAsync();
        Task<Result> ChangeDescriptionAsync
            (WorkTaskDto workTaskDto, string description);
        Task<Result> AddPerformerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto performer);
        void ChangeManagerAsync();
        void GetWorkTaskAsync();
        Task<DataResult<WorkTaskDto>> GetWorkTaskByNameAsync
            (string name, WorkTaskUserDto manager);
    }
}
