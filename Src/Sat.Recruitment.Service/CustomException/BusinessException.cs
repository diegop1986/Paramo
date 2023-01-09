using System;
using System.Net;

namespace Sat.Recruitment.Service.CustomException
{
    public abstract class BusinessException: BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, Exception exception) : base(message, exception) { }
    }
}
