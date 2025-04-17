using Microsoft.AspNetCore.Mvc;
using Models.JunkItem;
using MongoDB.Driver;

namespace JunkiappBackend.Controllers
{
    [ApiController]
    [Route("api/junkitem")]
    public class JunkItemController : ControllerBase
    {

        private readonly ILogger<JunkItemController> _logger;

        public JunkItemController(ILogger<JunkItemController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult UploadJunkItem(IJunkItem junkItem)
        {
            return Ok(junkItem);
        }
    }
}
