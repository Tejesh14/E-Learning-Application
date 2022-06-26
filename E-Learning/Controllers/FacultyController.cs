using E_Learning.BLL.Interface;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly ILearnService<Faculty> _facultyService;
        private readonly IProjectService _projectService;
        private readonly IChatService _chatService;

        public FacultyController(ILearnService<Faculty> facultyService, IChatService chatService, IProjectService projectService)
        {
            _facultyService = facultyService;
            _chatService = chatService;
            _projectService = projectService;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Student)]
        public async Task<ActionResult<List<Faculty>>> Get()
        {
            try
            {
                return Ok(await _facultyService.Get());
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [Route("{id}")]
        public async Task<ActionResult<Faculty>> Detail(string id)
        {
            try
            {
                return Ok(await _facultyService.Search(id));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [Route("{id}")]
        public async Task<ActionResult<Faculty>> Edit([FromRoute] string id, [FromBody] Faculty faculty)
        {
            try
            {
                return Ok(await _facultyService.Edit(id, faculty));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<List<Faculty>>> AddFaculty(Faculty faculty)
        {
            try
            {
                return Ok(await _facultyService.Add(faculty));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("{id}")]
        public async Task<ActionResult<List<Faculty>>> Delete([FromRoute] string id)
        {
            try
            {
                return Ok(await _facultyService.Delete(id));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Faculty + "," + UserRoles.Student)]
        public async Task<ActionResult<Chat>> GetMessage(string reciever)
        {
            var user = User.Identity.Name;
            return Ok(await _chatService.GetMessages(user, reciever));
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Faculty)]
        [Route("")]
        public async Task<ActionResult<Chat>> SendMessage([FromBody] Chat chat)
        {
            chat.SendFrom = User.Identity.Name;
            return Ok(await _chatService.SendMessage(chat));
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Faculty)]
        [Route("{id}")]
        public async Task<ActionResult<Chat>> DeleteMessage(string id)
        {
            var result = await _chatService.DeleteMessage(id, User.Identity.Name);
            if (result == null)
                return BadRequest("You cannot delete other's message");
            return Ok(result);
        }
    }
}
