using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Homework12.Middleware
{
    public class CheckBookingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public CheckBookingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration; // allows access to the application's configuration settings
        }
        public async Task Invoke(HttpContext context)
        {
            bool isBookingNotAllowed = _configuration.GetValue<bool>("BookingNotAllowed");
            if (isBookingNotAllowed)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden; // random status code
                await context.Response.WriteAsync("Booking is not possible.");
                return; 
            }

            await _next(context);
        }
    }
}
