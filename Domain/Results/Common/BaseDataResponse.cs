using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results.Common
{
    public class BaseDataResponse<T> : BaseResponse where T : class, new()
    {
        public BaseDataResponse(T data,string message, bool success) : base(message, success)
        {
            Data = data;
        }
        public BaseDataResponse(T data,bool success, int? totalCount) : base(success)
        {
            Data = data;
            TotalCount = totalCount;

        }
        public BaseDataResponse(T data, bool success) : base(success)
        {
            Data = data;
          

        }

        public T Data { get; }
        public int? TotalCount { get; }
    }
}
