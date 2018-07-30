using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Common.Results;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;

namespace TaskTracker.Bll.Impl.Services
{
    public class WorkTaskService : IWorkTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<WorkTaskUser, WorkTaskUserDto>
            _workTaskUserDtoMapper;
        private readonly IMapper<WorkTask, WorkTaskDto> _workTaskDtoMapper;
        

        public WorkTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddPerformerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto performer)
        {
            Result methodResult = new Result(); 

            var userEntity = _workTaskUserDtoMapper.Map(performer);
            var taskEntity = _workTaskDtoMapper.Map(workTaskDto);

            var findedTask = await _unitOfWork.WorkTaskRepository
                .FirstAsync(new Specification<WorkTask>(x 
                => x.Name == taskEntity.Name 
                && x.DateInfo.CreationDate == taskEntity.DateInfo.CreationDate 
                && x.Manager.UserContacts.Mail 
                == taskEntity.Manager.UserContacts.Mail));

            if (findedTask != null)
            {

                var findedUser = await _unitOfWork.WorkTaskUserRepository
                    .FirstAsync(new Specification<WorkTaskUser>(x => x.UserContacts.Mail
                    == userEntity.UserContacts.Mail));

                bool ifUserExist = findedUser != null;

                if (ifUserExist)
                {
                    findedUser.WorkTasks.Add(findedTask);
                    findedTask.Performers.Add(findedUser);

                    _unitOfWork.WorkTaskUserRepository.Update(findedUser);
                    _unitOfWork.WorkTaskRepository.Update(findedTask);
                }
                else
                {
                    userEntity.WorkTasks.Add(findedTask);
                    findedTask.Performers.Add(userEntity);

                    _unitOfWork.WorkTaskUserRepository.Add(userEntity);
                    _unitOfWork.WorkTaskRepository.Update(findedTask);
                    
                }
                methodResult.Success = true;
                methodResult.Message = $"Added performer: {userEntity.Name}" +
                    $" to Task: {taskEntity.Name}.";
            }
            else
            {
                methodResult.Message = "Task not found.";
            }

            return methodResult;
        }

        public async Task<Result> ChangeDescriptionAsync
            (WorkTaskDto workTaskDto, string description)
        {
            Result methodResult = new Result();

            var taskEntity = _workTaskDtoMapper.Map(workTaskDto);

            var findedTask = await _unitOfWork.WorkTaskRepository
               .FirstAsync(new Specification<WorkTask>(x
               => x.Name == taskEntity.Name
               && x.DateInfo.CreationDate == taskEntity.DateInfo.CreationDate
               && x.Manager.UserContacts.Mail
               == taskEntity.Manager.UserContacts.Mail));

            if (findedTask != null)
            {
                findedTask.Description = description;

                _unitOfWork.WorkTaskRepository.Update(findedTask);

                methodResult.Success = true;
                methodResult.Message = $"Description updated " +
                    $"in Task({findedTask.Name})";
            }
            else
            {
                methodResult.Message = "Task not fount.";
            }

            return methodResult;
        }

        public void ChangeManagerAsync()
        {
            throw new NotImplementedException();
        }

        public void CreateWorkTaskAsync()
        {
            throw new NotImplementedException();
        }

        public void GetWorkTaskAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<WorkTaskDto>> GetWorkTaskByNameAsync
            (string name, WorkTaskUserDto manager)
        {
            DataResult<WorkTaskDto> methodResult 
                = new DataResult<WorkTaskDto>();

            WorkTask workTask = await _unitOfWork.WorkTaskRepository
                .FirstAsync(new Specification<WorkTask>(x => x.Name == name
                && x.Manager.UserContacts.Mail == manager.Mail));

            if (workTask != null)
            {
                methodResult.Data = _workTaskDtoMapper.Map(workTask);
                methodResult.Success = true;
            }
            else
            {
                methodResult.Message = $"WorkTask: ({name})";
            }

            return methodResult;
        }
        
        public void UpdateWorkTaskProgressAsync()
        {
            throw new NotImplementedException();
        }
    }
}
