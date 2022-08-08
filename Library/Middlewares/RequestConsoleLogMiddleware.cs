using Microsoft.AspNetCore.Http.Extensions;

namespace Library.Middlewares
{
    public class RequestConsoleLogMiddleware
    {
		private readonly RequestDelegate _next;

		public RequestConsoleLogMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext)
        {
			try
			{
				await _next(httpContext);
			}
            finally
            {
				ConsoleLog(httpContext.Request.Method + " " + httpContext.Request.GetDisplayUrl());
				ConsoleLog("Headers: " + string.Join("| ", httpContext.Request.Headers));
				ConsoleLog("Query: " + string.Join("| ", httpContext.Request.Query));
				ConsoleLog("Body: " + httpContext.Request.Body);
			}
		}

		private void ConsoleLog(string message)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"{message}");
			Console.ResetColor();
		}
	}
}
