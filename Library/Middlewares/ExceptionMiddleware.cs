using Library.Domain.DTO.Error;
using System.Net;

namespace Library.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (AccessViolationException avEx)
			{
				ErrorLog($"A new violation exception has been thrown: {avEx}");
				await HandleExceptionAsync(httpContext, avEx);
			}
			catch (Exception ex)
			{
				ErrorLog($"Something went wrong: {ex}");
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var message = exception switch
			{
				AccessViolationException =>  "Access violation error from the custom middleware",
				_ => "Internal Server Error from the custom middleware."
			};

			await context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = message
			}.ToString());
		}

		private void ErrorLog(string message)
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"{message}");
			Console.ResetColor();
		}
	}

}
