using TattooApp.Models;

namespace TattooApp {
    public class TestMiddleware {
        private RequestDelegate nextDelegate;

        public TestMiddleware(RequestDelegate next) {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context,
                DataContext dataContext) {
            if (context.Request.Path == "/test") {
                await context.Response.WriteAsync($"There are "
                    + dataContext.Artists.Count() + " artists\n");
                await context.Response.WriteAsync("There are "
                    + dataContext.Appointments.Count() + " appointments\n");
                await context.Response.WriteAsync($"There are "
                    + dataContext.Specialties.Count() + " specialties\n");
            } else {
                await nextDelegate(context);
            }
        }
    }
}
