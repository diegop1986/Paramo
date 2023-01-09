using System;
using System.Net;

namespace Sat.Recruitment.Service.CustomException
{
    public abstract class BaseException: Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, Exception exception): base(message, exception) { }
    }
}
