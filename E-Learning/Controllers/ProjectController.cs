using E_Learning.BLL.Interface;
using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectController(IProjectService projectService, IWebHostEnvironment webHostEnvironment)
        {
            _projectService = projectService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<ActionResult<Project>> AssignProject(IFormFile file,[FromForm] string project, [FromForm] string assignTo)
        {
            var result = await _projectService.AssignProject(file, User.Identity.Name, project, assignTo);
            if (result == null)
                return BadRequest("File not saved");
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Project>> GetAllProjects()
        {
            var result = await _projectService.Get();
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Faculty + "," + UserRoles.Student)]
        public async Task<ActionResult<Project>> GetProjects()
        {
            string userName = User.Identity.Name;
            var result = await _projectService.Get(userName);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Student)]
        public async Task<ActionResult<List<Project>>> GetUnSubmitted()
        {
            string userName = User.Identity.Name;
            var result = await _projectService.GetUnSubmitted(userName);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Faculty)]
        public async Task<ActionResult<Project>> DeleteProject(string id)
        {
            var result = await _projectService.Delete(id);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Faculty)]
        [Route("{id}")]
        public async Task<ActionResult<Project>> EditProject(string id, IFormFile file, [FromForm] string project)
        {
            var result = await _projectService.Edit(id, file, project);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Student)]
        [Route("{id}")]
        public async Task<ActionResult<Project>> SubmitProject(string id, IFormFile file)
        {
            var result = await _projectService.SubmitProject(id, file, User.Identity.Name);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpGet]
        //[Authorize(Roles = UserRoles.Faculty + "," + UserRoles.Admin + "," + UserRoles.Student)]
        public async Task<IActionResult> DownloadAssignment(string id)
        {
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            var file = await _projectService.GetProject(id);
            var filePath = path + id ;
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, file.FileTypeAssigned);
            }
            return null;
        }

        [HttpGet]
        //[Authorize(Roles = UserRoles.Faculty + "," + UserRoles.Admin + "," + UserRoles.Student)]
        public async Task<IActionResult> DownloadSubmition(string id)
        {
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            var file = await _projectService.GetProject(id);
            var filePath = path + file.FileNameSubmitted;
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, file.FileTypeSubmitted);
            }
            return null;
        }
    }
}
