using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Common.Results
{
    public class Result
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result(bool success)
        {
            Success = success;
        }

        public Result() : this(false){}

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
