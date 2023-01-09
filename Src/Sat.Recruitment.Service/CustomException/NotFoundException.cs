using System;
using System.Net;

namespace Sat.Recruitment.Service.CustomException
{
    public abstract class NotFoundException: BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception exception) : base(message, exception) { }
    }
}
