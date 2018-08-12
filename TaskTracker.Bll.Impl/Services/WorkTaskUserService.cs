using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Bll.Impl.Services.Base;
using TaskTracker.Common.Results;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;

namespace TaskTracker.Bll.Impl.Services
{
    public class WorkTaskUserService : UnitOfWorkBasedService, 
        IWorkTaskUserService
    {
        private readonly IMapper<WorkTaskUser, WorkTaskUserDto> _userMapper;

        public WorkTaskUserService
            (
            IUnitOfWork unitOfWork, 
            IMapper<WorkTaskUser, WorkTaskUserDto> userMapper
            ) : base(unitOfWork)
        {
            _userMapper = userMapper;
        }

        public async Task<Result> CreateWorkTaskUserAsync
            (WorkTaskUserDto workTaskUserDto)
        {
            var result = new Result();
            
            var workTaskUserEntity = _userMapper.Map(workTaskUserDto);

            if (workTaskUserDto.Name == string.Empty ||
                workTaskUserDto.Mail == string.Empty)
            {
                result.Message = "Can'nt create user. Mail or name are wrong.";
                return result;
            }

            _unitOfWork.WorkTaskUserRepository.Add(workTaskUserEntity);
            await _unitOfWork.SaveChangesAsync();

            result.Message = $"Created user (Name: {workTaskUserDto.Name}," +
                $" Mail: {workTaskUserDto.Mail}).";
            result.Success = true;

            return result;
        }

        public async Task<Result> DeleteWorkTaskUserAsync
            (WorkTaskUserDto workTaskUserDto)
        {
            var result = new Result();

            var findedUser = await _unitOfWork.WorkTaskUserRepository
                .GetByMailAsync(workTaskUserDto.Mail);

            if (findedUser == null)
            {
                result.Message = "User not found";
                return result;
            }

            _unitOfWork.WorkTaskUserRepository.Delete(findedUser);
            await _unitOfWork.SaveChangesAsync();

            result.Success = true;
            result.Message = $"User({workTaskUserDto.Name}) created.";

            return result;
        }

        public async Task<DataResult<WorkTaskUserDto>> 
            GetWorkTaskUserByIdAsync(int id)
        {
            var result = new DataResult<WorkTaskUserDto>();

            var findedUser = await _unitOfWork.WorkTaskUserRepository
                .GetWithContactsAsync(id);

            if (findedUser == null)
            {
                result.Message = "User not found.";
                return result;
            }

            var mappedUserDto = _userMapper.Map(findedUser);

            result.Data = mappedUserDto;
            result.Message = "Success.";
            result.Success = true;

            return result;
        }

        public async Task<DataResult<WorkTaskUserDto>> 
            GetWorkTaskUserByMailAsync(string mail)
        {
            var result = new DataResult<WorkTaskUserDto>();

            var findedUser = await _unitOfWork.WorkTaskUserRepository
                .GetByMailAsync(mail);

            if (findedUser == null)
            {
                result.Message = "User not found.";
                return result;
            }

            var mappedUserDto = _userMapper.Map(findedUser);

            result.Data = mappedUserDto;
            result.Message = "Success.";
            result.Success = true;

            return result;
        }

        public async Task<DataResult<WorkTaskUserDto>> GetWorkTaskUserByNameAsync(string name)
        {
            var result = new DataResult<WorkTaskUserDto>();

            var findedUser = await _unitOfWork.WorkTaskUserRepository
                .GetByNameAsync(name);

            if (findedUser == null)
            {
                result.Message = "User not found.";
                return result;
            }

            var mappedUserDto = _userMapper.Map(findedUser);

            result.Data = mappedUserDto;
            result.Message = "Success.";
            result.Success = true;

            return result;
        }

        public async Task<Result> UpdateWorkTaskUserAsync
            (WorkTaskUserDto workTaskUserDto)
        {
            var result = new Result();

            var findedUser = await _unitOfWork.WorkTaskUserRepository
                .GetByMailAsync(workTaskUserDto.Mail);

            if (findedUser == null)
            {
                result.Message = "User not found";
                return result;
            }

            var mappedUser = _userMapper.Map(workTaskUserDto);
            mappedUser.Id = findedUser.Id;

            _unitOfWork.WorkTaskUserRepository.Update(findedUser);
            await _unitOfWork.SaveChangesAsync();

            result.Success = true;
            result.Message = $"User({workTaskUserDto.Name}) created.";

            return result;
        }
    }
}
