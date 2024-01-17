using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;


namespace TABP.API.Logging
{
    public class RequestResponseLoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<RequestResponseLoggingFilter> _logger;

        public RequestResponseLoggingFilter(ILogger<RequestResponseLoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = await FormatRequest(context.HttpContext.Request);
            _logger.LogInformation($"Request: {request}");

            var originalBodyStream = context.HttpContext.Response.Body;

            using var responseBody = new MemoryStream();
            context.HttpContext.Response.Body = responseBody;

            await next();

            await LogResponse(context.HttpContext.Response, responseBody);

            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
            context.HttpContext.Response.Body = originalBodyStream;
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = await new StreamReader(request.Body, Encoding.UTF8, true, 1024, true).ReadToEndAsync();
            request.Body.Position = 0;

            return $"{request.Method} {request.Path} {request.QueryString} Body: {body}";
        }

        private async Task LogResponse(HttpResponse response, MemoryStream responseBody)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var body = await new StreamReader(responseBody, Encoding.UTF8, true, 1024, true).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation($"Response: Status: {response.StatusCode} Body: {body}");
        }
    }


}
