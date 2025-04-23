using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("GetNotFound")]
        public ActionResult GetNotFound()
        {
            var product = _storeContext.Products.Find(1000);

            if (product == null)
            {
                return NotFound(new APIResponse(404));
            }

            return Ok();
        }

        [HttpGet("GetServerError")]
        public ActionResult GetServerError()
        {
            var product = _storeContext.Products.Find(1000);

            var serverError = product.ToString();

            return Ok();
        }

        [HttpGet("GetBadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
