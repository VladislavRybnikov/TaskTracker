using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;
using TaskTracker.Dto;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;
using TaskTracker.ViewModels.Json.User;

namespace TaskTracker.Mapping.ViewModel
{
    public class WorkTaskUserViewModelMapper
        : IMapper<WorkTaskUserDto, WorkTaskUserViewModel>
    {
        public WorkTaskUserViewModel Map(WorkTaskUserDto from)
        {
            return new WorkTaskUserViewModel
            {
                Id = from.Id,
                Name = from.Name,
                FullName = from.FullName,
                City = from.City,
                Country = from.Country,
                Info = from.Info,
                Mail = from.Mail,
                PhoneNumber = from.PhoneNumber,
                AvatarPath = from.AvatarPath,
                Role = from.Role
                == (int)WorkTaskUserRoles.TaskPerformer
                ? "performer"
                : "manager",
                Specialization = from.Specialization
            };
        }

        public IEnumerable<WorkTaskUserViewModel> Map(IEnumerable<WorkTaskUserDto> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }

        public WorkTaskUserDto Map(WorkTaskUserViewModel from)
        {
            return new WorkTaskUserDto
            {
                Id = from.Id,
                Name = from.Name,
                FullName = from.FullName,
                AvatarPath = from.AvatarPath,
                City = from.City,
                Country = from.Country,
                Info = from.Info,
                Mail = from.Mail,
                PhoneNumber = from.PhoneNumber,
                Role = from.Role
                == "performer"
                ? (int)WorkTaskUserRoles.TaskPerformer
                : (int)WorkTaskUserRoles.TaskManager,
                Specialization = from.Specialization
            };
        }

        public IEnumerable<WorkTaskUserDto> Map(IEnumerable<WorkTaskUserViewModel> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
