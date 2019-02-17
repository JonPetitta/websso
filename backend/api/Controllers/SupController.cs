using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    [Route("api/sup")]
    [ApiAuth(Role = "supervisor")]
    public class SupController : ApiController
    {
        // GET: api/Sup
        public IEnumerable<string> Get()
        {
            return new string[] { "sup value1", "sup value2" };
        }

        // GET: api/Sup/5
        public string Get(int id)
        {
            return "sup value";
        }

        // POST: api/Sup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sup/5
        public void Delete(int id)
        {
        }
    }
}
