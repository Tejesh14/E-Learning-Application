using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningMVC.Controllers
{
    public class FacultyController : Controller
    {
        BaseClass _api = new BaseClass();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Role = HomeController.role;
            return View();
        }

        [HttpGet]
        public IActionResult Projects()
        {
            using (var client = _api.Initial())
            {
                List<Project> projects = new List<Project>();
                var res = client.GetAsync("Faculty/GetProjects");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getStudents = result.Content.ReadAsStringAsync().Result;
                    projects = JsonConvert.DeserializeObject<List<Project>>(getStudents);
                }
                return View(projects);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (var client = _api.Initial())
            {
                List<Student> students = new List<Student>();
                var res = client.GetAsync("student/get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getStudents = result.Content.ReadAsStringAsync().Result;
                    students = JsonConvert.DeserializeObject<List<Student>>(getStudents);
                }

                return View(students);
            }
        }
    }
}
