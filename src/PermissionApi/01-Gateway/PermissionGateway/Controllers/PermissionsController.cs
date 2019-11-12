using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermissionGateway.Models;

namespace PermissionGateway.Controllers
{
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        // GET api/permissions
        [HttpGet(nameof(GetPermission))]
        public IActionResult GetPermission()
        {
            var response = new
            {
                name = nameof(GetPermission),
                href = Url.Link(nameof(GetPermission), null)
            };

            return Ok(response);
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
