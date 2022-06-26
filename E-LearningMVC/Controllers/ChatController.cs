using E_Learning.DAL.Models;
using E_LearningMVC.Helper;
using E_LearningMVC.Models;
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
    public class ChatController : Controller
    {
        BaseClass _api = new BaseClass();
        public static string reciever = "";
        public IActionResult Index()
        {
            using (var client = _api.Initial())
            {
                List<Faculty> allFaculties = new List<Faculty>();
                List<string> faculties = new List<string>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync("Faculty/Get");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getResources = result.Content.ReadAsStringAsync().Result;
                    allFaculties = JsonConvert.DeserializeObject<List<Faculty>>(getResources);
                }
                ViewBag.Role = HomeController.role;
                faculties = allFaculties.Select(x => x.Username).ToList();
                ViewBag.Faculties = faculties;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Index(string faculty)
        {
            reciever = faculty;
            return RedirectToAction("GetChat");
        }

        [HttpGet]
        public IActionResult GetChat()
        {
            string reciverName = reciever;

            using (var client = _api.Initial())
            {
                List<Chat> chats = new List<Chat>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var res = client.GetAsync($"student/getmessage?reciever={reciverName}");
                res.Wait();
                var result = res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var getChats = result.Content.ReadAsStringAsync().Result;
                    chats = JsonConvert.DeserializeObject<List<Chat>>(getChats);
                }
                ViewBag.Role = HomeController.role;
                ViewBag.Reciever = reciever;
                return View(chats);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Reciever = reciever;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Chat chat)
        {
            try
            {
                chat.SendTo = reciever;
                using (var client = _api.Initial())
                {
                    var newStudent = JsonConvert.SerializeObject(chat);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var content = new StringContent(newStudent, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"student/SendMessage", content);
                    result.Wait();
                    var res = result.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetChat");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            using (var client = _api.Initial())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                var result = client.DeleteAsync($"student/DeleteMessage/{id}");
                result.Wait();
                var res = result.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetChat");
                }
            }
            return View();
        }
    }
}
