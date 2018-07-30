using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Common.Results
{
    public class DataResult<TResultData> : Result
    {
        public TResultData Data { get; set; }

        public DataResult() : base(){ }

        public DataResult(bool success) : base(success) { }

        public DataResult(bool success, string message) 
            : base(success, message) { }
    }
}
