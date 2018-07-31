using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Abstract.Services
{
    /// <summary>
    /// WorkTaskPoint Service.
    /// Has methods for working with work task's points.
    /// </summary>
    public interface IWorkTaskPointService
    {
        Task<Result> ChangePointProgressAsync
            (WorkTaskPointDto workTaskPointDto, 
            WorkTaskPointProgressDto workTaskPointProgressDto);
        Task<Result> CreateWorkTaskPointAsync(WorkTaskPointDto 
            workTaskPointDto);
    }
}
