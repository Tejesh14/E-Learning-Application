using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
using E_LearningMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningMVC.Controllers
{
    public class ProjectController : Controller
    {
        BaseClass _api = new BaseClass();
        public static string reciever = "";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Projects(string projectData, string search)
        {
            using (var client = _api.Initial())
            {
                List<Project> projects = new List<Project>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                if(projectData == "All" || projectData == null)
                {
                    var res = client.GetAsync("project/getprojects");
                    res.Wait();
                    var result = res.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var getProjects = result.Content.ReadAsStringAsync().Result;
                        projects = JsonConvert.DeserializeObject<List<Project>>(getProjects);
                    }
                }else if(projectData == "Pending")
                {
                    var res = client.GetAsync("project/getunsubmitted");
                    res.Wait();
                    var result = res.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var getProjects = result.Content.ReadAsStringAsync().Result;
                        projects = JsonConvert.DeserializeObject<List<Project>>(getProjects);
                    }
                }
                ViewBag.Role = HomeController.role;
                if (search != null)
                {
                    projects = projects.Where(x => x.ProjectName.Contains(search)).ToList();
                }
                return View(projects);
            }
        }

        [HttpGet]
        public IActionResult SubmitAssignment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAssignment(string id,[FromForm] IFormFile file)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newFile = JsonConvert.SerializeObject(file);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newFile, Encoding.UTF8, "application/octet-stream");
                    var result = client.PatchAsync($"Project/SubmitProject/{id}", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("AllProject");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (var client = _api.Initial())
            {
                List<Student> allStudents = new List<Student>();
                List<string> students = new List<string>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync("Student/Get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getResources = result.Content.ReadAsStringAsync().Result;
                    allStudents = JsonConvert.DeserializeObject<List<Student>>(getResources);
                }
                ViewBag.Role = HomeController.role;
                students = allStudents.Select(x => x.Username).ToList();
                ViewBag.Students = students;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(string student)
        {
            reciever = student;
            return RedirectToAction("CreateProject");
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectModel projectModel)
        {
            try
            {
                projectModel.assignTo = reciever;
                using (var client = _api.Initial())
                {
                    var newStudent = JsonConvert.SerializeObject(projectModel);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
                    var result = client.PatchAsync($"project/AssignProject", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Projects");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
