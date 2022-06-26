using E_Learning.BLL.Interface;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IReService<Resources> _reService;
        public ResourceController(IReService<Resources> reService)
        {
            _reService = reService;
        }

        [Authorize(Roles = UserRoles.Faculty)]
        [HttpPost]
        public async Task<ActionResult<Resources>> Add(Resources resources)
        {
            try
            {
                return Ok(await _reService.Add(resources));
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Faculty + "," + UserRoles.Student)]
        public async Task<ActionResult<List<Resources>>> Get()
        {
            try
            {
                return Ok(await _reService.Get());
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<ActionResult<Resources>> Get(string id)
        {
            try
            {
                return Ok(await _reService.Get(id));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<ActionResult<Resources>> Edit([FromRoute] string id, Resources resources)
        {
            try
            {
                return Ok(await _reService.Edit(id, resources));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<ActionResult<Resources>> Delete([FromRoute] string id)
        {
            try
            {
                return Ok(await _reService.Delete(id));
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
