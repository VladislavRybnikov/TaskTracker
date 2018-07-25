using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTracker.Dal.Abstract.Base;

namespace TaskTracker.Dal.Impl.Ef.Base
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }

        public List<string> IncludeStrings { get; }
    }
}
