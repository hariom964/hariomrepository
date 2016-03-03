using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld
{
    public class HomeController : Controller
    {
        private IMailService _mailService;

        public HomeController(IMailService service)
        {
             _mailService = service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model )
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];
                if(string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "something is wrong");
                }
                if(_mailService.SendMail(email, email, $"contact page from{model.Name}({model.Email})", model.Message))
                {
                    ModelState.Clear();
                }
                
            }
            return View();
        }

    }
}
