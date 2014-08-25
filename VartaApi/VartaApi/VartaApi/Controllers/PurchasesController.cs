using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VartaApi.Services;

namespace VartaApi.Controllers
{
    public class PurchasesController : ApiController
    {
        // GET: api/Purchases
        public IEnumerable<string> Get()
        {
            (new PurchasesService()).Get();

            return new string[] { "value1", "value2" };
        }

        // GET: api/Purchases/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Purchases
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Purchases/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Purchases/5
        public void Delete(int id)
        {
        }
    }
}
