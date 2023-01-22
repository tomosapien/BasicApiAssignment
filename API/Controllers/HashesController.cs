using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HashesController : BaseApiController
    {
        public HashesController() {}
        

        /// <summary>
        /// An endpoint that will retrieve data by using it's key
        /// </summary>
        /// <param name="key">The key of the requested data</param>
        /// <returns>A data string or null if it does not exist</returns>
        [HttpGet]
        public ActionResult<string?> GetData(ulong key) {
          return TableManager.Get(key);
        }

        /// <summary>
        /// An endpoint that will add a data string to a table and returns it's hash.
        /// </summary>
        /// <param name="data">The data string to add to the table</param>
        /// <returns>Hash if element is new or null if it already exists</returns>
        [HttpPost]
        public ActionResult<ulong?> AddToTable(string data) {
            var hash = TableManager.Add(data);
            return hash;
        }
    }
}