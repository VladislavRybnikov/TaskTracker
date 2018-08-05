using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Common.Enums;
using TaskTracker.Common.Results;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;

namespace TaskTracker.Bll.Impl.Services
{
    /// <summary>
    /// Service that provides access to WorkTask's data.
    /// CRUD operations. 
    /// </summary>
    public class WorkTaskService : IWorkTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<WorkTaskUser, WorkTaskUserDto>
            _workTaskUserDtoMapper;
        private readonly IMapper<WorkTask, WorkTaskDto> _workTaskDtoMapper;
        private readonly IMapper<WorkTaskPoint, WorkTaskPointDto> 
            _workTaskPointDtoMapper;
        

        public WorkTaskService
            (
            IUnitOfWork unitOfWork, 
            IMapper<WorkTaskUser, WorkTaskUserDto> workTaskUserDtoMapper, 
            IMapper<WorkTask, WorkTaskDto> workTaskDtoMapper,
            IMapper<WorkTaskPoint, WorkTaskPointDto> workTaskPointDtoMapper
            )
        {
            _unitOfWork = unitOfWork;
            _workTaskUserDtoMapper = workTaskUserDtoMapper;
            _workTaskPointDtoMapper = workTaskPointDtoMapper;
            _workTaskDtoMapper = workTaskDtoMapper;
        }

        /// <summary>
        /// Add performer to the task.
        /// </summary>
        /// <param name="workTaskDto">WorkTask</param>
        /// <param name="performer"> Performer</param>
        /// <returns>Return Result of adding performer.</returns>
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

        /// <summary>
        /// Add WorkTaskPoint to the WorkTask.
        /// </summary>
        /// <param name="workTaskDto"> WorkTask information</param>
        /// <param name="workTaskPointDto"> WorkTaskPoint information</param>
        /// <returns></returns>
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

        /// <summary>
        /// Change WorkTask Description.
        /// </summary>
        /// <param name="workTaskDto"> WorkTask information</param>
        /// <param name="description"> Description</param>
        /// <returns></returns>
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

        /// <summary>
        /// Change manager of the task.
        /// </summary>
        /// <param name="workTaskDto"> WorkTask information</param>
        /// <param name="manager">Manager information</param>
        /// <returns></returns>
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

        /// <summary>
        /// Create WorkTask.
        /// </summary>
        /// <param name="workTaskDto">WorkTask information</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete WorkTask by WorkTaskManager.
        /// </summary>
        /// <param name="workTaskDto"> WorkTask information</param>
        /// <param name="workTaskUserDto"> WorkTaskUser information</param>
        /// <returns></returns>
        public async Task<Result> DeleteWorkTaskAsync(WorkTaskDto workTaskDto,
            WorkTaskUserDto workTaskUserDto)
        {
            var result = new Result();

            var findedUser = await _unitOfWork
                .WorkTaskUserRepository.FindByMailAsync(workTaskUserDto.Mail);

            var findedTask = await _unitOfWork.WorkTaskRepository
                .FirstAsync(new Specification<WorkTask>(x => x.Name 
                == "dtoName"));

            if(findedUser.Role != (int)WorkTaskUserRoles.TaskManager)
            {
                result.Message = $"User: {findedUser.Name} " +
                    $"- is not a manager.";
                return result;
            }

            var managedTasks = await _unitOfWork.WorkTaskRepository
                   .GetAllTasksByManagerIdAsync(findedUser.Id);

            bool isManagerOfCurrentTask = managedTasks
                .FirstOrDefault(x => x.Id == findedTask.Id) != null;

            if (isManagerOfCurrentTask)
            {
                _unitOfWork.WorkTaskRepository.Delete(findedTask);
                await _unitOfWork.SaveChangesAsync();

                result.Message = $"Work task: {findedTask.Name}, " +
                    $"deleted by user: {findedUser.Name}";
                result.Success = true;
            }
            else
            {
                result.Message = result.Message = $"User: {findedUser.Name} " +
                    $"- is not a manager of work task: {findedTask.Name}.";
            }

            return result;
        }

        /// <summary>
        /// Get WorkTaskiInformation.
        /// </summary>
        /// <param name="name"> WorkTask name </param>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<DataResult<WorkTaskDto>> GetWorkTaskAsync
            (string name)
        {
            DataResult<WorkTaskDto> methodResult 
                = new DataResult<WorkTaskDto>();

            WorkTask workTask = await _unitOfWork.WorkTaskRepository
                .FirstAsync(new Specification<WorkTask>(x => x.Name == name));

            if (workTask != null)
            {
                methodResult.Data = _workTaskDtoMapper.Map(workTask);
                methodResult.Success = true;

                methodResult.Message = $"WorkTask: ({name})";
            }
            else
            {
                methodResult.Message = $"Not Found.";
            }

            return methodResult;
        }

    }
}
