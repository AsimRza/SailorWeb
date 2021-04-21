using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SailorWeb.Controllers.Admin
{
    public class ContactController : Controller
    {
        // GET: Contact
        SailorDbContext db = new SailorDbContext();
        public ActionResult Index()
        {
            var item = from i in db.Contact_TBL select i;
            return View(item.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int? id=1)
        {
            var item =from i in db.Contact_TBL select i; 
            if (db.Contact_TBL.Any(x=>x.ContactId==id))
            {
                 item = from i in db.Contact_TBL where i.ContactId == id select i;
            }
           
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact_TBL ct)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.Contact_TBL where i.ContactId == ct.ContactId select i).FirstOrDefault();
                item.Location = ct.Location;
                item.Number = ct.Number;
                item.Email = ct.Email;
                item.Facebook = ct.Facebook;
                item.Twitter = ct.Twitter;
                item.Skype = ct.Skype;
                item.Linkedin = ct.Linkedin;
                item.Instagram = ct.Instagram;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ct);
        }
        public ActionResult Details(int? id)
        {
            var item = db.Contact_TBL.Where(x => x.ContactId == id).FirstOrDefault();

            return View(item);
        }
    }
}