using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTracker.Dal.Abstract.Base;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; }
        public List<string> IncludeStrings { get; }

        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<T, object>>>();
            IncludeStrings = new List<string>();
        }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

    }
}
