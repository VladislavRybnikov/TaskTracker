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
        private readonly IMapper<WorkTaskPoint, WorkTaskPointDto> 
            _workTaskPointDtoMapper;
        

        public WorkTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddPerformerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto performer)
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
                var userEntity = _workTaskUserDtoMapper.Map(performer);

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

                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                methodResult.Message = "Task not found.";
            }

            return methodResult;
        }

        public async Task<Result> AddWorkTaskPoint(WorkTaskDto workTaskDto,
            WorkTaskPointDto workTaskPointDto)
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
                var pointEntity = _workTaskPointDtoMapper.Map(workTaskPointDto);

                var findedTaskPoint = await _unitOfWork.WorkTaskPointRepository
                    .FirstAsync(new Specification<WorkTaskPoint>
                    (x => x.Name == pointEntity.Name
                    && x.Description == pointEntity.Description));

                if (findedTask != null)
                {
                    findedTask.WorkTaskPoints.Add(pointEntity);

                    _unitOfWork.WorkTaskRepository.Update(findedTask);
                }
                else
                {
                    _unitOfWork.WorkTaskPointRepository.Add(pointEntity);
                }

                await _unitOfWork.SaveChangesAsync();
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

                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                methodResult.Message = "Task not fount.";
            }

            return methodResult;
        }

        public async Task<Result> ChangeManagerAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto manager)
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
                var userEntity = _workTaskUserDtoMapper.Map(manager);

                var findedUser = await _unitOfWork.WorkTaskUserRepository
                    .FirstAsync(new Specification<WorkTaskUser>(x => x.UserContacts.Mail
                    == userEntity.UserContacts.Mail));

                bool ifUserExist = findedUser != null;

                if (ifUserExist)
                {
                    findedUser.WorkTasks.Add(findedTask);
                    findedTask.Manager = findedUser;

                    _unitOfWork.WorkTaskUserRepository.Update(findedUser);
                    _unitOfWork.WorkTaskRepository.Update(findedTask);
                }
                else
                {
                    userEntity.WorkTasks.Add(findedTask);
                    findedTask.Manager = userEntity;

                    _unitOfWork.WorkTaskUserRepository.Add(userEntity);
                    _unitOfWork.WorkTaskRepository.Update(findedTask);

                }
                methodResult.Success = true;
                methodResult.Message = $"Added manager: {userEntity.Name}" +
                    $" to Task: {taskEntity.Name}.";

                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                methodResult.Message = "Task not found.";
            }

            return methodResult;
        }

        public async Task<Result> CreateWorkTaskAsync(WorkTaskDto workTaskDto)
        {
            Result methodResult = new Result();

            var taskEntity = _workTaskDtoMapper.Map(workTaskDto);

            await Task.Run(() =>
            {
                try
                {
                    _unitOfWork.WorkTaskRepository.Add(taskEntity);
                }
                catch (Exception ex)
                {
                    methodResult.Success = false;
                    methodResult.Message = ex.Message;
                }
            });

            await _unitOfWork.SaveChangesAsync();

            return methodResult;
        }
        
        public async Task<DataResult<WorkTaskDto>> GetWorkTaskAsync
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

            await _unitOfWork.SaveChangesAsync();

            return methodResult;
        }
        
        public Task<Result> UpdateWorkTaskProgressAsync(WorkTaskDto workTaskDto, 
            WorkTaskProgressDto progressDto)
        {
            throw new NotImplementedException();
        }
    }
}
