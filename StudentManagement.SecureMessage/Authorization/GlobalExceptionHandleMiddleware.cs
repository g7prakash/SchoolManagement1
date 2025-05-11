
using StudentManagement.DataAccess.Helpers;
using System.Net;

namespace StudentManagement.SecureMessage.Authorization
{
    public class GlobalExceptionHandleMiddleware
    {
        private readonly ILogger<GlobalExceptionHandleMiddleware> _logger;
        private readonly RequestDelegate _next;
        public GlobalExceptionHandleMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandleMiddleware> logger) { 
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                //handle exception
                switch (ex)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                        
                }
            }
        }
    }
}
