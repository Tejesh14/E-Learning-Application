using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
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
    public class StudentController : Controller
    {
        BaseClass _api = new BaseClass();
        public IActionResult Index()
        {
            ViewBag.Role = HomeController.role;
            //ViewBag.UserID = HomeController.userId;
            return View();
        }

        //[HttpGet]
        //public IActionResult EditProfile(string userId)
        //{
        //    Student student = new Student();
        //    using (var client = _api.Initial())
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
        //        var res = client.GetAsync($"student/detail/{userId}");
        //        res.Wait();
        //        var result = res.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var getProjects = result.Content.ReadAsStringAsync().Result;
        //            student = JsonConvert.DeserializeObject<Student>(getProjects);
        //        }
        //    }
        //    return View(student);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditProfile(string userId, Student student)
        //{
        //    try
        //    {
        //        using (var client = _api.Initial())
        //        {
        //            var newStudent = JsonConvert.SerializeObject(student);
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
        //            var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
        //            var result = client.PatchAsync($"student/edit/{HomeController.userId}", content);
        //            result.Wait();
        //            var res = result.Result;
        //            if (res.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Student/Index");
        //            }
        //        }
        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
