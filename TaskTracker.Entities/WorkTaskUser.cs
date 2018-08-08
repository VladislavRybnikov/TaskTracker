using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTaskUser : BaseUser
    {
        public WorkTaskUser()
        {
            WorkTasks = new HashSet<WorkTask>();
        }

        public UserContacts UserContacts { get; set; }
        public byte Role { get; set; }
        public string Specialization { get; set; }
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
        public string AvatarPath { get; set; }
    }
}
