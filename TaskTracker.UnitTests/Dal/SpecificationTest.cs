using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Dal.Impl.Ef.Specifications;

namespace TaskTracker.UnitTests.Dal
{
    public class SpecificationTest
    {
        private List<TestEntity> _testData = new List<TestEntity>
        {
            new TestEntity { Value = 1 },
            new TestEntity { Value = 0 },
            new TestEntity { Value = 2 }
        };

        private Specification<TestEntity> TestSpecification()
            => new Specification<TestEntity>(x => x.Value > 0);

        [Test]
        [Category("Dal tests")]
        public void SpecificationCriteriaTest()
        {
            var spec = TestSpecification();

            var resultData = _testData.AsQueryable().Where(spec.Criteria);

            Assert.IsNull(resultData.FirstOrDefault(x => x.Value == 0));
        }
    }

    #region Test Entity

    public class TestEntity
    {
        public int Value;
    } 
    #endregion
}
