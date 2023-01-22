using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HashesController : BaseApiController
    {
      private const UInt32 kTableSize = 100;
        public HashesController()
        {}

        /// <summary>
        /// An endpoint that will add a data string to a table and returns it's hash.
        /// </summary>
        /// <param name="data">The data string to add to the table</param>
        /// <returns>Hash</returns>
        [HttpPost]
        public ActionResult<UInt64> AddToTable(string data) {
            var hash = calculateHash(data);

            return hash;
        }

        /// <summary>
        /// Method to calculate hash from string. The algorithm is folding algorithm where the string is divided into sections of 4 bytes.
        /// Each section of 4 bytes is added together. In the end the modulus function will map it to the range of values of the hash table.
        /// </summary>
        /// <param name="data">The string to hash</param>
        /// <param name="tableSize">The table size that the hash needs to mapped to</param>
        /// <returns>A hash that is mapped to the table size</returns>
        private UInt64 calculateHash(string data, UInt32 tableSize) {
          UInt64 sum = 0;
            UInt64 mul = 1;

            for (int i = 0; i < data.Length; i++) {
              mul = (i % 4 == 0) ? 1 : mul * 256;
              sum += data.ElementAt<char>(i) * mul;
            }

            return sum % tableSize;
        }
    }
}