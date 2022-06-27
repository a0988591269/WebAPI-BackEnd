using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Result
{
    public class ResultModel : IResultModel
    {
        public Guid ID
        {
            get;
            private set;
        }

        public bool Success
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string ReturnValue
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }

        public List<IResultModel> InnerResults
        {
            get;
            protected set;
        }

        public ResultModel()
            : this(false)
        {
        }

        public ResultModel(bool success)
        {
            ID = Guid.NewGuid();
            Success = success;
            InnerResults = new List<IResultModel>();
        }
    }
}
