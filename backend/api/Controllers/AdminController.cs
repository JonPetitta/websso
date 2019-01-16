using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    [Route("api/admin")]
    public class AdminController : ApiController
    {
        // GET: api/Admin
        public IEnumerable<string> Get()
        {
            return new string[] { "admin value1", "admin value2" };
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "admin value";
        }

        // POST: api/Admin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
