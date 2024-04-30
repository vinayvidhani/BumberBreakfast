using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BumberBreakfast.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult EroorAai()
        {
            return Problem();
        }
    }
}
