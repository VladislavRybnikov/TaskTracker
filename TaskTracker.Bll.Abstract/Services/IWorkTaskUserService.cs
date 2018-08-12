using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Abstract.Services
{
    /// <summary>
    /// Service for users CRUD.
    /// </summary>
    public interface IWorkTaskUserService
    {
        Task<Result> CreateWorkTaskUserAsync(WorkTaskUserDto
            workTaskUserDto);
        Task<Result> UpdateWorkTaskUserAsync(WorkTaskUserDto 
            workTaskUserDto);
        Task<Result> DeleteWorkTaskUserAsync(WorkTaskUserDto 
            workTaskUserDto);
        Task<DataResult<WorkTaskUserDto>> GetWorkTaskUserByMailAsync
            (string mail);
        Task<DataResult<WorkTaskUserDto>> GetWorkTaskUserByNameAsync
            (string name);
        Task<DataResult<WorkTaskUserDto>> GetWorkTaskUserByIdAsync(int id);
        
    }
}
