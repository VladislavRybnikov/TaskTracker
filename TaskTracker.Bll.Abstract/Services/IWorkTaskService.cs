using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Bll.Abstract.Services
{
    public interface IWorkTaskService
    {
        void UpdateWorkTaskProgressAsync();
        void CreateWorkTaskAsync();
        void ChangeDescriptionAsync();
        void AddPerformerAsync();
        void ChangeManagerAsync();
        void GetWorkTaskPointCountAsync();
        void GetWorkTaskInfoForManagerAsync();
        void GetWorkTaskInfoForPerformerAsync();
    }
}
