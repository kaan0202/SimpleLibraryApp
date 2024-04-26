using Domain.Results.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
    public class ErrorDataResponse<T> : BaseDataResponse<T> where T : class, new()
    {
        public ErrorDataResponse( string message) : base(default, message, false)
        {
        }
        public ErrorDataResponse():base(default,false)
        {
        }
    }
}
