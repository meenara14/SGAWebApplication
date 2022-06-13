using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;
        private DataContext db = new DataContext();
        public ManageController(ILogger<ManageController> logger)
        {
            _logger = logger;
        }
        public IActionResult ManageHome()
        {
            if (checklogin() == true)
            {
                return View();
            }
            else
            {
                return View("login");
            }
        }       
        public IActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(User mdl)
        {
            var rslt = db.user.Where(x => x.username == mdl.username && x.password == mdl.password).ToList();
            var actionname = "";
            if (rslt.Count() > 0)
            {
                HttpContext.Session.SetString("login", "1");
                actionname = "ManageHome";
            }
            else
            {
                actionname = "Login";
            }
            return RedirectToAction(actionname);
        }
        private bool checklogin()
        {
            bool result = false;
            if(HttpContext.Session.GetString("login") != null)
            {
                if (HttpContext.Session.GetString("login") == "1")
                {
                    result = true;
                }
            }
            return result;
        }
      
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("login");
        }
        
    }
}
