using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Result
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
