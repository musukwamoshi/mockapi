using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Truestory.Mock.API.Exceptions
{

    public class MockAPIExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<MockAPIExceptionHandler> _logger;

        public MockAPIExceptionHandler(ILogger<MockAPIExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            if (exception is BadHttpRequestException)
            {
                // Handle specific exceptions
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new { error = "Invalid request" }, cancellationToken);
                return true; // Signal that the exception is handled
            }

            // Handle other exceptions (e.g., Internal Server Error)
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "Internal server error" }, cancellationToken);
            return true; // Or false to let the default handler handle it
        }
    }
}
