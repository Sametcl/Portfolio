using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        StellerDBEntities db = new StellerDBEntities();
        public ActionResult Index()
        {
            var values = db.TblMessage.Where(x => x.IsRead == null).ToList();
            return View(values);
        }

        public ActionResult MessageDetails(int id)
        {
            var message = db.TblMessage.Find(id);
            message.IsRead = true;
            db.SaveChanges();
            return View(message);

        }

        public ActionResult ReadMessages()
        {
            var values = db.TblMessage.Where(x => x.IsRead == true).ToList();
            return View(values);

        }
    }
}