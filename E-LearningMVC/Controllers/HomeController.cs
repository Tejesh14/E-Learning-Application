using E_Learning.DAL.Authentication;
using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
using E_LearningMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningMVC.Controllers
{
    public class HomeController : Controller
    {
        public static string token = "";
        public static string role = "";
        public static string userId = "";
        BaseClass _api = new BaseClass();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel registerModel, string Role)
        {
            using (var client = _api.Initial())
            {
                string data = JsonConvert.SerializeObject(registerModel);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> postData = null;
                if (Role == "Student")
                {
                    postData = client.PostAsync($"Authentication/register/student", content);
                    postData.Wait();
                }else if(Role == "Faculty")
                {
                    postData = client.PostAsync($"Authentication/register/faculty", content);
                    postData.Wait();
                }
                var result = postData.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                return null;
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            using(var client = _api.Initial())
            {
                string data = JsonConvert.SerializeObject(loginModel);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                var postData = client.PostAsync($"Authentication/login", content);
                postData.Wait();
                var result = postData.Result;

                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    var resultJson = JsonConvert.DeserializeObject<TokenReturn>(res);
                    role = resultJson.Role;
                    userId = resultJson.userId;
                    token = resultJson.Token;
                    if(resultJson.Role == "Student")
                    {
                        return RedirectToAction("Index", "Student");
                    }else if(resultJson.Role == "Faculty")
                    {
                        return RedirectToAction("Index", "Faculty");
                    }else if(resultJson.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                return null;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
