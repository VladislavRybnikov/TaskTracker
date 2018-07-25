using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Base
{
    internal class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext()
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<WorkTaskCategory> WorkTaskCategories { get; set; }
        public DbSet<WorkTaskDateInfo> WorkTaskDateInfos { get; set; }
        public DbSet<WorkTaskProgress> WorkTaskProgresses { get; set; }
        public DbSet<WorkTaskUser> WorkTaskUsers { get; set; }
    }
}
