using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results.Common
{
    public abstract class BaseResponse
    {
        public BaseResponse(string message, bool success):this(success)
        {
            Message = message;

            

        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
