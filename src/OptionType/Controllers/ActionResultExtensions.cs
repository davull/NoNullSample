using Microsoft.AspNetCore.Mvc;
using OptionType.Monads;

namespace OptionType.Controllers;

internal static class ActionResultExtensions
{
    public static IActionResult ToResult<T, TDto>(this Option<T> option, Func<T, TDto> f)
    {
        var result = option.Match(
            None: () => (IActionResult)new NotFoundResult(),
            Some: value => new OkObjectResult(f(value)));
        return result;
    }
}