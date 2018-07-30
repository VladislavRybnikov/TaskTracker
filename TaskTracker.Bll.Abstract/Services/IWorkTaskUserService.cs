using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Bll.Abstract.Services
{
    public interface IWorkTaskUserService
    {
        void CreateWorkTaskUserAsync();
        void GetWorkTaskUserAsync();
        void UpdateWorkTaskUserAsync();
        void DeleteWorkTaskUserAsync();
        void GetManagerWorkTasksCountAsync();
        void GetPerformerWorkTasksCountAsync();
    }
}
