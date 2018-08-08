using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Base
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext() : base("name=TaskTrackerDb")
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<WorkTaskCategory> WorkTaskCategories { get; set; }
        public DbSet<WorkTaskDateInfo> WorkTaskDateInfos { get; set; }
        public DbSet<WorkTaskProgress> WorkTaskProgresses { get; set; }
        public DbSet<WorkTaskUser> WorkTaskUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkTaskUser>()
                .HasMany(u => u.WorkTasks)
                .WithMany(t => t.WorkTaskUsers)
                .Map(ut =>
                {
                    ut.MapLeftKey("WorkTaskUserRefId");
                    ut.MapRightKey("WorkTaskRefId");
                    ut.ToTable("WorkTaskUser_WorkTask");
                });
        }
    }
}
