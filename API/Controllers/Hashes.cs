using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HashesController : BaseApiController
    {
        public HashesController()
        {}

        [HttpPost("{data}")]
        public ActionResult<UInt32> GetHash(UInt32 data) {
            return data;
        }
    }
}