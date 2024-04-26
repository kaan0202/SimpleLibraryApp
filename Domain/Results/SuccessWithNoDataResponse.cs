using Domain.Results.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
    public class SuccessWithNoDataResponse : BaseResponse
    {
        public SuccessWithNoDataResponse(string message) : base(message, true)
        {
        }
        public SuccessWithNoDataResponse():base(true)
        {
            
        }
    }
}
