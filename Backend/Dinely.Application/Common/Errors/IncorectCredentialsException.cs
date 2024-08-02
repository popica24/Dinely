using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dinely.Application.Common.Errors
{
    public class IncorectCredentialsException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public string ErrorMessage => "Email or password incorrect";
    }
}