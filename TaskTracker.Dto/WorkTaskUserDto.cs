using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Dto
{
    public class WorkTaskUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Info { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public string Specialization { get; set; }
        public string AvatarPath { get; set; }
    }
}
