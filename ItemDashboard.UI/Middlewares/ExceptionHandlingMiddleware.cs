using System.Net;

namespace ItemDashboard.UI.Middlewares;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;       // the subsequest middleware
		_logger = logger;
	}

	public async Task Invoke(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(httpContext, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
	{
		_logger.LogError(ex, "An unexpected error occurred.");

		ExceptionResponse response = ex switch
		{
			ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application Exception Occurred."),
			KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The Request Key Not Found."),
			UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
			_ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal Server Error. Please retry later."),
		};

		httpContext.Response.ContentType = "application/json";
		httpContext.Response.StatusCode = (int)response.StatusCode;
		await httpContext.Response.WriteAsJsonAsync(response);
	}
}

public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
