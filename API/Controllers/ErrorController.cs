using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors")]
    public class ErrorController : BaseAPIController
    {
        [HttpGet("{code}")]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}
