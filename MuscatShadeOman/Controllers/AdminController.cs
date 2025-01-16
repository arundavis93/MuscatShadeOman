using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MuscatShadeOman.Models.DbModel;
using System.IO;
using MuscatShadeOman.Models.ViewModels;

namespace MuscatShadeOman.Controllers
{
    public class AdminController : Controller
    {
        MuscatShadeEntitiesNew db = new MuscatShadeEntitiesNew();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var userName = collection["txtuser"];
            var password = collection["txtpass"];
            if (userName == "muscatshadeadmin"&&password=="!muscatshadepass")
            {
                Session["loginstatus"] = "verified";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        
        public ActionResult Logout()
        {
            Session.Remove("loginstatus");
            return RedirectToAction("Login");
        }
        public ActionResult Index()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult ChangeServicesContent()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public ActionResult ChangeServicesContent(FormCollection collection)
        {
            var galleryImageDetail = new GalleryImageDetail();
            galleryImageDetail.Type = collection["hidType"];
            galleryImageDetail.Title = collection["Title"];
            galleryImageDetail.ParagraphContent = collection["ParagraphContent"];
            db.GalleryImageDetails.Add(galleryImageDetail);
            db.SaveChanges();
            return View();
        }
        public ActionResult AddServicesImage()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public ActionResult AddServicesImage(FormCollection collection, HttpPostedFileBase[] ImagePath)
        {
            
            var ServerSavePath = string.Empty;
            var imagePath = string.Empty;
            foreach (HttpPostedFileBase file in ImagePath)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    Random rnd = new Random();
                    var randomNumber = rnd.Next(100);
                    var InputFileName = Path.GetFileName(file.FileName);
                    InputFileName = randomNumber.ToString()+InputFileName;
                    if (collection["hidType"] == "steel")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/SteelStrucutres/") + InputFileName);
                        imagePath = "/images/SteelStrucutres/" + InputFileName;
                    }
                    else if (collection["hidType"] == "fabric")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/FabricArchitectures/") + InputFileName);
                        imagePath = "/images/FabricArchitectures/" + InputFileName;
                    }
                    else if (collection["hidType"] == "glazing")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/StructuralGlazing/") + InputFileName);
                        imagePath = "/images/StructuralGlazing/" + InputFileName;
                    }
                    else if (collection["hidType"] == "crafting")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/ArchitecturalMetalCrafting/") + InputFileName);
                        imagePath = "/images/ArchitecturalMetalCrafting/" + InputFileName;
                    }
                    else if (collection["hidType"] == "pergolas")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/ArchitecturalPergolas/") + InputFileName);
                        imagePath = "/images/ArchitecturalPergolas/" + InputFileName;
                    }
                    
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);

                    var galleryImage = new GalleryImage();
                    galleryImage.Type = collection["hidType"];
                    galleryImage.ImageName = InputFileName;
                    galleryImage.ImagePath = imagePath;
                    db.GalleryImages.Add(galleryImage);
                    db.SaveChanges();

                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = ImagePath.Count().ToString() + " files uploaded successfully.";
                }

            }
            return View();
        }
        public ActionResult ChangeProjectsContent()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public ActionResult ChangeProjectsContent(FormCollection collection)
        {
            var projectsImageDetail = new ProjectImageDetail();
            projectsImageDetail.Type = collection["hidType"];
            projectsImageDetail.Title = collection["Title"];
            projectsImageDetail.ParagraphContent = collection["ParagraphContent"];
            db.ProjectImageDetails.Add(projectsImageDetail);
            db.SaveChanges();
            return View();
        }
        public ActionResult AddProjectsImage()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public ActionResult AddProjectsImage(FormCollection collection, HttpPostedFileBase[] ImagePath)
        {

            var ServerSavePath = string.Empty;
            var imagePath = string.Empty;
            foreach (HttpPostedFileBase file in ImagePath)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    Random rnd = new Random();
                    var randomNumber = rnd.Next(100);
                    var InputFileName = Path.GetFileName(file.FileName);
                    InputFileName = randomNumber.ToString()+InputFileName;
                    if (collection["hidType"] == "steel")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/SteelStrucutres/") + InputFileName);
                        imagePath = "/images/SteelStrucutres/" + InputFileName;
                    }
                    else if (collection["hidType"] == "fabric")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/FabricArchitectures/") + InputFileName);
                        imagePath = "/images/FabricArchitectures/" + InputFileName;
                    }
                    else if (collection["hidType"] == "glazing")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/StructuralGlazing/") + InputFileName);
                        imagePath = "/images/StructuralGlazing/" + InputFileName;
                    }
                    else if (collection["hidType"] == "crafting")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/ArchitecturalMetalCrafting/") + InputFileName);
                        imagePath = "/images/ArchitecturalMetalCrafting/" + InputFileName;
                    }
                    else if (collection["hidType"] == "pergolas")
                    {
                        ServerSavePath = Path.Combine(Server.MapPath("~/images/ArchitecturalPergolas/") + InputFileName);
                        imagePath = "/images/ArchitecturalPergolas/" + InputFileName;
                    }

                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);

                    var projectImage = new ProjectImage();
                    projectImage.Type = collection["hidType"];
                    projectImage.ImageName = InputFileName;
                    projectImage.ImagePath = imagePath;
                    db.ProjectImages.Add(projectImage);
                    db.SaveChanges();

                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = ImagePath.Count().ToString() + " files uploaded successfully.";
                }

            }
            return View();
        }
        public ActionResult RemoveServicesImage()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    var galleryImage = db.GalleryImages.ToList();
                    var imageDetails = new ImageDetails(galleryImage);
                    return View(imageDetails);
                    
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult RemoveProjectsImage()
        {
            if (Session["loginstatus"] != null)
            {
                if (Session["loginstatus"].ToString() == "verified")
                {
                    var projectImage = db.ProjectImages.ToList();
                    var imageDetails = new ImageDetails(projectImage);
                    return View(imageDetails);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult deleteImageFromGallery(int id)
        {
            var galleryImage = db.GalleryImages.Where(i => i.ID == id).FirstOrDefault();
            db.GalleryImages.Remove(galleryImage);
            int response = db.SaveChanges();
            ViewBag.deleteSuccess = true;
            return RedirectToAction("RemoveServicesImage","Admin");
            //return response;
        }

        public ActionResult deleteImageFromProject(int id)
        {
            var projectImage = db.ProjectImages.Where(i => i.ID == id).FirstOrDefault();
            db.ProjectImages.Remove(projectImage);
            int response = db.SaveChanges();
            ViewBag.deleteSuccess = true;
            return RedirectToAction("RemoveProjectsImage", "Admin");
            //return response;
        }
        //public ActionResult ChangeAboutusContent()
        //{
        //    if (Session["loginstatus"] != null)
        //    {
        //        if (Session["loginstatus"].ToString() == "verified")
        //        {
        //            return View();
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }

        //}
    }
}