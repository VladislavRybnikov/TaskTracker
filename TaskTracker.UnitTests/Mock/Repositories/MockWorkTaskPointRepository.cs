using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock.Repositories
{
    public class MockWorkTaskPointRepository
         : MockGenericRepository<WorkTaskPoint>,
        IWorkTaskPointRepository
    {
        public MockWorkTaskPointRepository(MockData mockData) : base(mockData)
        {
        }
    }
}
