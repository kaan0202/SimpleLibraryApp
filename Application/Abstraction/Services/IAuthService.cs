﻿using Application.Abstraction.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IAuthService:IInternalAuthentication,IExternalAuthentication
    {
    }
}
