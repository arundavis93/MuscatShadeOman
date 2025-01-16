using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using MuscatShadeOman.Models;
using MuscatShadeOman.Models.DbModel;
using MuscatShadeOman.Models.ViewModels;

namespace MuscatShadeOman.Controllers
{
    
    public class HomeController : Controller
    {
        private MuscatShadeEntitiesNew db = new MuscatShadeEntitiesNew();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gallery(string type)
        {
            if (type != null)
            {
                var galleryImageModel = db.GalleryImages.Where(i => i.Type == type).ToList();
                var galleryDetailsModel = db.GalleryImageDetails.Where(i => i.Type == type).OrderByDescending(i=>i.ID).FirstOrDefault();
                if (galleryImageModel.Count()>0)
                {
                    var imageDetails = new ImageDetails(galleryImageModel, galleryDetailsModel);

                    //ViewBag.type = type;
                    return View(imageDetails);
                }
                return null;
            }
            else
            {
                return null;
            }
            
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult OurProjects(string type)
        {
            if (type != null)
            {
                var projectsImageModel = db.ProjectImages.Where(i => i.Type == type).ToList();
                var projectsDetailsModel = db.ProjectImageDetails.Where(i => i.Type == type).OrderByDescending(i => i.ID).FirstOrDefault();
                if (projectsImageModel.Count()>0)
                {
                    var imageDetails = new ImageDetails(projectsImageModel, projectsDetailsModel);

                    //ViewBag.type = type;
                    return View(imageDetails);
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}