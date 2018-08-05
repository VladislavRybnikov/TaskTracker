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

namespace TaskTracker.UnitTests.Bll.Services
{
    public class WorkTaskServiceTest
    {
        public IWorkTaskService MockWorkTaskService
            => new WorkTaskService
            (
                new MockUnitOfWork(),
                new WorkTaskUserDtoMapper(),
                new WorkTaskDtoMapper(),
                new WorkTaskPointDtoMapper()
            ); 

        [TestCase("QwertyTask")]
        [Category("Services")]
        public void GetWorkTaskMustReturnWorkTask(string name)
        {
            var service = MockWorkTaskService;

            var workTaskResult = service.GetWorkTaskAsync(name).Result;

            TestContext.Out.WriteLine(workTaskResult.Message);
            Assert.True(workTaskResult.Success);
        }
    }
}
