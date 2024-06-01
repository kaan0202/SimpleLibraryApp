using Domain.Results.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
    public class SuccessDataResponse<T> : BaseDataResponse<T> where T : class,new()
    {
        public SuccessDataResponse(T data, string message) : base(data, message, true)
        {
        }

        public SuccessDataResponse(T data,int? totalCount):base(data,true,totalCount)
        {
        }
        public SuccessDataResponse(T data) : base(data, true)
        {
        }
    }
}
