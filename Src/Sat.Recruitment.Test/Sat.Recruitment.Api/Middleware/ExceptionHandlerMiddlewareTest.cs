using Xunit;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sat.Recruitment.Service.Dto;
using System.Security.Authentication;
using Sat.Recruitment.Api.Middleware;
using System.ComponentModel.DataAnnotations;
using Sat.Recruitment.Service.CustomException;

namespace Sat.Recruitment.Test.Sat.Recruitment.Api.Middleware
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class ExceptionHandlerMiddlewareTest
    {
        [Fact]
        public async Task ServerErrorTest()
        {
            var exception = new Exception("Server Error");
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
        }

        [Fact]
        public async Task NotImplementedTest()
        {
            var exception = new NotImplementedException();
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)HttpStatusCode.NotImplemented, context.Response.StatusCode);
        }

        [Fact]
        public async Task AuthenticationTest()
        {
            var exception = new AuthenticationException();
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)HttpStatusCode.Forbidden, context.Response.StatusCode);
        }

        [Fact]
        public async Task FormatTest()
        {
            var exception = new FormatException();
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
        }

        [Fact]
        public async Task ValidationTest()
        {
            var exception = new ValidationException();
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
        }

        [Fact]
        public async Task UserDuplicatedTest()
        {
            var exception = new UserDuplicatedException();
            var ExpectedResult = JsonConvert.SerializeObject(new ResultErrorDto
            {
                IsSuccess = false,
                Errors = exception.Message
            });

            var middleware = new ExceptionHandlerMiddleware(
                next: async (innerHttpContext) =>
                {
                    await Task.Factory.StartNew(() => throw exception);
                }
            );

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.Equal(ExpectedResult, body);
            Assert.Equal((int)exception.StatusCode, context.Response.StatusCode);
        }
    }
}
