using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
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
    public class AdminController : Controller
    {
        BaseClass _api = new BaseClass();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Role = HomeController.role;
            return View();
        }

        [HttpGet]
        public ActionResult Students()
        {
            using (var client = _api.Initial())
            {
                List<Student> students = new List<Student>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
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

        [HttpGet]
        public ActionResult StudentDetails([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Student student = new Student();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"student/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getStudent = result.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<Student>(getStudent);
                }
                return View(student);
            }
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent([FromForm] Student student)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newStudent = JsonConvert.SerializeObject(student);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("student/addstudent", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Students");
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
        public ActionResult EditStudent([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Student student = new Student();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"student/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getStudent = result.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<Student>(getStudent);
                }
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent([FromRoute] string id, Student student)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newStudent = JsonConvert.SerializeObject(student);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
                    var result = client.PatchAsync($"student/edit/{id}", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Students");
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
        public ActionResult DeleteStudent(string id)
        {
            using (var client = _api.Initial())
            {
                Student student = new Student();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"student/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getStudent = result.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<Student>(getStudent);
                }
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(string id, Student student)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var result = client.DeleteAsync($"student/delete/{id}");
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Students");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //=====================Faculty==========================

        [HttpGet]
        public ActionResult Faculties()
        {
            using (var client = _api.Initial())
            {
                List<Faculty> faculties = new List<Faculty>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync("Faculty/get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getFaculties = result.Content.ReadAsStringAsync().Result;
                    faculties = JsonConvert.DeserializeObject<List<Faculty>>(getFaculties);
                }
                return View(faculties);
            }
        }

        [HttpGet]
        public ActionResult FacultyDetails([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Faculty faculty = new Faculty();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"Faculty/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getFaculty = result.Content.ReadAsStringAsync().Result;
                    faculty = JsonConvert.DeserializeObject<Faculty>(getFaculty);
                }
                return View(faculty);
            }
        }

        [HttpGet]
        public ActionResult CreateFaculty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFaculty([FromForm] Faculty faculty)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newFaculty = JsonConvert.SerializeObject(faculty);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newFaculty, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("Faculty/AddFaculty", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Faculties");
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
        public ActionResult EditFaculty([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Faculty faculty = new Faculty();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"Faculty/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getFaculty = result.Content.ReadAsStringAsync().Result;
                    faculty = JsonConvert.DeserializeObject<Faculty>(getFaculty);
                }
                return View(faculty);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFaculty([FromRoute] string id, Faculty faculty)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newFaculty = JsonConvert.SerializeObject(faculty);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newFaculty, Encoding.UTF8, "application/json");
                    var result = client.PatchAsync($"Faculty/edit/{id}", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Faculties");
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteFaculty(string id)
        {
            using (var client = _api.Initial())
            {
                Faculty faculty = new Faculty();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"Faculty/detail/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getFaculty = result.Content.ReadAsStringAsync().Result;
                    faculty = JsonConvert.DeserializeObject<Faculty>(getFaculty);
                }
                return View(faculty);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFaculty(string id, Faculty faculty)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var result = client.DeleteAsync($"Faculty/delete/{id}");
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Faculties");
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
