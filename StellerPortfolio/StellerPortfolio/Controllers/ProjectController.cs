using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        StellerDBEntities db =new StellerDBEntities();
        public ActionResult Index()
        {
            var values=db.TblProject.ToList();
            return View(values);
        }


        public ActionResult DeleteProject(int id)
        {
            var project=db.TblProject.Find(id);
            db.TblProject.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject project)
        {
            db.TblProject.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject project)
        {
            var value = db.TblProject.Find(project.ProjectId);
            value.Description = project.Description;
            value.ImageUrl = project.ImageUrl;
            value.GithubUrl = project.GithubUrl;
            value.Title = project.Title;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}