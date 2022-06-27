using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Result
{
    public interface IResultModel
    {
        Guid ID
        {
            get;
        }

        bool Success
        {
            get;
            set;
        }

        string Message
        {
            get;
            set;
        }

        string ReturnValue
        {
            get;
            set;
        }

        Exception Exception
        {
            get;
            set;
        }

        List<IResultModel> InnerResults
        {
            get;
        }
    }
}
