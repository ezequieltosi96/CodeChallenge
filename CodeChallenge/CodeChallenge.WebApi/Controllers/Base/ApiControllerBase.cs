using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.WebApi.Controllers.Base
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected virtual IActionResult OkIfNotNullNotFoundOtherwise<T>(T content)
        {
            if (content == null)
                return this.NotFound();

            return this.Ok(content);
        }
    }
}
