using E_Learning.DAL.Models;
using E_Learning.BLL.Interface;
using E_Learning.BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using E_Learning.DAL.Authentication;

namespace E_LearningApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILearnService<Student> _studentService;
        private readonly IChatService _chatService;

        public StudentController(ILearnService<Student> studentService, IChatService chatService)
        {
            _studentService = studentService;
            _chatService = chatService;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        public async Task<ActionResult<List<Student>>> Get()
        {
            try
            {
                return Ok(await _studentService.Get());
            }catch
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Student)]
        public async Task<ActionResult<Student>> GetByUserName()
        {
            try
            {
                return Ok(await _studentService.GetByUserName(User.Identity.Name));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Student)]
        [Route("{id}")]
        public async Task<ActionResult<Student>> Detail(string id)
        {
            try
            {
                return Ok(await _studentService.Search(id));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Student)]
        [Route("{id}")]
        public async Task<ActionResult<Student>> Edit([FromRoute] string id, [FromBody] Student student)
        {
            try
            {
                student.Username = User.Identity.Name;
                return Ok(await _studentService.Edit(id, student));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] Student student)
        {
            try
            {
                return Ok(await _studentService.Add(student));
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("{id}")]
        public async Task<ActionResult<List<Student>>> Delete([FromRoute] string id)
        {
            try
            {
                return Ok(await _studentService.Delete(id));
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
        [Authorize(Roles = UserRoles.Student)]
        [Route("")]
        public async Task<ActionResult<Chat>> SendMessage([FromBody] Chat chat)
        {
            chat.SendFrom = User.Identity.Name;
            return Ok(await _chatService.SendMessage(chat));
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Student)]
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
