using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGAWebApplication.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SGAWebApplication.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MasterController : Controller
    {
        // GET: AboutUsController
        private readonly ILogger<MasterController> _logger;
        private DataContext db = new DataContext();
       
        public MasterController(ILogger<MasterController> logger)
        {
            _logger = logger;
        }
        //public IActionResult AddAboutUs()
        //{
        //    AboutUs md = new AboutUs();
        //    return View("AboutUsMstr", md);
        //}       
        // GET: AboutUsController/Edit/5

        public IActionResult AboutUsEdit()
        {
            if (checklogin() == true)
            {
                var _id = db.aboutus.ToList().FirstOrDefault();
                return View("updateAboutUs", _id);
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AboutUsEdit(AboutUs mdl)
        {
            if (checklogin() == true)
            {
                db.Entry(mdl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AboutUsEdit");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }          

        }
        public IActionResult UploadSliderImages()
        {
            if (checklogin() == true)
            {
                ModelImgClass mdl = new ModelImgClass();
                mdl.simgList = db.sliderimages.ToList();
                return View(mdl);
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadSliderImages(List<IFormFile> Files, ModelImgClass model)
        {
            if (checklogin() == true)
            {
                ModelImgClass mdl = new ModelImgClass();
                mdl.simgList = db.sliderimages.ToList();
                return View(mdl);
                if (ModelState.IsValid)
                {
                    if (Files.Count > 0)
                    {
                        foreach (var fileobj in Files)
                        {
                            if (fileobj != null)
                            {
                                if (fileobj.Length > 0)
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(fileobj.FileName);
                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);
                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                                    var objfiles = new SliderImages()
                                    {
                                        ImgName = newFileName,
                                        Extension = fileExtension,
                                        ImgContent = model.simg.ImgContent,
                                        ImgTitle = model.simg.ImgTitle
                                    };

                                    using (var target = new MemoryStream())
                                    {
                                        fileobj.CopyTo(target);
                                        objfiles.Data = target.ToArray();
                                    }
                                    db.sliderimages.Add(objfiles);
                                    db.SaveChanges();

                                }
                            }
                        }
                        ViewBag.Message = "Files upload successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Please select files";
                    }
                }
                return RedirectToAction("UploadSliderImages");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }
        }
        [HttpPost]
        public IActionResult DeleteSliderImage(int id)
        {
            if (checklogin() == true)
            {
                SliderImages img = db.sliderimages.Where(e => e.Id == id).FirstOrDefault();
                db.Remove(img);
                db.SaveChanges();
                return RedirectToAction("UploadSliderImages");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }
        }
        [HttpGet]
        public IActionResult ServiceMaster()
        {
            if (checklogin() == true)
            {
                ModelImgClass mdl = new ModelImgClass();
                mdl.srvobjlist = db.servicesmstr.ToList();
                mdl.srvhdrcontent = db.servicesheadercontent.ToList().FirstOrDefault();
                return View(mdl);
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ServiceMaster(List<IFormFile> Files, ModelImgClass model)
        {
            if (checklogin() == true)
            {
                if (ModelState.IsValid)
                {
                    if (Files.Count > 0)
                    {
                        foreach (var fileobj in Files)
                        {
                            if (fileobj != null)
                            {
                                if (fileobj.Length > 0)
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(fileobj.FileName);
                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);
                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                                    var objfiles = new ServicesMstr()
                                    {
                                        ImgName = newFileName,
                                        Extension = fileExtension,
                                        SrvTitle = model.srvobj.SrvTitle
                                    };

                                    using (var target = new MemoryStream())
                                    {
                                        fileobj.CopyTo(target);
                                        objfiles.Data = target.ToArray();
                                    }
                                    db.servicesmstr.Add(objfiles);
                                    db.SaveChanges();

                                }
                            }
                        }
                        ViewBag.Message = "Files upload successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Please select files";
                    }
                }
                return RedirectToAction("ServiceMaster");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }
        }
        [HttpPost]
        public IActionResult DeleteServiceMaster(int id)
        {
            if (checklogin() == true)
            {
                ServicesMstr img = db.servicesmstr.Where(e => e.Id == id).FirstOrDefault();
                db.Remove(img);
                db.SaveChanges();
                return RedirectToAction("ServiceMaster");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SrvHeaderContent(ModelImgClass mdl)
        {
            if (checklogin() == true)
            {
                db.Entry(mdl.srvhdrcontent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ServiceMaster");
            }
            else
            {
                return RedirectToAction("Login", "Manage");
            }        
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
    }
}
