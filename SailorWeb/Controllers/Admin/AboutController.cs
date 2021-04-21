using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SailorWeb.Controllers.Admin
{
    public class AboutController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: About
        public ActionResult Index()
        {
            var item = db.About_TBL.FirstOrDefault();
            return View(item);
        }
        public ActionResult Details(int? id=1)
        {
            var item = (from i in db.About_TBL where i.AboutId==id select i).FirstOrDefault();
            return View(item);
        }
        [HttpGet]
        public ActionResult Edit(int id=1)
        {
            var item = (from i in db.About_TBL where i.AboutId==id  select i).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About_TBL at)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.About_TBL where i.AboutId == at.AboutId select i).FirstOrDefault();
                item.AboutDescrition = at.AboutDescrition;
                item.AboutHeader = at.AboutHeader;
                item.AboutShHeader = at.AboutShHeader;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(at);
            }
        }
    }
}