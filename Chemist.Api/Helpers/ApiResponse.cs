using Microsoft.AspNetCore.Mvc;

namespace Chemist.Api.Helpers
{
    public static class ApiResponse
    {
        public static ActionResult Ok(object o)
        {
            return new OkObjectResult(o);
        }

        public static ActionResult BadRequest(string message)
        {
            return new BadRequestObjectResult(message);
        }
    }
}
