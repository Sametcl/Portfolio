using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ContactController : Controller
    {
        StellerDBEntities db = new StellerDBEntities();
        public ActionResult Index()
        {
            var values= db.TblContact.ToList();
            return View(values);
        }


        public ActionResult DeleteContact(int id)
        {
            var value=db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddContact() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TblContact contact)
        {
            db.TblContact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id) 
        { 
            var contact = db.TblContact.Find(id);   
            return View(contact);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact contact)
        {
            var value =db.TblContact.Find(contact.ContactId);
            value.Phone = contact.Phone;
            value.Email = contact.Email;
            value.Address = contact.Address;
            value.MapUrl = contact.MapUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}