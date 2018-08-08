using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;
using TaskTracker.Dto;
using TaskTracker.Mapping.Base;
using TaskTracker.Mapping.Helpers;
using TaskTracker.ViewModels.Json.Auth;

namespace TaskTracker.Mapping.ViewModel
{
    public class RegisterUserViewModelMapper
        : ILeftSideMapper<RegisterUserViewModel, WorkTaskUserDto>
    {

        public WorkTaskUserDto Map(RegisterUserViewModel from)
        {
            var result = new WorkTaskUserDto
            {
                Name = from.Name,
                FullName = from.FullName,
                Mail = from.Email,
            };

            result.Role = from.Role == "performer" 
                ? (int)WorkTaskUserRoles.TaskPerformer 
                : (int)WorkTaskUserRoles.TaskManager;

            return result;
        }

        public IEnumerable<WorkTaskUserDto> Map
            (IEnumerable<RegisterUserViewModel> from)
        {
            return MapperHelper.TransformRange(from, Map);
        }
    }
}
