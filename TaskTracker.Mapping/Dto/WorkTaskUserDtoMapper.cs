using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;
using TaskTracker.ViewModels;

namespace TaskTracker.Mapping.Dto
{
    public class WorkTaskUserDtoMapper
        : IMapper<WorkTaskUser, WorkTaskUserDto>
    {
        public WorkTaskUser Map(WorkTaskUserDto from)
        {
            return new WorkTaskUser
            {
                Name = from.Name,
                FullName = from.FullName,
                Info = from.Info,
                AvatarPath = from.AvatarPath,
                Role = (byte)from.Role,
                Specialization = from.Specialization,
                UserContacts = new UserContacts
                {
                    Mail = from.Mail,
                    PhoneNumber = from.PhoneNumber,
                    Location = new Location
                    {
                        Country = from.Country,
                        City = from.City
                    }
                }
            };
        }

        public WorkTaskUserDto Map(WorkTaskUser from)
        {
            return new WorkTaskUserDto
            {
                Name = from.Name,
                FullName = from.FullName,
                Info = from.Info,
                AvatarPath = from.AvatarPath,
                Role = from.Role,
                Specialization = from.Specialization,
                Mail = from.UserContacts.Mail,
                PhoneNumber = from.UserContacts.PhoneNumber,
                City = from.UserContacts.Location.City,
                Country = from.UserContacts.Location.Country
            };
        }

        public IEnumerable<WorkTaskUser> Map(IEnumerable<WorkTaskUserDto> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }

        public IEnumerable<WorkTaskUserDto> Map(IEnumerable<WorkTaskUser> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
