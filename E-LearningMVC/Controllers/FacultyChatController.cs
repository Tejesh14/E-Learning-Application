using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_LearningMVC.Controllers
{
    public class FacultyChatController : Controller
    {
        //public IActionResult Index()
        //{
        //    using (var client = _api.Initial())
        //    {
        //        List<Student> allStudents = new List<Student>();
        //        List<string> students = new List<string>();
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
        //        var res = client.GetAsync("Student/Get");
        //        res.Wait();
        //        var result = res.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var getResources = result.Content.ReadAsStringAsync().Result;
        //            allStudents = JsonConvert.DeserializeObject<List<Student>>(getResources);
        //        }
        //        ViewBag.Role = HomeController.role;
        //        students = allStudents.Select(x => x.Username).ToList();
        //        ViewBag.Faculties = faculties;
        //        return View();
        //    }
        //}
    }
}
