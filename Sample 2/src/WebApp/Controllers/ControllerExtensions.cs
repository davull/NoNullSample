using Microsoft.AspNetCore.Mvc;
using SharedKernel.Functional;

namespace WebApp.Controllers;

internal static class ControllerExtensions
{
    public static IActionResult ToResult<T>(this Option<T> option) =>
        option.Match<IActionResult>(
                () => new NotFoundResult(),
                value => new OkObjectResult(value));
}