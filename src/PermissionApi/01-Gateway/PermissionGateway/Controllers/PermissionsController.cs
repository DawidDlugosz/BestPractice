using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PermissionGateway.Controllers
{
    [Route("api/[controller]")]
    public class PermissionsController : Controller
    {
        // GET api/permissions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/permissions/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/permissions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/permissions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/permissions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
