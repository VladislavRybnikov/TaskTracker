using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Repositories
{
    public class WorkTaskPointRepository 
        : GenericRepository<WorkTaskPoint>, IWorkTaskPointRepository
    {
        public WorkTaskPointRepository(DbContext context) 
            : base(context) { }
    }
}
