using E_Learning.BLL.Interface;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Learning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IReService<Calendar> _calendarService;

        public CalendarController(IReService<Calendar> calendarService)
        {
            _calendarService = calendarService;
        }

        // GET: api/<CalendarController>
        [Authorize(Roles = UserRoles.Student)]
        [HttpGet]
        public async Task<ActionResult<List<Calendar>>> Get()
        {
            try
            {
                return Ok(await _calendarService.Get());
            }
            catch
            {
                return NoContent();
            }
        }

        // GET api/<CalendarController>/5
        [Authorize(Roles = UserRoles.Student)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendar>> Get(string id)
        {
            try
            {
                return Ok(await _calendarService.Get(id));
            }
            catch
            {
                return NoContent();
            }
        }

        // POST api/<CalendarController>
        [Authorize(Roles = UserRoles.Student)]
        [HttpPost]
        public async Task<ActionResult<Calendar>> Post([FromBody] Calendar calendar)
        {
            try
            {
                calendar.user = User.Identity.Name;
                return Ok(await _calendarService.Add(calendar));
            }
            catch
            {
                return StatusCode(409);
            }
        }

        // PUT api/<CalendarController>/5
        [Authorize(Roles = UserRoles.Student)]
        [HttpPatch("{id}")]
        public async Task<ActionResult<Calendar>> Edit(string id, [FromBody] Calendar calendar)
        {
            try
            {
                return Ok(await _calendarService.Edit(id, calendar));
            }
            catch
            {
                return NoContent();
            }
        }

        // DELETE api/<CalendarController>/5
        [Authorize(Roles = UserRoles.Student)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calendar>> Delete(string id)
        {
            try
            {
                return Ok(await _calendarService.Delete(id));
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
