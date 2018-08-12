using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Bll.Impl.Services;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Dto;
using TaskTracker.UnitTests.Mock;
using System.Linq;
using TaskTracker.Mapping.Base;

namespace TaskTracker.UnitTests.Bll.Services
{
    public class WorkTaskServiceTest
    {
        #region Mock Objects

        private readonly MockData _mockData = new MockData();
        private readonly IMapper<WorkTask, WorkTaskDto> _workTaskMapper
            = new WorkTaskDtoMapper();
        private readonly IMapper<WorkTaskUser, WorkTaskUserDto> 
            _workTaskUserMapper = new WorkTaskUserDtoMapper();
        private readonly IMapper<WorkTaskPoint, WorkTaskPointDto>
            _workTaskPoinMapper = new WorkTaskPointDtoMapper();

        public IWorkTaskService MockWorkTaskService
            => new WorkTaskService
            (
                new MockUnitOfWork(_mockData),
                _workTaskUserMapper,
                _workTaskMapper,
                _workTaskPoinMapper
            );

        #endregion

        #region Testing Data
        public WorkTaskDto TestWorkTaskDto => _workTaskMapper
            .Map(_mockData.Find<WorkTask>(1));
        public WorkTaskUserDto TestManager => 
            _workTaskUserMapper.Map(_mockData
                .Get<WorkTaskUser>().First(x => x.Role == 2));
        public WorkTaskUserDto TestPerformer =>
            _workTaskUserMapper.Map(_mockData
                .Get<WorkTaskUser>().First(x => x.Role == 1));
        public WorkTaskPointDto TestWorkTaskPoint = new WorkTaskPointDto
        {
            Name = "test",
            AttachmentPath = "test.test",
            Description = "testtest",
            ExecutedPercent = 0,
            PointSateDescripton = "teststate",
            PointState = 1
        };
        #endregion

        [TestCase("QwertyTask")]
        [Category("Services")]
        public void GetWorkTaskMustReturnWorkTaskWithSuccessResult(string name)
        {
            var service = MockWorkTaskService;

            var workTaskResult = service.GetWorkTaskByNameAsync(name).Result;

            TestContext.Out.WriteLine(workTaskResult.Message);
            Assert.True(workTaskResult.Success);
        }

        [Test]
        [Category("Services")]
        public void ChangeDescriptionResultMustReturnTrue()
        {
            var service = MockWorkTaskService;

            var result = service
                .ChangeDescriptionAsync(new WorkTaskDto
                { Name = "QwertyTask" }, "TEST").Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.True(result.Success);
        }

        [Test]
        [Category("Services")]
        public void AddPerformerResultSuccessReturnTrue()
        {
            var service = MockWorkTaskService;
            var performer = TestPerformer;
            var workTask = TestWorkTaskDto;

            var result = service.AddPerformerAsync(workTask, performer).Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.True(result.Success);
        }

        [Test]
        [Category("Services")]
        public void ChangeManagerResultSuccessReturnTrue()
        {
            var service = MockWorkTaskService;
            var manager = TestManager;
            var workTask = TestWorkTaskDto;

            var result = service.ChangeManagerAsync(workTask, manager).Result;

            TestContext.Out.WriteLine();
            Assert.True(result.Success);
        }

        [Test]
        [Category("Services")]
        public void CreateWorkTaskResultSuccessReturnTrue()
        {
            var service = MockWorkTaskService;
            var manager = TestManager;
            var workTask = TestWorkTaskDto;
            workTask.Name = "TEST";

            var result = service.CreateWorkTaskAsync(workTask, manager).Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.True(result.Success);
        }

        [Test]
        [Category("Services")]
        public void CreateWorkTaskResultSuccessReturnFalseWhenWorkTaskExist()
        {
            var service = MockWorkTaskService;
            var manager = TestManager;
            var workTask = TestWorkTaskDto;

            var result = service.CreateWorkTaskAsync(workTask, manager).Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.False(result.Success);
        }

        [Test]
        [Category("Services")]
        public void DeleteWorkTaskResultSuccessReturnTrue()
        {
            var service = MockWorkTaskService;
            var manager = TestManager;
            var workTask = TestWorkTaskDto;

            var result = service.DeleteWorkTaskAsync(workTask, manager).Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.True(result.Success);
        }
        [Test]
        [Category("Services")]
        public void DeleteWorkTaskResultSuccessReturnFalseWhenUserIsPerformer()
        {
            var service = MockWorkTaskService;
            var manager = TestPerformer;
            var workTask = TestWorkTaskDto;

            var result = service.DeleteWorkTaskAsync(workTask, manager).Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.False(result.Success);
        }

        [Test]
        [Category("Services")]
        public void AddWorkTaskPointResultSuccessReturnTrue()
        {
            var service = MockWorkTaskService;
            var workTaskPoint = TestWorkTaskPoint;
            var workTask = TestWorkTaskDto;

            var result = service.AddWorkTaskPointAsync(workTask, workTaskPoint)
                .Result;

            TestContext.Out.WriteLine(result.Message);
            Assert.True(result.Success);
        }

    }
}
