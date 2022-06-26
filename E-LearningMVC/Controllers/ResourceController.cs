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
    public class ResourceController : Controller
    {
        BaseClass _api = new BaseClass();
        public IActionResult Index()
        {
            using (var client = _api.Initial())
            {
                List<Resources> resources = new List<Resources>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync("resource/get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getResources = result.Content.ReadAsStringAsync().Result;
                    resources = JsonConvert.DeserializeObject<List<Resources>>(getResources);
                }
                ViewBag.Role = HomeController.role;
                return View(resources);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([FromForm] Resources resources)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newResource = JsonConvert.SerializeObject(resources);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newResource, Encoding.UTF8, "application/json");
                    var result = client.PostAsync("resource/add", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
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
        public ActionResult Edit([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Resources resources = new Resources();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"Resource/Get/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getFaculty = result.Content.ReadAsStringAsync().Result;
                    resources = JsonConvert.DeserializeObject<Resources>(getFaculty);
                }
                return View(resources);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute] string id, Resources resources)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    var newStudent = JsonConvert.SerializeObject(resources);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
                    var result = client.PatchAsync($"resource/edit/{id}", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
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
        public ActionResult Delete([FromRoute] string id)
        {
            using (var client = _api.Initial())
            {
                Resources student = new Resources();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"resource/get/{id}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getResourse = result.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<Resources>(getResourse);
                }
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(string id, Resources student)
        {
            try
            {
                using (var client = _api.Initial())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var result = client.DeleteAsync($"resource/delete/{id}");
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
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
