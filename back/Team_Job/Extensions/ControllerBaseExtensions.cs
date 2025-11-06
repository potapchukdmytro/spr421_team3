using Microsoft.AspNetCore.Mvc;
using Team_Job.BLL.Services;

namespace Team_Job.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult ToActionResult(this ControllerBase controller, ServiceResponse response)
        {
            return controller.StatusCode((int)response.StatusCode, response);
        }
    }
}
