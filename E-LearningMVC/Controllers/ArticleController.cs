using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_LearningMVC.Controllers
{
    public class ArticleController : Controller
    {
        BaseClass _api = new BaseClass();

        [HttpGet]
        public IActionResult Index()
        {
            using (var client = _api.Initial())
            {
                List<Resources> articles = new List<Resources>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync("Resource/Get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getArticles = result.Content.ReadAsStringAsync().Result;
                    articles = JsonConvert.DeserializeObject<List<Resources>>(getArticles);
                }
                ViewBag.Roles = HomeController.role;
                return View(articles);
            }
        }
    }
}
