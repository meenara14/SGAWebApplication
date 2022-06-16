using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace SGAWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private DataContext db = new DataContext();
        private readonly DataContext db;

        
        public HomeController(ILogger<HomeController> logger,DataContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            ModelImgClass mdl = new ModelImgClass();
            mdl.simgList = db.sliderimages.ToList();
            return View(mdl);
        }        
        public IActionResult AboutUs()
        {
            ViewBag.aboutus= db.aboutus.ToList().FirstOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }            
        [HttpPost]
        public IActionResult Contact(EmailService.EmailConfiguration vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("meena.rani@sgatechsolutions.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.office365.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("meena.rani@sgatechsolutions.com", "Me2022Ra!@");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
       
        public IActionResult Service()
        {
            ModelImgClass mdl = new ModelImgClass();
            mdl.srvobjlist = db.servicesmstr.ToList();
            mdl.srvhdrcontent = db.servicesheadercontent.ToList().FirstOrDefault();
            return View(mdl);
        }
        public IActionResult Project()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
