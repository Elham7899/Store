using Store.Utilities;

namespace Store.Infrastructure
{
	public class ExceptionMiddleware
	{
		public static async Task Handel(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				var message = MyUtilities.AppendLogs(ex.Message);

				context.Response.StatusCode = StatusCodes.Status400BadRequest;

				await context.Response.WriteAsync(message);
			}
		}
	}
}
