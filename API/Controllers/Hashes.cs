using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HashesController : BaseApiController
    {
        public HashesController()
        {}

        [HttpPost]
        public ActionResult<UInt64> GetHash(string data) {
            UInt64 hash = 3461;
            foreach (char c in data) {
                hash = (c + hash) * c;
            }
            return hash;
        }
    }
}