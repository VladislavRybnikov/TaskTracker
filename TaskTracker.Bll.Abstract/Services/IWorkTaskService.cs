using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Abstract.Services
{
    /// <summary>
    /// Main service for WorkTasks. 
    /// </summary>
    public interface IWorkTaskService
    {
        Task<Result> CreateWorkTaskAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto manager);
        Task<Result> ChangeDescriptionAsync
            (WorkTaskDto workTaskDto, string description);
        Task<Result> AddPerformerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto performer);
        Task<Result> ChangeManagerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto manager);
        Task<DataResult<WorkTaskDto>> GetWorkTaskByNameAsync
            (string name);
        Task<Result> AddWorkTaskPointAsync(WorkTaskDto workTaskDto,
            WorkTaskPointDto workTaskPointDto);
        Task<Result> DeleteWorkTaskAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto workTaskUserDto);
        Task<Result> UpdateWorkTaskAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto manager);
        Task<DataResult<IEnumerable<WorkTaskDto>>> GetByManagerName
            (string name);
        Task<DataResult<IEnumerable<WorkTaskDto>>> GetByPerformerName
            (string name);
        Task<DataResult<WorkTaskDto>> GetWorkTaskByIdAsync(int id);
    }
}
